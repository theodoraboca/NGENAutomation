using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace NGEN
{
    public class BarcodeTests
    {
        [Fact]
        public void CheckIf_BarcodeImage_IsVisible()
        {
            // Arrange 

            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            var webpage = new LoginPage(driver, wait);

            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);

            // Act

            webpage.Login().OpenPreparePage().OpenBarcodePage();

            var barcodeImageCssSelector = "img.barcode-image";

            // Assert
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(barcodeImageCssSelector)));

            Assert.True(driver.FindElementByCssSelector(barcodeImageCssSelector).Displayed);

            driver.Close();
        }

    }
}
