namespace ITLT.Data.Classes
{

    using ITLT.Data.Classes.References;

    /// <summary>
    /// EN: Table Part of Outcomming Invoice; RU: Табличная Часть Исходящего Счета(Чека, Накладной)
    /// </summary>
    public class InvoiceOutRow : DocumentRow
    {
        /// <summary>
        /// 
        /// </summary>
        public Good Good { get; set; }

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
        /// EN: ; RU: Сслыка на шапку документа
        /// </summary>
        public InvoiceOutHead Head { get; set; }
    }
}
