namespace ITLT.Data.Classes
{

    using System.Collections.Generic;

    public class Contragent : Entity
    {
        public string Name { get; set; }

        public string ITIN { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
