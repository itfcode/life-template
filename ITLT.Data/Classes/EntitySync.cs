namespace ITLT.Data.Classes
{
    using ITLT.Data.Interfaces;

    public abstract class EntitySync : IEntitySync
    {
        public System.Guid Id { get; set; }
    }
}
