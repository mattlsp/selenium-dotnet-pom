using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CRM_UI_Tests.PageActionContainer;
using CRM_UI_Tests.PageContainer;
using CRM_UI_Tests.PageObjectModels;

namespace CRM_UI_Tests;

public class Tests
{
    IWebDriver driver;

    [SetUp]
    public void Start_Browser_And_Login()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://demo.1crmcloud.com");

        var loginPage = new LoginPage(driver);
        var loginPageActions = new LoginPageActions(loginPage);

        loginPageActions.VerifyLoginPage();
        loginPageActions.Login("admin", "admin");
    }

    [Test]
    public void Create_Contact_Verify_Delete()
    {
        var homePage = new HomePage(driver);
        var homePageActions = new HomePageActions(homePage);
        var createContactPage = new CreateContactPage(driver);
        var createContactPageActions = new CreateContactPageActions(createContactPage);

        homePageActions.GoToCreateContact();
        createContactPageActions.CreateNewContact();
        createContactPageActions.VerifyNewContact();
        createContactPageActions.DeleteContact();
    }

    [TearDown]
    public void Close_Browser()
    {
        driver.Quit();
    }
}
