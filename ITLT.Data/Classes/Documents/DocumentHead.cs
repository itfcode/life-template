namespace ITLT.Data.Classes
{

    using System;

    public class DocumentHead : EntitySync
    {

        public DateTime Date { get; set; }

        public bool Commited { get; set; }

        public string Comment { get; set; }
    }
}
