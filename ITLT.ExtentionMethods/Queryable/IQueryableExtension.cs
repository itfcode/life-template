namespace ITLT.ExtentionMethods
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    public static class IQueryableExtension
    {

        #region Union of several LINQ methods 

        public static List<TSource> UnionToList<TSource>(this IQueryable<TSource> first, IQueryable<TSource> second)
        {
            return first.Union(second).ToList();
        }

        public static IQueryable<TResult> SelectDistinct<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector)
        {
            return source.Select(selector).Distinct();
        }

        public static List<TResult> SelectToList<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector)
        {
            return source.Select(selector).ToList();
        }

        public static List<TResult> SelectDistinctToList<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector)
        {
            return source.Select(selector).Distinct().ToList();
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query"></param>
        /// <param name="getters"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> NotEmpty<TEntity>(this IQueryable<TEntity> query, params Expression<Func<TEntity, string>>[] getters)
        {
            var q = query;

            foreach (var getter in getters)
            {
                Expression<Func<TEntity, bool>> filter = x => getter.Call()(x).Trim() != "" && getter.Call()(x) != null;
                q = q.Where(filter.SubstituteMarker());
            }

            return q;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="query"></param>
        /// <param name="getters"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> NotNull<TEntity, TObject>(this IQueryable<TEntity> query, params Expression<Func<TEntity, TObject>>[] getters) where TObject : class
        {
            var q = query;

            foreach (var getter in getters)
            {
                Expression<Func<TEntity, bool>> filter = x => getter.Call()(x) != null;
                q = q.Where(filter.SubstituteMarker());
            }

            return q;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="query"></param>
        /// <param name="getters"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> HasValue<TEntity, TValue>(this IQueryable<TEntity> query, params Expression<Func<TEntity, TValue?>>[] getters) where TValue : struct
        {
            var q = query;

            foreach (var getter in getters)
            {
                Expression<Func<TEntity, bool>> filter = x => getter.Call()(x).HasValue;
                q = q.Where(filter.SubstituteMarker());
            }

            return q;
        }
    }
}
