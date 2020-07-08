using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class RGISEvaluationPage : FinishPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public RGISEvaluationPage(IWebDriver driver, WebDriverWait wait)
            :base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public IWebElement NGENFeedbackButton => _driver.FindElements(By.CssSelector(RedTabCSSSelector))[1];

        public NGENFeedbackPage OpenNGENFeedbackPage()
        {
            NGENFeedbackButton.Click();
            return new NGENFeedbackPage(_driver, _wait);
        }
    }
}