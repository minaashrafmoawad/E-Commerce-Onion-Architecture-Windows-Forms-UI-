using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ICartService
    {
        void AddToCart(int userId, int productId, int quantity);
        List<CartItemDTO> GetCartItems(int userId);
        void UpdateCartItem(int cartItemId, int quantity);
        void RemoveCartItem(int cartItemId);
        decimal GetCartTotal(int userId);
        public void DeleteProductFromCart(int userId, int productId);
        public bool IsProductInCart(int userId, int productId);
    }
}
