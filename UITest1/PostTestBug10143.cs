using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Threading;

namespace UITest1
{
    class PostTestBug10143 : JupiterTestBase
    {
        public static void TestBug10143(string pathDirectory)
        // [Universal] Import and crash.
        {
            Driver.FindElementByName("Preferences").Click();

            var preferences = jupiter.FindElementByName("Preferences");
            preferences.FindElementByName("Mouse").Click();
            preferences.FindElementByName("TSV-Pre").Click();
            preferences.FindElementByName("OK").Click();

            jupiter.FindElementByName("Import Results").Click();

            Driver.FindElementByName("Universal").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10143\\Dummy_New-Pre_Segment.unv");
            action.SendKeys(Keys.Enter);
            action.Perform();

            toolBar.FindElementByName("Home").Click();
            jupiter.FindElementByName("To Image").Click();
            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"\"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10143\\Actual\\Dummy_New-Pre_Segment.jpg\"");
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

            // Output Image Compare
            byte[] imageArrayExpected = File.ReadAllBytes(pathDirectory + @"\TestResults\JPT-Post\TestBug10143\Expected\Dummy_New-Pre_Segment.jpg");
            string base64ImageRepresentationExpected = Convert.ToBase64String(imageArrayExpected);

            byte[] imageArrayActual = File.ReadAllBytes(pathDirectory + @"\TestResults\JPT-Post\TestBug10143\Actual\Dummy_New-Pre_Segment.jpg");
            string base64ImageRepresentationActual = Convert.ToBase64String(imageArrayActual);

            try
            {
                Assert.AreEqual(base64ImageRepresentationActual, base64ImageRepresentationExpected, "Assert.AreEqual failed - Output Images Not Identical");
            }
            catch
            {
                logger.Error("Assert.AreEqual failed - Output Images Not Identical");
            }

            Thread.Sleep(2000);

            Driver.FindElementByXPath("//Button[@Name='Application menu']").Click();
            Driver.FindElementByName("Save As...").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10143\\Dummy_New-Pre_Segment.tsdb");
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
