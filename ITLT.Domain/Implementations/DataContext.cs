namespace ITLT.Domain.Implementations
{
    using ITLT.Data.Classes;
    using ITLT.Data.Interfaces;
    using ITLT.Domain.Interfaces;
    using ITLT.Domain.Mapping;
    using ITLT.Domain.Migrations;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public class DataContext : DbContext, IDataContext
    {

        #region Public Properties 

        public IDbSet<ExpenseItem> ExpenseItems { get; set; }

        public IDbSet<RevenueItem> RevenueItems { get; set; }

        public IDbSet<Good> Goods { get; set; }

        #endregion

        #region Constructors

        static DataContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, DataConfiguration>());
        }

        public DataContext() : base("DefaultConnection")
        {
            this.Goods = this.Set<Good>();
            this.ExpenseItems = this.Set<ExpenseItem>();
            this.RevenueItems = this.Set<RevenueItem>();

            //this.IncomingPayments = this.Set<IncomingPayment>();
            //this.OutgoingPayments = this.Set<OutgoingPayment>();
            //this.PurchaseInvoices = this.Set<PurchaseInvoice>();
            //this.SalesInvoices = this.Set<SalesInvoice>();
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

        public IEnumerable<T> Insert<T>(IEnumerable<T> entities) where T : class, new()
        {
            var items = this.Set<T>().AddRange(entities);
            this.Commit();

            return items;
        }

        public void Update<T>(object id, Action<T> updateStrategy) where T : class, new()
        {
            var entity = this.Get<T>(id);

            if (entity != null)
            {
                updateStrategy(entity);
                this.Commit();
            }
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

        #region MyRegion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.RegisterConfigurations(modelBuilder);
        }

        protected void RegisterConfigurations(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null) throw new ArgumentNullException("modelBuilder");

            List<Type> compatableTypes = new List<Type>()
            {
                typeof(EntityTypeConfiguration<>),
                typeof(EntityBaseMap<>),
                typeof(EntityMap<>),
                typeof(EntitySyncMap<>),
                typeof(ReferenceMap<>),
                typeof(ReferenceSyncMap<>),
                typeof(DocumentHeadMap<>),
                typeof(DocumentRowMap<>),
            };

            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type =>
                    type.BaseType != null &&
                    type.BaseType.IsGenericType &&
                    !type.IsAbstract &&
                    compatableTypes.Contains(type.BaseType.GetGenericTypeDefinition()))
                .ToList()
                .ForEach(type =>
                {
                    dynamic instance = Activator.CreateInstance(type);
                    modelBuilder.Configurations.Add(instance);
                });
        }

        #endregion

        #region Public Methods

        public override int SaveChanges()
        {
            var now = DateTime.UtcNow;
            //var trackables = this.ChangeTracker.Entries<ITrackable>();

            //if (trackables != null)
            //{

            //    foreach (var item in trackables.Where(t => t.State == EntityState.Added))
            //    {
            //        item.Entity.CreatedDateTimeUtc = now;
            //    }

            //    foreach (var item in trackables.Where(t => t.State == EntityState.Modified))
            //    {
            //        item.Entity.ModifiedDateTimeUtc = now;
            //    }
            //}

            return base.SaveChanges();
        }

        #endregion
    }
}
