using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        IQueryable<CartItem> GetByUser(int userId);
    }
}
