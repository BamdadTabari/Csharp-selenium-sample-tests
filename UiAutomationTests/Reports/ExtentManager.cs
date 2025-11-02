using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace UiAutomationTests.Reports
{
    public static class ExtentManager
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;

        public static ExtentReports GetExtent()
        {
            if (_extent == null)
            {
                // Get project root instead of bin directory
                string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;

                string reportsDirectory = Path.Combine(projectRoot, "Reports");
                Directory.CreateDirectory(reportsDirectory);

                string reportPath = Path.Combine(reportsDirectory, $"TestReport_{DateTime.Now:yyyyMMdd_HHmmss}.html");
                var htmlReporter = new ExtentSparkReporter(reportPath);

                _extent = new ExtentReports();
                _extent.AttachReporter(htmlReporter);
            }

            return _extent;
        }

        public static void FlushReport()
        {
            _extent?.Flush();
        }

        public static ExtentTest CreateTest(string testName)
        {
            _test = _extent.CreateTest(testName);
            return _test;
        }
    }
}
