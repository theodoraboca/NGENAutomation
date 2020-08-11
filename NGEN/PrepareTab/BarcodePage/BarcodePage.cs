using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGEN
{

    public class BarcodePage : PreparePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public BarcodePage(IWebDriver driver, WebDriverWait wait)
            : base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public IWebElement BarcodeImage => _driver.FindElement(By.CssSelector("img.barcode-image"));
        
    }
}

