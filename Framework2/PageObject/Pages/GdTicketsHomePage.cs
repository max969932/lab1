using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using PageObject.Models;
using PageObject.Pages;
using PageObject.Tests;
using PageObject.Driver;

namespace PageObject
{
    class GdTicketsHomePage
    {
        private readonly IWebDriver _driver;

        private readonly string url = "https://gd.tickets.ua/en";

        [FindsBy(How = How.XPath, Using = "//button[@type='button' and @class='t-select__activator']")]
        private IWebElement departureCityButton;

        [FindsBy(How = How.XPath, Using = "//input[@type='text' and @class='t-autocomplete-v2__input']")]
        private IWebElement departureCityField;

        [FindsBy(How = How.XPath, Using = "//div[@data-uil='direction-to']")]
        private IWebElement arriveCityButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='t-menu open t-select big t-autocomplete-v2 has-items search-form-railway__field']/menu/li/div/input")]
        private IWebElement arriveCityField;

        [FindsBy(How = How.XPath, Using = "//button[@data-uil='btn-search']")]
        private IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = "//div[@data-uil='calendar']/div/div/button/div")]
        private IWebElement calendarDepartButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='t-date-picker__error-message']")]
        private IWebElement error;

        [FindsBy(How = How.XPath, Using = "//section[@class='lang top-nav__link']/div/button")]
        private IWebElement langMenu;

        [FindsBy(How = How.XPath, Using = "//a[@href='/en' and @class='top-nav__item']")]
        private IWebElement langEnglish;

        string xpath = "//button[@type='button' and @class='t-calendar__month__week__day__button' and contains(text(),'{0}')]/..";

        [FindsBy(How = How.XPath, Using = "//body[@class='body_container  gd_search_body  ']")]
        private IWebElement searchResultPage;

        public GdTicketsHomePage()
        {
            _driver = DriverSingleton.GetDriver();
            PageFactory.InitElements(_driver, this);
            _driver.Navigate().GoToUrl(url);
        }

        public GdTicketsHomePage FillFieldDeparture(Route route)
        {
            departureCityButton.Click();
            departureCityField.SendKeys(route.DepartureCity);
            IWebElement _departureCity = GetWebElement("//a[contains(text(), 'Kiev')]");
            _departureCity.Click();
            return this;
        }

        public GdTicketsHomePage FillFieldArrive(Route route)
        {
            arriveCityButton.Click();
            arriveCityField.SendKeys(route.ArrivalCity);
            IWebElement _arriveCity = GetWebElement("//a[contains(text(),'Kharkov')]");

            _arriveCity.Click();
            return this;
        }

        public string getErrorMessage()
        {
            return error.Text;
        }

        public IEnumerable<IWebElement> GetCalendarDates()
        {
            var datesList = GetWebElement("//table[@class='ui-datepicker-calendar']");
            return datesList.FindElements(By.XPath("//a"));
        }

        public GdTicketsHomePage OpenDepartCalendar()
        {
            calendarDepartButton.Click();
            return this;
        }

        public GdTicketsHomePage ChoiceDepartureDate(Route route)
        {
            IWebElement date = GetWebElement(string.Format(xpath, route.DateDepart));
            date.Click();
            
            return this;
        }

        public GdTicketsHomePage ChoiceYesterdayDepartureDate(Route route)
        {
            IWebElement date = GetWebElement(string.Format(xpath, route.YesterdayDateDepart));
            date.Click();

            return this;
        }

        public SearchResultsPage SearchClick()
        {
            searchButton.Click();
            SearchResultsPage page = new SearchResultsPage(_driver);
            return page;
        }

        public SearchResultsPage GoToSearchResult()
        {

            searchButton.Click();
            searchResultPage.Click();
            SearchResultsPage page = new SearchResultsPage(_driver);
            return page;
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
