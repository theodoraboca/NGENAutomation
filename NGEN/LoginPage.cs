using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NGEN
{
    public class LoginPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private IConfiguration _configuration;

        public LoginPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public IWebElement EventID => _driver.FindElement(By.Id("login-event-id"));

        public IWebElement EventCode => _driver.FindElement(By.Id("login-event-code"));

        public IWebElement BadgeID => _driver.FindElement(By.Id("login-badge-id"));

        public IWebElement CustomRadioRGISOption => _driver.FindElement(By.XPath("//span[@class='custom-radio']"));

        public IWebElement Submit => _driver.FindElement(By.XPath("//button[@class ='login-button']"));


        public PageBase Login()
        {
            Thread.Sleep(1000);
            EventID.SendKeys(CustomNGENConfiguration.DefaultConfiguration["Login:EventID"]);
            EventCode.SendKeys(CustomNGENConfiguration.DefaultConfiguration["Login:EventCode"]);
            BadgeID.SendKeys(CustomNGENConfiguration.DefaultConfiguration["Login:BadgeID"]);
            CustomRadioRGISOption.Click();
            Submit.Click();
            return new PageBase(_driver, _wait);
        }





    }
}
