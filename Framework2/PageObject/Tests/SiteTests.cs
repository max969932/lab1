using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageObject.Driver;
using PageObject.Tests;
using PageObject.Models;
using PageObject.Services;
using PageObject.Pages;

namespace PageObject
{
    [TestFixture]
    public class SiteTests : CommonConditions
    {
        // Найти билет, не указав дату.
        //-зайти на https://gd.tickets.ua
        //-откуда: Kiev
        //-куда: Harkov Pas
        //-дата: поле оставить пустым
        //
        //*ожидаемый результат: вывод сообщения - 'This field is mandatory'
        [Test]
        [Category("SearchTest")]
        public void FindTicketWithEmptyFieldDepartureDate()
        {
            #region TestData
            const string expectedErrorMessage = "This field is mandatory";
            #endregion

            Route route = RouteCreator.WithAllProperties();
            GdTicketsHomePage page = new GdTicketsHomePage();
            page
                .FillFieldDeparture(route)
                .FillFieldArrive(route)
                .SearchClick();

            Assert.AreEqual(expectedErrorMessage, page.getErrorMessage());
        }

        // Найти билет, указав вчерашнюю дату
        //-зайти на https://gd.tickets.ua
        //-откуда: Kiev
        //-куда: Harkov Pas
        //-дата: вчерашняя
        //-нажать "найти"
        //
        //*ожидаемый результат: вывод сообщения - 'This field is mandatory'
        [Test]
        public void FindTicketWithYeasterdayDate()
        {
            #region TestData
            const string expectedErrorMessage = "This field is mandatory";
            #endregion

            Route route = RouteCreator.WithAllProperties();
            GdTicketsHomePage page = new GdTicketsHomePage();

            page
                .FillFieldDeparture(route)
                .FillFieldArrive(route)
                .OpenDepartCalendar()
                .ChoiceYesterdayDepartureDate(route)
                .SearchClick();

            Assert.AreEqual(expectedErrorMessage, page.getErrorMessage());
        }

        [Test]
        public void OpenSearchResultPage()
        {
            #region TestData
            string searchResultsPageUrl = "https://gd.tickets.ua/en/search/results";
            #endregion

            Route route = RouteCreator.WithAllProperties();
            GdTicketsHomePage page = new GdTicketsHomePage();

            SearchResultsPage searchResultsPage =
            page
                .FillFieldDeparture(route)
                .FillFieldArrive(route)
                .OpenDepartCalendar()
                .ChoiceDepartureDate(route)
                .GoToSearchResult();
            bool pageIsResultsPage = searchResultsPage.GetUrl().Contains(searchResultsPageUrl);
            Assert.IsTrue(pageIsResultsPage);
        }

        [Test]
        public void CheckCorrectnessRoute()
        {
            Route route = RouteCreator.WithAllProperties();
            GdTicketsHomePage gdTicketsHomePage = new GdTicketsHomePage();

            SearchResultsPage searchResultsPage = gdTicketsHomePage
                .FillFieldDeparture(route)
                .FillFieldArrive(route)
                .OpenDepartCalendar()
                .ChoiceDepartureDate(route)
                .GoToSearchResult();

            string trip = route.DepartureCity + "-" + route.ArrivalCity;

            bool pageIsResultsPage = searchResultsPage.GetTrip().Contains(trip);


            Assert.IsTrue(pageIsResultsPage);
        }

        [Test]
        public void RouteHaveSeats()
        {
            #region TestData
            string numSeat = "45";
            bool hasSeats;
            #endregion
            Route route = RouteCreator.WithAllProperties();
            GdTicketsHomePage gdTicketsHomePage = new GdTicketsHomePage();

            SearchResultsPage searchResultsPage = gdTicketsHomePage
                .FillFieldDeparture(route)
                .FillFieldArrive(route)
                .OpenDepartCalendar()
                .ChoiceDepartureDate(route)
                .GoToSearchResult();

            searchResultsPage.ChoiceFirstTrain();
            string strNumber = searchResultsPage.GetNumberFreeSeats();
            int number = int.Parse(strNumber);
            if (number > 0) hasSeats = true;
            else hasSeats = false;

            Assert.IsTrue(hasSeats);
        }

        [Test]
        public void BuyChildrenTicketIfAdult()
        {
            #region TestData
            string error = "Please specify a valid date in the format DD/MM/YYYY";
            Route route = RouteCreator.WithAllProperties();
            User user = UserCreator.WithAllProperties();
            #endregion

            GdTicketsHomePage gdTicketsHomePage = new GdTicketsHomePage();

            SearchResultsPage searchResultsPage = gdTicketsHomePage
                .FillFieldDeparture(route)
                .FillFieldArrive(route)
                .OpenDepartCalendar()
                .ChoiceDepartureDate(route)
                .GoToSearchResult()
                .ChoiceFirstTrain()
                .ChoiceChildTo14YearsAndWriteData(user);

            Assert.AreEqual(error, searchResultsPage.GetDateError());
        }
    }
}
