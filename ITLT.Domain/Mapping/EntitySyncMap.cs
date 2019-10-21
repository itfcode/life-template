namespace ITLT.Domain.Mapping
{

    using ITLT.Data.Classes;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class EntitySyncMap<T> : EntityBaseMap<T> where T : EntitySync
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
