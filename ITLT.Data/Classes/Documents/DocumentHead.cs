namespace ITLT.Data.Classes
{

    using System;

    public class DocumentHead : EntitySync
    {

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public virtual Contragent Contragent { get; set; }
    }
}
