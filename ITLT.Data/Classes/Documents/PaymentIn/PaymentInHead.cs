namespace ITLT.Data.Classes.Documents.PaymentIn
{

    public class PaymentInHead
    {

        /// <summary>
        /// Contragent
        /// </summary>
        public Contragent Contragent { get; set; }

        /// <summary>
        /// Contract
        /// </summary>
        public Contract Contract { get; set; }

        /// <summary>
        /// Account 
        /// </summary>
        public MoneyAccount Account { get; set; }

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
