
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Saucedemo.Pages.LoginPage;
using Saucedemo.Pages.ProductsPage;
using Saucedemo.Pages.CartPage;
using Saucedemo.Pages.CheckoutPage;
using System.Diagnostics;

[TestFixture]
[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class BaseTest
{
    protected Stopwatch watch;
    protected IWebDriver driver;
    protected LoginPage loginPage;
    protected ProductsPage productsPage;
    protected CartPage cartPage;
    protected CheckoutPage checkoutPage;
    [SetUp]
    public void SetUp()
    {
        watch = Stopwatch.StartNew();
        var options = new ChromeOptions();
        options.AddArgument("--incognito");
        driver = new ChromeDriver(options);
        // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        loginPage = new LoginPage(driver);
        productsPage = new ProductsPage(driver);
        cartPage = new CartPage(driver);
        checkoutPage = new CheckoutPage(driver);
    }
    [Test]
    public void CompleteCheckOutFlow()
    {
        loginPage.Login("standard_user", "secret_sauce");
        productsPage.AddProduct("sauce-labs-backpack");
        productsPage.AddProduct("sauce-labs-bike-light");
        Assert.That(productsPage.GetCartCount(), Is.EqualTo("2"));
        cartPage.GoToCart();
        cartPage.RemoveProduct("sauce-labs-bike-light");
        Assert.That(productsPage.GetCartCount(), Is.EqualTo("1"));
        Assert.That(cartPage.IsProductInCart("Sauce Labs Backpack"), Is.True);
        cartPage.Checkout();
        checkoutPage.EnterInfo("John", "Doe", "12345");
        Assert.That(checkoutPage.IsProductListed("Sauce Labs Backpack"), Is.True);
        checkoutPage.FinishCheckout();
        Assert.That(checkoutPage.GetConfirmationMessage(), Is.EqualTo("Thank you for your order!"));
    }
    [Test]
    public void CheckoutWithDiffItems()
    {
        loginPage.Login("standard_user", "secret_sauce");
        productsPage.AddProduct("sauce-labs-backpack");
        productsPage.AddProduct("sauce-labs-bike-light");
        productsPage.AddProduct("sauce-labs-bolt-t-shirt");
        Assert.That(productsPage.GetCartCount(), Is.EqualTo("3"));
        cartPage.GoToCart();
        cartPage.Checkout();
        checkoutPage.EnterInfo("John", "Doe", "12345");
        checkoutPage.FinishCheckout();
        Assert.That(checkoutPage.GetConfirmationMessage(), Is.EqualTo("Thank you for your order!"));
    }
    [Test]
    public void CartAbandonment()
    {
        loginPage.Login("standard_user", "secret_sauce");
        productsPage.AddProduct("sauce-labs-backpack");
        productsPage.AddProduct("sauce-labs-bike-light");
        Assert.That(productsPage.GetCartCount(), Is.EqualTo("2"));
        cartPage.GoToCart();
        cartPage.RemoveProduct("sauce-labs-backpack");
        cartPage.RemoveProduct("sauce-labs-bike-light");
        Assert.That(productsPage.GetCartCount(), Is.EqualTo(""));
        cartPage.LogOut();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        watch.Stop();
        Console.WriteLine($"[Selenium] Execution Time : {watch.ElapsedMilliseconds} ms");
    }

}
