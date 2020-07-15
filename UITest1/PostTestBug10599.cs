using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Threading;

namespace UITest1
{
    class PostTestBug10599 : JupiterTestBase
    {
        public static void TestBug10599(string pathDirectory)
        // View Fit does not work for Group mode.
        {
            Driver.FindElementByName("Preferences").Click();

            var preferences = jupiter.FindElementByName("Preferences");
            preferences.FindElementByName("Mouse").Click();
            preferences.FindElementByName("TSV-Pre").Click();
            preferences.FindElementByName("OK").Click();

            Driver.FindElementByXPath("//Button[@Name='Application menu']").Click();
            Driver.FindElementByName("Open...").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10599\\ViewFitTest.tsdb");
            action.SendKeys(Keys.Enter);
            action.Perform();

            jupiter.FindElementByName("Group").FindElementByName("Group").Click();

            var elementGroup = jupiter.FindElementByName("Element Groups");

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.DoubleClick(elementGroup).Perform();
            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.DoubleClick(elementGroup.FindElementByName("Group (1)")).Perform();

            var mainWindow = jupiter.FindElementByAccessibilityId("59648");
            mainWindow.Click();

            action = new Actions(Driver);
            action.SendKeys("f").Perform();

            toolBar.FindElementByName("Home").Click();
            jupiter.FindElementByName("To Image").Click();
            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"\"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10599\\Actual\\GroupElementSelectedDisplayedAll_AfterFit.jpg\"");
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

            mainWindow.Click();

            action = new Actions(Driver);
            action.SendKeys("e");
            action.KeyDown(Keys.Control);
            action.MoveToElement(mainWindow).ClickAndHold();
            action.MoveByOffset(-100, -50);
            action.Release().Perform();

            action = new Actions(Driver);
            action.KeyUp(Keys.Control);
            action.MoveToElement(jupiter, 0, 0).MoveByOffset(1064, 227).Click();
            action.SendKeys("f").Perform();

            toolBar.FindElementByName("Home").Click();
            jupiter.FindElementByName("To Image").Click();
            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"\"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10599\\Actual\\GroupElementSelectedDisplayedOnly_AfterFit.jpg\"");
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

            action = new Actions(Driver);
            action.MoveToElement(jupiter, 0, 0).MoveByOffset(926, 187).Click();
            action.SendKeys("f").Perform();

            toolBar.FindElementByName("Home").Click();
            jupiter.FindElementByName("To Image").Click();
            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"\"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10599\\Actual\\DisplayedAll_AfterFit.jpg\"");
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
            byte[] image1ArrayExpected = File.ReadAllBytes(pathDirectory + @"\TestResults\JPT-Post\TestBug10599\Expected\GroupElementSelectedDisplayedAll_AfterFit.jpg");
            string base64Image1RepresentationExpected = Convert.ToBase64String(image1ArrayExpected);

            byte[] image1ArrayActual = File.ReadAllBytes(pathDirectory + @"\TestResults\JPT-Post\TestBug10599\Actual\GroupElementSelectedDisplayedAll_AfterFit.jpg");
            string base64Image1RepresentationActual = Convert.ToBase64String(image1ArrayActual);

            try
            {
                Assert.AreEqual(base64Image1RepresentationExpected, base64Image1RepresentationActual);
            }
            catch
            {
                logger.Error("Assert.AreEqual failed - Output Images \"GroupElementSelectedDisplayedAll_AfterFit.jpg\" Not Identical");
            }

            // Output Image 2 Compare
            byte[] image2ArrayExpected = File.ReadAllBytes(pathDirectory + @"\TestResults\JPT-Post\TestBug10599\Expected\GroupElementSelectedDisplayedOnly_AfterFit.jpg");
            string base64Image2RepresentationExpected = Convert.ToBase64String(image2ArrayExpected);

            byte[] image2ArrayActual = File.ReadAllBytes(pathDirectory + @"\TestResults\JPT-Post\TestBug10599\Actual\GroupElementSelectedDisplayedOnly_AfterFit.jpg");
            string base64Image2RepresentationActual = Convert.ToBase64String(image2ArrayActual);

            try
            {
                Assert.AreEqual(base64Image2RepresentationExpected, base64Image2RepresentationActual);
            }
            catch
            {
                logger.Error("Assert.AreEqual failed - Output Images \"GroupElementSelectedDisplayedOnly_AfterFit.jpg\" Not Identical");
            }

            // Output Image 3 Compare
            byte[] image3ArrayExpected = File.ReadAllBytes(pathDirectory + @"\TestResults\JPT-Post\TestBug10599\Expected\DisplayedAll_AfterFit.jpg");
            string base64Image3RepresentationExpected = Convert.ToBase64String(image3ArrayExpected);

            byte[] image3ArrayActual = File.ReadAllBytes(pathDirectory + @"\TestResults\JPT-Post\TestBug10599\Actual\DisplayedAll_AfterFit.jpg");
            string base64Image3RepresentationActual = Convert.ToBase64String(image3ArrayActual);

            try
            {
                Assert.AreEqual(base64Image3RepresentationExpected, base64Image3RepresentationActual);
            }
            catch
            {
                logger.Error("Assert.AreEqual failed - Output Images \"DisplayedAll_AfterFit.jpg\" Not Identical");
            }
        }
    }
}
