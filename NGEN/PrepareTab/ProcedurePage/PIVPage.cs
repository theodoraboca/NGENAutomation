using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class PIVPage: PreparePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public PIVPage(IWebDriver driver, WebDriverWait wait)
            :base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }

    }
}