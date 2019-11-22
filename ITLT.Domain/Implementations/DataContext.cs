﻿namespace ITLT.Domain.Implementations
{
    using ITLT.Data.Classes;
    using ITLT.Data.Classes.References;
    using ITLT.Domain.Interfaces;
    using ITLT.Domain.Mapping;
    using ITLT.Domain.Migrations;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public class DataContext : DbContext, IDataContext
    {

        #region EN: References; RU: Справочники

        public IDbSet<ExpenseItem> ExpenseItems { get; set; }

        public IDbSet<RevenueItem> RevenueItems { get; set; }

        public IDbSet<Good> Goods { get; set; }

        public IDbSet<Currency> Currencies { get; set; }

        public IDbSet<MoneyAccount> MoneyAccounts { get; set; }

        #endregion

        #region EN: Documents; RU: Документы

        public IDbSet<InvoiceInHead> InvoiceInHeads { get; set; }

        public IDbSet<InvoiceInRow> InvoiceInRows { get; set; }

        public IDbSet<InvoiceOutHead> InvoiceOutHeads { get; set; }

        public IDbSet<InvoiceOutRow> InvoiceOutRows { get; set; }

        public IDbSet<MoneyTransferHead> MoneyTransferHeads { get; set; }

        public IDbSet<PaymentInHead> PaymentInHeads { get; set; }

        public IDbSet<PaymentOutHead> PaymentOutHeads { get; set; }

        #endregion

        #region EN: Totals; RU: Итоги

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
            this.Currencies = this.Set<Currency>();
            this.MoneyAccounts = this.Set<MoneyAccount>();

            this.InvoiceInHeads = this.Set<InvoiceInHead>();
            this.InvoiceInRows = this.Set<InvoiceInRow>();
            this.InvoiceOutHeads = this.Set<InvoiceOutHead>();
            this.InvoiceOutRows = this.Set<InvoiceOutRow>();
            this.MoneyTransferHeads = this.Set<MoneyTransferHead>();
            this.InvoiceInHeads = this.Set<InvoiceInHead>();
            this.InvoiceOutHeads = this.Set<InvoiceOutHead>();
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

        public ICollection<T> Insert<T>(ICollection<T> entities) where T : class, new()
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

        public ICollection<T> Update<T>(ICollection<T> items, Action<T> updateStrategy) where T : class, new()
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
            // do something 
            return base.SaveChanges();
        }

        #endregion
    }
}
