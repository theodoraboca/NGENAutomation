﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class ListViewPage: LocationStatisticsPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public ListViewPage(IWebDriver driver, WebDriverWait wait)
            :base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }
    }
}