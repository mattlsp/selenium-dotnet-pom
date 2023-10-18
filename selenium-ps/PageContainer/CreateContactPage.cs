using CRM_UI_Tests.WaitMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CRM_UI_Tests.PageContainer
{
	public class CreateContactPage
	{
        private readonly IWebDriver Driver;

        WaitForTextToBeDisplayed waitForTextToBeDisplayed;

        public CreateContactPage(IWebDriver driver)
        {
            Driver = driver;
            waitForTextToBeDisplayed = new WaitForTextToBeDisplayed(driver);
        }

        IWebElement FirstNameInput => Driver.FindElement(By.Id("DetailFormfirst_name-input"));
        IWebElement LastNameInput => Driver.FindElement(By.Id("DetailFormlast_name-input"));
        IWebElement RoleDropdown => Driver.FindElement(By.Id("DetailFormbusiness_role-input"));
        IWebElement RoleCEO => Driver.FindElement(By.XPath("//div[contains(text(), 'CEO')]"));
        IWebElement SaveButton => Driver.FindElement(By.Id("DetailForm_save2-label"));
        IWebElement FormHeader => Driver.FindElement(By.XPath("//div[@id='_form_header']/h3"));
        IWebElement BusinessRole => Driver.FindElement(By.XPath("//p[text()='Business Role']/following-sibling::div"));
        IWebElement DeleteButton => Driver.FindElement(By.Id("DetailForm_delete-label"));

        public void ClickAtFirstNameInput()
        {
            waitForTextToBeDisplayed.WaitUntilElementIsVisible(By.Id("DetailFormfirst_name-input"));
            waitForTextToBeDisplayed.WaitUntilElementIsPresent(FirstNameInput);
            FirstNameInput.Click();
        }

        public void ClickAtLastNameInput()
        {
            waitForTextToBeDisplayed.WaitUntilElementIsVisible(By.Id("DetailFormlast_name-input"));
            waitForTextToBeDisplayed.WaitUntilElementIsPresent(FirstNameInput);
            LastNameInput.Click();
        }

        public void TypeAtFirstNameInput(string firstName)
        {
            FirstNameInput.SendKeys(firstName);
        }

        public void TypeAtLastNameInput(string lastName)
        {
            LastNameInput.SendKeys(lastName);
        }

        public void ClickAtRoleDropdown() 
        {
            var js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollBy(0, 500);");
            waitForTextToBeDisplayed.WaitUntilElementIsVisible(By.Id("DetailFormbusiness_role-input"));
            waitForTextToBeDisplayed.WaitUntilElementIsPresent(RoleDropdown);
            RoleDropdown.Click();
        }

        public void SelectRoleCEO()
        {
            waitForTextToBeDisplayed.WaitUntilElementIsVisible(By.XPath("//div[contains(text(), 'CEO')]"));
            waitForTextToBeDisplayed.WaitUntilElementIsPresent(RoleCEO);
            RoleCEO.Click();
        }

        public void ClickAtSaveButton()
        {
            SaveButton.Click();
        }

        public string GetValueOfFormHeader()
        {
            waitForTextToBeDisplayed.WaitUntilElementIsVisible(By.XPath("//div[@id='_form_header']/h3"));
            waitForTextToBeDisplayed.WaitUntilElementIsPresent(FormHeader);
            string headerInnerText = FormHeader.Text;
            return headerInnerText;
        }

        public string GetValueOfBusinessRole()
        {
            string businessRoleText = BusinessRole.Text;
            return businessRoleText;
        }

        public void ClickAtDeleteButton()
        {
            var js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollBy(0, -500);");
            waitForTextToBeDisplayed.WaitUntilElementIsVisible(By.Id("DetailForm_delete-label"));
            waitForTextToBeDisplayed.WaitUntilElementIsPresent(DeleteButton);
            DeleteButton.Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Accept();
        }
    }
}

