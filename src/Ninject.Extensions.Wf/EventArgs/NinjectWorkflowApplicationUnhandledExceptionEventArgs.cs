//-------------------------------------------------------------------------------
// <copyright file="NinjectWorkflowApplicationUnhandledExceptionEventArgs.cs" company="bbv Software Services AG">
//   Copyright (c) 2010 bbv Software Services AG
//   Author: Daniel Marbach
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace Ninject.Extensions.Wf
{
    using System;
    using System.Activities;

    public class NinjectWorkflowApplicationUnhandledExceptionEventArgs : NinjectWorkflowApplicationEventArgs
    {
        public NinjectWorkflowApplicationUnhandledExceptionEventArgs(Guid instanceId, Exception unhandledException, Activity exceptionSource, string exceptionSourceInstanceId)
            : base(instanceId)
        {
            this.UnhandledException = unhandledException;
            this.ExceptionSource = exceptionSource;
            this.ExceptionSourceInstanceId = exceptionSourceInstanceId;
        }

        public NinjectWorkflowApplicationUnhandledExceptionEventArgs(WorkflowApplicationUnhandledExceptionEventArgs workflowApplicationUnhandledExceptionEventArgs)
            : base(workflowApplicationUnhandledExceptionEventArgs)
        {
            this.UnhandledException = workflowApplicationUnhandledExceptionEventArgs.UnhandledException;
            this.ExceptionSource = workflowApplicationUnhandledExceptionEventArgs.ExceptionSource;
            this.ExceptionSourceInstanceId = workflowApplicationUnhandledExceptionEventArgs.ExceptionSourceInstanceId;
        }

        public Exception UnhandledException { get; private set; }

        public Activity ExceptionSource
        { get; private set; }

        public string ExceptionSourceInstanceId
        { get; private set; }

        public new WorkflowApplicationUnhandledExceptionEventArgs Arguments
        {
            get { return (WorkflowApplicationUnhandledExceptionEventArgs)base.Arguments; }
        }
    }
}