using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Xunit;

namespace NGEN
{
    public class InterimReportsTests
    {
        // Test Case #1

        [Fact]
        public void watchButton_Should_Generate_SingleReport()
        {
            // Arrange

            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            var webpage = new LoginPage(driver, wait);

            // Act

            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);

            var interimReportPage = webpage.Login().OpenCountPage().OpenInterimReportPage();

            Thread.Sleep(3000);
            IWebElement RapportdeBalisage = driver.FindElement(By.XPath("//div[text()='Rapport de Balisage']"));

            var reportPage = interimReportPage.GenerateSingleReport(RapportdeBalisage);

            // Assert

            Assert.True(reportPage.NoErrorIsRaised() == true);

            driver.Close();

        }

        // Test Case #2

        [Fact]
        public void watchButton_Should_Generate_ParameterReport()
        {
            // Arrange

            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            var webpage = new LoginPage(driver, wait);

            // Act

            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);

            var interimReportPage = webpage.Login().OpenCountPage().OpenInterimReportPage();

            Thread.Sleep(3000);
            IWebElement RapportDetailZone = driver.FindElement(By.XPath("//div[text()='Rapport Détail Zone (Qté Cumule)']"));

            var reportPage = interimReportPage.GenerateParameterReport(RapportDetailZone);

            // Assert

            Assert.True(reportPage.NoErrorIsRaised() == true);

            driver.Close();

        }

        // Test Case #5
        [Fact]
        public void PrintButton_Should_Display_GeneratedReport()
        {
            // Arrange

            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            var webpage = new LoginPage(driver, wait);

            // Act

            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);
            var interimReportPage = webpage.Login().OpenCountPage().OpenInterimReportPage();

            Thread.Sleep(3000);
            IWebElement RapportDetailZone = driver.FindElement(By.XPath("//div[text()='Rapport Détail Zone (Qté Cumule)']"));

            var reportPage = interimReportPage.DisplayLastGeneratedReport(RapportDetailZone);

            // Assert

            Assert.True(reportPage.NoErrorIsRaised() == true);


            driver.Close();

        }

        // Test Case #6
        [Fact]
        public void PrintButton_Should_Generate_Error_When_NoReportIsGenerated()
        {
            // Arrange

            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            var webpage = new LoginPage(driver, wait);

            // Act

            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);

            var interimReportPage = webpage.Login().OpenCountPage().OpenInterimReportPage();

            Thread.Sleep(3000);
            IWebElement RapportdeDoublons = driver.FindElement(By.XPath("//div[text()='Rapport des Doublons']"));

            var reportPage = interimReportPage.GenerateSingleReport(RapportdeDoublons);

            // Assert

            Assert.True(reportPage.NoErrorIsRaised() == false);

            driver.Close();

        }

        // Test Case #7

        [Fact]
        public void PreviousButton_Should_Display_ListOf_GeneratedReports()
        {
            // Arrange

            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            var webpage = new LoginPage(driver, wait);

            // Act

            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);
            var interimReportPage = webpage.Login().OpenCountPage().OpenInterimReportPage();

            Thread.Sleep(3000);
            IWebElement RapportDetailZone = driver.FindElement(By.XPath("//div[text()='Rapport Détail Zone (Qté Cumule)']"));

            var reportPage = interimReportPage.DisplayAllGeneratedReportsList(RapportDetailZone);

            // Assert
            Assert.True(reportPage.NoErrorIsRaised() == true);


            driver.Close();


        }

        // Test Case #8

        [Fact]
        public void PreviousButton_Should_Display_Error_When_NoReportIsGenerated()
        {
            // Arrange

            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            var webpage = new LoginPage(driver, wait);

            // Act

            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);
            var interimReportPage = webpage.Login().OpenCountPage().OpenInterimReportPage();

            Thread.Sleep(3000);
            IWebElement RapportDetailZone = driver.FindElement(By.XPath("//div[text()='Rapport Détail Zone (Qté Cumule)']"));

            var reportPage = interimReportPage.DisplayAllGeneratedReportsList(RapportDetailZone);

            // Assert
            Assert.True(reportPage.NoErrorIsRaised() == false);


            driver.Close();


        }
    }
}