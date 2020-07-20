namespace ITLT.Domain.Implementations
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

    public class DataContext : DataGenericContext, IDataContext
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

        public IDbSet<InvoiceInSrc> InvoiceInSrcs { get; set; }

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

            this.InvoiceInSrcs = this.Set<InvoiceInSrc>();
        }

        #endregion

        #region Basic Database Options

        #endregion

        #region Model Creating

        protected override void RegisterConfigurations(DbModelBuilder modelBuilder)
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
        #endregion
    }
}
