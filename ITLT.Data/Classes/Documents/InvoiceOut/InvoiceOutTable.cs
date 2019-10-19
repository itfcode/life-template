namespace ITLT.Data.Classes
{

    public class InvoiceOutTable : DocumentTable
    {

        public Good Good { get; set; }

        public InvoiceOutHead Head { get; set; }
    }
}
