namespace ITLT.Domain.Mapping
{
    using ITLT.Data.Classes;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class EntityMap<T> : EntityBaseMap<T> where T : Entity
    {
        public EntityMap()
        {

            this.HasKey(t => t.Id);

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("Id");
        }
    }
}
