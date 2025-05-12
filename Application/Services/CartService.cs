using Application.Contract;
using Application.Dtos;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductRepository _productRepository;

        public CartService(ICartItemRepository cartItemRepository, IProductRepository productRepository)
        {
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
        }

        //public void AddToCart(int userId, int productId, int quantity)
        //{
        //    var product = _productRepository.GetById(productId);
        //    if (product == null)
        //        throw new KeyNotFoundException("Product not found.");
        //    if (product.UnitsInStock < quantity)
        //        throw new InvalidOperationException("Insufficient stock.");

        //    var existingCartItem = _cartItemRepository.GetByUser(userId)
        //        .FirstOrDefault(ci => ci.ProductID == productId);

        //    if (existingCartItem != null)
        //    {
        //        existingCartItem.Quantity += quantity;
        //        _cartItemRepository.Update(existingCartItem);
        //    }
        //    else
        //    {
        //        var cartItem = new CartItem
        //        {
        //            UserID = userId,
        //            ProductID = productId,
        //            Quantity = quantity,

        //            DateAdded = DateTime.UtcNow

        //        };
        //        _cartItemRepository.Create(cartItem);
        //    }
        //    _cartItemRepository.SaveChanges();
        //}

        public void AddToCart(int userId, int productId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

            var product = _productRepository.GetById(productId);
            if (product == null)
                throw new KeyNotFoundException("Product not found.");
            if (product.UnitsInStock < quantity)
                throw new InvalidOperationException($"Insufficient stock. Available: {product.UnitsInStock}");

            var existingCartItem = _cartItemRepository.GetByUser(userId)
                .FirstOrDefault(ci => ci.ProductID == productId);

            if (existingCartItem != null)
            {
                // Check if combined quantity exceeds available stock
                if (product.UnitsInStock < existingCartItem.Quantity + quantity)
                    throw new InvalidOperationException(
                        $"Cannot add {quantity} more. Current in cart: {existingCartItem.Quantity}, Available: {product.UnitsInStock}");

                existingCartItem.Quantity += quantity;
                existingCartItem.DateAdded = DateTime.UtcNow; // Update timestamp
                _cartItemRepository.Update(existingCartItem);
            }
            else
            {
                var cartItem = new CartItem
                {
                    UserID = userId,
                    ProductID = productId,
                    Quantity = quantity,
                    DateAdded = DateTime.UtcNow
                };
                _cartItemRepository.Create(cartItem);
            }

            _cartItemRepository.SaveChanges();
        }

        public bool IsProductInCart(int userId, int productId)
        {
            // Check if any cart item matches the user and product
            return _cartItemRepository.GetByUser(userId)
                .Any(ci => ci.ProductID == productId);
        }

        public void DeleteProductFromCart(int userId, int productId)
        {
            // Find the cart item for this user and product
            var cartItem = _cartItemRepository.GetByUser(userId)
                .FirstOrDefault(ci => ci.ProductID == productId);

            // If not found, throw exception
            if (cartItem == null)
            {
                throw new KeyNotFoundException("Product not found in the user's cart.");
            }

            // Remove the item from cart
            _cartItemRepository.Delete(cartItem);
            _cartItemRepository.SaveChanges();
        }

        //public List<CartItemDTO> GetCartItems(int userId)
        //{
        //    return _cartItemRepository.GetByUser(userId)
        //        .ProjectToType<CartItemDTO>()
        //        .ToList();
        //}
        public List<CartItemDTO> GetCartItems(int userId)
        {
            return _cartItemRepository.GetByUser(userId)
           .Include(ci => ci.Product) // Double ensure inclusion
           .AsEnumerable() // Switch to client evaluation for debugging
          .Select(ci => new CartItemDTO
        {
            CartItemID = ci.CartItemID,
            ProductID = ci.ProductID,
            ProductName = ci.Product?.Name ?? "[Product not loaded]",
            Quantity = ci.Quantity,
            Price = ci.Product?.Price ?? -1, // Will show -1 if product not loaded
            DateAdded = ci.DateAdded
        })
        .ToList();
        }

        public void UpdateCartItem(int cartItemId, int quantity)
        {
            var cartItem = _cartItemRepository.GetById(cartItemId);
            if (cartItem == null)
                throw new KeyNotFoundException("Cart item not found.");

            var product = _productRepository.GetById(cartItem.ProductID);
            if (product.UnitsInStock < quantity)
                throw new InvalidOperationException("Insufficient stock.");

            cartItem.Quantity = quantity;
            _cartItemRepository.Update(cartItem);
            _cartItemRepository.SaveChanges();
        }

        public void RemoveCartItem(int cartItemId)
        {
            var cartItem = _cartItemRepository.GetById(cartItemId);
            if (cartItem == null)
                throw new KeyNotFoundException("Cart item not found.");

            _cartItemRepository.Delete(cartItem);
            _cartItemRepository.SaveChanges();
        }

        public decimal GetCartTotal(int userId)
        {
            return _cartItemRepository.GetByUser(userId)
                .Sum(ci => ci.Quantity * ci.Product.Price);
        }
    }
}
