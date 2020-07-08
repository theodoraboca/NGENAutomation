using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class ConfigurationSummaryPage : PreparePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public ConfigurationSummaryPage(IWebDriver driver, WebDriverWait wait)
            :base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public IWebElement NotesButton => _driver.FindElements(By.CssSelector(RedTabCSSSelector))[2];

        public NotesPage OpenNotesPage()
        {
            NotesButton.Click();
            return new NotesPage(_driver, _wait);
        }
    }
}