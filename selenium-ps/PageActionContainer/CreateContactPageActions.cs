using CRM_UI_Tests.PageContainer;

namespace CRM_UI_Tests.PageActionContainer
{
    public class CreateContactPageActions
    {
        private CreateContactPage createContactPage;

        public CreateContactPageActions(CreateContactPage createContactPage)
        {
            this.createContactPage = createContactPage;
        }

        public void CreateNewContact()
        {
            createContactPage.ClickAtFirstNameInput();
            createContactPage.TypeAtFirstNameInput("FirstName");
            createContactPage.ClickAtLastNameInput();
            createContactPage.TypeAtLastNameInput("LastName");
            createContactPage.ClickAtRoleDropdown();
            createContactPage.SelectRoleCEO();
            createContactPage.ClickAtSaveButton();
        }

        public void VerifyNewContact()
        {
            StringAssert.Contains("FirstName", createContactPage.GetValueOfFormHeader());
            StringAssert.Contains("LastName", createContactPage.GetValueOfFormHeader());
            StringAssert.Contains("CEO", createContactPage.GetValueOfBusinessRole());
        }

        public void DeleteContact()
        {
            createContactPage.ClickAtDeleteButton();
        }
    }
}
