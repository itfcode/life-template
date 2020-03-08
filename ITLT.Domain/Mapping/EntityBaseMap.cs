namespace ITLT.Domain.Mapping
{
    using System;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.ModelConfiguration.Configuration;
    using System.Data.Entity.Spatial;
    using System.Linq.Expressions;

    /// <summary>
    /// To simplify mapping of entities to sql-tables
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class EntityBaseMap<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : class
    {
        #region Private Methods 

        private void DefineBasic<TConfig>(TConfig property, string propName, bool isRequired = false) where TConfig : PrimitivePropertyConfiguration
        {
            var config = isRequired ? property.IsRequired() : property.IsOptional();
            config.HasColumnName(propName);
        }

        #endregion

        #region Protected Methods 

        protected void Define(Expression<Func<TEntity, TimeSpan>> propertyExpression, string propName, bool isRequired = false)
        {
            this.DefineBasic(this.Property(propertyExpression), propName, isRequired);
        }

        protected void Define(Expression<Func<TEntity, TimeSpan?>> propertyExpression, string propName, bool isRequired = false)
        {
            this.DefineBasic(this.Property(propertyExpression), propName, isRequired);
        }

        protected void Define(Expression<Func<TEntity, DateTimeOffset>> propertyExpression, string propName, bool isRequired = false)
        {
            this.DefineBasic(this.Property(propertyExpression), propName, isRequired);
        }

        protected void Define(Expression<Func<TEntity, DateTimeOffset?>> propertyExpression, string propName, bool isRequired = false)
        {
            this.DefineBasic(this.Property(propertyExpression), propName, isRequired);
        }

        protected void Define(Expression<Func<TEntity, decimal>> propertyExpression, string propName, bool isRequired = false)
        {
            this.DefineBasic(this.Property(propertyExpression), propName, isRequired);
        }

        protected void Define(Expression<Func<TEntity, decimal?>> propertyExpression, string propName, bool isRequired = false)
        {
            this.DefineBasic(this.Property(propertyExpression), propName, isRequired);
        }

        protected void Define(Expression<Func<TEntity, string>> propertyExpression, string propName, bool isRequired = false)
        {
            this.DefineBasic(this.Property(propertyExpression), propName, isRequired);
        }

        protected void Define(Expression<Func<TEntity, byte[]>> propertyExpression, string propName, bool isRequired = false)
        {
            this.DefineBasic(this.Property(propertyExpression), propName, isRequired);
        }

        protected void Define(Expression<Func<TEntity, DbGeography>> propertyExpression, string propName, bool isRequired = false)
        {
            this.DefineBasic(this.Property(propertyExpression), propName, isRequired);
        }

        protected void Define(Expression<Func<TEntity, DbGeometry>> propertyExpression, string propName, bool isRequired = false)
        {
            this.DefineBasic(this.Property(propertyExpression), propName, isRequired);
        }

        protected void Define<TType>(Expression<Func<TEntity, TType>> propertyExpression, string propName, bool isRequired = false) where TType : struct
        {
            this.DefineBasic(this.Property(propertyExpression), propName, isRequired);
        }

        protected void Define<TType>(Expression<Func<TEntity, TType?>> propertyExpression, string propName, bool isRequired = false) where TType : struct
        {
            this.DefineBasic(this.Property(propertyExpression), propName, isRequired);
        }

        #endregion
    }
}
