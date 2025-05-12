using Application.Contract;
using Context;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Product> GetByCategory(int categoryId)
        {
            return _context.Products.Where(p => p.CategoryID == categoryId);
        }
    }
}
