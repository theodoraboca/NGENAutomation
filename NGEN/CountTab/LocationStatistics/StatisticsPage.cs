using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class StatisticsPage : LocationStatistics
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public StatisticsPage(IWebDriver driver, WebDriverWait wait)
            :base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }


    }
}