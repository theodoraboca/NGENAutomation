﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class VariancesPage: VerifyPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public VariancesPage(IWebDriver driver, WebDriverWait wait)
            :base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }
    }
}