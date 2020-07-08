using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class QuantityPage:PreparePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public QuantityPage(IWebDriver driver, WebDriverWait wait)
            :base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public IWebElement PreviousDataButton => _driver.FindElements(By.CssSelector(RedTabCSSSelector))[3];

        public PreviousDataPage OpenPreviousDataPage()
        {
            PreviousDataButton.Click();
            return new PreviousDataPage(_driver, _wait);

        }
    }
}