using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace UITest1
{
    [TestClass]
    public class SolverTestMain : JupiterTestBase
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            if (Driver == null)
            {
                Setup("Root");
                objTestContext = testContext;
            }
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TearDown();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(50));
            Assert.IsNotNull(wait);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            TearDown();
        }

        [TestMethod]
        public void TestScenario3Boxes()
        {
            SolverTestScenario3Boxes.TestScenario3Boxes(pathDirectory);
        }
    }
}