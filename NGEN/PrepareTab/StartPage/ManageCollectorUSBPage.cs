using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class ManageCollectorUSBPage : PreparePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public ManageCollectorUSBPage(IWebDriver driver, WebDriverWait wait)
            :base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public IWebElement HandheldDevicesButton => _driver.FindElements(By.CssSelector(RedTabCSSSelector))[2];


        public HandheldDevicesPage OpenHandheldDevicesPage()
        {
            HandheldDevicesButton.Click();
            return new HandheldDevicesPage(_driver, _wait);

        }
    }
}