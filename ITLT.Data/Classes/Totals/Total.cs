namespace ITLT.Data.Classes.Totals
{
    using System;

    public abstract class Total
    {
        public Guid Id { get; set; }

        public DateTime Period { get; set; }
    }
}
