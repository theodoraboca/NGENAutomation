using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace NGEN
{
    public class InterimReportPage : CountPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public InterimReportPage(IWebDriver driver, WebDriverWait wait)
            : base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public IWebElement WatchButton => _driver.FindElement(By.CssSelector("div.header-filters-item.view.header-filters-item-active"));
        public IWebElement PrintButton => _driver.FindElement(By.CssSelector("div.header-filters-item.print.header-filters-item-active"));
        public IWebElement PreviousButton => _driver.FindElement(By.CssSelector("div.header-filters-item.previous.header-filters-item-active"));


        public ReportPage GenerateSingleReport(IWebElement singleReport)
        {
            singleReport.Click();
            Thread.Sleep(3000);
            WatchButton.Click();
            Thread.Sleep(3000);
            return new ReportPage(_driver, _wait);
        }

        public ReportPage GenerateParameterReport(IWebElement parameterReport)
        {
            parameterReport.Click();
            Thread.Sleep(3000);
            WatchButton.Click();
            var Yesbutton = _driver.FindElement(By.CssSelector("button.modal-rgis-button.mr-5"));
            Yesbutton.Click();
            return new ReportPage(_driver, _wait);
        }

        public ReportPage DisplayLastGeneratedReport(IWebElement report)
        {
            report.Click();
            Thread.Sleep(3000);
            PrintButton.Click();
            return new ReportPage(_driver, _wait);
        }

        public RapportImpressionZonePage DisplayAllGeneratedReportsList(IWebElement report)
        {
            report.Click();
            Thread.Sleep(3000);
            PreviousButton.Click();
            return new RapportImpressionZonePage(_driver, _wait);

        }

    }
}