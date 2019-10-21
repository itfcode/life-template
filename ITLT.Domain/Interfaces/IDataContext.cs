namespace ITLT.Domain.Interfaces
{

    using ITLT.Data.Classes;
    using System.Data.Entity;

    public interface IDataContext : IGenericRepository
    {

        IDbSet<Good> Goods { get; set; }

        IDbSet<ExpenseItem> ExpenseItems { get; set; }

        IDbSet<RevenueItem> RevenueItems { get; set; }

        IDbSet<Currency> Currencies { get; set; }

        IDbSet<MoneyAccount> MoneyAccounts { get; set; }
    }
}
