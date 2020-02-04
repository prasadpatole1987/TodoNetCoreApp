using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TodoApp.DAL.Data;

namespace TodoApp.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApiDbContext apiDbContext;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(ApiDbContext context)
        {
            this.apiDbContext = context;
            entities = context.Set<T>();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            apiDbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            apiDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            apiDbContext.SaveChanges();
        }
    }
}
