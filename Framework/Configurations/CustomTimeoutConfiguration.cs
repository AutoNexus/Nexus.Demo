﻿using Nexus.Core.Utilities;
using TimeoutConfiguration = Nexus.Selenium.Configurations.TimeoutConfiguration;

namespace Framework.Configurations
{
    internal class CustomTimeoutConfiguration : TimeoutConfiguration, ICustomTimeoutConfiguration
    {
        private readonly ISettingsFile settingsFile;

        /// <summary>
        /// Instantiates class using JSON file with general settings.
        /// </summary>
        /// <param name="settingsFile">JSON settings file.</param>
        public CustomTimeoutConfiguration(ISettingsFile settingsFile)
            : base(settingsFile)
        {
            this.settingsFile = settingsFile;
            ElementAppear = GetTimeoutFromSeconds(nameof(ElementAppear));
        }

        private TimeSpan GetTimeoutFromSeconds(string name)
        {
            return TimeSpan.FromSeconds(settingsFile.GetValue<int>($".timeouts.timeout{name}"));
        }

        public TimeSpan ElementAppear { get; }
    }
}
