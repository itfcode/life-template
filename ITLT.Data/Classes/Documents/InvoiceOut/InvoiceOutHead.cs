namespace ITLT.Data.Classes
{

    using System.Collections.Generic;

    public class InvoiceOutHead
    {
        public virtual ICollection<InvoiceOutTable> Rows { get; set; }
    }
}
