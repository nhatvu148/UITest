using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace UITest1
{
    class SolverTestScenario3Boxes : JupiterTestBase
    {
        public static void TestScenario3Boxes(string pathDirectory)
        {
            Thread.Sleep(1000);
  
            var desktop1 = Driver.FindElementByName("Desktop 1");
            desktop1.FindElementByName("Taskbar").FindElementByName("Start").Click();

            action = new Actions(Driver);
            action.SendKeys("run");
            action.SendKeys(Keys.Enter);
            action.Perform();


            action = new Actions(Driver);
            action.SendKeys(@"C:\Program Files\TechnoStar\SunShine_2.3.0\wizard.bat");
            action.SendKeys(Keys.Enter);
            action.Perform();

            Thread.Sleep(2000);

            action = new Actions(Driver);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Pre\\TestScenario3Boxes\\Actual\\BoxTest.bdf");
            action.SendKeys(Keys.Enter);
            action.Perform();

            Thread.Sleep(1000);
            Driver.FindElementByName("Browse For Folder").FindElementByName("OK").Click();


            Thread.Sleep(60000);

            action = new Actions(Driver);
            action.SendKeys(Keys.Enter);
            action.Perform();
        }
    }
}
