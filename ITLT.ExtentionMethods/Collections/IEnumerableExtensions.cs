namespace ITLT.ExtentionMethods
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class IEnumerableExtensions
    {

        #region Union of several LINQ methods 

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

        public static List<TResult> SelectToList<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return source.Select(selector).ToList();
        }

        #endregion

        /// <summary>
        /// Works like linq-method 'OrderBy' 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelectors"></param>
        /// <returns></returns>
        public static IOrderedEnumerable<TSource> SortBy<TSource>(this IEnumerable<TSource> source, params Func<TSource, object>[] keySelectors)
        {
            var result = source.OrderBy(keySelectors[0]);

            for (int i = 1; i < keySelectors.Length; i++)
            {
                result = result.ThenBy(keySelectors[i]);
            }

            return result;
        }

        /// <summary>
        /// Works like linq-method 'OrderByDescending' 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelectors"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Makes new string where values delimeted by delimeter
        /// </summary>
        /// <param name="values"></param>
        /// <param name="delimeter"></param>
        /// <returns></returns>
        public static string ToStringWithDelimeters(this IEnumerable<string> values, char delimeter)
        {
            return values.ToStringWithDelimeters(delimeter.ToString());
        }

        /// <summary>
        /// Makes new string where values delimeted by delimeter
        /// </summary>
        /// <param name="values"></param>
        /// <param name="delimeter"></param>
        /// <returns></returns>
        public static string ToStringWithDelimeters(this IEnumerable<string> values, string delimeter)
        {
            if (values != null && values.Count() > 0)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var value in values)
                {
                    sb.Append(value);
                    sb.Append(delimeter);
                }

                sb.Remove(sb.Length - delimeter.Length, delimeter.Length);

                return sb.ToString();
            }
            return string.Empty;
        }
    }
}
