using Nexus.Selenium.Configurations;

namespace Framework.Configurations
{
    public interface ICustomTimeoutConfiguration : ITimeoutConfiguration
    {
        public TimeSpan ElementAppear { get; }
    }
}
