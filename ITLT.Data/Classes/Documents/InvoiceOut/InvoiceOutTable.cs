namespace ITLT.Data.Classes
{
    /// <summary>
    /// en: table part of outcomming invoice; ru: табличная часть исходящего счета(чека, накладной)
    /// </summary>
    public class InvoiceOutTable : DocumentTable
    {

        public Good Good { get; set; }

        public InvoiceOutHead Head { get; set; }
    }
}
