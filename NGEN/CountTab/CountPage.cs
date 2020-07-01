using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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


        public LocationStatistics OpenLocationStatistics()
        {
            LocationStatisticsButton.Click();
            return new LocationStatistics(_driver, _wait);
        }
    }
}