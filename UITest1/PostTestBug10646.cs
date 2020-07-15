using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Threading;

namespace UITest1
{
    class PostTestBug10646 : JupiterTestBase
    {
        public static void TestBug10646(string pathDirectory)
        // FFT: Export file without OA.
        {
            Driver.FindElementByName("Preferences").Click();

            var preferences = jupiter.FindElementByName("Preferences");
            preferences.FindElementByName("Mouse").Click();
            try
            {
                preferences.FindElementByName("MyPreset1").Click();
            }
            catch
            {

                preferences.FindElementByName("New").Click();
                preferences.FindElementByName("MyPreset1").Click();
                logger.Info("MyPreset1 Created");
            }

            var rotateLBtn = preferences.FindElementsByName("LButton")[0];
            if (!rotateLBtn.Selected) rotateLBtn.Click();

            preferences.FindElementsByName("Reset")[0].Click();
            preferences.FindElementByAccessibilityId("35037").Click();
            action = new Actions(Driver);
            action.SendKeys(Keys.Shift);
            action.Perform();

            var panRBtn = preferences.FindElementsByName("RButton")[1];
            if (!panRBtn.Selected) panRBtn.Click();

            var zoomShiftLBtn = preferences.FindElementsByName("LButton")[2];
            if (!zoomShiftLBtn.Selected) zoomShiftLBtn.Click();

            preferences.FindElementsByName("Reset")[2].Click();
            preferences.FindElementByAccessibilityId("35024").Click();
            action = new Actions(Driver);
            action.SendKeys(Keys.Shift);
            action.SendKeys(Keys.Shift);
            action.Perform();

            preferences.FindElementByName("OK").Click();

            action = new Actions(Driver);
            action.KeyUp(Keys.Shift).Perform();

            jupiter.FindElementByName("Import Results").Click();

            Driver.FindElementByName("Nastran Op2").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10646\\cylinder.op2");
            action.SendKeys(Keys.Enter);
            action.Perform();

            Thread.Sleep(1000);
            var assembly = Driver.FindElementByName("Assembly");
            var analysisCollection = assembly.FindElementByName("Analysis collection");
            Assert.IsNotNull(analysisCollection);

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(analysisCollection, 0, 0).MoveByOffset(-30, 5).Click().Perform();

            var displacement = analysisCollection.FindElementByName("Displacement");

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(displacement, 0, 0).MoveByOffset(-30, 5).Click().Perform();

            var translational = displacement.FindElementByName("Translational");

            action = new Actions(Driver);
            action.DoubleClick(translational).Perform();

            assembly.FindElementByName("Tools").Click();

            toolBar.FindElementByName("Appearance").Click();
            jupiter.FindElementByName("Result Display").Click();
            jupiter.FindElementByName("Show Deform").Click();


            var mainWindow = jupiter.FindElementByAccessibilityId("59648");
            mainWindow.Click();

            action = new Actions(Driver);
            action.SendKeys("f").Perform();

            action = new Actions(Driver);
            action.KeyDown(Keys.Shift);
            action.MoveToElement(mainWindow).ClickAndHold();
            action.MoveByOffset(6, -2);
            action.Release().Perform();

            action = new Actions(Driver);
            action.KeyUp(Keys.Shift).Perform();

            toolBar.FindElementByName("Home").Click();
            Driver.FindElementByName("Preferences").Click();
            preferences = jupiter.FindElementByName("Preferences");
            preferences.FindElementByName("Mouse").Click();
            preferences.FindElementByName("TSV-Pre").Click();
            preferences.FindElementByName("OK").Click();

            toolBar.FindElementByName("Tools").Click();
            jupiter.FindElementByName("Analysis").Click();
            jupiter.FindElementByName("FFT Analysis").Click();

            var fftCondition = jupiter.FindElementByName("FFT Analysis").FindElementByName("FFT Condition");

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(fftCondition);
            action.ContextClick();
            action.SendKeys(Keys.Down);
            action.SendKeys(Keys.Enter);
            action.Build().Perform();

            var fftBore = jupiter.FindElementByName("Set FFT Bore Parameter");
            fftBore.FindElementByName("Edge Angle Setting").Click();
            Thread.Sleep(1000);
            var angleSurfaceEdge = fftBore.FindElementByName("Angle for Surface Edge");
            var angle = angleSurfaceEdge.FindElementByAccessibilityId("5382");
            angle.Clear();
            angle.SendKeys("30");
            angleSurfaceEdge.FindElementByName("OK").Click();

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(jupiter, 0, 0).MoveByOffset(1247, 375).Click().Perform();

            fftBore.FindElementByName("Pick Bore Top/Bottom").Click();

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(jupiter, 0, 0).MoveByOffset(1290, 286).Click();
            action.MoveToElement(jupiter, 0, 0).MoveByOffset(1162, 388).Click().Perform();

            fftBore.FindElementByName("OK").Click();

            fftCondition = jupiter.FindElementByName("FFT Analysis").FindElementByName("FFT Condition");
            var bore1 = fftCondition.FindElementByName("BORE1");

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(bore1);
            action.ContextClick();
            action.SendKeys(Keys.Down);
            action.SendKeys(Keys.Enter);
            action.Build().Perform();

            var fftParam = jupiter.FindElementByName("FFT Parameter Setting");
            var fftExport = fftParam.FindElementByAccessibilityId("5378");
            if (!fftExport.Selected) fftExport.Click();

            var exportAllFile = fftParam.FindElementByAccessibilityId("2246");
            if (!exportAllFile.Selected) exportAllFile.Click();

            var originalShift = fftParam.FindElementByAccessibilityId("2243");
            if (!originalShift.Selected) originalShift.Click();


            fftParam.FindElementByName("Path Setting").Click();
            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10646\\Actual\\without_oa");
            action.SendKeys(Keys.Enter);
            action.Perform();
            try
            {
                jupiter.FindElementByName("Yes").Click();
            }
            catch
            {
                logger.Warn("Confirm Dialog Not Appeared");
            }
            fftParam.FindElementByName("OK").Click();

            action = new Actions(Driver);
            action.SendKeys(Keys.Control + Keys.Tab + Keys.Control);
            action.Perform();

            fftCondition = jupiter.FindElementByName("FFT Analysis").FindElementByName("FFT Condition");

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(fftCondition);
            action.ContextClick();
            action.SendKeys(Keys.Down);
            action.SendKeys(Keys.Enter);
            action.Build().Perform();

            fftBore = jupiter.FindElementByName("Set FFT Bore Parameter");
            fftBore.FindElementByName("Edge Angle Setting").Click();
            Thread.Sleep(1000);
            angleSurfaceEdge = fftBore.FindElementByName("Angle for Surface Edge");
            angle = angleSurfaceEdge.FindElementByAccessibilityId("5382");
            angle.Clear();
            angle.SendKeys("30");
            angleSurfaceEdge.FindElementByName("OK").Click();

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(jupiter, 0, 0).MoveByOffset(1247, 375).Click().Perform();

            fftBore.FindElementByName("Pick Bore Top/Bottom").Click();

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(jupiter, 0, 0).MoveByOffset(1290, 286).Click();
            action.MoveToElement(jupiter, 0, 0).MoveByOffset(1162, 388).Click().Perform();

            fftBore.FindElementByName("OK").Click();

            fftCondition = jupiter.FindElementByName("FFT Analysis").FindElementByName("FFT Condition");
            var bore2 = fftCondition.FindElementByName("BORE2");

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(bore2);
            action.ContextClick();
            action.SendKeys(Keys.Down);
            action.SendKeys(Keys.Enter);
            action.Build().Perform();

            fftParam = jupiter.FindElementByName("FFT Parameter Setting");
            var defineOAPlot = fftParam.FindElementByAccessibilityId("1930");
            if (!defineOAPlot.Selected) defineOAPlot.Click();

            fftExport = fftParam.FindElementByAccessibilityId("5378");
            if (!fftExport.Selected) fftExport.Click();

            exportAllFile = fftParam.FindElementByAccessibilityId("2246");
            if (!exportAllFile.Selected) exportAllFile.Click();

            originalShift = fftParam.FindElementByAccessibilityId("2243");
            if (!originalShift.Selected) originalShift.Click();


            fftParam.FindElementByName("Path Setting").Click();
            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10646\\Actual\\with_oa");
            action.SendKeys(Keys.Enter);
            action.Perform();
            try
            {
                jupiter.FindElementByName("Yes").Click();
            }
            catch
            {
                logger.Warn("Confirm Dialog Not Appeared");
            }
            fftParam.FindElementByName("OK").Click();

            // Output CSV 1 Compare
            string without_oa_actual = File.ReadAllText($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10646\\Actual\\without_oa.csv");
            string without_oa_expected = File.ReadAllText($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10646\\Expected\\without_oa.csv");

            try
            {
                Assert.AreEqual(without_oa_expected, without_oa_actual);
            }
            catch
            {
                logger.Error("Assert.AreEqual failed - Output CSV \"without_oa.csv\" Not Identical");
            }

            // Output CSV 2 Compare
            string without_oa_DC_actual = File.ReadAllText($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10646\\Actual\\without_oa_DC.csv");
            string without_oa_DC_expected = File.ReadAllText($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10646\\Expected\\without_oa_DC.csv");

            try
            {
                Assert.AreEqual(without_oa_DC_expected, without_oa_DC_actual);
            }
            catch
            {
                logger.Error("Assert.AreEqual failed - Output CSV \"without_oa_DC.csv\" Not Identical");
            }

            // Output CSV 3 Compare
            string without_oa_RC_actual = File.ReadAllText($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10646\\Actual\\without_oa_RC.csv");
            string without_oa_RC_expected = File.ReadAllText($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10646\\Expected\\without_oa_RC.csv");

            try
            {
                Assert.AreEqual(without_oa_RC_expected, without_oa_RC_actual);
            }
            catch
            {
                logger.Error("Assert.AreEqual failed - Output CSV \"without_oa_RC.csv\" Not Identical");
            }

            // Output CSV 4 Compare
            string with_oa_actual = File.ReadAllText($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10646\\Actual\\with_oa.csv");
            string with_oa_expected = File.ReadAllText($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10646\\Expected\\with_oa.csv");

            try
            {
                Assert.AreEqual(with_oa_expected, with_oa_actual);
            }
            catch
            {
                logger.Error("Assert.AreEqual failed - Output CSV \"with_oa.csv\" Not Identical");
            }

            // Output CSV 5 Compare
            string with_oa_DC_actual = File.ReadAllText($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10646\\Actual\\with_oa_DC.csv");
            string with_oa_DC_expected = File.ReadAllText($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10646\\Expected\\with_oa_DC.csv");

            try
            {
                Assert.AreEqual(with_oa_DC_expected, with_oa_DC_actual);
            }
            catch
            {
                logger.Error("Assert.AreEqual failed - Output CSV \"with_oa_DC.csv\" Not Identical");
            }

            // Output CSV 6 Compare
            string with_oa_RC_actual = File.ReadAllText($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10646\\Actual\\with_oa_RC.csv");
            string with_oa_RC_expected = File.ReadAllText($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10646\\Expected\\with_oa_RC.csv");

            try
            {
                Assert.AreEqual(with_oa_RC_expected, with_oa_RC_actual);
            }
            catch
            {
                logger.Error("Assert.AreEqual failed - Output CSV \"with_oa_RC.csv\" Not Identical");
            }


            Driver.FindElementByXPath("//Button[@Name='Application menu']").Click();
            Driver.FindElementByName("Save As...").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Post\\TestBug10646\\cylinder.tsdb");
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
