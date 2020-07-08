using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class FinalReportPreCloseoutChecksPage : FinishPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public FinalReportPreCloseoutChecksPage(IWebDriver driver, WebDriverWait wait)
            :base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public IWebElement ReportsOutputsAndFilesButton => _driver.FindElements(By.CssSelector(RedTabCSSSelector))[1];

        public ReportsOutputsAndFilesPage OpenReportsOutputsAndFilesPage()
        {
            ReportsOutputsAndFilesButton.Click();
            _wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.divTable.rgisTable")));
            return new ReportsOutputsAndFilesPage(_driver, _wait);
        }
    }
}