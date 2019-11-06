namespace ITLT.Data.Classes.References
{

    using System;

    /// <summary>
    /// EN: Reference "Contract"; RU: Справочник "Контракты"
    /// </summary>
    public class Contract : Reference
    {
        /// <summary>
        /// EN: Date Start; RU: Дата начала
        /// </summary>
        public DateTime? DateStart { get; set; }

        /// <summary>
        /// EN: Date Finish; RU: Дата окончания
        /// </summary>
        public DateTime? DateFinish { get; set; }

        /// <summary>
        /// Contragent
        /// </summary>
        public virtual Contragent Contragent { get; set; }
    }
}
