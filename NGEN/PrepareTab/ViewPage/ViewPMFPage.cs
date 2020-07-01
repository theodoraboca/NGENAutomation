using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class ViewPMFPage : PreparePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public ViewPMFPage(IWebDriver driver, WebDriverWait wait)
            :base (driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }
    }
}