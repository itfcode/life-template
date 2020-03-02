namespace ITLT.Domain.Mapping.References
{

    using ITLT.Data.Classes.References;

    public class RevenueItemMap : ReferenceMap<RevenueItem>
    {

        public RevenueItemMap()
        {


            //this.HasRequired(t => t.)
            //    .WithOptional(t => t.Kingpost)
            //    .Map(t => t.MapKey("PileId")).WillCascadeOnDelete(true);



            this.ToTable("RevenueItem");
        }
    }
}
