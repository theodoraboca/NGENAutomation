using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class CloseOutFinalChecksPage : FinishPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public CloseOutFinalChecksPage(IWebDriver driver, WebDriverWait wait)
            :base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public IWebElement CloseEventButton => _driver.FindElements(By.CssSelector(RedTabCSSSelector))[1];

        public CloseEventPage OpenCloseEventPage()
        {
            CloseEventButton.Click();
            _wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.divTableBody")));
            return new CloseEventPage(_driver, _wait);
        }

    }
}