using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject
{
    [TestFixture]
    public class Tests
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
        public void QuitDriver()
        {
            webDriver.Quit();
        }

        // Найти билет, не указав дату.
        //-зайти на https://gd.tickets.ua
        //-откуда: Киев
        //-куда: Харьков-Пасс
        //-дата: поле оставить пустым
        //
        //*ожидаемый результат: вывод сообщения - 'Это поле необходимо заполнить'
        [Test]
        public void FindTicketWithEmptyFieldDepartureDate()
        {
            var homepage = new GdTicketsHomePage(webDriver);

            #region TestData
            const string departureCityText = "Киев";
            const string arriveCityText = "Харьков-Пасс";
            const string expectedErrorMessage = "Это поле необходимо заполнить";
            #endregion

            homepage.ChoiceDepartureCity(departureCityText);
            homepage.ChoiceArriveCity(arriveCityText);
            homepage.searchButton.Click();

            Assert.AreEqual(expectedErrorMessage, homepage.getErrorMessage());
        }

        // Найти билет, указав вчерашнюю дату
        //-зайти на https://gd.tickets.ua
        //-откуда: Киев
        //-куда: Харьков-Пасс
        //-дата: вчерашняя
        //-нажать "найти"
        //
        //*ожидаемый результат: вывод сообщения - 'Это поле необходимо заполнить'
        [Test]
        public void FindTicketWithYeasterdayDate()
        {
            var homepage = new GdTicketsHomePage(webDriver);
            #region TestData
            const string departureCityText = "Киев";
            const string arriveCityText = "Харьков-Пасс";
            const string expectedErrorMessage = "Это поле необходимо заполнить";
            int yesterday = DateTime.Now.Day - 1;
            #endregion

            homepage.ChoiceDepartureCity(departureCityText);
            homepage.ChoiceArriveCity(arriveCityText);
            homepage.OpenCalendar();
            var dates = homepage.GetCalendarDates();
            var day = dates.FirstOrDefault(d => d.Text.Equals(yesterday.ToString()));
            day.Click();
            homepage.searchButton.Click();

            Assert.AreEqual(expectedErrorMessage, homepage.getErrorMessage());
        }
    }
}
