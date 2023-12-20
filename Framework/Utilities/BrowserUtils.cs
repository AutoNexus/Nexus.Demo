using OpenQA.Selenium;
using static Nexus.Selenium.Browsers.NexusServices;
namespace Framework.Utilities
{
    public static class BrowserUtils
    {
        public static void AddСookiesByKey(string key, string value) => Browser.Driver.Manage().Cookies.AddCookie(new Cookie(key, value));

    }
}
