using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract
{
    public interface IGenericRepository<T> where T : class
    {
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
        IQueryable<T> GetAll();
        T? GetById(int id);

        void SaveChanges();

    }
}
