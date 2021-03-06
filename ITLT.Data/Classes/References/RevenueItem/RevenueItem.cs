﻿namespace ITLT.Data.Classes.References
{
    using System.Collections.Generic;

    /// <summary>
    /// EN: Revenue Item; RU: Статья Доходов 
    /// </summary>
    public class RevenueItem : Reference
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Good> Goods { get; set; }
    }
}
