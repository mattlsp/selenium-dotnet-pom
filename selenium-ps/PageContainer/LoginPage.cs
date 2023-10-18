using OpenQA.Selenium;

namespace CRM_UI_Tests.PageObjectModels
{
	public class LoginPage
	{
		private readonly IWebDriver Driver;

		public LoginPage(IWebDriver driver)
		{
			Driver = driver;
		}

        IWebElement LoginField => Driver.FindElement(By.Id("login_user"));
        IWebElement PasswordField => Driver.FindElement(By.Id("login_pass"));
        IWebElement SubmitButton => Driver.FindElement(By.Id("login_button"));

        public string GetPageTitle()
        {
            return Driver.Title;
        }
        public string GetPageURL()
        {
            return Driver.Url;
        }
        public void ClearLoginField()
        {
            LoginField.Clear();
        }
        public void TypeIntoLoginField(string loginName)
        {
            LoginField.SendKeys(loginName);
        }
        public void ClearPasswordField()
        {
            PasswordField.Clear();
        }
        public void TypeIntoPasswordField(string passwordValue)
        {
            PasswordField.SendKeys(passwordValue);
        }

        public void ClickAtSubmitButton()
        {
            SubmitButton.Click();
        }
    }

}

