using NUnit.Framework;
using UiAutomationTests.Base;
using UiAutomationTests.Pages;

namespace UiAutomationTests.Tests
{
    public class LoginTests : BaseTest
    {
        private LoginPage _loginPage;

        [SetUp]
        public void TestSetup()
        {
            _loginPage = new LoginPage(Driver);
            _loginPage.GoToPage();
        }

        [Test]
        public void ValidLogin_ShouldNavigateToProductsPage()
        {
            _loginPage.Login("standard_user", "secret_sauce");
            Assert.That(Driver.Url, Does.Contain("inventory.html"));
        }

        [Test]
        public void InvalidLogin_ShouldShowErrorMessage()
        {
            _loginPage.Login("wrong_user", "wrong_pass");
            Assert.That(_loginPage.GetErrorMessage(), Does.Contain("Username and password do not match"));
        }
    }
}
