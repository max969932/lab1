using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace PageObject.Driver
{
    class DriverSingleton
    {
        private static IWebDriver Driver;

        private DriverSingleton() { }

        public static IWebDriver GetDriver()
        {
            if (null == Driver)
            {
                switch (TestContext.Parameters.Get("browser"))
                {
                    case "Chrome":
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        Driver = new ChromeDriver();
                        break;
                    default:
                        new DriverManager().SetUpDriver(new OperaConfig());
                        Driver = new OperaDriver();
                        break;
                }
                Driver.Manage().Window.Maximize();
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            }
            return Driver;
        }

        public static void CloseDriver()
        {
            Driver.Quit();
            Driver = null;
        }
    }
}