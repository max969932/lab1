using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject
{
    class GdTicketsHomePage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//table[@class='ui-datepicker-calendar']")]
        private IWebElement calendar;

        public GdTicketsHomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public IWebElement arriveCity => GetWebElementById("arrival");

        public IWebElement departureCity => GetWebElementById("departure");

        public IWebElement searchButton => GetWebElement("//button[@data-uil='submit_search']");

        public void ChoiceDepartureCity(string city)
        {
            departureCity.SendKeys(city);
            IWebElement _departureCity = GetWebElement($"//a[@class='ui-menu__item ui-menu__item--pin ui-corner-all' and text()='{city}']");
            _departureCity.Click();
        }

        public void ChoiceArriveCity(string city)
        {
            arriveCity.SendKeys(city);
            IWebElement _arriveCity = GetWebElement($"//a[@class='ui-menu__item ui-menu__item--pin ui-corner-all ui-state-focus' and text()='{city}']");
            _arriveCity.Click();
        }

        public string getErrorMessage()
        {
            return GetWebElement("//samp[@generated='true' and @for='departure_date' and @class='error _idx_2']").Text;
        }

        public IEnumerable<IWebElement> GetCalendarDates()
        {
            var datesList = GetWebElement("//table[@class='ui-datepicker-calendar']");
            return datesList.FindElements(By.XPath("//a"));
        }

        public void OpenCalendar()
        {
            calendar.Click();
        }

        private IWebElement GetWebElement(string xPath)
        {
            return _driver.FindElement(By.XPath(xPath));
        }

        private IWebElement GetWebElementById(string Id)
        {
            return _driver.FindElement(By.Id(Id));
        }
    }
}
