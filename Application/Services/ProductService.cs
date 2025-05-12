using Application.Contract;
using Applications.DTOs;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductDTO> GetAllProducts()
        {
            return _productRepository.GetAll()
                .Include(p => p.Category)
                .ProjectToType<ProductDTO>()
                .ToList();
        }

        public ProductDTO GetProductById(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
                throw new KeyNotFoundException("Product not found.");
            return product.Adapt<ProductDTO>();
        }

        public List<ProductDTO> GetProductsByCategory(int categoryId)
        {
            return _productRepository.GetByCategory(categoryId)
                .Include(p => p.Category)
                .ProjectToType<ProductDTO>()
                .ToList();
        }
        public List<ProductDTO> SearchProductsByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return GetAllProducts();

            return _productRepository.GetAll()
                .Include(p => p.Category)
                .Where(p => EF.Functions.Like(p.Name, $"%{name}%"))
                .ProjectToType<ProductDTO>()
                .ToList();
        }


        public ProductDTO GetProductByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be empty.");

            var product = _productRepository.GetAll()
                .Include(p => p.Category)
                .Where(p => EF.Functions.Like(p.Name, name))
                .ProjectToType<ProductDTO>()
                .FirstOrDefault();

            if (product == null)
                throw new KeyNotFoundException("Product not found.");

            return product;
        }

        public List<ProductDTO> GetProductsByCategoryName(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
                return GetAllProducts();

            return _productRepository.GetAll()
                .Include(p => p.Category)
                .Where(p => EF.Functions.Like(p.Category.Name, $"%{categoryName}%"))
                .ProjectToType<ProductDTO>()
                .ToList();
        }

        public List<ProductDTO> Search(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                return _productRepository.GetAll().ProjectToType<ProductDTO>()
                .ToList(); ;
            }

            return _productRepository.GetAll()
                .Where(p => EF.Functions.Like(p.Name, $"%{productName}%"))
                .ProjectToType<ProductDTO>() 
                .ToList();
        }

    }
}
    

 
