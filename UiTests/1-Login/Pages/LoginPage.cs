using OpenQA.Selenium;

namespace UiTests.Pages;

public class LoginPage
{
    private readonly IWebDriver _driver;

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
    }

    private IWebElement Username => _driver.FindElement(By.Id("user-name"));
    private IWebElement Password => _driver.FindElement(By.Id("password"));
    private IWebElement LoginButton => _driver.FindElement(By.Id("login-button"));

    public void GoToPage()
    {
        _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
    }

    public void Login(string user, string pass)
    {
        Username.SendKeys(user);
        Password.SendKeys(pass);
        LoginButton.Click();
    }
}
