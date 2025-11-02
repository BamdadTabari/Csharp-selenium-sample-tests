using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UiAutomationTests.Reports;
using AventStack.ExtentReports;
using UiAutomationTests.Helpers;

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
            Extent = ExtentManager.GetExtent();
        }

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            Driver = new ChromeDriver(options);

            Test = ExtentManager.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = TestContext.CurrentContext.Result.StackTrace;
            var message = TestContext.CurrentContext.Result.Message;
            var testName = TestContext.CurrentContext.Test.Name;

            switch (status)
            {
                case NUnit.Framework.Interfaces.TestStatus.Passed:
                    Test.Pass("✅ Test passed!");
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    Test.Fail($"❌ Test failed: {message}");
                    Test.Fail(stacktrace);
                    string screenshotPath = ScreenshotHelper.CaptureScreenshot(Driver, testName);
                    if (screenshotPath != null)
                    {
                        Test.AddScreenCaptureFromPath(screenshotPath);
                        Test.Fail($"Test failed — screenshot attached: {testName}");
                    }
                    break;
                default:
                    Test.Skip("⚠️ Test skipped.");
                    break;
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
