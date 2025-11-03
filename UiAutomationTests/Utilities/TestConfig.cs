using Microsoft.Extensions.Configuration;

namespace UiAutomationTests.Utilities
{
    public static class TestConfig
    {
        private static IConfigurationRoot _config;

        static TestConfig()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public static string Browser => _config["TestSettings:Browser"];
        public static string BaseUrl => _config["TestSettings:BaseUrl"];
        public static int ImplicitWaitSeconds => int.Parse(_config["TestSettings:ImplicitWaitSeconds"] ?? "5");
        public static string ReportsPath => _config["TestSettings:ReportsPath"];
    }
}
