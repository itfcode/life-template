namespace ITLT.Domain.Mapping.References
{
    using ITLT.Data.Classes;

    /// <summary>
    /// 
    /// </summary>
    public class InvoiceInRowMap : DocumentRowMap<InvoiceInRow> 
    {
        public InvoiceInRowMap()
        {
            this.ToTable("InvoiceInRow");
        }
    }
}
