namespace ITLT.Domain.Mapping.References
{

    using ITLT.Data.Classes;

    public class MoneyAccountMap : ReferenceMap<MoneyAccount>
    {

        public MoneyAccountMap()
        {

            this.HasOptional(t => t.Currency)
                .WithMany(t => t.MoneyAccounts)
                .HasForeignKey(t => t.CurrencyId)
                .WillCascadeOnDelete(false);

            this.ToTable("MoneyAccount");
        }
    }
}
