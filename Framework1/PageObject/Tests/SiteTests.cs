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
            GdTicketsHomePage page = new GdTicketsHomePage(webDriver);
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
            GdTicketsHomePage page = new GdTicketsHomePage(webDriver);

            page
                .FillFieldDeparture(route)
                .FillFieldArrive(route)
                .OpenDepartCalendar()
                .ChoiceDepartureDate(route)
                .SearchClick();

            Assert.AreEqual(expectedErrorMessage, page.getErrorMessage());
        }
    }
}
