using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection.Metadata;
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
        public IWebElement YesLogoutConfirmationButton => _driver.FindElement(By.CssSelector("button.modal-rgis-button"));
        public IWebElement PrepareButton => _driver.FindElement(By.CssSelector("a.header-navigation-tab.prepare.active"));
        public IWebElement CountButton => _driver.FindElement(By.CssSelector("a.header-navigation-tab.count"));
        public IWebElement VerifyButton => _driver.FindElement(By.CssSelector("a.header-navigation-tab.verify"));
        public IWebElement FinishButton => _driver.FindElement(By.CssSelector("a.header-navigation-tab.finish"));

        public static string RedTabCSSSelector = "a.header-navigation-tab.red-tab.header-navigation-tab-sm";
        public static string HeaderNavigationItemButton = "a.header-navigation-item.header-navigation-item";


        public LoginPage Logout()
        {
            Thread.Sleep(2000);
            LogoutButton.Click();
            YesLogoutConfirmationButton.Click();
            return new LoginPage(_driver, _wait);
        }

        public PreparePage OpenPreparePage()
        {
            Thread.Sleep(3000);
            PrepareButton.Click();
            return new PreparePage(_driver, _wait);
        }

        public CountPage OpenCountPage()
        {
            CountButton.Click();
            return new CountPage(_driver, _wait);
        }

        public VerifyPage OpenVerifyPage()
        {
            VerifyButton.Click();
            return new VerifyPage(_driver, _wait);
        }

        public FinishPage OpenFinishPage()
        {
            FinishButton.Click();
            return new FinishPage(_driver, _wait);
        }

    }
}
