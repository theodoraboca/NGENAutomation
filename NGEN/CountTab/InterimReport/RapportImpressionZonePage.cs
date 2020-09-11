using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class RapportImpressionZonePage : ReportPage 
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public RapportImpressionZonePage(IWebDriver driver, WebDriverWait wait)
            :base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public IWebElement CloseButton => _driver.FindElement(By.CssSelector("button.close"));

        public InterimReportPage CloseRapportImpressionZonePage()
        {
            CloseButton.Click();
            return new InterimReportPage(_driver, _wait);
        }
    }
}