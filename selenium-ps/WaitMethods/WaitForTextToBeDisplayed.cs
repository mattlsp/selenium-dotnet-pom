using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CRM_UI_Tests.WaitMethods
{
    class WaitForTextToBeDisplayed
    {
        private readonly IWebDriver Driver;

        public WaitForTextToBeDisplayed(IWebDriver driver)
        {
            Driver = driver;
        }

        public void WaitUntilTextIsPresent(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(45));
            wait.Timeout = TimeSpan.FromSeconds(45);
            wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            wait.Until(driver =>
            {

                if (element.Text != string.Empty)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            });
        }
        
        public void WaitUntilElementIsPresent(IWebElement element)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(Driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));
            fluentWait.Message = "Element to be searched not found";
        }

        public void WaitUntilElementIsVisible(By by)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

    }
}
