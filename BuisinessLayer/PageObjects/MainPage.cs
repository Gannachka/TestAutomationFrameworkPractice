using CoreLayer.WebDriver.WebdriverWrapper;
using OpenQA.Selenium;

namespace BuisinessLayer.PageObjects
{
    public class MainPage
    {
        private WebdriverWrapper driver;
       // private readonly By productNameLocator = By.XPath("//a[./div[@class = 'inventory_item_name ']]");
        private readonly By productNameLocator = By.Id("item_4_title_link");

        public MainPage(WebdriverWrapper driver)
        {
            this.driver = driver;
        }

        public ProductItemPage ClickProductByTitle()
        {
          // var itemButton =  driver.FindElements(productNameLocator).First(element => element.Text.Equals(title));
          // itemButton.Click();
          driver.Click(productNameLocator);
            return new ProductItemPage(driver);
        }
    }
}
