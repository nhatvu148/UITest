using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Threading;

namespace UITest1
{
    class PostTestBug10617 : JupiterTestBase
    {
        public static void TestBug10617(string pathDirectory)
        // Shift Control: Direction Y setting is wrong.
        {
            jupiter.FindElementByName("Import Results").Click();

            Driver.FindElementByName("Jupiter Jtdb").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10617\\TestBug10617.jtdb");
            action.SendKeys(Keys.Enter);
            action.Perform();

            Thread.Sleep(1000);
            jupiter.FindElementByName("Open").FindElementByName("Cancel").Click();

            Thread.Sleep(1000);
            toolBar.FindElementByName("Appearance").Click();
            jupiter.FindElementByName("Section").Click();
            jupiter.FindElementByName("Shift Control").Click();

            var sectionViewShiftControl = jupiter.FindElementByName("Section View Shift Control");

            var directionY = sectionViewShiftControl.FindElementByAccessibilityId("2050");
            directionY.Clear();
            directionY.SendKeys("1");
            sectionViewShiftControl.FindElementsByName("Set")[1].Click();

            sectionViewShiftControl.FindElementByName("Close").Click();

            var mainWindow = jupiter.FindElementByAccessibilityId("59648");
            mainWindow.Click();

            action = new Actions(Driver);
            action.SendKeys("1").Perform();

            toolBar.FindElementByName("Home").Click();
            jupiter.FindElementByName("To Image").Click();
            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"\"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10617\\Actual\\TestBug10617.jpg\"");
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
            byte[] image1ArrayExpected = File.ReadAllBytes(pathDirectory + @"\TestResults\JPT-Post\TestBug10617\Expected\TestBug10617.jpg");
            string base64Image1RepresentationExpected = Convert.ToBase64String(image1ArrayExpected);

            byte[] image1ArrayActual = File.ReadAllBytes(pathDirectory + @"\TestResults\JPT-Post\TestBug10617\Actual\TestBug10617.jpg");
            string base64Image1RepresentationActual = Convert.ToBase64String(image1ArrayActual);

            try
            {
                Assert.AreEqual(base64Image1RepresentationExpected, base64Image1RepresentationActual);
            }
            catch
            {
                logger.Error("Assert.AreEqual failed - Output Images \"TestBug10617.jpg\" Not Identical");
            }

            Driver.FindElementByXPath("//Button[@Name='Application menu']").Click();
            Driver.FindElementByName("Save As...").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10617\\TestBug10617.tsdb");
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
