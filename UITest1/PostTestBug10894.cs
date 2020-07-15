using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace UITest1
{
    class PostTestBug10894 : JupiterTestBase
    {
        public static void TestBug10894(string pathDirectory)
        // [ADVC] Component Name Error.
        {
            Driver.FindElementByName("Preferences").Click();

            var preferences = jupiter.FindElementByName("Preferences");
            preferences.FindElementByName("Mouse").Click();
            preferences.FindElementByName("TSV-Pre").Click();
            preferences.FindElementByName("OK").Click();

            jupiter.FindElementByName("Import Results").Click();

            Driver.FindElementByName("ADVENTURECluster2.0").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10894\\eqmech_inelas_f2");
            action.SendKeys(Keys.Enter);
            action.Perform();

            jupiter.FindElementByName("Please select folder").FindElementByName("Select Folder").Click();

            Thread.Sleep(1000);
            var assembly = Driver.FindElementByName("Assembly");
            var analysis = assembly.FindElementByName("Analysis");

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(analysis, 0, 0).MoveByOffset(-30, 5).Click().Perform();

            var step0 = analysis.FindElementByName("Process= 0").FindElementByName("Step= 0, Time=1.00000e+00");

            var NodalEquivalentInElasticStrain = step0.FindElementByName("NodalEquivalentInElasticStrain");

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(NodalEquivalentInElasticStrain, 0, 0).MoveByOffset(-30, 5).Click().Perform();

            var NodalEquivalentInElasticStrain_son = NodalEquivalentInElasticStrain.FindElementByName("NodalEquivalentInElasticStrain");
            Assert.AreEqual("NodalEquivalentInElasticStrain", NodalEquivalentInElasticStrain.GetAttribute("Name"));
            Assert.AreEqual("NodalEquivalentInElasticStrain", NodalEquivalentInElasticStrain_son.GetAttribute("Name"));

            var NodalEquivalentInElasticStrainNI = step0.FindElementByName("NodalEquivalentInElasticStrainNI");

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(NodalEquivalentInElasticStrainNI, 0, 0).MoveByOffset(-30, 5).Click().Perform();

            var NodalEquivalentInElasticStrainNI_son = NodalEquivalentInElasticStrainNI.FindElementByName("NodalEquivalentInElasticStrainNI");
            Assert.AreEqual("NodalEquivalentInElasticStrainNI", NodalEquivalentInElasticStrainNI.GetAttribute("Name"));
            Assert.AreEqual("NodalEquivalentInElasticStrainNI", NodalEquivalentInElasticStrainNI_son.GetAttribute("Name"));


            var NodalEquivalentMechanicalStrain = step0.FindElementByName("NodalEquivalentMechanicalStrain");

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(NodalEquivalentMechanicalStrain, 0, 0).MoveByOffset(-30, 5).Click().Perform();

            var NodalEquivalentMechanicalStrain_son = NodalEquivalentMechanicalStrain.FindElementByName("NodalEquivalentMechanicalStrain");
            Assert.AreEqual("NodalEquivalentMechanicalStrain", NodalEquivalentMechanicalStrain.GetAttribute("Name"));
            Assert.AreEqual("NodalEquivalentMechanicalStrain", NodalEquivalentMechanicalStrain_son.GetAttribute("Name"));


            var NodalEquivalentMechanicalStrainNI = step0.FindElementByName("NodalEquivalentMechanicalStrainNI");

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(NodalEquivalentMechanicalStrainNI, 0, 0).MoveByOffset(-30, 5).Click().Perform();

            var NodalEquivalentMechanicalStrainNI_son = NodalEquivalentMechanicalStrainNI.FindElementByName("NodalEquivalentMechanicalStrainNI");
            Assert.AreEqual("NodalEquivalentMechanicalStrainNI", NodalEquivalentMechanicalStrainNI.GetAttribute("Name"));
            Assert.AreEqual("NodalEquivalentMechanicalStrainNI", NodalEquivalentMechanicalStrainNI_son.GetAttribute("Name"));


            Driver.FindElementByXPath("//Button[@Name='Application menu']").Click();
            Driver.FindElementByName("Save As...").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10894\\eqmech_inelas_f2.tsdb");
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
