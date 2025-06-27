using OpenQA.Selenium;

namespace Saucedemo.Pages.CartPage
{
    public class CartPage
    {
        private readonly IWebDriver driver;
        public CartPage(IWebDriver driver) => this.driver = driver;

        private IWebElement Cart_button => driver.FindElement(By.ClassName("shopping_cart_link"));
        private IWebElement Checkout_button => driver.FindElement(By.Id("checkout"));
        private IWebElement Menu_button => driver.FindElement(By.Id("react-burger-menu-btn"));
        private IWebElement Logout_button => driver.FindElement(By.Id("logout_sidebar_link"));

        public void GoToCart() => Cart_button.Click();

        public void RemoveProduct(string productId) => driver.FindElement(By.Id($"remove-{productId}")).Click();

        public bool IsProductInCart(string productName) => driver.PageSource.Contains(productName);

        public void Checkout()
        {
            //manaul wait added for testing
            // IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            // js.ExecuteScript(@"
            // var e1 = document.querySelector('#checkout');
            // if(e1){
            // e1.remove();
            // setTimeout(()=>{
	        // document.querySelector('.cart_footer').appendChild(e1);
            // }, 3000);
            // }");
            Checkout_button.Click();
        }

        public void LogOut()
        {
            Menu_button.Click();
            Logout_button.Click();
        }

    }
}
