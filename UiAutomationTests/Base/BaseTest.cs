using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using UiAutomationTests.Drivers;
using UiAutomationTests.Reports;
using UiAutomationTests.Utilities;

namespace UiAutomationTests.Base
{
    public class BaseTest
    {
        protected IWebDriver Driver;
        protected ExtentReports Extent;
        protected ExtentTest Test;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Extent = ExtentManager.GetInstance();
        }

        [SetUp]
        public void Setup()
        {
            Driver = DriverFactory.CreateDriver("chrome");
        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var testName = TestContext.CurrentContext.Test.Name;

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var screenshotPath = ScreenshotHelper.CaptureScreenshot(Driver, testName);
                Test.Fail("Test failed").AddScreenCaptureFromPath(screenshotPath);
            }

            Driver.Quit();
            Driver.Dispose();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ExtentManager.FlushReport();
        }
    }
}
