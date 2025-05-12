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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Category GetByName(string name)
        {
            return _context.Categories.FirstOrDefault(c => c.Name == name);
        }
    }
}