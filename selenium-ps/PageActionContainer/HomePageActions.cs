using CRM_UI_Tests.PageContainer;

namespace CRM_UI_Tests.PageActionContainer
{
	public class HomePageActions
	{
		private HomePage homePage;

		public HomePageActions(HomePage homePage)
		{
			this.homePage = homePage;
		}

		public void GoToCreateContact()
		{
			homePage.ClickAtSalesAndMarketingButton();
			homePage.ClickContactsButton();
			homePage.ClickAtCreateContactButton();
		}
	}
}

