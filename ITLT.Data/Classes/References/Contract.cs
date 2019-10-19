namespace ITLT.Data.Classes
{
    using System;

    public class Contract : EntitySync
    {

        public string Name { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateFinish { get; set; }

        public virtual Contragent Contraget { get; set; }

        public string Description { get; set; }
    }
}
