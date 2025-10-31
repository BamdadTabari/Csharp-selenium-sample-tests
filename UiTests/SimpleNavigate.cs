using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using FluentAssertions;

namespace UiTests;

public class SmokeTests
{
    private IWebDriver _driver = null!;

    [SetUp]
    public void Setup()
    {
        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        var options = new ChromeOptions();
        options.AddArgument("--remote-allow-origins=*");
        // options.AddArgument("--headless=new"); // you can try headless if Chrome won't open
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");

        _driver = new ChromeDriver(options);
    }


    [Test]
    public void HomePage_Title_ShouldContainKeyword()
    {
        _driver.Navigate().GoToUrl("https://google.com/");
        _driver.Title.Should().Contain("Google");
    }

    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}
