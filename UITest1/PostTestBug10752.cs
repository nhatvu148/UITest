using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace UITest1
{
    class PostTestBug10752 : JupiterTestBase
    {
        public static void TestBug10752(string pathDirectory)
        // Window placement is not stable.
        {
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
            assembly.FindElementByName("Tools").Click();
            var analysis = assembly.FindElementByName("Analysis");
            Assert.IsNotNull(analysis);

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

            Driver.FindElementByXPath("//Button[@Name='Application menu']").Click();
            Driver.FindElementByName("Open...").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10939\\quad4.tsdb");
            action.SendKeys(Keys.Enter);
            action.Perform();

            Thread.Sleep(1000);

            assembly = Driver.FindElementByName("Assembly");
            var analysisCollection = assembly.FindElementByName("Analysis collection");

            action = new Actions(Driver);
            Assert.IsNotNull(analysisCollection);

            Driver.FindElementByXPath("//Button[@Name='Application menu']").Click();
            Driver.FindElementByName("Save").Click();

            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
                logger.Info("Closed Jupiter");
            }
        }
    }
}
