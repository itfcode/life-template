namespace ITLT.Data.Classes.References
{
    using ITLT.Data.Interfaces;

    /// <summary>
    /// Base class for reference
    /// </summary>
    public abstract class ReferenceSync : EntitySync, IReferenceSync
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
