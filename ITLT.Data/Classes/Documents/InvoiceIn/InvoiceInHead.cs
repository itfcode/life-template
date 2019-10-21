namespace ITLT.Data.Classes
{
    using System.Collections.Generic;

    public class InvoiceInHead : DocumentHead
    {
        public virtual ICollection<InvoiceInRow> Rows { get; set; }
    }
}
