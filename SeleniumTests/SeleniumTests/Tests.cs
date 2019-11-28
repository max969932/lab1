using System;
using NUnit.Framework;
    
namespace SeleniumTests
{
    [TestFixture]
    public class Tests : BrowserFunctions
    {
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
            #region TestData
            const string departureCityText = "Киев";
            const string arriveCityText = "Харьков-Пасс";
            #endregion

            var departureCity = GetWebElementById("departure");
            departureCity.SendKeys(departureCityText);
            var departureCityInList = GetWebElementById("ui-id-6");
            departureCityInList.Click();

            var arriveCity = GetWebElementById("arrival");
            arriveCity.SendKeys(arriveCityText);
            var arriveCityInList = GetWebElementByXPath("/html/body/ul[2]/li/a");
            arriveCityInList.Click();

            var searchButton = GetWebElementByXPath("/html/body/div[1]/div[1]/div/form/div[2]/div[3]/div/button");
            searchButton.Click();

            var errorMessage = GetWebElementByXPath("/html/body/div[1]/div[1]/div/form/div[2]/div[2]/div[1]/samp");

            Assert.AreEqual("Это поле необходимо заполнить", errorMessage.Text);
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
            #region TestData
            const string departureCityText = "Киев";
            const string arriveCityText = "Харьков-Пасс";
            int yesterday = DateTime.Now.Day - 1;
            #endregion

            var departureCity = GetWebElementById("departure");
            departureCity.SendKeys(departureCityText);
            var departureCityInList = GetWebElementById("ui-id-6");
            departureCityInList.Click();

            var arriveCity = GetWebElementById("arrival");
            arriveCity.SendKeys(arriveCityText);
            var arriveCityInList = GetWebElementByXPath("/html/body/ul[2]/li/a");
            arriveCityInList.Click();

            string xPath = ".//td[@class = ' ui-datepicker-unselectable ui-state-disabled ']/span[@class = 'ui-state-default' and text() = '" + yesterday.ToString() + "']";
            var yesterdayDate = GetWebElementByXPath(xPath);
            yesterdayDate.Click();

            var searchButton = GetWebElementByXPath("/html/body/div[1]/div[1]/div/form/div[2]/div[3]/div/button");
            searchButton.Click();

            var errorMessage = GetWebElementByXPath("/html/body/div[1]/div[1]/div/form/div[2]/div[2]/div[1]/samp");

            Assert.AreEqual("Это поле необходимо заполнить", errorMessage.Text);
        }
    }
}
