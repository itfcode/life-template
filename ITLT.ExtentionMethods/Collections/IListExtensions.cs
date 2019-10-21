namespace ITLT.ExtentionMethods
{

    using System.Collections.Generic;

    public static class IListExtensions
    {

        #region Private Methods

        #endregion

        #region Public Methods 

        /// <summary>
        /// Inserts self to list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self">The self.</param>
        /// <param name="collection">The collection.</param>
        /// <returns></returns>
        public static T InsertTo<T>(this T self, IList<T> collection, int index)
        {
            collection.Insert(index, self);
            return self;
        }

        #endregion
    }
}
