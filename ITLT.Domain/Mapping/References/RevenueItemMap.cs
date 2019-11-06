namespace ITLT.Domain.Mapping.References
{

    using ITLT.Data.Classes.References;

    public class RevenueItemMap : ReferenceMap<RevenueItem>
    {

        public RevenueItemMap()
        {

            this.ToTable("RevenueItem");
        }
    }
}
