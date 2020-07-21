using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NGEN
{
    public class StartInventoryStartPropertiesPage : PreparePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public StartInventoryStartPropertiesPage(IWebDriver driver, WebDriverWait wait)
            : base(driver, wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public static string FormsCSSSelector = "input.form-input";

        public IWebElement DistrictNumberField => _driver.FindElements(By.CssSelector(FormsCSSSelector))[1];
        public IWebElement SupervisorField => _driver.FindElements(By.CssSelector(FormsCSSSelector))[2];
        public IWebElement RGISPhoneField => _driver.FindElements(By.CssSelector(FormsCSSSelector))[3];
        public IWebElement StreetAddressField => _driver.FindElements(By.CssSelector(FormsCSSSelector))[4];
        public IWebElement InventoryDateField => _driver.FindElements(By.CssSelector(FormsCSSSelector))[5];
        public IWebElement CityStateField => _driver.FindElements(By.CssSelector(FormsCSSSelector))[6];
        public IWebElement StartTimeField => _driver.FindElements(By.CssSelector(FormsCSSSelector))[7];
        public IWebElement StoreManagerField => _driver.FindElements(By.CssSelector(FormsCSSSelector))[8];
        public IWebElement EndTimeField => _driver.FindElements(By.CssSelector(FormsCSSSelector))[9];
        public IWebElement StorePhoneField => _driver.FindElements(By.CssSelector(FormsCSSSelector))[10];
        public IWebElement NumbersOfAuditorsField => _driver.FindElements(By.CssSelector(FormsCSSSelector))[11];
        public IWebElement SaveButton => _driver.FindElement(By.CssSelector("button.form-button.btn.btn-primary"));
        public IWebElement YesConfirmationSaveButton => _driver.FindElement(By.CssSelector("button.modal-rgis-button"));
        public IWebElement ManageCollectorUSBButton => _driver.FindElements(By.CssSelector(RedTabCSSSelector))[1];

        public ManageCollectorUSBPage OpenManageCollectorUSBPage()
        {
            ManageCollectorUSBButton.Click();
            return new ManageCollectorUSBPage(_driver, _wait);
        }

        private StartInventoryStartPropertiesPage EditFormField(IWebElement formField, string fieldValue)
        {
            formField.Clear();
            formField.SendKeys(fieldValue);
            return this;
        }
        public StartInventoryStartPropertiesPage SetDistrictNumberField(string districtNumber)
        {
            return EditFormField(DistrictNumberField, districtNumber);
        }
        public StartInventoryStartPropertiesPage SetSupervisorField(string supervisorName)
        {
            return EditFormField(SupervisorField, supervisorName);
        }

        public StartInventoryStartPropertiesPage SetRGISPhoneField(string rgisPhoneNumber)
        {
            return EditFormField(RGISPhoneField, rgisPhoneNumber);
        }

        public StartInventoryStartPropertiesPage SetStreetAdressField(string streetAdress)
        {
            return EditFormField(StreetAddressField, streetAdress);
        }

        public StartInventoryStartPropertiesPage SetInventoryDateField(string inventoryDate)
        {
            return EditFormField(InventoryDateField, inventoryDate);
        }

        public StartInventoryStartPropertiesPage SetCityStateFieldField(string cityState)
        {
            return EditFormField(CityStateField, cityState);
        }

        public StartInventoryStartPropertiesPage SetStartTimeField(string startTime)
        {
            return EditFormField(StartTimeField, startTime);
        }

        public StartInventoryStartPropertiesPage SetStoreManagerField(string storeManager)
        {
            return EditFormField(StoreManagerField, storeManager);
        }

        public StartInventoryStartPropertiesPage SetEndTimeField(string endTime)
        {
            return EditFormField(EndTimeField, endTime);
        }

        public StartInventoryStartPropertiesPage SetStorePhoneField(string storePhone)
        {
            return EditFormField(StorePhoneField, storePhone);
        }

        public StartInventoryStartPropertiesPage SetNumbersOfAuditorsField(string numbersOfAuditors)
        {
            return EditFormField(NumbersOfAuditorsField, numbersOfAuditors);
        }

        public StartInventoryStartPropertiesPage ClickOnSaveButton()
        {
            SaveButton.Click();
            _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button.modal-rgis-button")));
            YesConfirmationSaveButton.Click();
            return this;
        }









    }
}