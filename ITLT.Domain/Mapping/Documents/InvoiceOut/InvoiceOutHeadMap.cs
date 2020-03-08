namespace ITLT.Domain.Mapping.References
{
    using ITLT.Data.Classes;

    public class InvoiceOutHeadMap : DocumentHeadMap<InvoiceOutHead>
    {
        public InvoiceOutHeadMap()
        {
            this.ToTable("InvoiceOutHead");
        }
    }
}
