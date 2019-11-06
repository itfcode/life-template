namespace ITLT.UnitTests
{
    using NUnit.Framework;

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

    }
}
