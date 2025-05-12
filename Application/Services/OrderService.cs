using Application.Contract;
using Application.Dtos;
using Mapster;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, ICartItemRepository cartItemRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
        }

        public OrderDTO CreateOrder(int userId)
        {
            var cartItems = _cartItemRepository.GetByUser(userId).ToList();
            if (!cartItems.Any())
                throw new InvalidOperationException("Cart is empty.");

            var order = new Order
            {
                UserID = userId,
                OrderDate = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                TotalAmount = cartItems.Sum(ci => ci.Quantity * ci.Product.Price),
                OrderDetails = cartItems.Select(ci => new OrderDetail
                {
                    ProductID = ci.ProductID,
                    Quantity = ci.Quantity
                }).ToList()
            };

            // Update stock
            foreach (var cartItem in cartItems)
            {
                var product = _productRepository.GetById(cartItem.ProductID);
                product.UnitsInStock -= cartItem.Quantity;
                _productRepository.Update(product);
            }

            // Clear cart
            foreach (var cartItem in cartItems)
            {
                _cartItemRepository.Delete(cartItem);
            }

            _orderRepository.Create(order);
            _orderRepository.SaveChanges();

            return order.Adapt<OrderDTO>();
        }

        public List<OrderDTO> GetUserOrders(int userId)
        {
            return _orderRepository.GetByUser(userId)
                .ProjectToType<OrderDTO>()
                .ToList();
        }
    }
}
