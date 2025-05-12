using Applications.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IProductService
    {
        List<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(int id);
        List<ProductDTO> GetProductsByCategory(int categoryId);
        List<ProductDTO> SearchProductsByName(string name);
        ProductDTO GetProductByName(string name);
        List<ProductDTO> GetProductsByCategoryName(string categoryName);
        public List<ProductDTO> Search(string ProductName);
    }

}
