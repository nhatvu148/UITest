using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Threading;

namespace UITest1
{
    class PostTestBug10606 : JupiterTestBase
    {
        public static void TestBug10606(string pathDirectory)
        // View Fit disabled for ADVC data.
        {
            Driver.FindElementByName("Preferences").Click();

            var preferences = jupiter.FindElementByName("Preferences");
            preferences.FindElementByName("Mouse").Click();
            preferences.FindElementByName("TSV-Pre").Click();
            preferences.FindElementByName("OK").Click();

            jupiter.FindElementByName("Import Results").Click();

            Driver.FindElementByName("Nastran Op2").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10606\\101_new.op2");
            action.SendKeys(Keys.Enter);
            action.Perform();

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(jupiter, 0, 0).MoveByOffset(1888, 358).Click();
            action.MoveToElement(jupiter, 0, 0).MoveByOffset(1190, 468).Click();
            action.MoveToElement(jupiter, 0, 0).MoveByOffset(1132, 413).Click().Perform();

            action = new Actions(Driver);
            action.SendKeys("f").Perform();

            toolBar.FindElementByName("Home").Click();
            jupiter.FindElementByName("To Image").Click();
            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"\"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10606\\Actual\\101_new_AfterFit.jpg\"");
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

            // Output Image 1 Compare
            byte[] image1ArrayExpected = File.ReadAllBytes(pathDirectory + @"\TestResults\JPT-Post\TestBug10606\Expected\101_new_AfterFit.jpg");
            string base64Image1RepresentationExpected = Convert.ToBase64String(image1ArrayExpected);

            byte[] image1ArrayActual = File.ReadAllBytes(pathDirectory + @"\TestResults\JPT-Post\TestBug10606\Actual\101_new_AfterFit.jpg");
            string base64Image1RepresentationActual = Convert.ToBase64String(image1ArrayActual);

            try
            {
                Assert.AreEqual(base64Image1RepresentationExpected, base64Image1RepresentationActual);
            }
            catch
            {
                logger.Error("Assert.AreEqual failed - Output Images \"101_new_AfterFit.jpg\" Not Identical");
            }

            Driver.FindElementByXPath("//Button[@Name='Application menu']").Click();
            Driver.FindElementByName("Save As...").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10606\\101_new.tsdb");
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

            jupiter.FindElementByName("Import Results").Click();

            Driver.FindElementByName("ADVENTURECluster2.0").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10606\\HT_f2");
            action.SendKeys(Keys.Enter);
            action.Perform();

            jupiter.FindElementByName("Please select folder").FindElementByName("Select Folder").Click();

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(jupiter, 0, 0).MoveByOffset(1888, 358).Click();
            action.MoveToElement(jupiter, 0, 0).MoveByOffset(1052, 473).Click();
            action.MoveToElement(jupiter, 0, 0).MoveByOffset(1194, 474).Click().Perform();

            action = new Actions(Driver);
            action.SendKeys("f").Perform();

            toolBar.FindElementByName("Home").Click();
            jupiter.FindElementByName("To Image").Click();
            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"\"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10606\\Actual\\ADVCResultAfterFit.jpg\"");
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

            // Output Image 2 Compare
            byte[] image2ArrayExpected = File.ReadAllBytes(pathDirectory + @"\TestResults\JPT-Post\TestBug10606\Expected\ADVCResultAfterFit.jpg");
            string base64Image2RepresentationExpected = Convert.ToBase64String(image2ArrayExpected);

            byte[] image2ArrayActual = File.ReadAllBytes(pathDirectory + @"\TestResults\JPT-Post\TestBug10606\Actual\ADVCResultAfterFit.jpg");
            string base64Image2RepresentationActual = Convert.ToBase64String(image2ArrayActual);

            try
            {
                Assert.AreEqual(base64Image2RepresentationExpected, base64Image2RepresentationActual);
            }
            catch
            {
                logger.Error("Assert.AreEqual failed - Output Images \"ADVCResultAfterFit.jpg\" Not Identical");
            }

            Driver.FindElementByXPath("//Button[@Name='Application menu']").Click();
            Driver.FindElementByName("Save As...").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10606\\HT_f2.tsdb");
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
