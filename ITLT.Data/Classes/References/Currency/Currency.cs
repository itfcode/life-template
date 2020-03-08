namespace ITLT.Data.Classes.References
{
    using System.Collections.Generic;

    /// <summary>
    /// RU: Валюта
    /// </summary>
    public class Currency : Reference
    {
        /// <summary>
        /// 
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<MoneyAccount> MoneyAccounts { get; set; }
    }
}
