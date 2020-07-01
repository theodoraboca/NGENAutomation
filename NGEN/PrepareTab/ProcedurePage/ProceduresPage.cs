using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class ProceduresPage : PreparePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public ProceduresPage(IWebDriver driver, WebDriverWait wait)
            :base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }
    }
}