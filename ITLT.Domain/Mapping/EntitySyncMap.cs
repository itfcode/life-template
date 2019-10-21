namespace ITLT.Domain.Mapping
{

    using ITLT.Data.Classes;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public abstract class EntitySyncMap<T> : EntityTypeConfiguration<T> where T : EntitySync
    {
        public EntitySyncMap()
        {

            this.HasKey(t => t.Id);

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("Id");
        }
    }
}
