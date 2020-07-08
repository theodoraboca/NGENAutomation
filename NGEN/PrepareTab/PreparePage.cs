using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace NGEN
{
    public class PreparePage : PageBase
        
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public PreparePage(IWebDriver driver, WebDriverWait wait)
            : base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public IWebElement StartButton => _driver.FindElement(By.CssSelector("a.header-navigation-item.header-navigation-item-active"));
        public IWebElement ProceduresButton => _driver.FindElement(By.XPath("//a[@title='Procedures']"));
        public IWebElement ViewButton => _driver.FindElement(By.XPath("//a[@title='View']"));
        public IWebElement ExtraButton => _driver.FindElement(By.XPath("//a[@title='Extra']"));


        public StartInventoryStartPropertiesPage OpenInventoryStartPropertiesTab()
        {
            Thread.Sleep(2000);
            StartButton.Click();
            return new StartInventoryStartPropertiesPage(_driver, _wait);

        }

        public ProceduresPage OpenProceduresPage()
        {
            ProceduresButton.Click();
            return new ProceduresPage(_driver, _wait);
        }

        public ViewPMFPage OpenViewPMFPage()
        {
            ViewButton.Click();
            return new ViewPMFPage(_driver, _wait);
        }

        public ExtraPage OpenExtraPage()
        {
            ExtraButton.Click();
            return new ExtraPage(_driver, _wait);
        }

    }
}