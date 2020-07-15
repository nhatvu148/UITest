using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace UITest1
{
    class PostTestScenario3Boxes : JupiterTestBase
    {
        public static void TestScenario3Boxes(string pathDirectory)
        {
            jupiter.FindElementByName("Import Results").Click();

            Driver.FindElementByName("Nastran Op2").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Pre\\TestScenario3Boxes\\BoxTest.op2");
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

            jupiter.FindElementByName("To Image").Click();
            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"\"{pathDirectory}\\TestResults\\JPT-Pre\\TestScenario3Boxes\\BoxTest.jpg\"");
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

            Driver.FindElementByXPath("//Button[@Name='Application menu']").Click();
            Driver.FindElementByName("Save As...").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Pre\\TestScenario3Boxes\\BoxTest.tsdb");
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
