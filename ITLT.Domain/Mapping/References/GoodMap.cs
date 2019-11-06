namespace ITLT.Domain.Mapping.References
{

    using ITLT.Data.Classes.References;

    public class GoodMap : ReferenceMap<Good>
    {

        public GoodMap()
        {

            this.HasOptional(t => t.ExpenseItem)
                .WithMany(t => t.Goods)
                .HasForeignKey(t => t.ExpenseItemId)
                .WillCascadeOnDelete(false);

            this.HasOptional(t => t.RevenueItem)
                .WithMany(t => t.Goods)
                .HasForeignKey(t => t.RevenueItemId)
                .WillCascadeOnDelete(false);

            this.ToTable("Good");
        }
    }
}
