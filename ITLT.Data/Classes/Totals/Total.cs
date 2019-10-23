namespace ITLT.Data.Classes.Totals
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Total
    {

        public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Period { get; set; }

    }
}
