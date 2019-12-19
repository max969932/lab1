using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;
using PageObject.Driver;
using PageObject.Utils;

namespace PageObject.Tests
{
    public class CommonConditions
    {
        public IWebDriver webDriver;

        [SetUp]
        public void OpenBrowserAndGoToSite()
        {
            webDriver = DriverSingleton.GetDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        [TearDown]
        public void QuitDriver()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                ScreenshotCreater.SaveScreenShot(webDriver);
            }

            DriverSingleton.CloseDriver();
        }
    }
}
