namespace ITLT.UnitTests.Extentions
{
    using ITLT.ExtentionMethods;
    using NUnit.Framework;
    using System;

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
            this.AreEqual(value1, true,"BooleanExt.IfHasNull");

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

        #endregion
    }
}
