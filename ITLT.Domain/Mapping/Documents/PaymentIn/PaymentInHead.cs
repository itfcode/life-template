namespace ITLT.Domain.Mapping.Documents
{
    using ITLT.Data.Classes;

    public class PaymentInHeadMap : DocumentHeadMap<PaymentInHead>
    {
        public PaymentInHeadMap()
        {
            this.ToTable("PaymentInHead");
        }
    }
}
