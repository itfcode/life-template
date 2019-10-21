namespace ITLT.Domain.Mapping
{

    using ITLT.Data.Classes;
    using ITLT.Data.Interfaces;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public abstract class SyncEntityMap<T> : EntityTypeConfiguration<T> where T : class, IEntitySync
    {
        public SyncEntityMap()
        {

            this.HasKey(t => t.Id);

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("Id");
        }
    }
}
