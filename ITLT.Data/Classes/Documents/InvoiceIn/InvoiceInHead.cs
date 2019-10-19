namespace ITLT.Data.Classes
{
    using System.Collections.Generic;

    public class InvoiceInHead
    {
        public virtual ICollection<InvoiceInTable> Rows { get; set; }
    }
}
