namespace ITLT.Domain.Mapping
{

    using ITLT.Data.Classes;

    public abstract class ReferenceMap<T> : EntityMap<T> where T : Reference
    {

        public ReferenceMap()
        {

            Define(x => x.Name, "Name", true);
            Define(x => x.Description, "Description", false);
        }
    }
}
