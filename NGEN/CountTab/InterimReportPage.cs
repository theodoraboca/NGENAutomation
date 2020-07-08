using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class InterimReportPage : CountPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public InterimReportPage(IWebDriver driver, WebDriverWait wait)
            :base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }
    }
}