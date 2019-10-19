namespace ITLT.Data.Classes
{

    using System.Collections.Generic;

    public class InvoiceOutHead : DocumentHead
    {
        public virtual ICollection<InvoiceOutTable> Rows { get; set; }
    }
}
