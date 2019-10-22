namespace ITLT.Domain.Mapping.References
{

    using ITLT.Data.Classes;

    public class InvoiceOutRowMap : DocumentRowMap<InvoiceOutRow> 
    {

        public InvoiceOutRowMap()
        {

            this.ToTable("InvoiceOutRow");
        }
    }
}
