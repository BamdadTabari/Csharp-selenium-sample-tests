using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using UiAutomationTests.Reports;
using UiAutomationTests.Helpers;

namespace UiAutomationTests.Tests
{
    [TestFixture]
    public class HomeTests
    {
        private IWebDriver _driver;
        private ExtentReports _extent;
        private ExtentTest _test;

        [SetUp]
        public void Setup()
        {
            _extent = ExtentManager.GetExtent();
            _test = ExtentManager.CreateTest(TestContext.CurrentContext.Test.Name);
            _driver = new OpenQA.Selenium.Chrome.ChromeDriver();
        }

        [Test]
        public void GoogleSearch_ValidQuery_ShouldDisplayResults()
        {
            _driver.Navigate().GoToUrl("https://www.google.com");
            _test.Info("Navigated to Google");

            var searchBox = _driver.FindElement(By.Name("q"));
            searchBox.SendKeys("Selenium WebDriver");
            searchBox.Submit();

            Assert.That(true == _driver.Title.Contains("Selenium"), "page is not valid");
            _test.Pass("Google search successful");
        }

        [TearDown]
        public void Teardown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var testName = TestContext.CurrentContext.Test.Name;

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                string screenshotPath = ScreenshotHelper.CaptureScreenshot(_driver, testName);
                if (screenshotPath != null)
                {
                    _test.AddScreenCaptureFromPath(screenshotPath);
                    _test.Fail($"Test failed — screenshot attached: {testName}");
                }
            }

            _driver.Quit();
            _driver.Dispose();
            ExtentManager.FlushReport();
        }
    }
}
