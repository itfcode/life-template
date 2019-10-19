namespace ITLT.Data.Classes
{

    using System.Collections.Generic;

    public class Contragent : Reference
    {

        public string ITIN { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
