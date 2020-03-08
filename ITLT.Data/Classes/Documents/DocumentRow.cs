namespace ITLT.Data.Classes
{
    using System;

    public class DocumentRow : EntitySync
    {
        public Guid HeadId { get; set; }
        
        public int Number { get; set; }
    }
}
