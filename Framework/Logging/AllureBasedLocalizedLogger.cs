﻿using Allure.Commons;
using Nexus.Core.Configuration;
using Nexus.Core.Localization;
using Nexus.Core.Logging;
namespace Framework.Logging
{
    public class AllureBasedLocalizedLogger : LocalizedLogger, ILocalizedLogger
    {
        private readonly ILocalizationManager localizationManager;

        public AllureBasedLocalizedLogger(ILocalizationManager localizationManager, Logger logger, ILoggerConfiguration configuration)
            : base(localizationManager, logger, configuration)
        {
            this.localizationManager = localizationManager;
        }

        public new void InfoElementAction(string elementType, string elementName, string messageKey, params object[] args)
        {
            AddStepToAllure($"{elementType} '{elementName}' :: {localizationManager.GetLocalizedMessage(messageKey, args)}");
            base.InfoElementAction(elementType, elementName, messageKey, args);
        }

        public new void Info(string messageKey, params object[] args)
        {
            AddStepToAllure(localizationManager.GetLocalizedMessage(messageKey, args));
            base.Info(messageKey, args);
        }

        private void AddStepToAllure(string message)
        {
            var timeStamp = DateTime.Now.ToString("HH:mm:ss.fff");
            AllureLifecycle.Instance.WrapInStep(() => { }, $"{timeStamp} - {message}");
        }
    }
}
