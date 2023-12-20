﻿using AspectInjector.Broker;
namespace Framework.CustomAttributes
{
    [Injection(typeof(TraceAspect))]
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class LogStepAttribute : Attribute
    {
        public StepType StepType { get; }

        public LogStepAttribute(StepType stepType)
        {
            StepType = stepType;
        }
    }
}
