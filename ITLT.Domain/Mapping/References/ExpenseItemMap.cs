namespace ITLT.Domain.Mapping.References
{

    using ITLT.Data.Classes;

    public class ExpenseItemMap : ReferenceMap<ExpenseItem>
    {

        public ExpenseItemMap()
        {

            this.ToTable("ExpenseItem");
        }
    }
}
