using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace NGEN
{
    public class StartInventoryStartPropertiesPage : PreparePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public StartInventoryStartPropertiesPage(IWebDriver driver, WebDriverWait wait)
            :base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public IWebElement ManageCollectorUSBButton => _driver.FindElements(By.CssSelector("a.header-navigation-tab.red-tab.header-navigation-tab-sm"))[1];
        
        public ManageCollectorUSBPage OpenManageCollectorUSBPage()
        {
                        ManageCollectorUSBButton.Click();
            return new ManageCollectorUSBPage(_driver, _wait);
        }

    }
}