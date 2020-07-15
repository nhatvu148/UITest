using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Threading;

namespace UITest1
{
    class PostTestBug10739 : JupiterTestBase
    {
        public static void TestBug10739(string pathDirectory)
        // Strain Gauge: an arrow mark always displayed whether the check box turned on/off.
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
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Pre\\results\\BoxTest.op2");
            action.SendKeys(Keys.Enter);
            action.Perform();

            Thread.Sleep(1000);
            var assembly = Driver.FindElementByName("Assembly");
            var analysisCollection = assembly.FindElementByName("Analysis collection");

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(analysisCollection, 0, 0).MoveByOffset(-30, 5).Click().Perform();

            var stressNode = analysisCollection.FindElementByName("Stress (Node)");

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(stressNode, 0, 0).MoveByOffset(-30, 5).Click().Perform();

            var mises = stressNode.FindElementByName("Mises");

            action = new Actions(Driver);
            action.DoubleClick(mises).Perform();

            var mainWindow = jupiter.FindElementByAccessibilityId("59648");

            action = new Actions(Driver);
            action.KeyDown(Keys.Control);
            action.MoveToElement(mainWindow).ClickAndHold();
            action.MoveByOffset(100, 50);
            action.Release().Perform();

            action = new Actions(Driver);
            action.KeyUp(Keys.Control).Perform();

            toolBar.FindElementByName("Tools").Click();
            Driver.FindElementByName("Strain Gauge").Click();
            var strainGauge = jupiter.FindElementByName("Strain/Stress Gauge");
            strainGauge.FindElementByAccessibilityId("5076").Click();
            action = new Actions(Driver);
            action.SendKeys("m");
            action.Perform();

            var nodeId = strainGauge.FindElementByAccessibilityId("1961");
            nodeId.Click();
            nodeId.SendKeys("10018");
            var search = strainGauge.FindElementByName("Search");
            search.Click();
            nodeId.Click();
            nodeId.Clear();
            nodeId.SendKeys("10017");
            search.Click();
            strainGauge.FindElementByName("Close").Click();

            action = new Actions(Driver);
            action.SendKeys("1").Perform();

            toolBar.FindElementByName("Home").Click();
            jupiter.FindElementByName("To Image").Click();
            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"\"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10739\\Actual\\StrainGaugeBefore.jpg\"");
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

            var watch = jupiter.FindElementByName("Watch");
            watch.Click();
            watch = jupiter.FindElementByName("Watch");
            var row10017 = watch.FindElementByName("10017");
            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(row10017);
            action.MoveToElement(row10017, -row10017.Size.Width / 2, 2).Click();
            action.Perform();


            var row10018 = watch.FindElementByName("10018");
            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(row10018);
            action.MoveToElement(row10018, -row10018.Size.Width / 2, 2).Click();
            action.Perform();

            jupiter.FindElementByName("To Image").Click();
            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"\"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10739\\Actual\\StrainGaugeAfter.jpg\"");
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
            byte[] image1ArrayExpected = File.ReadAllBytes(pathDirectory + @"\TestResults\JPT-Post\TestBug10739\Expected\StrainGaugeBefore.jpg");
            string base64Image1RepresentationExpected = Convert.ToBase64String(image1ArrayExpected);

            byte[] image1ArrayActual = File.ReadAllBytes(pathDirectory + @"\TestResults\JPT-Post\TestBug10739\Actual\StrainGaugeBefore.jpg");
            string base64Image1RepresentationActual = Convert.ToBase64String(image1ArrayActual);

            try
            {
                Assert.AreEqual(base64Image1RepresentationExpected, base64Image1RepresentationActual);
            }
            catch
            {
                logger.Error("Assert.AreEqual failed - Output Images \"StrainGaugeBefore.jpg\" Not Identical");
            }

            // Output Image 2 Compare
            byte[] image2ArrayExpected = File.ReadAllBytes(pathDirectory + @"\TestResults\JPT-Post\TestBug10739\Expected\StrainGaugeAfter.jpg");
            string base64Image2RepresentationExpected = Convert.ToBase64String(image2ArrayExpected);

            byte[] image2ArrayActual = File.ReadAllBytes(pathDirectory + @"\TestResults\JPT-Post\TestBug10739\Actual\StrainGaugeAfter.jpg");
            string base64Image2RepresentationActual = Convert.ToBase64String(image2ArrayActual);

            try
            {
                Assert.AreEqual(base64Image2RepresentationExpected, base64Image2RepresentationActual);
            }
            catch
            {
                logger.Error("Assert.AreEqual failed - Output Images \"StrainGaugeAfter.jpg\" Not Identical");
            }

            Driver.FindElementByXPath("//Button[@Name='Application menu']").Click();
            Driver.FindElementByName("Save As...").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Pre\\results\\BoxTest.tsdb");
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
