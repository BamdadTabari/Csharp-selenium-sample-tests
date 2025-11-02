using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace UiAutomationTests.Drivers
{
    public class DriverSetup
    {
        public IWebDriver Driver { get; private set; } = null!;

        public void StartBrowser(bool headless = false)
        {
            var options = new ChromeOptions();

            if (headless)
            {
                options.AddArgument("--headless");
                options.AddArgument("--disable-gpu");
            }

            options.AddArgument("--start-maximized");

            Driver = new ChromeDriver(options);
        }

        public void CloseBrowser()
        {
            Driver.Quit();
            //Driver.Dispose();
        }
    }
}
