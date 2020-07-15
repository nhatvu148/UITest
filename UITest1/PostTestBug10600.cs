using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace UITest1
{
    class PostTestBug10600 : JupiterTestBase
    {
        public static void TestBug10600(string pathDirectory)
        // Ansys Rst : can not import.
        {
            Driver.FindElementByName("Preferences").Click();

            var preferences = jupiter.FindElementByName("Preferences");
            preferences.FindElementByName("Mouse").Click();
            preferences.FindElementByName("TSV-Pre").Click();
            preferences.FindElementByName("OK").Click();

            jupiter.FindElementByName("Import Results").Click();

            Driver.FindElementByName("Ansys Rst").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10600\\kiyo_Job1.rst");
            action.SendKeys(Keys.Enter);
            action.Perform();

            toolBar.FindElementByName("Home").Click();
            jupiter.FindElementByName("To Image").Click();
            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"\"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10600\\kiyo_Job1.jpg\"");
            action.SendKeys(Keys.Enter);
            action.Perform();

            Thread.Sleep(1000);
            try
            {
                jupiter.FindElementByName("Yes").Click();
            }
            catch
            {
                logger.Warn("Confirm Dialog Not Appeared");
            }

            Driver.FindElementByXPath("//Button[@Name='Application menu']").Click();
            Driver.FindElementByName("Save As...").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10600\\kiyo_Job1.tsdb");
            action.SendKeys(Keys.Enter);
            action.Perform();

            Thread.Sleep(1000);
            try
            {
                jupiter.FindElementByName("Yes").Click();
            }
            catch
            {
                logger.Warn("Confirm Dialog Not Appeared");
            }
        }
    }
}
