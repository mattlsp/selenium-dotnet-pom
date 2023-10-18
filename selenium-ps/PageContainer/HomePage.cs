using OpenQA.Selenium;
using CRM_UI_Tests.WaitMethods;

namespace CRM_UI_Tests.PageContainer
{
	public class HomePage
	{
        private readonly IWebDriver Driver;

		WaitForTextToBeDisplayed waitForTextToBeDisplayed;
		
        public HomePage(IWebDriver driver)
		{
			Driver = driver;
			waitForTextToBeDisplayed = new WaitForTextToBeDisplayed(driver);
		}

        IWebElement CreateContactButton => Driver.FindElement(By.XPath("//span[contains(text(), 'Create Contact')]/.."));
        IWebElement SalesAndMarketingButton => Driver.FindElement(By.CssSelector("a[title='Sales & Marketing']"));
        IWebElement ContactsButton => Driver.FindElement(By.XPath("//a[contains(text(), 'Contacts')]"));

		public void ClickAtSalesAndMarketingButton()
		{
            waitForTextToBeDisplayed.WaitUntilElementIsVisible(By.Id("main-title"));
            waitForTextToBeDisplayed.WaitUntilElementIsVisible(By.CssSelector("a[title='Sales & Marketing']"));
            waitForTextToBeDisplayed.WaitUntilElementIsPresent(SalesAndMarketingButton);
            SalesAndMarketingButton.Click();
        }

        public void ClickContactsButton()
        {
            waitForTextToBeDisplayed.WaitUntilElementIsVisible(By.XPath("//a[contains(text(), 'Contacts')]"));
            waitForTextToBeDisplayed.WaitUntilElementIsPresent(ContactsButton);
            ContactsButton.Click();
        }

        public void ClickAtCreateContactButton()
		{
            waitForTextToBeDisplayed.WaitUntilElementIsVisible(By.XPath("//span[contains(text(), 'Create Contact')]/.."));
			waitForTextToBeDisplayed.WaitUntilElementIsPresent(CreateContactButton);
			CreateContactButton.Click();
		}
    }
}

