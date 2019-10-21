namespace ITLT.Data.Classes
{
    using ITLT.Data.Interfaces;

    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
