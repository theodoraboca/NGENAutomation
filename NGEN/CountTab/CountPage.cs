using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace NGEN
{
    public class CountPage : PageBase
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public CountPage(IWebDriver driver, WebDriverWait wait)
            :base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }


        public IWebElement LocationStatisticsButton => _driver.FindElement(By.CssSelector("a.header-navigation-item.header-submenu-open.header-navigation-item-active"));
        public IWebElement EditButton => _driver.FindElement(By.XPath("//a[@title='Edit']"));
        public IWebElement InterimReportButton => _driver.FindElement(By.XPath("//a[@title='Interim Report']"));
        public IWebElement InterimOutputs => _driver.FindElement(By.XPath("//a[@title = 'Interim Outputs']"));


        public LocationStatisticsPage OpenLocationStatisticsPage()
        {
            LocationStatisticsButton.Click();
            return new LocationStatisticsPage(_driver, _wait);
        }

        public EditPage OpenEditPage()
        {
            EditButton.Click();
            return new EditPage(_driver, _wait);
        }

        public InterimReportPage OpenInterimReportPage()
        {
            InterimReportButton.Click();
            return new InterimReportPage(_driver, _wait);
        }

        public InterimOutputsPage OpenInterimOutputsPage()
        {
            InterimOutputs.Click();
            return new InterimOutputsPage(_driver, _wait);
        }



    }
}