namespace ITLT.Data.Classes
{
    using System.Collections.Generic;

    /// <summary>
    /// Статья расходов 
    /// </summary>
    public class RevenueItem : Reference
    {
        public virtual ICollection<Good> Goods { get; set; }
    }
}
