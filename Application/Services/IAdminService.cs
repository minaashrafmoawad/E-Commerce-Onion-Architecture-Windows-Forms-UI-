using Application.Dtos;
using Applications.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IAdminService
    {
        // Category Management
        List<CategoryDTO> GetAllCategories(); 
        CategoryDTO AddCategory(CategoryDTO categoryDto); 
        CategoryDTO UpdateCategory(CategoryDTO categoryDto); 
        void DeleteCategory(int categoryId); 

        // Product Management
        List<ProductDTO> GetAllProducts(); 
        ProductDTO AddProduct(ProductDTO productDto); 
        ProductDTO UpdateProduct(ProductDTO productDto); 
        void DeleteProduct(int productId); 

        // Order Management
        List<OrderDTO> GetAllOrders(string status = null);
       
        void UpdateOrderStatus(int orderId, string status); 

        // User Management
        List<UserDTO> GetAllClients(); 
        void ActivateUser(int userId); 
        void DeactivateUser(int userId); 
        UserDTO CreateAdmin(UserDTO userDto); 
        List<UserDTO> GetAllAdmins(); 
        void ManageAdminUser(int userId, bool activate); 
    }
}
