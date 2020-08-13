namespace ITLT.UnitTests.Extentions
{
    using ITLT.ExtentionMethods;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Test for class DateTimeOffsetExtentions
    /// </summary>
    public class BooleanExt_Tests : NUnitBaseTests
    {
        #region Private Fields 

        #endregion

        #region Protected Properties 
        #endregion

        #region Method Tests

        [Test]
        public void IfHasNull_Test()
        {
            var value1 = true.IfHasNull(default(string), 1, default(int?));
            this.AreEqual(value1, true, "BooleanExt.IfHasNull");

            var value2 = true.IfHasNull("test", 1, false);
            this.AreEqual(!value2, true, "BooleanExt.IfHasNull");
        }

        [Test]
        public void IfAllNull_Test()
        {
            var value1 = true.IfAllNull(default(string), default(int?), default(DateTime?));
            this.AreEqual(value1, true, "BooleanExt.IfAllNull");

            var value2 = true.IfAllNull(default(string), default(int?), "test");
            this.AreEqual(!value2, true, "BooleanExt.IfAllNull");
        }

        [Test]
        public void Test2()
        {
            Assembly thisAssembly = typeof(DateTimeExtentions).Assembly;
            var list = GetExtensionMethods(thisAssembly, typeof(DateTime));
            foreach (MethodInfo method in list)
            {
                Debug.WriteLine(method.Name);
            }
        }

        public static IList<MethodInfo> GetExtensionMethods(Assembly assembly,
                Type extendedType)
        {
            var query = from type in assembly.GetTypes()
                        where type.IsSealed && !type.IsGenericType && !type.IsNested
                        from method in type.GetMethods(BindingFlags.Static
                            | BindingFlags.Public | BindingFlags.NonPublic)
                        where method.IsDefined(typeof(ExtensionAttribute), false)
                        where method.GetParameters()[0].ParameterType == extendedType
                        select method;
            return query.ToList();
        }
        #endregion
    }
}
