using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq.Expressions;

namespace NGEN
{
    public class MapViewPage: LocationStatistics
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public MapViewPage(IWebDriver driver, WebDriverWait wait)
            :base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }

        
    }
}