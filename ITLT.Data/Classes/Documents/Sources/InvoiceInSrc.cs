namespace ITLT.Data.Classes
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class InvoiceInSrc : EntitySync
    {
        public DateTimeOffset Date { get; set; }

        public string CheckNumber { get; set; }

        public string Name { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }

        public bool Cash { get; set; }
    }
}
