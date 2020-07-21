using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NGEN
{
    public class InventoryStartTests
    {
        
        [Fact]
        public void SAVEbuttonShouldWork_WhenAllFieldsAreValid()
        {
            // Arrange 

            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            var webpage = new LoginPage(driver, wait);

            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);

            // Act

            webpage.Login().OpenPreparePage().OpenInventoryStartPropertiesTab()
            .SetDistrictNumberField("5430").SetSupervisorField("Martin Morris")
            .SetRGISPhoneField("56457648391").SetStreetAdressField("5th Flower Street")
            .SetInventoryDateField("16092020").SetCityStateFieldField("Miami Gardens, Florida")
            .SetStartTimeField("0400AM").SetStoreManagerField("George Blake")
            .SetEndTimeField("0600PM").SetStorePhoneField("1855667215")
            .SetNumbersOfAuditorsField("3").ClickOnSaveButton();

            // Assert

            var errorElements = driver.FindElements(By.ClassName("form-error"));
            Assert.True(errorElements.Count == 0);
            driver.Close();
        }

        [Theory]
        [InlineData("AbTest", false)]
        [InlineData("4356", true)]
        [InlineData("3452AbTest", false)]
        [InlineData("tEsT1234", false)]
        [InlineData("0123Test", false)]
        [InlineData("!?@#$%^&*()", false)]

        public void DistrictNumberField_Should_Accept_OnlyLettersAndNumbers(string districtNumberInput, bool expected )
        {
            // Arrange 

            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            var webpage = new LoginPage(driver, wait);

            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);


            // Act

            webpage.Login().OpenPreparePage().OpenInventoryStartPropertiesTab()
            .SetDistrictNumberField(districtNumberInput);

            // Assert

            AssertIfFormHasErrors(driver, expected);
            driver.Close();
        }

        [Theory]
        [InlineData("ABCtest", false)]
        [InlineData("#$%&*()-=+*>?!<>'/,.;'[]|@", false)]
        [InlineData("345(544)32", false)]
        [InlineData("345(544)3240", true)]
        public void StorePhoneField_Should_AcceptNumbersOnly(string storePhoneFieldInput, bool expected)
        {
            // Arrange 

            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            var webpage = new LoginPage(driver, wait);

            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);

            // Act

            webpage.Login().OpenPreparePage().OpenInventoryStartPropertiesTab().SetStorePhoneField(storePhoneFieldInput);

            // Assert

            AssertIfFormHasErrors(driver, expected);

            driver.Close();
        }

        [Theory]
        [InlineData("265700359", false)]
        [InlineData("2657003590", true)]
        public void StorePhoneField_Should_Accept_Minimum_10_Numbers(string storePhoneFieldInput, bool expected)
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            var webpage = new LoginPage(driver, wait);

            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);

            // Act

            webpage.Login().OpenPreparePage().OpenInventoryStartPropertiesTab().SetStorePhoneField(storePhoneFieldInput);

            // Assert

            AssertIfFormHasErrors(driver, expected);

            driver.Close();

        }

        [Theory]
        [InlineData("ABCtest", false)]
        [InlineData("#$%&*()-=+*>?!<>'/,.;'[]|@", false)]
        [InlineData("345(544)32", false)]
        [InlineData("345(544)3240", true)]
        public void RGISPhoneField_Should_AcceptNumbersOnly(string storePhoneFieldInput, bool expected)
        {
            // Arrange 

            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            var webpage = new LoginPage(driver, wait);

            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);

            // Act

            webpage.Login().OpenPreparePage().OpenInventoryStartPropertiesTab().SetRGISPhoneField(storePhoneFieldInput);

            // Assert

            AssertIfFormHasErrors(driver, expected);

            driver.Close();
        }

        private void AssertIfFormHasErrors(ChromeDriver driver, bool expected)
        {
            var errorElements = driver.FindElements(By.ClassName("form-error"));
            var result = errorElements.Count == 0;
            Assert.Equal(result, expected);
        }
    }
}

