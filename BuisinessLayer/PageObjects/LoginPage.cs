using CoreLayer.WebDriver.WebdriverWrapper;
using OpenQA.Selenium;

namespace BuisinessLayer.PageObjects
{
    public class LoginPage
    {
        private WebdriverWrapper driver;

        public LoginPage(WebdriverWrapper driver)
        {
            this.driver = driver;
        }

        private readonly By userNameLocator = By.Id("user-name");
        private readonly By passwordLocator = By.Id("password");
        private readonly By LoginButtonLocator = By.Id("login-button");

        public MainPage Login(string password, string login)
        {
            driver.EnterText(userNameLocator, login);
            driver.EnterText(passwordLocator, password);
            driver.Click(LoginButtonLocator);

            return new MainPage(driver);
        }

    }
}
