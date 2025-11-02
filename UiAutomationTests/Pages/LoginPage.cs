using OpenQA.Selenium;

namespace UiAutomationTests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        // ✅ Locators
        private By UsernameInput => By.Id("user-name");
        private By PasswordInput => By.Id("password");
        private By LoginButton => By.Id("login-button");
        private By ErrorMessage => By.CssSelector("h3[data-test='error']");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // ✅ Actions
        public void GoToPage()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        public void Login(string username, string password)
        {
            _driver.FindElement(UsernameInput).SendKeys(username);
            _driver.FindElement(PasswordInput).SendKeys(password);
            _driver.FindElement(LoginButton).Click();
        }

        public string GetErrorMessage()
        {
            return _driver.FindElement(ErrorMessage).Text;
        }
    }
}
