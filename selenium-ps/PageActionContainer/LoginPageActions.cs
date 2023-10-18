using CRM_UI_Tests.PageObjectModels;

namespace CRM_UI_Tests.PageActionContainer
{
    public class LoginPageActions
	{
		private LoginPage loginPage;

		public LoginPageActions(LoginPage loginPage)
		{
			this.loginPage = loginPage;
		}

		public void VerifyLoginPage()
		{
			Assert.AreEqual("Login | 1CRM System", loginPage.GetPageTitle());
		}

        public void Login(string loginName, string password)
        {
            loginPage.ClearLoginField();
            loginPage.ClearPasswordField();
            loginPage.TypeIntoLoginField(loginName);
            loginPage.TypeIntoPasswordField(password);
            loginPage.ClickAtSubmitButton();
        }
    }
}

