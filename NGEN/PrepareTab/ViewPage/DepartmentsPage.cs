using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class DepartmentsPage: PreparePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public DepartmentsPage(IWebDriver driver, WebDriverWait wait)
            :base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public IWebElement QuantityButton => _driver.FindElements(By.CssSelector(RedTabCSSSelector))[2];

        public QuantityPage OpenQuantityPage()
        {
            QuantityButton.Click();
            return new QuantityPage(_driver, _wait);

        }
    }
}