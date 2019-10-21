namespace ITLT.Domain.Mapping.References
{

    using ITLT.Data.Classes;

    public class CurrencyMap : ReferenceMap<Currency>
    {

        public CurrencyMap()
        {

            this.Define(x => x.Code, "Code", true);
            this.Define(x => x.ShortName, "ShortName", true);

            this.ToTable("Currency");
        }
    }
}
