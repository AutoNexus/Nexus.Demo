﻿using Allure.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Logging
{
    public static class AllureExtensions
    {
        /// <summary>
        /// Wraps Action into AllureStep.
        /// </summary>
        public static void WrapInStep(this AllureLifecycle lifecycle, Action action, string stepName = "", [CallerMemberName] string callerName = "")
        {
            if (string.IsNullOrEmpty(stepName))
            {
                stepName = callerName;
            }

            var id = Guid.NewGuid().ToString();
            var stepResult = new StepResult { name = stepName };
            try
            {
                lifecycle.StartStep(id, stepResult);
                action.Invoke();
                lifecycle.StopStep(step => stepResult.status = Status.passed);
            }
            catch (Exception e)
            {
                lifecycle.StopStep(step =>
                {
                    step.statusDetails = new StatusDetails
                    {
                        message = e.Message,
                        trace = e.StackTrace
                    };
                });
                throw;
            }
        }

    }
}
