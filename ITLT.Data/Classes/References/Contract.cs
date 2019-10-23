namespace ITLT.Data.Classes
{

    using System;

    public class Contract : Reference
    {

        public DateTime DateStart { get; set; }

        public DateTime DateFinish { get; set; }

        public virtual Contragent Contraget { get; set; }
    }
}
