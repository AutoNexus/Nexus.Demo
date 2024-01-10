using Framework.Browsers;
using Framework.Configurations;
using Framework.Utilities;
using Humanizer;
using Nexus.Core.Logging;
using Nexus.Selenium.Browsers;
using Nexus.TestProject.Steps;
using NUnit.Allure.Attributes;
using NUnit.Framework.Interfaces;

namespace Nexus.TestProject.Tests
{
    public abstract class BaseWebTest
    {
        protected static string ScenarioName
                                    => TestContext.CurrentContext.Test.Properties.Get("Description")?.ToString()
                                       ?? TestContext.CurrentContext.Test.Name.Replace("_", string.Empty).Humanize();

        private static Logger Logger => Logger.Instance;
        private static TestContext.ResultAdapter Result => TestContext.CurrentContext.Result;
        private readonly ScreenshotProvider screenshotProvider = new ScreenshotProvider();

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Logger.Info("Setup startup config");
            NexusServices.SetStartup(new CustomStartup());
        }

        [SetUp]
        public void Setup()
        {
            Logger.Info($"Start scenario [{ScenarioName}]");
            GoToPageStartPage();
            SetScreenExpansionMaximize();
        }

        [TearDown]
        public void CleanUp()
        {
            LogScenarioResult();
            if (NexusServices.IsBrowserStarted)
            {
                NexusServices.Browser.Quit();
            }
        }

        [AllureStep]
        public static void SetScreenExpansionMaximize()
        {
            NexusServices.Browser.Maximize();
        }

        [AllureStep]
        public static void GoToPageStartPage()
        {
            NexusServices.Browser.GoTo(Configuration.StartUrl);
        }

        private void LogScenarioResult()
        {
            Logger.Info($"Scenario [{ScenarioName}] result is {Result.Outcome.Status}!");
            if (Result.Outcome.Status != TestStatus.Passed)
            {
                if (NexusServices.IsBrowserStarted)
                {
                    AttachmentHelper.AddAttachment(screenshotProvider.TakeScreenshot(), "Screenshot");
                }
                Logger.Error(Result.Message);
            }
            Logger.Info(new string('=', 100));
        }
    }
}
