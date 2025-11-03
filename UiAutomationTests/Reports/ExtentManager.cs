using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace UiAutomationTests.Reports
{
    public static class ExtentManager
    {
        private static ExtentReports? _extent;
        private static ExtentTest? _test;

        public static ExtentReports GetInstance()
        {
            if (_extent == null)
            {
                var reportsPath = Path.Combine(
                    Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName,
                    "Reports", "HTMLReports"
                );

                Directory.CreateDirectory(reportsPath);

                var htmlReporter = new ExtentSparkReporter(
                    Path.Combine(reportsPath, $"TestReport_{DateTime.Now:yyyyMMdd_HHmmss}.html")
                );

                _extent = new ExtentReports();
                _extent.AttachReporter(htmlReporter);
            }

            return _extent;
        }

        public static ExtentTest CreateTest(string testName)
        {
            _test = GetInstance().CreateTest(testName);
            return _test;
        }

        public static void FlushReport()
        {
            _extent?.Flush();
        }
    }
}
