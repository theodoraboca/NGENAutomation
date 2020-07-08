﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class PreviousDataPage : PreparePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public PreviousDataPage(IWebDriver driver, WebDriverWait wait)
            :base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }
    }
}