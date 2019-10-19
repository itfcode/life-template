namespace ITLT.Data.Classes
{
    /// <summary>
    /// RU: Товары и услуги; EN: Goods and Services 
    /// </summary>
    public class Good : Reference
    {

        /// <summary>
        /// Id of Revenue Item by deafult 
        /// </summary>
        public int? RevenueItemId { get; set; }

        /// <summary>
        /// Id of Expense Item by deafult
        /// </summary>
        public int? ExpenseItemId { get; set; }

        /// <summary>
        /// RU: Статья Доходов по умолчанию; EN: Revenue Item by deafult
        /// </summary>
        public virtual RevenueItem RevenueItem { get; set; }

        /// <summary>
        /// RU: Статья Расходов по умолчанию EN: Expense Item by deafult
        /// </summary>
        public virtual ExpenseItem ExpenseItem { get; set; }
    }
}
