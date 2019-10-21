namespace ITLT.Domain.Mapping
{

    using ITLT.Data.Classes;

    public abstract class DocumentRowMap<T> : EntitySyncMap<T> where T : DocumentRow
    {

        public DocumentRowMap()
        {

            Define(x => x.Number, "Number", true);
        }
    }
}
