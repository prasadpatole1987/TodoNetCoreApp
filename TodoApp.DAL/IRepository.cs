using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.DAL
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
