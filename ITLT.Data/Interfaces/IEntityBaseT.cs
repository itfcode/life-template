namespace ITLT.Data
{
    public interface IEntityBase<T> : IEntityBase where T : struct
    {
        T Id { get; set; }
    }
}
