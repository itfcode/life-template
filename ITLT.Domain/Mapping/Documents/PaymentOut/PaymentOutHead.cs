namespace ITLT.Domain.Mapping.Documents
{
    using ITLT.Data.Classes;
 
    public class PaymentOutHeadMap : DocumentHeadMap<PaymentOutHead>
    {
        public PaymentOutHeadMap()
        {
            this.ToTable("PaymentOutHead");
        }
    }
}
