using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace CoreLayer.WebDriver.WebdriverWrapper
{
    public partial class WebdriverWrapper
    {
        public void Click(By by)
        {
            WaitForElementToBePresent(_driver, by, _timeout)?.Click();
        }

        public void EnterText(By by, string text)
        {
            var element = WaitForElementToBePresent(_driver, by, _timeout);
            element.Clear();
            element.SendKeys(text);
        }

        public IReadOnlyCollection<IWebElement> FindElements(By by)
        {
            var elementPresent = WaitForElementToBePresent(_driver, by, _timeout);
            return elementPresent.FindElements(by);
        }

        public IWebElement FindElement(By by)
        {
            var elementPresent = WaitForElementToBePresent(_driver, by, _timeout);
            return elementPresent.FindElement(by);
        }

        public IWebElement FindChildByName(By byParent, string childName)
        {
            var elementParent = WaitForElementToBePresent(_driver, byParent, _timeout);
            return elementParent.FindElement(By.Name(childName));
        }

        public void ClickAndSendAction(IWebElement element, string textToSend)
        {
            var clickAndSendKeysActions = new Actions(_driver);
            clickAndSendKeysActions.Click(element)
                .Pause(TimeSpan.FromSeconds(1))
                .SendKeys(textToSend)
                .Perform();
        }

        public IWebElement WaitForElementToBePresent(IWebDriver Driver, By by, TimeSpan _timeout)
        {
            var wait = new WebDriverWait(Driver, _timeout);
            return wait.Until(drv =>
            {
                try
                {
                    var element = drv.FindElement(by);
                    if (element != null && element.Displayed)
                        return element;
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("WaitForElementToBePresent method: 'NoSuchElementException' is found.");
                }

                return null;
            });
        }
    }
}
