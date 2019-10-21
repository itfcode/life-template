namespace ITLT.Data.Classes
{
    /// <summary>
    /// EN: Money Accounts;  RU: Денежные счета
    /// </summary>
    public class MoneyAccount : Reference
    {
        /// <summary>
        /// Id of Currency 
        /// </summary>
        public int? CurrencyId { get; set; }

        /// <summary>
        /// EN: Account Currency; RU: Валюта счета
        /// </summary>
        public virtual Currency Currency { get; set; }
    }
}
