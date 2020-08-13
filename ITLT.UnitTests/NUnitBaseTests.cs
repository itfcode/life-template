namespace ITLT.UnitTests
{
    using NUnit.Framework;
    using System;
    using System.Diagnostics;

    [TestFixture]
    public abstract class NUnitBaseTests
    {

        #region Protected Fields

        bool ShowTestingValues = true;

        #endregion

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
            if (ShowTestingValues)
            {
                Debug.WriteLine(new string('-', 50));
                Debug.WriteLine($"Method: {methodName} ");
                Debug.WriteLine($"  value1: {value1}");
                Debug.WriteLine($"  value2: {value2}");
            }

            Assert.AreEqual(value1, value2, $"{methodName}: {value1} is not {value2}");
        }

        protected void AreEqual(DateTime value1, DateTime value2, string methodName)
        {
            var view1 = $"{value1:d dd/MM/yyyy HH:mm:ss fffffff}";
            var view2 = $"{value2:d dd/MM/yyyy HH:mm:ss fffffff}";

            if (ShowTestingValues)
            {
                Debug.WriteLine(new string('-', 50));
                Debug.WriteLine($"Method: {methodName} ");
                Debug.WriteLine($"  value1: {view1}");
                Debug.WriteLine($"  value2: {view2}");
            }
            Assert.AreEqual(value1, value2, $"{methodName}: {view1} is not {view2}");
        }

        protected void AreEqual(DateTimeOffset value1, DateTimeOffset value2, string methodName)
        {
            if (ShowTestingValues)
            {
                Debug.WriteLine(new string('-', 50));
                Debug.WriteLine($"Method: {methodName} ");
                Debug.WriteLine($"  value1: {value1}");
                Debug.WriteLine($"  value2: {value2}");
            }
            Assert.AreEqual(value1, value2, $"{methodName}: {value1} is not {value2}");
        }

        protected void AreEqual(DateTimeOffset? value1, DateTimeOffset? value2, string methodName)
        {
            Assert.AreEqual(value1, value2, $"{methodName}: {value1} is not {value2}");
        }

        #endregion
    }
}
