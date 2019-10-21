namespace ITLT.Data.Classes
{

    using ITLT.Data.Interfaces;

    public class Reference : Entity, IReference
    {

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
