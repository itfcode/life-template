namespace ITLT.Domain.Mapping
{

    using ITLT.Data.Classes;

    public abstract class DocumentHeadMap<T> : EntitySyncMap<T> where T : DocumentHead
    {

        public DocumentHeadMap()
        {

            Define(x => x.Date, "Date", true);
            Define(x => x.Comment, "Comment", false);
        }
    }
}
