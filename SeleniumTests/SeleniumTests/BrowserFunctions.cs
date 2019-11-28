using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;

namespace SeleniumTests
{
    public abstract class BrowserFunctions
    {
        public IWebDriver webDriver;

        [SetUp]
        public void OpenBrowserAndGoToSite()
        {
            webDriver = new OperaDriver("C:\\WebDriver\\bin\\");
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            webDriver.Navigate().GoToUrl("https://gd.tickets.ua/");
        }

        [TearDown]
        public void CloseBrowser()
        {
            webDriver.Quit();
        }

        protected IWebElement GetWebElementById(string Id)
        {
            return webDriver.FindElement(By.Id(Id));
        }

        protected IWebElement GetWebElementByXPath(string xPath)
        {
            return webDriver.FindElement(By.XPath(xPath));
        }
    }
}
