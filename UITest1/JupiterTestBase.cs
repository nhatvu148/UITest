using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace UITest1
{
    public class JupiterTestBase
    {
        protected static WindowsDriver<WindowsElement> Driver;
        protected static TestContext objTestContext;
        protected static Actions action;
        protected static WebDriverWait wait;
        protected static WindowsElement allParts;
        protected static WindowsElement toolBar;
        protected static WindowsElement jupiter;
        protected string pathDirectory = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\..\\..\\..\\..";
        protected static Logger logger = LogManager.GetCurrentClassLogger();

        public static void Setup(string path)
        {
            AppiumOptions appOptions = new AppiumOptions();
            Assert.IsNotNull(appOptions);
            appOptions.AddAdditionalCapability("app", path);
            logger.Info("Opened Jupiter");

            Driver = new WindowsDriver<WindowsElement>(
                new Uri("http://127.0.0.1:4723"),
                appOptions,
                TimeSpan.FromMinutes(5)
                );
            Assert.IsNotNull(Driver);
            Assert.IsNotNull(Driver.SessionId);
        }

        public static void TearDown()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
                logger.Info("Closed Jupiter");
            }
        }
    }
}
