namespace ITLT.Data.Classes
{
    using ITLT.Data.Classes.References;

    /// <summary>
    /// EN: Incoming Payment; RU: Входящий платеж
    /// </summary>
    public class PaymentInHead : DocumentHead
    {
        /// <summary>
        /// Contragent
        /// </summary>
        public virtual Contragent Contragent { get; set; }

        /// <summary>
        /// Contract
        /// </summary>
        public virtual Contract Contract { get; set; }

        /// <summary>
        /// Account 
        /// </summary>
        public virtual MoneyAccount Account { get; set; }

        /// <summary>
        /// Summ 
        /// </summary>
        public decimal Summ { get; set; }

        /// <summary>
        /// Fee Payment
        /// </summary>
        public decimal Fee { get; set; }
    }
}
