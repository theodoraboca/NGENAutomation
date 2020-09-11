using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace NGEN
{
    public class ReportPage 
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public ReportPage(IWebDriver driver, WebDriverWait wait)
            
        {
            _driver = driver;
            _wait = wait;
        }

        public bool NoErrorIsRaised()
        {
            Thread.Sleep(3000);
            try
            {
                var errorModal = _driver.FindElement(By.CssSelector("div.modal-dialog.modal-rgis.modal-rgis-confirm"));

            }

            catch (NoSuchElementException exception)
            {
                return true;
            }

            return false;
        }
    }
}