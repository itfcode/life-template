namespace ITLT.Data.Classes
{
    using System.Collections.Generic;

    /// <summary>
    /// Входящий чек: Шапка
    /// </summary>
    public class InvoiceInHead : DocumentHead
    {
        /// <summary>
        /// 
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<InvoiceInRow> Rows { get; set; }
    }
}
