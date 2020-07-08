using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class NotesPage : PreparePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public NotesPage(IWebDriver driver, WebDriverWait wait)
            :base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }
        public IWebElement PIVButton => _driver.FindElements(By.CssSelector(RedTabCSSSelector))[3];

        public PIVPage OpenPIVPage()
        {
            PIVButton.Click();
            return new PIVPage(_driver, _wait);
        }
    }
}