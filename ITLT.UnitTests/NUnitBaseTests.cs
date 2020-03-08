namespace ITLT.UnitTests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public abstract class NUnitBaseTests
    {

        [TestFixtureSetUp]
        public virtual void StartUp()
        {
            // do somthing if it needed 
        }

        [TestFixtureTearDown]
        public virtual void TearDown()
        {
            // do somthing if it needed 
        }

        #region Protected Methods 

        protected void AreEqual(bool value1, bool value2, string methodName)
        {
            Assert.AreEqual(value1, value2, $"{methodName}: {value1} is not {value2}");
        }

        protected void AreEqual(DateTimeOffset value1, DateTimeOffset value2, string methodName)
        {
            Assert.AreEqual(value1, value2, $"{methodName}: {value1} is not {value2}");
        }

        protected void AreEqual(DateTimeOffset? value1, DateTimeOffset? value2, string methodName)
        {
            Assert.AreEqual(value1, value2, $"{methodName}: {value1} is not {value2}");
        }

        #endregion
    }
}
