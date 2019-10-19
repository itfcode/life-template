namespace ITLT.Data.Classes
{

    using System;

    public class DocumentTable : EntitySync
    {

        public Guid HeadId { get; set; }
        
        public int RowNumber { get; set; }
    }
}
