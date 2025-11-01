using NUnit.Framework;
using FluentAssertions;
using UiTests.Pages;

namespace UiTests.Tests;

public class LoginTests : BaseTest
{
    [Test]
    public void SuccessfulLogin_ShouldNavigateToInventoryPage()
    {
        var login = new LoginPage(driver);
        login.GoToPage();
        login.Login("standard_user", "secret_sauce");

        driver.Url.Should().Contain("inventory");
    }
}
