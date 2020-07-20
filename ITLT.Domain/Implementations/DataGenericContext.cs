namespace ITLT.Domain.Implementations
{
    using ITLT.Domain.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// 
    /// </summary>
    public abstract class DataGenericContext : DbContext, IGenericRepository
    {
        #region Constructors

        public  DataGenericContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        #endregion

        #region Basic Database Options

        public T Get<T>(Func<T, bool> expr) where T : class, new()
        {
            return this.Set<T>().SingleOrDefault(expr);
        }

        public T Get<T>(object id) where T : class, new()
        {
            return this.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll<T>() where T : class, new()
        {
            return this.Set<T>();
        }

        public IQueryable<T> GetAll<T>(Expression<Func<T, bool>> expr) where T : class, new()
        {
            return this.GetAll<T>().Where(expr);
        }

        public T Insert<T>(T entity) where T : class, new()
        {
            var item = this.Set<T>().Add(entity);
            this.Commit();
            return item;
        }

        public ICollection<T> InsertBulk<T>(ICollection<T> entities) where T : class, new()
        {
            var items = this.Set<T>().AddRange(entities).ToList();
            this.Commit();
            return items;
        }

        public T Update<T>(object id, Action<T> updateStrategy) where T : class, new()
        {
            var entity = this.Get<T>(id);

            if (entity != null)
            {
                updateStrategy(entity);
                this.Commit();
            }

            return entity;
        }

        public ICollection<T> UpdateBulk<T>(ICollection<T> items, Action<T> updateStrategy) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(object id) where T : class, new()
        {
            var entity = this.Get<T>(id);
            this.Delete(entity);
        }

        public void Delete<T>(T entity) where T : class, new()
        {
            if (entity == null) return;

            if (this.Entry(entity).State == EntityState.Detached)
            {
                this.Set<T>().Attach(entity);
            }

            this.Set<T>().Remove(entity);
            this.Commit();
        }

        public void DeleteBulk<T>(IEnumerable<object> ids) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public void DeleteBulk<T>(IEnumerable<T> entities) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            var changedEntries = this.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Modified))
            {
                entry.CurrentValues.SetValues(entry.OriginalValues);
                entry.State = EntityState.Unchanged;
            }

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Added))
            {
                entry.State = EntityState.Detached;
            }

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Deleted))
            {
                entry.State = EntityState.Unchanged;
            }
        }

        #endregion

        #region Model Creating

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.RegisterConfigurations(modelBuilder);
        }

        protected abstract void RegisterConfigurations(DbModelBuilder modelBuilder);

        #endregion

        #region Public Methods

        public override int SaveChanges()
        {
            // do something 
            return base.SaveChanges();
        }

        #endregion
    }
}
