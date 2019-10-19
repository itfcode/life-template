namespace ITLT.Data.Classes
{

    using System.Collections.Generic;

    /// <summary>
    /// en: head of outcomming invoice; ru: шапка исходящего счета(чека, накладной)
    /// </summary>
    public class InvoiceOutHead : DocumentHead
    {
        public virtual Contragent Contragent { get; set; }

        public virtual Contract Contract { get; set; }

        public virtual ICollection<InvoiceOutTable> Rows { get; set; }
    }
}
