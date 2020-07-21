using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Xunit;

namespace NGEN
{
    public class SmokeTests
    {
        [Fact]
        public void UserShouldLoginSuccessfully_WhenCredentialsAreValid_AndLogout()
        {
            // Arrange

            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0,0,5));

            var webpage = new LoginPage(driver, wait);            
           
            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);

            // Act

            webpage.Login().Logout();

            // Assert
            Thread.Sleep(2000);
            var loginUrl = "https://ngen-dev.rgiseu.com/#/login";
            var expectedUrl = driver.Url;

            Assert.True(loginUrl == driver.Url);

            driver.Close();

        }

        [Fact]
        public void UserShouldSuccesfullyNavigateToEveryNGENPage()
        {
            // Arrange

            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0,0,10));

            var webpage = new LoginPage(driver, wait);

            // Act

            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);
            webpage.Login().OpenPreparePage().OpenInventoryStartPropertiesTab().OpenManageCollectorUSBPage().OpenHandheldDevicesPage()
            .OpenProceduresPage().OpenConfigurationSummaryPage().OpenNotesPage().OpenPIVPage()
            .OpenViewPMFPage().OpenDepartmentsPage().OpenQuantityPage().OpenPreviousDataPage()
            .OpenExtraPage()
            .OpenCountPage().OpenLocationStatisticsPage().OpenMapViewPage().OpenListViewPage().OpenStatisticsPage()
            .OpenEditPage().OpenInterimReportPage()
            .OpenVerifyPage().OpenQueuePage().OpenAlterationsPage().OpenPieceCountPage().OpenVariancesPage()
            .OpenFinishPage().OpenFinalReportPreCloseoutChecksPage().OpenReportsOutputsAndFilesPage()
            .OpenCustomerEvaluationPIQAPage().OpenRGISEvaluationPage().OpenNGENFeedbackPage()
            .OpenCloseOutFinalChecksPage().OpenCloseEventPage();

            // Assert

            var closeEventUrl = "https://ngen-dev.rgiseu.com/#/finish/close-out/outputs";

            Assert.True( driver.Url == closeEventUrl);

            webpage.Logout();
             
            driver.Close();


        }

    }
}
