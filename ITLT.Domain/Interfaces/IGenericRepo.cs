namespace ITLT.Domain.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IGenericRepository
    {
        /// <summary>
        /// Get Item by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get<T>(object id) where T : class, new();

        /// <summary>
        /// Get Items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IQueryable<T> GetAll<T>() where T : class, new();

        /// <summary>
        /// Get Items by condition
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        IQueryable<T> GetAll<T>(Expression<Func<T, bool>> expr) where T : class, new();

        /// <summary>
        /// Add Item to DbSet 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Insert<T>(T entity) where T : class, new();

        /// <summary>
        /// Add Items to DbSet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        ICollection<T> InsertBulk<T>(ICollection<T> entities) where T : class, new();

        /// <summary>
        /// Update Item 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="updateStrategy"></param>
        /// <returns></returns>
        T Update<T>(object id, Action<T> updateStrategy) where T : class, new();

        /// <summary>
        /// Update Items 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="updateStrategy"></param>
        /// <returns></returns>
        ICollection<T> UpdateBulk<T>(ICollection<T> items, Action<T> updateStrategy) where T : class, new();

        /// <summary>
        /// Delete Item by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        void Delete<T>(object id) where T : class, new();

        /// <summary>
        /// Delete Items by Ids
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ids"></param>
        void DeleteBulk<T>(IEnumerable<object> ids) where T : class, new();

        /// <summary>
        /// Delete Item 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Delete<T>(T entity) where T : class, new();

        void DeleteBulk<T>(IEnumerable<T> entities) where T : class, new();

        /// <summary>
        /// Commit Changes
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollback Changes 
        /// </summary>
        void Rollback();
    }
}
