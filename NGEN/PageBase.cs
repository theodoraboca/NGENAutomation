using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace NGEN
{
    public class PageBase
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public PageBase(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public IWebElement LogoutButton => _driver.FindElement(By.XPath("//div[@class='nav-right']/div[4]"));
        public IWebElement YesConfirmationButton => _driver.FindElement(By.CssSelector("button.modal-rgis-button"));
        public IWebElement PrepareButton => _driver.FindElement(By.CssSelector("a.header-navigation-tab.prepare.active"));
        public IWebElement CountButton => _driver.FindElement(By.CssSelector("a.header-navigation-tab.count"));

        public LoginPage Logout()
        {
            Thread.Sleep(2000);
            LogoutButton.Click();
            YesConfirmationButton.Click();
            return new LoginPage(_driver, _wait);
        }

        public PreparePage OpenPrepareTab()
        {
            Thread.Sleep(2000);
            PrepareButton.Click();
            return new PreparePage(_driver, _wait);
        }

        public CountPage OpenCountPage()
        {
            CountButton.Click();
            return new CountPage(_driver, _wait); 
        }


    }
}
