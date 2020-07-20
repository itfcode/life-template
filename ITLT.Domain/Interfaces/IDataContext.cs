namespace ITLT.Domain.Interfaces
{
    using ITLT.Data.Classes;
    using ITLT.Data.Classes.References;
    using System.Data.Entity;

    public interface IDataContext : IGenericRepository
    {

        #region EN: References; RU: Справочники

        IDbSet<Good> Goods { get; set; }

        IDbSet<ExpenseItem> ExpenseItems { get; set; }

        IDbSet<RevenueItem> RevenueItems { get; set; }

        IDbSet<Currency> Currencies { get; set; }

        IDbSet<MoneyAccount> MoneyAccounts { get; set; }

        #endregion

        #region EN: Documents; RU: Документы

        IDbSet<InvoiceInHead> InvoiceInHeads { get; set; }

        IDbSet<InvoiceInRow> InvoiceInRows { get; set; }

        IDbSet<InvoiceOutHead> InvoiceOutHeads { get; set; }

        IDbSet<InvoiceOutRow> InvoiceOutRows { get; set; }

        IDbSet<MoneyTransferHead> MoneyTransferHeads { get; set; }

        IDbSet<PaymentInHead> PaymentInHeads { get; set; }

        IDbSet<PaymentOutHead> PaymentOutHeads { get; set; }

        IDbSet<InvoiceInSrc> InvoiceInSrcs { get; set; }

        #endregion

        #region EN: Totals; RU: Итоги

        #endregion

    }
}
