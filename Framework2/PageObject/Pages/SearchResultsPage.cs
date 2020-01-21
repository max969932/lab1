using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageObject.Models;

namespace PageObject.Pages
{
    class SearchResultsPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//div[@class='trip__info-direction']")]
        IWebElement tripInfo;

        [FindsBy(How = How.ClassName, Using = "results__item")]
        IList<IWebElement> field;//
        const string value = "results__item-seats__button";

        [FindsBy(How = How.XPath, Using = "//div[@data-auto-controller='RailWayTrainController']")]
        IWebElement railWayTrain;

        [FindsBy(How = How.XPath, Using = "//div[@class='train-info-text row']")]
        IList<IWebElement> freeSeats;

        [FindsBy(How = How.XPath, Using = "//label[@for='passenger[9][type][kid]' and class='label label--form-radio-icon kid']")]
        IWebElement childLabel;

        [FindsBy(How = How.XPath, Using = "//input[@data-passenger-field='last_name']")]
        IWebElement lastNameField;

        [FindsBy(How = How.XPath, Using = "//input[@data-passenger-field='first_name']")]
        IWebElement firstNameField;

        [FindsBy(How = How.XPath, Using = "//input[@data-uil='birth_date']")]
        IWebElement dateOfBirthField;

        [FindsBy(How = How.XPath, Using = "//samp[@class='error']")]
        IWebElement dateError;

        public SearchResultsPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public string GetUrl()
        {
            return _driver.Url;
        }

        public string GetTrip()
        {
            string trip = tripInfo.Text;

            return trip;
        }

        public SearchResultsPage ChoiceFirstTrain()
        {
            var val = field[0].FindElement(By.ClassName(value));
            val.Click();

            return this;
        }

        public string GetNumberFreeSeats()
        {
            IWebElement numSeats = freeSeats[0].FindElement(By.XPath("//span[@class='js-train-scheme-seats']"));

            return numSeats.Text;
        }

        public SearchResultsPage ChoiceChildTo14YearsAndWriteData(User user)
        {
            childLabel.Click();

            firstNameField.SendKeys(user.FirstName);
            lastNameField.SendKeys(user.LastName);
            dateOfBirthField.SendKeys(user.DateOfBirth);

            return this;
        }

        public string GetDateError()
        {
            return dateError.Text;
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
