using Framework.Configurations;
using Nexus.Selenium.Browsers;
using NUnit.Allure.Attributes;

namespace Nexus.TestProject.Tests
{
    public abstract class BaseWebTest : BaseTest
    {

        [TearDown]
        public void CleanUp()
        {
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
    }
}
