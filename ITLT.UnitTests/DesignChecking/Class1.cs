namespace ITLT.UnitTests.DesignChecking
{
    using ITLT.Data.Classes;
    using ITLT.Data.Classes.References;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// Checking of Design of Classes
    /// </summary>
    public class DesignCheckingTests : NUnitBaseTests
    {

        #region Private && Protected Fields 

        protected readonly string ReferenceNamespace = "ITLT.Data.Classes.References";

        protected readonly string DocumentNamespace = "ITLT.Data.Classes.Documents";

        protected readonly string TotalNamespace = "ITLT.Data.Classes.Totals";

        protected readonly Assembly DataLib = typeof(Entity).Assembly;

        #endregion

        #region MyRegion

        public DesignCheckingTests()
        {

        }

        #endregion

        #region Public Methods

        [Test]
        public void ReferenceDesignCheckingTest()
        {
            var hasError = false;

            var sb = new StringBuilder();
            sb.AppendLine($"{Environment.NewLine} >>> Reference Design Checking Test starts ... {Environment.NewLine}");

            foreach (var type in GetTypesInNamespace(DataLib, ReferenceNamespace))
            {
                if (!type.IsAbstract && !(type.IsSubclassOf(typeof(Reference)) || type.IsSubclassOf(typeof(ReferenceSync))))
                {
                    hasError = true;
                    sb.AppendLine($"    Type 'References.{type.Name}' should be subclass of 'Reference' or 'ReferenceSync' ");
                }
            }

            sb.AppendLine($"{Environment.NewLine} <<< Reference Design Checking Test ends ... ");

            var message = sb.ToString();
            Debug.WriteLine(sb.ToString());

            Assert.IsFalse(hasError);

        }

        [Test]
        public void DocumentDesignCheckingTest()
        {
            foreach (var type in GetTypesInNamespace(DataLib, DocumentNamespace))
            {
                Debug.WriteLine($"TYPE: {type.Name}");
            }
        }

        #endregion

        #region Protected Methods 

        protected IReadOnlyList<Type> GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
              assembly.GetTypes()
                      .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                      .ToList();
        }

        #endregion

    }
}
