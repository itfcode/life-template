namespace ITLT.Data.Classes
{

    using System;

    public class DocumentHead : EntitySync
    {

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public virtual Contragent Contragent { get; set; }
    }
}
