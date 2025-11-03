using OpenQA.Selenium;

namespace UiAutomationTests.Utilities
{
    public static class ScreenshotHelper
    {
        public static string CaptureScreenshot(IWebDriver driver, string testName)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var screenshotsDir = Path.Combine(
                Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName,
                "Reports", "Screenshots"
            );

            Directory.CreateDirectory(screenshotsDir);

            var filePath = Path.Combine(screenshotsDir, $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            screenshot.SaveAsFile(filePath);
            return filePath;
        }
    }
}
