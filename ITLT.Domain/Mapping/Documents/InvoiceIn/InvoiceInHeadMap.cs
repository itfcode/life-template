namespace ITLT.Domain.Mapping.References
{

    using ITLT.Data.Classes;

    public class InvoiceInHeadMap : DocumentHeadMap<InvoiceInHead>
    {

        public InvoiceInHeadMap()
        {

            this.ToTable("InvoiceInHead");
        }
    }
}
