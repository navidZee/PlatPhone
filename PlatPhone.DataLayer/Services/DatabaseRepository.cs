using Microsoft.EntityFrameworkCore;
using PlatPhone.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PlatPhone.DataLayer.Service
{
    public class DatabaseRepository<TEntity> where TEntity : class
    {
        private ApplicationContext entity;
        private DbSet<TEntity> _dbset;

        public DatabaseRepository(ApplicationContext context)
        {
            _dbset = context.Set<TEntity>();
            entity = context;
        }

        public virtual List<TEntity> Select(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includes = "")
        {
            IQueryable<TEntity> query = _dbset;

            if (where != null)
            {
                query = query.Where(where);
            }

            if (orderby != null)
            {
                query = orderby(query);
            }

            if (includes != "")
            {
                foreach (string include in includes.Split(','))
                {
                    query = query.Include(include);
                }
            }

            return query.ToList();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbset.AsQueryable();
        }

        public void Delete(int id)
        {
            _dbset.Remove(Read(id));
        }

        public void Create(TEntity record)
        {
            _dbset.Add(record);
        }

        public List<TEntity> Read()
        {
            return _dbset.ToList();
        }

        public TEntity Read(int id)
        {
            return _dbset.Find(id);
        }

        public List<TEntity> Read(int n, bool flag)
        {
            return _dbset.Take(n).ToList();
        }

        public void Update(TEntity record)
        {   
            _dbset.Attach(record);
            entity.Entry(record).State = EntityState.Modified;
            Save();
        }

        public bool Save()
        {
            try
            {
                var x = entity.SaveChanges();             
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
