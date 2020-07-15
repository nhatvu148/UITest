using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace UITest1
{
    class PostTestBug10763 : JupiterTestBase
    {
        public static void TestBug10763()
        // Preference: "Use wheel for zoom" is not kept
        {
            Driver.FindElementByName("Preferences").Click();

            var preferences = jupiter.FindElementByName("Preferences");
            preferences.FindElementByName("Mouse").Click();
            preferences.FindElementByName("MyPreset1").Click();
            var useWheel = preferences.FindElementByAccessibilityId("2037");

            if (!useWheel.Selected)
            {
                useWheel.Click();
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

            Driver.FindElementByName("Preferences").Click();

            preferences = jupiter.FindElementByName("Preferences");
            preferences.FindElementByName("Mouse").Click();
            preferences.FindElementByName("MyPreset1").Click();
            useWheel = preferences.FindElementByAccessibilityId("2037");
            Assert.IsTrue(useWheel.Selected);
            Thread.Sleep(2000);
        }
    }
}
