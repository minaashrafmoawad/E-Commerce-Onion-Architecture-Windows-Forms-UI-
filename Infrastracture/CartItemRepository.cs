using Application.Contract;
using Context;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        private readonly AppDbContext _context;

        public CartItemRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<CartItem> GetByUser(int userId)
        {
            return _context.CartItems.Where(ci => ci.UserID == userId).Include(ci => ci.Product);
        }
    }
}
