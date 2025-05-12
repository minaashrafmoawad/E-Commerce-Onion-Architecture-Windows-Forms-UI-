using Application.Contract;
using Application.Dtos;
using Applications.DTOs;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;

        public AdminService(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IOrderRepository orderRepository,
            IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        // Category Management
        public List<CategoryDTO> GetAllCategories() 
        {
            return _categoryRepository.GetAll()
                .ProjectToType<CategoryDTO>()
                .ToList();
        }

        public CategoryDTO AddCategory(CategoryDTO categoryDto) 
        {
            var existingCategory = _categoryRepository.GetByName(categoryDto.Name);
            if (existingCategory != null)
                throw new Exception("Category name already exists.");

            var category = categoryDto.Adapt<Category>();
            _categoryRepository.Create(category);
            _categoryRepository.SaveChanges();
            return category.Adapt<CategoryDTO>();
        }

        public CategoryDTO UpdateCategory(CategoryDTO categoryDto) 
        {
            var category = _categoryRepository.GetById(categoryDto.CategoryID);
            if (category == null)
                throw new Exception("Category not found.");

            var existingCategory = _categoryRepository.GetByName(categoryDto.Name);
            if (existingCategory != null && existingCategory.CategoryID != categoryDto.CategoryID)
                throw new Exception("Category name already exists.");

            category.Name = categoryDto.Name;
            category.Description = categoryDto.Description;
            _categoryRepository.Update(category);
            _categoryRepository.SaveChanges();
            return category.Adapt<CategoryDTO>();
        }

        public void DeleteCategory(int categoryId) 
        {
            var category = _categoryRepository.GetById(categoryId);
            if (category == null)
                throw new Exception("Category not found.");

            var products = _productRepository.GetByCategory(categoryId).ToList();
            if (products.Any())
                throw new Exception("Cannot delete category with associated products.");

            _categoryRepository.Delete(category);
            _categoryRepository.SaveChanges();
        }

        // Product Management
        public List<ProductDTO> GetAllProducts()
        {
            return _productRepository.GetAll()
                .Include(p => p.Category)
                .ProjectToType<ProductDTO>()
                .ToList();
        }

        public ProductDTO AddProduct(ProductDTO productDto) 
        {
            var category = _categoryRepository.GetById(productDto.CategoryID);
            if (category == null)
                throw new Exception("Category not found.");

            var product = productDto.Adapt<Product>();
            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return product.Adapt<ProductDTO>();
        }

        public ProductDTO UpdateProduct(ProductDTO productDto) 
        {
            var product = _productRepository.GetById(productDto.ProductID);
            if (product == null)
                throw new Exception("Product not found.");

            var category = _categoryRepository.GetById(productDto.CategoryID);
            if (category == null)
                throw new Exception("Category not found.");

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.UnitsInStock = productDto.UnitsInStock;
            product.ImagePath = productDto.ImagePath;
            product.CategoryID = productDto.CategoryID;

            _productRepository.Update(product);
            _productRepository.SaveChanges();
            return product.Adapt<ProductDTO>();
        }

        public void DeleteProduct(int productId) 
        {
            var product = _productRepository.GetById(productId);
            if (product == null)
                throw new Exception("Product not found.");

            _productRepository.Delete(product);
            _productRepository.SaveChanges();
        }

        // Order Management
        public List<OrderDTO> GetAllOrders(string status)
        {
            var query = _orderRepository.GetAll();

            query = query.Include(o => o.OrderDetails)
                         .ThenInclude(od => od.Product);

            if (!string.IsNullOrEmpty(status))
            {
                if (Enum.TryParse<OrderStatus>(status, true, out var orderStatus))
                {
                    query = query.Where(o => o.Status == orderStatus);
                }
                else
                {
                    return new List<OrderDTO>();
                }
            }

            return query
                .ProjectToType<OrderDTO>()
                .ToList();
        }

        public void UpdateOrderStatus(int orderId, string status) 
        {
            var order = _orderRepository.GetById(orderId);
            if (order == null)
                throw new Exception("Order not found.");

            if (!Enum.TryParse<OrderStatus>(status, true, out var orderStatus))
                throw new Exception("Invalid order status.");

            order.Status = orderStatus;
            order.DateProcessed = DateTime.UtcNow;
            _orderRepository.Update(order);
            _orderRepository.SaveChanges();
        }

      
        // User Management
        public List<UserDTO> GetAllClients() 
        {
            return _userRepository.GetByRole(UserRole.Client)
                .ProjectToType<UserDTO>()
                .ToList();
        }

        public void ActivateUser(int userId) 
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new Exception("User not found.");

            user.IsActive = true;
            _userRepository.Update(user);
            _userRepository.SaveChanges();
        }

        public void DeactivateUser(int userId) 
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new Exception("User not found.");

            user.IsActive = false;
            _userRepository.Update(user);
            _userRepository.SaveChanges();
        }

        public UserDTO CreateAdmin(UserDTO userDto) 
        {
            var user = userDto.Adapt<User>();
            var existingUser = _userRepository.GetAll()
                .FirstOrDefault(u => u.Username == user.Username || u.Email == user.Email);
            if (existingUser != null)
            {
                if (existingUser.Username == user.Username)
                    throw new Exception("Username is already taken.");
                if (existingUser.Email == user.Email)
                    throw new Exception("Email is already in use.");
            }

            user.Role = UserRole.Admin;
            user.IsActive = true;
            user.DateCreated = DateTime.UtcNow;
            user.Password = HashPassword(user.Password);
            _userRepository.Create(user);
            _userRepository.SaveChanges();
            return user.Adapt<UserDTO>();
        }

        public List<UserDTO> GetAllAdmins()
        {
            return _userRepository.GetByRole(UserRole.Admin)
                .ProjectToType<UserDTO>()
                .ToList();
        }

        public void ManageAdminUser(int userId, bool activate) 
        {
            var user = _userRepository.GetById(userId);
            if (user == null || user.Role != UserRole.Admin)
                throw new Exception("Admin user not found.");

            user.IsActive = activate;
            _userRepository.Update(user);
            _userRepository.SaveChanges();
        }

        private string HashPassword(string password)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var bytes = System.Text.Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}