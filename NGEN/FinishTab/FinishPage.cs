using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class FinishPage : PageBase
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public FinishPage(IWebDriver driver, WebDriverWait wait)
            : base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public IWebElement FinalReportPreCloseoutButton => _driver.FindElement(By.CssSelector(HeaderNavigationItemButton));
        public IWebElement CustomerEvaluationPIQAButton => _driver.FindElements(By.CssSelector(HeaderNavigationItemButton))[1];
        public IWebElement RGISEvaluationButton => _driver.FindElements(By.CssSelector(HeaderNavigationItemButton))[2];
        public IWebElement CloseOutFinalChecksButton => _driver.FindElements(By.CssSelector(HeaderNavigationItemButton))[3];

        public FinalReportPreCloseoutChecksPage OpenFinalReportPreCloseoutChecksPage()
        {
            FinalReportPreCloseoutButton.Click();
            _wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.divTableBody")));
            return new FinalReportPreCloseoutChecksPage(_driver, _wait);

        }

        public CustomerEvaluationPIQAPage OpenCustomerEvaluationPIQAPage()
        {
            CustomerEvaluationPIQAButton.Click();
            return new CustomerEvaluationPIQAPage(_driver, _wait);
        }

        public RGISEvaluationPage OpenRGISEvaluationPage()
        {
            RGISEvaluationButton.Click();
            return new RGISEvaluationPage(_driver, _wait);
        }

        public CloseOutFinalChecksPage OpenCloseOutFinalChecksPage()
        {
            CloseOutFinalChecksButton.Click();
            _wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.divTableBody")));
            return new CloseOutFinalChecksPage(_driver, _wait);
        }


    }
}