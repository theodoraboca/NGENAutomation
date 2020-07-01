using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Xunit;

namespace NGEN
{
    public class NgenTests
    {
        [Fact]
        public void LoginLogout()
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, TimeSpan.MaxValue);

            var webpage = new LoginPage(driver, wait);

            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);

            webpage.Login().Logout();

            driver.Close();

        }

        [Fact]
        public void Test()
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, TimeSpan.MaxValue);

            var webpage = new LoginPage(driver, wait);

            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);
            webpage.Login().OpenPrepareTab().OpenInventoryStartPropertiesTab().OpenManageCollectorUSBPage().OpenHandheldDevicesPage()
            .OpenCountPage().OpenLocationStatistics().OpenMapViewPage().OpenListViewPage().OpenStatisticsPage();

        }

    }
}
