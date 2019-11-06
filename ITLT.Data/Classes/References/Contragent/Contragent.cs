namespace ITLT.Data.Classes.References
{

    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public class Contragent : Reference
    {

        /// <summary>
        /// EN: Tax Number; RU: Налоговый номер контрагента
        /// </summary>
        public string ITIN { get; set; }

        /// <summary>
        /// EN: Contracts of Contragent; RU: Контракты контрагента
        /// </summary>
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
