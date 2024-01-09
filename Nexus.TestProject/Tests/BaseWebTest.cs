using Framework.Configurations;
using Framework.Utilities;
using Humanizer;
using Nexus.Core.Logging;
using Nexus.Selenium.Browsers;
using NUnit.Allure.Attributes;
using NUnit.Framework.Interfaces;

namespace Nexus.TestProject.Tests
{
    public abstract class BaseWebTest : BaseTest
    {

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

        protected static string ScenarioName
=> TestContext.CurrentContext.Test.Properties.Get("Description")?.ToString()
?? TestContext.CurrentContext.Test.Name.Replace("_", string.Empty).Humanize();

        private static Logger Logger => Logger.Instance;

        private static TestContext.ResultAdapter Result => TestContext.CurrentContext.Result;
        private readonly ScreenshotProvider screenshotProvider = new ScreenshotProvider();

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
