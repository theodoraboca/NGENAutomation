using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class LocationStatistics : CountPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public LocationStatistics(IWebDriver driver, WebDriverWait wait)
            : base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public IWebElement MapViewButton => _driver.FindElement(By.XPath("//div[@title='Map View']"));
        public IWebElement ListViewButton => _driver.FindElement(By.XPath("//div[@title='List View']"));
        public IWebElement StatisticsButton => _driver.FindElement(By.XPath("//div[@title='Statistics']"));

        public MapViewPage OpenMapViewPage()
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(LocationStatisticsButton).Build().Perform();
            MapViewButton.Click();
            return new MapViewPage(_driver, _wait);
        }

        public ListViewPage OpenListViewPage()
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(LocationStatisticsButton).Build().Perform();
            ListViewButton.Click();
            return new ListViewPage(_driver, _wait);
        }

        public StatisticsPage OpenStatisticsPage()
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(LocationStatisticsButton).Build().Perform();
            StatisticsButton.Click();
            return new StatisticsPage(_driver, _wait);
        }

    }
}