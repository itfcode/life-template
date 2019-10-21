namespace ITLT.Data.Classes
{

    using ITLT.Data.Interfaces;

    public class ReferenceSync : EntitySync, IReferenceSync
    {

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
