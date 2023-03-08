using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test_Invoice_Schad.Core.Context;
using Test_Invoice_Schad.Infrastructure.Interfaces;

namespace Test_Invoice_Schad.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _entities;

        public Repository(DbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _entities.ToList();
            }
            catch (Exception _error)
            {
                throw;
            }
        }

        public TEntity GetById(int id)
        {
            try
            {
                return _entities.Find(id);
            }
            catch (Exception _error)
            {
                throw;
            }
        }

        public void Add(TEntity entity)
        {
            try
            {
                _entities.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception _error)
            {
                throw;
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception _error)
            {
                throw;
            }
        }

        public void Delete(TEntity entity)
        {
            try
            {
                _entities.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception _error)
            {
                throw;
            }
        }
    }
}
