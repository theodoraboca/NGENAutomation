using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class LocationStatisticsPage : CountPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public LocationStatisticsPage(IWebDriver driver, WebDriverWait wait)
            : base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public IWebElement MapViewButton => _driver.FindElement(By.XPath("//div[@title='Map View']"));
        public IWebElement ListViewButton => _driver.FindElement(By.XPath("//div[@title='List View']"));
        public IWebElement StatisticsButton => _driver.FindElement(By.XPath("//div[@title='Statistics']"));

        public void HoverOnLocationStatistics()
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(LocationStatisticsButton).Build().Perform();
        }

        public MapViewPage OpenMapViewPage()
        {
            HoverOnLocationStatistics();
            MapViewButton.Click();
            return new MapViewPage(_driver, _wait);
        }

        public ListViewPage OpenListViewPage()
        {
            HoverOnLocationStatistics();
            ListViewButton.Click();
            _wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.divTableContainer.w-100")));
            return new ListViewPage(_driver, _wait);
        }

        public StatisticsPage OpenStatisticsPage()
        {
            HoverOnLocationStatistics();
            StatisticsButton.Click();
            return new StatisticsPage(_driver, _wait);
        }

    }
}