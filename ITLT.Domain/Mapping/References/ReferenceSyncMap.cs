namespace ITLT.Domain.Mapping
{
    using ITLT.Data.Classes;

    public abstract class ReferenceSyncMap<T> : EntitySyncMap<T> where T : EntitySync
    {
    }
}
