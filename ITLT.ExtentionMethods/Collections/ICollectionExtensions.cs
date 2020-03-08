namespace ITLT.ExtentionMethods
{
    using System.Collections.Generic;

    public static class ICollectionExtensions
    {
        #region MyRegion

        #endregion

        #region Public Methods 

        /// <summary>
        /// Adds self to collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self">The self.</param>
        /// <param name="collection">The collection.</param>
        /// <returns></returns>
        public static T AddTo<T>(this T self, ICollection<T> collection)
        {
            collection.Add(self);
            return self;
        }

        #endregion
    }
}
