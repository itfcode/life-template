namespace ITLT.Data.Classes
{

    using System.Collections.Generic;

    /// <summary>
    /// EN: Expense Item; RU: Статья Расходов 
    /// </summary>
    public class ExpenseItem : Reference
    {

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Good> Goods { get; set; }
    }
}
