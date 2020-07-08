using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class NGENFeedbackPage : FinishPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public NGENFeedbackPage(IWebDriver driver, WebDriverWait wait)
            :base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }
    }
}