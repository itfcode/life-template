namespace ITLT.Data.Classes.Documents.MoneyTransfer
{

    public class MoneyTransferHead
    {

        /// <summary>
        /// Outcoming Account 
        /// </summary>
        public MoneyAccount AccountOut { get; set; }

        /// <summary>
        /// Outcoming Summ 
        /// </summary>
        public decimal SummOut { get; set; }

        /// <summary>
        /// Incoming Account 
        /// </summary>
        public MoneyAccount AccountIn { get; set; }

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
