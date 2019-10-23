namespace ITLT.Data.Classes
{

    using System.Collections.Generic;

    /// <summary>
    /// EN: Revenue Item; RU: Статья Доходов 
    /// </summary>
    public class RevenueItem : Reference
    {

        public virtual ICollection<Good> Goods { get; set; }
    }
}
