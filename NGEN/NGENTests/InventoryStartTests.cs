using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;
using Xunit;

namespace NGEN
{
    public class InventoryStartTests
    {
        // TestCase #01

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

            AssertIfFormHasErrors(driver, true);

            driver.Close();
        }

        // TestCase #02

        [Theory]
        [InlineData("AbTest", false)]
        [InlineData("4356", true)]
        [InlineData("3452AbTest", false)]
        [InlineData("tEsT1234", false)]
        [InlineData("0123Test", false)]
        [InlineData("!?@#$%^&*()", false)]

        public void DistrictNumberField_Should_Accept_OnlyLettersAndNumbers(string districtNumberInput, bool expected)
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

        // TestCase #03

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

        // TestCase #04

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

        // TestCase #05

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

        // TestCase #06

        [Theory]
        [InlineData("265700359", false)]
        [InlineData("2657003590", true)]
        public void RGISPhoneField_Should_Accept_Minimum_10_Numbers(string rgisPhoneFieldInput, bool expected)
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            var webpage = new LoginPage(driver, wait);

            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);

            // Act

            webpage.Login().OpenPreparePage().OpenInventoryStartPropertiesTab().SetRGISPhoneField(rgisPhoneFieldInput);

            // Assert

            AssertIfFormHasErrors(driver, expected);

            driver.Close();

        }

        // TestCase #07

        [Fact]
        public void InputFields_Should_Accept_50characters()
        {

            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            var webpage = new LoginPage(driver, wait);

            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);

            // Act
            webpage.Login().OpenPreparePage().OpenInventoryStartPropertiesTab();

            var inputElements = driver.FindElements(By.XPath("//form//input[contains(@class,'form-input') and contains(@type, 'text')]"));

            var stringMaxCharacters = "12345678901234567890123456789012345678901234567890";

            inputElements.ToList().ForEach(inputElement =>
            {
                inputElement.Clear();
                inputElement.SendKeys(stringMaxCharacters = "12345678901234567890123456789012345678901234567890"
);
            });


            var allElementsHaveMaxValue = inputElements.All(inputElement => inputElement.GetAttribute("value") == stringMaxCharacters);

            // Assert

            Assert.True(allElementsHaveMaxValue);

            driver.Close();

        }

        // TestCase #08

        [Fact]
        public void InputFields_Should_Accept_Maximum_50characters()
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            var webpage = new LoginPage(driver, wait);

            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);

            // Act
            webpage.Login().OpenPreparePage().OpenInventoryStartPropertiesTab();

            var inputElements = driver.FindElements(By.XPath("//form//input[contains(@class,'form-input') and contains(@type, 'text')]"));

            var stringCharacters = "123456789012345678901234567890123456789012345678901";
            var stringMaxCharacters = "12345678901234567890123456789012345678901234567890";

            inputElements.ToList().ForEach(inputElement =>
            {
                inputElement.Clear();
                inputElement.SendKeys(stringCharacters);
            });

            var allElementsHaveMaxValue = inputElements.All(inputElement => inputElement.GetAttribute("value") == stringMaxCharacters);

            // Assert

            Assert.True(allElementsHaveMaxValue);

            driver.Close();

        }

        // TestCase #09

        [Fact]
        public void InvalidDateTime_Should_Not_BeAccepted_ByForm()
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            var webpage = new LoginPage(driver, wait);

            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);

            // Act
            webpage.Login().OpenPreparePage().OpenInventoryStartPropertiesTab().SetInventoryDateField("16092020")
            .SetStartTimeField("0600PM")
            .SetEndTimeField("0400PM");

            // Assert

            AssertIfFormHasErrors(driver, true);

            driver.Close();

        }

        // TestCase #10

        [Theory]
        [InlineData("-2", false)]
        [InlineData("0", true)]
        [InlineData("5", true)]

        public void NumberOfAuditors_Should_NotBe_LessThan_0(string auditorsNumbers, bool expected)
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            var webpage = new LoginPage(driver, wait);

            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);

            // Act
            webpage.Login().OpenPreparePage().OpenInventoryStartPropertiesTab().SetNumbersOfAuditorsField(auditorsNumbers);

            // Assert

            AssertIfFormHasErrors(driver, expected);

            driver.Close();
        }

        // TestCase #11

        // [Fact]
        // public void NumberOfAuditors_Should_NotBe_Empty()
        // {
        // var driver = new ChromeDriver();
        //  var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

        //  var webpage = new LoginPage(driver, wait);

        //  driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);

        // Act
        //  var startInventoryStartPropertiesPage =  webpage.Login().OpenPreparePage().OpenInventoryStartPropertiesTab().SetNumbersOfAuditorsField("3");

        //   startInventoryStartPropertiesPage.NumbersOfAuditorsField.Clear();

        // Assert

        //   AssertIfFormHasErrors(driver, false);

        //    driver.Close();
        // 

        //}


        // Test Case 12

        [Fact]
        public void SaveButtonRaisesError_When_ARequiredField_IsNot_Completed()
        {
            // Arrange 

            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            var webpage = new LoginPage(driver, wait);

            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);

            // Act

            var StartInventoryStartPropertiesPage = webpage.Login().OpenPreparePage().OpenInventoryStartPropertiesTab()
           .SetDistrictNumberField("5430").SetSupervisorField("Martin Morris")
           .SetRGISPhoneField("56457648391").SetStreetAdressField(" ")
           .SetInventoryDateField("16092020").SetCityStateFieldField("Miami Gardens, Florida")
           .SetStartTimeField("0400AM").SetStoreManagerField("George Blake")
           .SetEndTimeField("0600PM").SetStorePhoneField("1855667215")
           .SetNumbersOfAuditorsField("3");

            StartInventoryStartPropertiesPage.SaveButton.Click();

            // Assert

            AssertIfFormHasErrors(driver, false);
            driver.Close();

        }

        // Test Case 13

        [Fact]
        public void SaveButtonWorks_When_A_NonRequiredField_IsNot_Completed()
        {
            // Arrange 

            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            var webpage = new LoginPage(driver, wait);

            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);

            // Act

            var StartInventoryStartPropertiesPage = webpage.Login().OpenPreparePage().OpenInventoryStartPropertiesTab()
           .SetDistrictNumberField("5430").SetSupervisorField("Martin Morris")
           .SetRGISPhoneField("56457648391").SetStreetAdressField("5th Flower Street")
           .SetInventoryDateField("16092020").SetCityStateFieldField("Miami Gardens, Florida")
           .SetStartTimeField("0400AM").SetStoreManagerField("George Blake")
           .SetEndTimeField("0600PM").SetNumbersOfAuditorsField("3");

            StartInventoryStartPropertiesPage.SaveButton.Click();

            // Assert

            AssertIfFormHasErrors(driver, true);
            driver.Close();

        }

        // Test Case 14

        [Fact]
        public void NewInsertedDataInField_IsNotSaved_If_TheSaveButtonIsNotClickedOn()
        {
            // Arrange 

            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            var webpage = new LoginPage(driver, wait);

            driver.Navigate().GoToUrl(CustomNGENConfiguration.DefaultConfiguration["Url"]);

            // Act

            var StartInventoryStartPropertiesPage = webpage.Login().OpenPreparePage().OpenInventoryStartPropertiesTab().SetStoreManagerField("John Smith");

            driver.Navigate().Refresh();

            // Assert
            var storeManagerName = StartInventoryStartPropertiesPage.StoreManagerField.GetAttribute("value");
            var currentStoreManagerName = "George Blake";
            Assert.True(storeManagerName == currentStoreManagerName);
           
            driver.Close();
        }


            private void AssertIfFormHasErrors(ChromeDriver driver, bool expected)
        {
            Thread.Sleep(2000);
            var errorElements = driver.FindElements(By.ClassName("form-error"));
            var result = errorElements.Count == 0;
            Assert.Equal(result, expected);
        }


    }
}

