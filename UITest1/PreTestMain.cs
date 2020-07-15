using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace UITest1
{
    [TestClass]
    public class PreTestMain : JupiterTestBase
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            if (Driver == null)
            {
                foreach (var process in Process.GetProcessesByName("DCAD_main"))
                {
                    process.Kill();
                }
                
                Setup("C:\\Program Files\\TechnoStar\\Jupiter-Pre_5.0\\DCAD_main.exe");
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
            if (Driver == null)
            {
                foreach (var process in Process.GetProcessesByName("DCAD_main"))
                {
                    process.Kill();
                }

                Thread.Sleep(4000);
                Setup("C:\\Program Files\\TechnoStar\\Jupiter-Pre_5.0\\DCAD_main.exe");
            }

            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(50));
            Assert.IsNotNull(wait);
            Driver.Manage().Window.Maximize();
            jupiter = Driver.FindElementByXPath("//Window[starts-with(@Name,'Jupiter-Pre 5.0')]");
            toolBar = Driver.FindElementByName("Ribbon Tabs");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            TearDown();
        }

        [TestMethod]
        public void TestScenario3Boxes()
        {
            PreTestScenario3Boxes.TestScenario3Boxes(pathDirectory);
        }
    }
}