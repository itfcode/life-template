namespace ITLT.Domain.Interfaces
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IGenericRepository
    {

        T Get<T>(Func<T, bool> expr) where T : class, new();

        T Get<T>(object id) where T : class, new();

        IQueryable<T> GetAll<T>() where T : class, new();

        IQueryable<T> GetAll<T>(Expression<Func<T, bool>> expr) where T : class, new();

        T Insert<T>(T entity) where T : class, new();

        ICollection<T> Insert<T>(ICollection<T> entities) where T : class, new();

        T Update<T>(object id, Action<T> updateStrategy) where T : class, new();

        // ICollection<T> Update<T>(object id, Action<T> updateStrategy) where T : class, new();

        void Delete<T>(object id) where T : class, new();

        void Delete<T>(T entity) where T : class, new();

        void Commit();

        void Rollback();
    }
}
