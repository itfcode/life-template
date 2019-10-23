namespace ITLT.Domain.Mapping
{

    using ITLT.Data.Classes;
    
    public class MoneyTransferHeadMap : DocumentHeadMap<MoneyTransferHead> 
    {

        public MoneyTransferHeadMap()
        {

            this.ToTable("MoneyTransferHead");
        }
    }
}
