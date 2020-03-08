namespace ITLT.Data.Classes.References
{
    using ITLT.Data.Interfaces;

    /// <summary>
    /// Base class for reference
    /// </summary>
    public abstract class Reference : Entity, IReference
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
    }
}
