
using CoreLayer.WebDriver.WebdriverWrapper;
using OpenQA.Selenium;

namespace BuisinessLayer.PageObjects
{
    public class ProductItemPage
    {
        private WebdriverWrapper driver;
        private readonly By ProductNameLocator = By.XPath("//div[@class = 'inventory_details_name large_size']");

        public ProductItemPage(WebdriverWrapper driver)
        {
            this.driver = driver;
        }

        public string GetProductName()
        {
            return driver.FindElement(ProductNameLocator).Text;
        }
    }
}
