namespace ITLT.Domain.Mapping.References
{
    using ITLT.Data.Classes.References;

    public class ExpenseItemMap : ReferenceMap<ExpenseItem>
    {
        public ExpenseItemMap()
        {
            this.ToTable("ExpenseItem");
        }
    }
}
