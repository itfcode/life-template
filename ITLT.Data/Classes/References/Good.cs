namespace ITLT.Data.Classes
{

    /// <summary>
    /// EN: Goods and Services;  RU: Товары и услуги
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
        /// EN: Revenue Item by deafult; RU: Статья Доходов по умолчанию; 
        /// </summary>
        public virtual RevenueItem RevenueItem { get; set; }

        /// <summary>
        /// EN: Expense Item by deafult; RU: Статья Расходов по умолчанию 
        /// </summary>
        public virtual ExpenseItem ExpenseItem { get; set; }
    }
}
