namespace ITLT.Data.Classes
{
    using System;
    using System.Collections.Generic;

    public class ExpenseItem : Reference
    {
        public virtual ICollection<Good> Goods { get; set; }
    }
}
