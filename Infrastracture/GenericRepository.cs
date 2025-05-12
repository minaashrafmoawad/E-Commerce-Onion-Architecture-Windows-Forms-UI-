using Application.Contract;
using Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context) {
        
            _context = context;
           _dbSet=context.Set<T>();
        
        }
        public T Create(T entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public T Delete(T entity)
        {
           return _context.Remove(entity).Entity;
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public T Update(T entity)
        {
           return _context.Update(entity).Entity;
        }
    }
}
