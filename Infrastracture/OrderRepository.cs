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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Order> GetAllOrders()
        {
            return _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product);
        }

        public IQueryable<Order> GetByUser(int userId)
        {
            return _context.Orders
                .Where(o => o.UserID == userId)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product);
        }
    }
}
