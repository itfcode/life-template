namespace ITLT.Data.Classes
{ 

    /// <summary>
    /// Входящий чек: Табличная часть
    /// </summary>
    public class InvoiceInRow : DocumentRow
    {

        /// <summary>
        /// EN: ; RU: Количество
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// EN: ; RU: Цена
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// EN: ; RU: Сумма по строке 
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual InvoiceInHead Head { get; set; }
    }
}
