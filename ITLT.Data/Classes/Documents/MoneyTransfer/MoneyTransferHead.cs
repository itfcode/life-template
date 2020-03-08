namespace ITLT.Data.Classes
{
    using ITLT.Data.Classes.References;

    /// <summary>
    /// EN: Money Transfer; RU: Денежный перевод между своими счетами
    /// </summary>
    public class MoneyTransferHead : DocumentHead
    {
        /// <summary>
        /// Outcoming Account 
        /// </summary>
        public virtual MoneyAccount AccountOut { get; set; }

        /// <summary>
        /// Outcoming Summ 
        /// </summary>
        public decimal SummOut { get; set; }

        /// <summary>
        /// Incoming Account 
        /// </summary>
        public virtual MoneyAccount AccountIn { get; set; }

        /// <summary>
        /// Incoming Summ 
        /// </summary>
        public decimal SummIn { get; set; }

        /// <summary>
        /// Fee Transfer
        /// </summary>
        public decimal Fee { get; set; }
    }
}
