namespace ITLT.Data.Classes
{

    using System.Collections.Generic;

    /// <summary>
    /// RU: Валюта
    /// </summary>
    public class Currency : Reference
    {

        public int Code { get; set; }

        public string ShortName { get; set; }

        public virtual ICollection<MoneyAccount> MoneyAccounts { get; set; }
    }
}
