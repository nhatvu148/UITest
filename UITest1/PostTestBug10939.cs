using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Threading;

namespace UITest1
{
    class PostTestBug10939 : JupiterTestBase
    {
        public static void TestBug10939(string pathDirectory)
        // Unexpected transparent with VBO mode
        {
            Driver.FindElementByName("Preferences").Click();

            var preferences = jupiter.FindElementByName("Preferences");
            preferences.FindElementByName("VBO").Click();
            var enableVBO = preferences.FindElementByAccessibilityId("5684");

            if (!enableVBO.Selected)
            {
                enableVBO.Click();
                preferences.FindElementByName("Jupiter-Post 4.1.2").FindElementByName("OK").Click();
                preferences.FindElementByName("OK").Click();
                Driver.Close();

                Thread.Sleep(4000);

                AppiumOptions appOptions = new AppiumOptions();
                Assert.IsNotNull(appOptions);
                appOptions.AddAdditionalCapability("app", @"C:\Program Files\TechnoStar\Jupiter-Post_4.1.2\PCAD_main.exe");
                Driver = new WindowsDriver<WindowsElement>(
                   new Uri("http://127.0.0.1:4723"),
                   appOptions,
                   TimeSpan.FromMinutes(5)
                   );
                Assert.IsNotNull(Driver);
                Assert.IsNotNull(Driver.SessionId);

                wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(50));
                Assert.IsNotNull(wait);
                Driver.Manage().Window.Maximize();
                jupiter = Driver.FindElementByXPath("//Window[starts-with(@Name,'Jupiter-Post 4.1.2')]");
                toolBar = Driver.FindElementByName("Ribbon Tabs");
            }

            Thread.Sleep(1000);

            try
            {
                preferences.FindElementByName("OK").Click();
            }
            catch
            {
                logger.Warn("Confirm Dialog Not Appeared");
            }

            jupiter.FindElementByName("Import Results").Click();

            Driver.FindElementByName("Nastran Op2").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10939\\quad4.op2");
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

            var mises = stressNode.FindElementByName("Shell Mises");

            action = new Actions(Driver);
            action.DoubleClick(mises).Perform();


            SelectView(ViewKey.Front, pathDirectory);
            SelectView(ViewKey.Rear, pathDirectory);
            SelectView(ViewKey.Top, pathDirectory);
            SelectView(ViewKey.Bottom, pathDirectory);
            SelectView(ViewKey.Left, pathDirectory);
            SelectView(ViewKey.Right, pathDirectory);


            Driver.FindElementByXPath("//Button[@Name='Application menu']").Click();
            Driver.FindElementByName("Save As...").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10939\\quad4.tsdb");
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

        public enum ViewKey
        {
            Front = 1,
            Rear = 2,
            Top = 3,
            Bottom = 4,
            Left = 5,
            Right = 6
        }

        public static void SelectView(ViewKey viewKey, string pathDirectory)
        {
            jupiter.FindElementByAccessibilityId("59648").Click();
            action = new Actions(Driver);
            action.SendKeys(((int)viewKey).ToString()).Perform();
            jupiter.FindElementByName("To Image").Click();
            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"\"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10939\\Actual\\{viewKey}View.jpg\"");
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
            byte[] image1ArrayExpected = File.ReadAllBytes(pathDirectory + @"\TestResults\JPT-Post\TestBug10939\Expected\" + viewKey + "View.jpg");
            string base64Image1RepresentationExpected = Convert.ToBase64String(image1ArrayExpected);

            byte[] image1ArrayActual = File.ReadAllBytes(pathDirectory + @"\TestResults\JPT-Post\TestBug10939\Actual\" + viewKey + "View.jpg");
            string base64Image1RepresentationActual = Convert.ToBase64String(image1ArrayActual);

            try
            {
                Assert.AreEqual(base64Image1RepresentationExpected, base64Image1RepresentationActual);
            }
            catch
            {
                logger.Error("Assert.AreEqual failed - Output Images \"" + viewKey + "View.jpg\" Not Identical");
            }
        }
    }
}
