using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace Appium_NotePad_Automation
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NotePad_Automation()
        {
            System.Diagnostics.Process.Start
               (@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");

            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("app", @"C:\Windows\notepad.exe");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            var driver = new WindowsDriver<WindowsElement>
                (new Uri("http://127.0.0.1:4723"), options);

            driver.FindElementByName("Help").Click();
            driver.FindElementByName("About Notepad").Click();
            Assert.AreEqual("Version 21H2 (OS Build 19044.2846)", driver.FindElementByAccessibilityId("13579").Text);
            driver.FindElementByName("OK").Click();

            driver.FindElementByClassName("Edit").SendKeys(DateTime.Now.ToString());
            driver.FindElementByClassName("Edit").Clear();

            driver.FindElementByName("Edit").Click();
            driver.FindElementByAccessibilityId("26").Click();
            Assert.IsNotNull(driver.FindElementByClassName("Edit"));
            driver.FindElementByClassName("Edit").Clear();

            string data = DateTime.Now.ToString() + " Amir Imam";

            driver.FindElementByClassName("Edit").SendKeys(data);
            driver.FindElementByName("File").Click();
            driver.FindElementByAccessibilityId("3").Click();
            Thread.Sleep(1000);

            driver.FindElementByAccessibilityId("FileNameControlHost").SendKeys("C:\\" + DateTime.Now.ToString("yyyymmdd hmmtt") + "_AmirImam.txt");
            driver.FindElementByAccessibilityId("1").Click();

            Thread.Sleep(1000);
            driver.CloseApp();
        }
    }
}
