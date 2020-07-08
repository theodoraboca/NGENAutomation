using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class VerifyPage : PageBase
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public VerifyPage(IWebDriver driver, WebDriverWait wait)
            : base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public IWebElement QueueButton => _driver.FindElement(By.CssSelector(RedTabCSSSelector));
        public IWebElement AlterationsButton => _driver.FindElements(By.CssSelector(RedTabCSSSelector))[1];
        public IWebElement PieceCountButton => _driver.FindElements(By.CssSelector(RedTabCSSSelector))[2];
        public IWebElement VariancesButton => _driver.FindElements(By.CssSelector(RedTabCSSSelector))[3];


        public QueuePage OpenQueuePage()
        {
            QueueButton.Click();
            return new QueuePage(_driver, _wait);
        }

        public AlterationsPage OpenAlterationsPage()
        {
            AlterationsButton.Click();
            return new AlterationsPage(_driver, _wait);
        }

        public PieceCountPage OpenPieceCountPage()
        {
            PieceCountButton.Click();
            return new PieceCountPage(_driver, _wait);
        }

        public VariancesPage OpenVariancesPage()
        {
            VariancesButton.Click();
            _wait.Until(ExpectedConditions.ElementExists(By.CssSelector("table.custom-table")));
            return new VariancesPage(_driver, _wait);
        }


    }
}