namespace ITLT.Domain.Mapping
{

    using ITLT.Data.Classes;

    public abstract class ReferenceSyncMap<T> : EntitySyncMap<T> where T : ReferenceSync
    {

        public ReferenceSyncMap()
        {

            Define(x => x.Name, "Name", true);
            Define(x => x.Description, "Description", false);
        }
    }
}
