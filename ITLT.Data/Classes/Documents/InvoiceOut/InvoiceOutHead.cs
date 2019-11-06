namespace ITLT.Data.Classes
{
    using ITLT.Data.Classes.References;
    using System.Collections.Generic;

    /// <summary>
    /// en: Head of Outcomming Invoice; Ru: шапка исходящего счета(чека, накладной)
    /// </summary>
    public class InvoiceOutHead : DocumentHead
    {

        /// <summary>
        /// 
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Contragent Contragent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Contract Contract { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<InvoiceOutRow> Rows { get; set; }
    }
}
