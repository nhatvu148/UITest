using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Threading;

namespace UITest1
{
    class PreTestScenario3Boxes : JupiterTestBase
    {
        public static void TestScenario3Boxes(string pathDirectory)
        {
            action = new Actions(Driver);
            Assert.IsNotNull(action);

            var importCad = jupiter.FindElementByName("Import CAD");
            action.MoveToElement(importCad);
            action.MoveToElement(importCad, importCad.Size.Width / 2, importCad.Size.Height / 3 + 40).Click();
            action.Perform();

            Driver.FindElementByName("TechnoStar Geometry").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            Assert.IsNotNull(action);
            var open = jupiter.FindElementByName("Open");
            open.FindElementByAccessibilityId("1001").Click();
            //action.SendKeys($"\"{pathDirectory}\\TestResults\\JPT-Pre\\box\\box1.bdf\"\"{pathDirectory}\\TestResults\\JPT-Pre\\box\\box2.bdf\"\"{pathDirectory}\\TestResults\\JPT-Pre\\box\\box3.bdf\"");
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Pre\\TestScenario3Boxes\\box");
            action.SendKeys(Keys.Enter);
            action.Perform();

            open.FindElementByName("Items View").Click();

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.SendKeys(Keys.Control + "a" + Keys.Control);
            action.SendKeys(Keys.Enter);
            action.Perform();

            toolBar.FindElementByName("Assemble").Click();
            jupiter.FindElementByName("Assemble Faces").Click();

            Driver.FindElementByName("Assembly").Click();
            allParts = Driver.FindElementByName("All Parts");

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(allParts);
            action.ContextClick();
            action.SendKeys(Keys.Down);
            action.SendKeys(Keys.Enter);
            action.Build().Perform();

            var assembleFace = jupiter.FindElementByName("Assemble Face");
            assembleFace.FindElementByName("Find").Click();
            assembleFace.FindElementByName("OK").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.MoveToElement(assembleFace).Click();
            action.SendKeys(Keys.Escape);
            action.Perform();

            jupiter.FindElementByName("Shared Faces").Click();
            var sharedFaces = jupiter.FindElementByName("Shared Faces");
            sharedFaces.FindElementByName("Apply").Click();

            jupiter.FindElementByXPath("/Window/Pane[4]/Window/Pane/Pane[4]/Button[14]").Click();

            var meshing = toolBar.FindElementByName("Meshing");
            meshing.Click();
            var localSettingIcon = Driver.FindElementByName("Local Settings");
            action = new Actions(Driver);
            action.MoveToElement(localSettingIcon, localSettingIcon.Size.Width / 4,
            localSettingIcon.Size.Height / 2).Click().Perform();
            Driver.FindElementByName("Part").Click();

            var localSettingsParts = jupiter.FindElementByName("Local Settings Parts");
            var meshSizeCB = localSettingsParts.FindElementByAccessibilityId("1005");
            if (!meshSizeCB.Selected) meshSizeCB.Click();

            var part1 = allParts.FindElementByName("Part_1");
            part1.Click();
            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(part1);
            action.ContextClick();
            action.SendKeys(Keys.Down);
            action.SendKeys(Keys.Enter);
            action.Build().Perform();

            localSettingsParts.FindElementByAccessibilityId("1006").Clear();
            Assert.IsFalse(localSettingsParts.FindElementByName("Apply").Enabled);
            Assert.IsFalse(localSettingsParts.FindElementByName("OK").Enabled);
            localSettingsParts.FindElementByAccessibilityId("1006").SendKeys("3");
            localSettingsParts.FindElementByAccessibilityId("1007").Clear();
            Assert.IsFalse(localSettingsParts.FindElementByName("Apply").Enabled);
            Assert.IsFalse(localSettingsParts.FindElementByName("OK").Enabled);
            localSettingsParts.FindElementByAccessibilityId("1007").SendKeys("1");
            localSettingsParts.FindElementByAccessibilityId("1008").Clear();
            Assert.IsFalse(localSettingsParts.FindElementByName("Apply").Enabled);
            Assert.IsFalse(localSettingsParts.FindElementByName("OK").Enabled);
            localSettingsParts.FindElementByAccessibilityId("1008").SendKeys("10");
            localSettingsParts.FindElementByName("Apply").Click();

            var part3 = allParts.FindElementByName("Part_3");
            part3.Click();
            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(part3);
            action.ContextClick();
            action.SendKeys(Keys.Down);
            action.SendKeys(Keys.Enter);
            action.Build().Perform();

            localSettingsParts.FindElementByAccessibilityId("1006").Clear();
            Assert.IsFalse(localSettingsParts.FindElementByName("Apply").Enabled);
            Assert.IsFalse(localSettingsParts.FindElementByName("OK").Enabled);
            localSettingsParts.FindElementByAccessibilityId("1006").SendKeys("5");
            localSettingsParts.FindElementByAccessibilityId("1007").Clear();
            Assert.IsFalse(localSettingsParts.FindElementByName("Apply").Enabled);
            Assert.IsFalse(localSettingsParts.FindElementByName("OK").Enabled);
            localSettingsParts.FindElementByAccessibilityId("1007").SendKeys("1");
            localSettingsParts.FindElementByAccessibilityId("1008").Clear();
            Assert.IsFalse(localSettingsParts.FindElementByName("Apply").Enabled);
            Assert.IsFalse(localSettingsParts.FindElementByName("OK").Enabled);
            localSettingsParts.FindElementByAccessibilityId("1008").SendKeys("10");
            localSettingsParts.FindElementByName("OK").Click();

            Driver.FindElementByName("Surface Meshing").Click();

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(allParts);
            action.ContextClick();
            action.SendKeys(Keys.Down);
            action.SendKeys(Keys.Enter);
            action.Build().Perform();

            var meshSurf = jupiter.FindElementByName("Meshing Surf Meshing");
            meshSurf.FindElementByAccessibilityId("1001").Clear();
            Assert.IsFalse(meshSurf.FindElementByName("Apply").Enabled);
            Assert.IsFalse(meshSurf.FindElementByName("OK").Enabled);
            meshSurf.FindElementByAccessibilityId("1001").SendKeys("4");
            meshSurf.FindElementByAccessibilityId("1002").Clear();
            Assert.IsFalse(meshSurf.FindElementByName("Apply").Enabled);
            Assert.IsFalse(meshSurf.FindElementByName("OK").Enabled);
            meshSurf.FindElementByAccessibilityId("1002").SendKeys("1");
            meshSurf.FindElementByAccessibilityId("1003").Clear();
            Assert.IsFalse(meshSurf.FindElementByName("Apply").Enabled);
            Assert.IsFalse(meshSurf.FindElementByName("OK").Enabled);
            meshSurf.FindElementByAccessibilityId("1003").SendKeys("12");
            meshSurf.FindElementByAccessibilityId("1004").Clear();
            Assert.IsFalse(meshSurf.FindElementByName("Apply").Enabled);
            Assert.IsFalse(meshSurf.FindElementByName("OK").Enabled);
            meshSurf.FindElementByAccessibilityId("1004").SendKeys("1");
            meshSurf.FindElementByName("OK").Click();

            Thread.Sleep(5000);
            action = new Actions(Driver);
            action.MoveToElement(meshSurf).Click();
            action.SendKeys(Keys.Escape);
            action.Perform();

            var meshCleanup = toolBar.FindElementByName("Mesh Cleanup");
            meshCleanup.Click();
            var freeEdgesIcon = Driver.FindElementByName("Free Edges");
            action = new Actions(Driver);
            action.MoveToElement(freeEdgesIcon).Click().Perform();

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(allParts);
            action.ContextClick();
            action.SendKeys(Keys.Down);
            action.SendKeys(Keys.Enter);
            action.Build().Perform();

            var meshQualityFreeEdges = jupiter.FindElementByName("Mesh Quality | Free Edges");
            var freeEdges = meshQualityFreeEdges.FindElementByAccessibilityId("1007");
            if (!freeEdges.Selected) freeEdges.Click();
            var nonManifold = meshQualityFreeEdges.FindElementByAccessibilityId("1008");
            if (nonManifold.Selected) nonManifold.Click();
            meshQualityFreeEdges.FindElementByName("Apply").Click();
            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.MoveToElement(meshQualityFreeEdges).Click();
            action.SendKeys(Keys.Escape);
            action.Perform();
            Assert.AreEqual("0", meshQualityFreeEdges.FindElementByAccessibilityId("1001").Text);


            var intersectionsIcon = Driver.FindElementByName("Intersections");
            action = new Actions(Driver);
            action.MoveToElement(intersectionsIcon).Click().Perform();

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(allParts);
            action.ContextClick();
            action.SendKeys(Keys.Down);
            action.SendKeys(Keys.Enter);
            action.Build().Perform();

            var meshQualityIntersectionsIcon = jupiter.FindElementByName("Mesh Quality | Intersections");
            meshQualityIntersectionsIcon.FindElementByName("Apply").Click();
            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.MoveToElement(meshQualityIntersectionsIcon).Click();
            action.SendKeys(Keys.Escape);
            action.Perform();
            Assert.AreEqual("0", meshQualityIntersectionsIcon.FindElementByAccessibilityId("1002").Text);

            meshing.Click();
            Driver.FindElementByName("Solid Meshing").Click();

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(allParts);
            action.ContextClick();
            action.SendKeys(Keys.Down);
            action.SendKeys(Keys.Enter);
            action.Build().Perform();

            var meshSolid = jupiter.FindElementByName("Meshing Solid Meshing");
            meshSolid.FindElementByName("OK").Click();

            Thread.Sleep(5000);
            action = new Actions(Driver);
            action.MoveToElement(meshSolid).Click();
            action.SendKeys(Keys.Escape);
            action.Perform();

            var meshEdit = toolBar.FindElementByName("Mesh Edit");
            meshEdit.Click();
            var deleteNodeIcon = Driver.FindElementByName("Delete Node");
            action = new Actions(Driver);
            action.MoveToElement(deleteNodeIcon).Click().Perform();

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(allParts);
            action.ContextClick();
            action.SendKeys(Keys.Down);
            action.SendKeys(Keys.Enter);
            action.Build().Perform();

            jupiter.FindElementByName("Delete Floating Node").FindElementByName("OK").Click();


            toolBar.FindElementByName("Assemble").Click();
            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(allParts);
            action.ContextClick();
            action.SendKeys(Keys.Down);
            action.SendKeys(Keys.Enter);
            action.Build().Perform();

            jupiter.FindElementByName("Shared Faces").Click();
            sharedFaces = jupiter.FindElementByName("Shared Faces");
            sharedFaces.FindElementByName("Apply").Click();

            jupiter.FindElementByName("Separate Faces").Click();
            Driver.FindElementByName("Solid").Click();
            var separateFaceSolid = jupiter.FindElementByName("Separate Face [Solid]");

            try
            {
                separateFaceSolid.FindElementByName(">").Click();
            }
            catch
            {
                logger.Info("Selection List Already Opened");
            }

            separateFaceSolid.FindElementByName("Face").Click();

            var mainWindow = jupiter.FindElementByAccessibilityId("59648");

            action = new Actions(Driver);
            action.MoveToElement(mainWindow, 0, 0).MoveByOffset(1200, 500).ClickAndHold();
            action.MoveByOffset(-2000, -1000);
            action.Release().Perform();

            Thread.Sleep(1000);
            separateFaceSolid.FindElementByName("Apply").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.MoveToElement(separateFaceSolid).Click();
            action.SendKeys(Keys.Escape);
            action.Perform();

            jupiter.FindElementByXPath("/Window/Pane[4]/Window/Pane/Pane[4]/Button[14]").Click();


            var connections = toolBar.FindElementByName("Connections");
            connections.Click();
            var mpcIcon = Driver.FindElementByName("MPC");
            action = new Actions(Driver);
            action.MoveToElement(mpcIcon).Click().Perform();
            Driver.FindElementByName("Faces-Faces").Click();

            var mpcGeneralFacetoFace = jupiter.FindElementByName("MPC General | Faces-Faces");

            try
            {
                mpcGeneralFacetoFace.FindElementByName(">").Click();
            }
            catch
            {
                logger.Info("Selection List Already Opened");
            }

            mpcGeneralFacetoFace.FindElementByName("Master").Click();

            toolBar.FindElementByName("Home").Click();
            var find = Driver.FindElementByName("Find");
            Assert.IsNotNull(find);
            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(find);
            action.MoveToElement(find, find.Size.Width / 2, find.Size.Height / 3 + 20).Click();
            action.SendKeys(Keys.Down);
            action.SendKeys(Keys.Enter);
            action.Perform();

            WindowsElement idBox = Driver.FindElementByAccessibilityId("1582");
            Assert.IsNotNull(idBox);
            InputId(894, idBox, action, Driver, find);

            mpcGeneralFacetoFace.FindElementByName("Slave").Click();
            InputId(827, idBox, action, Driver, find);
            mpcGeneralFacetoFace.FindElementByName("Apply").Click();

            mpcGeneralFacetoFace.FindElementByName("Master").Click();
            InputId(907, idBox, action, Driver, find);

            mpcGeneralFacetoFace.FindElementByName("Slave").Click();
            InputId(746, idBox, action, Driver, find);
            mpcGeneralFacetoFace.FindElementByName("Apply").Click();

            connections.Click();
            var contactsIcon = Driver.FindElementByName("Contacts");
            action = new Actions(Driver);
            action.MoveToElement(contactsIcon).Click().Perform();
            Driver.FindElementByName("TS SS").Click();

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.SendKeys(Keys.Down);
            action.SendKeys(Keys.Down);
            action.SendKeys(Keys.Enter);
            action.Perform();

            var contactManualFaceTSSS = jupiter.FindElementByName("Contact Manual Face TS SS");

            try
            {
                contactManualFaceTSSS.FindElementByName(">").Click();
            }
            catch
            {
                logger.Info("Selection List Already Opened");
            }

            contactManualFaceTSSS.FindElementByAccessibilityId("1004").Click();

            contactManualFaceTSSS.FindElementByName("Master").Click();
            toolBar.FindElementByName("Home").Click();
            find = Driver.FindElementByName("Find");
            Assert.IsNotNull(find);

            idBox = Driver.FindElementByAccessibilityId("1582");
            Assert.IsNotNull(idBox);
            InputId(894, idBox, action, Driver, find);

            contactManualFaceTSSS.FindElementByName("Slave").Click();
            InputId(827, idBox, action, Driver, find);
            contactManualFaceTSSS.FindElementByName("Apply").Click();

            contactManualFaceTSSS.FindElementByName("Master").Click();
            InputId(907, idBox, action, Driver, find);

            contactManualFaceTSSS.FindElementByName("Slave").Click();
            InputId(746, idBox, action, Driver, find);
            contactManualFaceTSSS.FindElementByName("Apply").Click();


            toolBar.FindElementByName("Boundary Conditions").Click();
            var pressure = Driver.FindElementByName("Pressure");
            Assert.IsNotNull(find);
            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(pressure);
            action.MoveToElement(pressure, find.Size.Width / 3, find.Size.Height / 3 + 20).Click();
            action.SendKeys(Keys.Down);
            action.SendKeys(Keys.Enter);
            action.Perform();

            var pressureGeneral = jupiter.FindElementByName("Pressure | General");
            try
            {
                pressureGeneral.FindElementByName(">").Click();
            }
            catch
            {
                logger.Info("Selection List Already Opened");
            }
            pressureGeneral.FindElementByName("Face").Click();

            toolBar.FindElementByName("Home").Click();
            find = Driver.FindElementByName("Find");
            Assert.IsNotNull(find);

            idBox = Driver.FindElementByAccessibilityId("1582");
            Assert.IsNotNull(idBox);
            InputId(11, idBox, action, Driver, find);


            pressureGeneral.FindElementByAccessibilityId("1002").Clear();
            Assert.IsTrue(pressureGeneral.FindElementByName("Apply").Enabled);
            Assert.IsTrue(pressureGeneral.FindElementByName("OK").Enabled);
            pressureGeneral.FindElementByAccessibilityId("1002").SendKeys("100");
            pressureGeneral.FindElementByName("Apply").Click();


            toolBar.FindElementByName("Boundary Conditions").Click();
            Driver.FindElementByName("Fixed Constraints").Click();

            var fixedConstraints = jupiter.FindElementByName("Fixed Constraints");
            try
            {
                fixedConstraints.FindElementByName(">").Click();
            }
            catch
            {
                logger.Info("Selection List Already Opened");
            }


            var tranX = fixedConstraints.FindElementByAccessibilityId("1011");
            if (!tranX.Selected) tranX.Click();
            var tranY = fixedConstraints.FindElementByAccessibilityId("1012");
            if (!tranY.Selected) tranY.Click();
            var tranZ = fixedConstraints.FindElementByAccessibilityId("1013");
            if (!tranZ.Selected) tranZ.Click();
            var rotX = fixedConstraints.FindElementByAccessibilityId("1014");
            if (rotX.Selected) rotX.Click();
            var rotY = fixedConstraints.FindElementByAccessibilityId("1015");
            if (rotY.Selected) rotY.Click();
            var rotZ = fixedConstraints.FindElementByAccessibilityId("1016");
            if (rotZ.Selected) rotZ.Click();
            fixedConstraints.FindElementByName("Face").Click();

            toolBar.FindElementByName("Home").Click();
            find = Driver.FindElementByName("Find");
            Assert.IsNotNull(find);

            idBox = Driver.FindElementByAccessibilityId("1582");
            Assert.IsNotNull(idBox);
            InputId(763, idBox, action, Driver, find);

            fixedConstraints.FindElementByName("Apply").Click();


            toolBar.FindElementByName("Properties").Click();
            Driver.FindElementByName("Material").Click();

            var material = jupiter.FindElementByName("Material");
            material.FindElementByName("Open Library").Click();
            System.Threading.Thread.Sleep(1000);
            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.SendKeys(@"C:\Program Files\TechnoStar\Jupiter-Pre_5.0\DataBase\JPTD_Materials.mlib");
            action.SendKeys(Keys.Enter);
            action.Perform();

            var aluminum = material.FindElementByName("Structural_Steel");
            aluminum.Click();
            action = new Actions(Driver);
            action.MoveToElement(aluminum, 0, 0).MoveByOffset(5, 5).ClickAndHold();
            action.MoveByOffset(0, -400);
            action.Release().Perform();

            material.FindElementByName("OK").Click();

            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.MoveToElement(allParts);
            action.ContextClick();
            action.SendKeys(Keys.Down);
            action.SendKeys(Keys.Enter);
            action.Build().Perform();

            Driver.FindElementByName("Solid").Click();
            jupiter.FindElementByName("3D Property Solid").FindElementByName("OK").Click();


            toolBar.FindElementByName("Analysis").Click();
            Driver.FindElementByName("TS-SunShine").Click();
            Driver.FindElementByName("Linear Static(SOL 101)").Click();

            var tsSolver = jupiter.FindElementByName("TS-SS - Linear Static (101)");

            tsSolver.FindElementByName("Ok").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            Assert.IsNotNull(action);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Pre\\TestScenario3Boxes\\Actual\\BoxTest");
            action.SendKeys(Keys.Enter);
            action.Perform();

            Thread.Sleep(1000);
            try
            {
                tsSolver.FindElementByName("Yes").Click();
            }
            catch
            {
                logger.Warn("Confirm Dialog Not Appeared");
            }

            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.MoveToElement(tsSolver).Click();
            action.SendKeys(Keys.Escape);
            action.Perform();

            // Output BDF Compare
            string boxTestActual = File.ReadAllText($"{pathDirectory}\\TestResults\\JPT-Pre\\TestScenario3Boxes\\Actual\\BoxTest.bdf");
            string boxTestExpected = File.ReadAllText($"{pathDirectory}\\TestResults\\JPT-Pre\\TestScenario3Boxes\\Expected\\BoxTest.bdf");

            try
            {
                Assert.AreEqual(boxTestExpected, boxTestActual);
            }
            catch
            {
                logger.Error("Assert.AreEqual failed - Output BDF \"BoxTest.bdf\" Not Identical");
            }

            Driver.FindElementByXPath("//Button[@Name='Application menu']").Click();
            Driver.FindElementByName("Save As...").Click();

            Thread.Sleep(1000);
            action = new Actions(Driver);
            action.SendKeys($"{pathDirectory}\\TestResults\\JPT-Pre\\TestScenario3Boxes\\BoxTest.jtdb");
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

        public static void InputId(int faceId, WindowsElement idBox, Actions action,
                           WindowsDriver<WindowsElement> sessionJpt, WindowsElement find)
        {
            idBox.SendKeys(Keys.Control + "a" + Keys.Control);
            idBox.SendKeys(Convert.ToString(faceId));
            action = new Actions(sessionJpt);
            action.MoveToElement(find);
            action.MoveToElement(find, find.Size.Width / 2 - 30, find.Size.Height / 3 - 4).Click().Perform();
        }

        public static void InputId(string faceId, WindowsElement idBox, Actions action,
                            WindowsDriver<WindowsElement> sessionJpt, WindowsElement find)
        {
            idBox.SendKeys(Keys.Control + "a" + Keys.Control);
            idBox.SendKeys(faceId);
            action = new Actions(sessionJpt);
            action.MoveToElement(find);
            action.MoveToElement(find, find.Size.Width / 2 - 30, find.Size.Height / 3 - 4).Click().Perform();
        }
    }
}
