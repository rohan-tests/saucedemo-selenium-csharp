using OpenQA.Selenium;

namespace Saucedemo.Pages.CheckoutPage
{
    public class CheckoutPage
    {
        private readonly IWebDriver driver;
        public CheckoutPage(IWebDriver driver) => this.driver = driver;

        private IWebElement First_name => driver.FindElement(By.Id("first-name"));
        private IWebElement Last_name => driver.FindElement(By.Id("last-name"));
        private IWebElement Postal_code => driver.FindElement(By.Id("postal-code"));
        private IWebElement Continue_button => driver.FindElement(By.Id("continue"));
        private IWebElement Finish_button => driver.FindElement(By.Id("finish"));
        private IWebElement SuccessMsg => driver.FindElement(By.ClassName("complete-header"));  
        public void EnterInfo(string firstName, string lastName, string zip)
        {
            First_name.SendKeys(firstName);
            Last_name.SendKeys(lastName);
            Postal_code.SendKeys(zip);
            Continue_button.Click();
        }

        public bool IsProductListed(string productName) => driver.PageSource.Contains(productName);

        public void FinishCheckout() => Finish_button.Click();


        public string GetConfirmationMessage() => SuccessMsg.Text;

    }
}
