using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposityPattern.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DesingPatternsContext _context;
        private DbSet<T> _dbSet;

        public Repository(DesingPatternsContext Context) { 
            _context = Context;
            _dbSet = Context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var data = _dbSet.Find(Id);
            if (data != null) { 
                _dbSet.Remove(data);
                _context.SaveChanges(); 
            }
        }

        public IEnumerable<T> GetAll() => _dbSet.ToList();

        public T GetById(int id) => _dbSet.Find(id);

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
