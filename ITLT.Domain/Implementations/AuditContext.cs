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

    public class AuditContext : DataGenericContext, IAuditContext
    {

        #region EN: References; RU: Справочники
        #endregion

        #region EN: Documents; RU: Документы
        #endregion

        #region EN: Totals; RU: Итоги
        #endregion

        #region Constructors

        static AuditContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, DataConfiguration>());
        }

        public AuditContext() : base("AuditConnection")
        {
        }

        #endregion

        #region Basic Database Options

        #endregion

        #region Model Creating

        protected override void RegisterConfigurations(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null) throw new ArgumentNullException("modelBuilder");
        }

        #endregion

        #region Public Methods
        #endregion
    }
}
