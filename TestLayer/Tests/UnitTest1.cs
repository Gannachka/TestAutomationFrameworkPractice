using BuisinessLayer.PageObjects;
using CoreLayer;
using CoreLayer.WebDriver.WebdriverWrapper;
using NUnit.Framework.Internal;

namespace TestLayer.Tests
{
    public class Tests
    {
        public WebdriverWrapper Browser { get; private set; }

        [SetUp]
        public void Setup()
        {
            var browserType = (BrowserType)Enum.Parse(typeof(BrowserType), Configuration.BrowserType);

            Browser = new WebdriverWrapper(browserType);
            Browser.StartBrowser();
            Browser.NavigateTo(Configuration.AppUrl);
        }

        [Test]
        public void Test1()
        {
            LoginPage loginPage = new LoginPage(Browser);
            string productTitle = "Sauce Labs Backpack";

            var productNameOnProductPage = loginPage.Login("secret_sauce", "standard_user")
                .ClickProductByTitle()
                .GetProductName();

            Assert.That(productNameOnProductPage, Is.EqualTo(productTitle));
        }
        [Test]
        public void Test2()
        {
            LoginPage loginPage = new LoginPage(Browser);
            string productTitle = "Sauce Labs Backpack";

            var productNameOnProductPage = loginPage.Login("secret_sauce", "standard_user")
                .ClickProductByTitle()
                .GetProductName();

            Assert.That(productNameOnProductPage, Is.EqualTo("Dog"));
        }

        [Test]
        public void Test3()
        {
            LoginPage loginPage = new LoginPage(Browser);
            string productTitle = "Sauce Labs Backpack";

            var productNameOnProductPage = loginPage.Login("secret_sauce", "standard_user")
                .ClickProductByTitle()
                .GetProductName();

            Assert.That(productNameOnProductPage, Is.EqualTo(productTitle));
        }

        [Test]
        public void Test4()
        {
            LoginPage loginPage = new LoginPage(Browser);
            string productTitle = "Sauce Labs Backpack";

            var productNameOnProductPage = loginPage.Login("secret_sauce", "standard_user")
                .ClickProductByTitle()
                .GetProductName();

            Assert.That(productNameOnProductPage, Is.EqualTo("Cat"));
        }
        [TearDown]
        public void Teardown()
        {
            Browser.Close();
        }
    }
}