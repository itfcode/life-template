namespace ITLT.ExtentionMethods
{

    using System.Linq;

    public static class BooleanExtension
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static bool HasNull(this bool self, params object[] objects)
        {
            return objects.Any(x => x == null) == self;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static bool IfNull(this bool self, params object[] objects)
        {
            return objects.Any(x => x == null) == self;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static bool AllNull(this bool self, params object[] objects)
        {
            return objects.All(x => x == null) == self;
        }
    }
}
