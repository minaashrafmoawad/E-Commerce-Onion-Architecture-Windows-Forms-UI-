using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Category GetByName(string name);
    }
}
