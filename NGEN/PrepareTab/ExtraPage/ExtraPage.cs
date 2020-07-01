using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class ExtraPage : PreparePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public ExtraPage(IWebDriver driver, WebDriverWait wait)
            :base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }
    }
}