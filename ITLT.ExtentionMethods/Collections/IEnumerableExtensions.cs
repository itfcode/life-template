namespace ITLT.ExtentionMethods
{

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableExtensions
    {

        #region Union of several methods 

        public static IEnumerable<TResult> SelectDistinct<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return source.Select(selector).Distinct();
        }

        public static IEnumerable<TResult> SelectDistinct<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, IEqualityComparer<TResult> comparer)
        {
            return source.Select(selector).Distinct(comparer);
        }

        public static List<TSource> UnionToList<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            return first.Union(second).ToList();
        }

        public static List<TSource> UnionToList<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            return first.Union(second, comparer).ToList();
        }

        #endregion

        public static List<TResult> SelectToList<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return source.Select(selector).ToList();
        }

        public static IOrderedEnumerable<TSource> SortBy<TSource>(this IEnumerable<TSource> source, params Func<TSource, object>[] keySelectors)
        {
            var result = source.OrderBy(keySelectors[0]);

            for (int i = 1; i < keySelectors.Length; i++)
            {
                result = result.ThenBy(keySelectors[i]);
            }

            return result;
        }

        public static IOrderedEnumerable<TSource> SortByDescending<TSource, TKey>(this IEnumerable<TSource> source, params Func<TSource, object>[] keySelectors)
        {
            var result = source.OrderByDescending(keySelectors[0]);

            for (int i = 1; i < keySelectors.Length; i++)
            {
                result = result.ThenByDescending(keySelectors[i]);
            }

            return result;
        }

        /// <summary>
        /// Crosses the apply - Like CROSS APPLY in MS SQL.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="keys">The keys.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> CrossApply<TSource, TKey>(this IEnumerable<TSource> source, IEnumerable<TKey> keys, Func<TSource, TKey> keySelector, int count = 1)
        {
            var items = source.Take(0); // initialization of result collection

            foreach (TKey key in keys)
            {
                items = items.Union(source.Where(x => keySelector(x).Equals(key)).Take(count));
            }

            return items;
        }
    }
}
