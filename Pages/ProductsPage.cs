using OpenQA.Selenium;

namespace Saucedemo.Pages.ProductsPage
{
    public class ProductsPage
    {
        private readonly IWebDriver driver;
        public ProductsPage(IWebDriver driver) => this.driver = driver;
        public void AddProduct(string productId) =>
            driver.FindElement(By.Id($"add-to-cart-{productId}")).Click();

        public string GetCartCount()
        {
            var cartElements = driver.FindElements(By.ClassName("shopping_cart_badge"));
            if (cartElements.Count > 0)
            {
                return cartElements[0].Text;
            }
            return "";
        }
    }
}
