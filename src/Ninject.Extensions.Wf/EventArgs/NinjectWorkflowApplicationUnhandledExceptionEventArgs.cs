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

    /// <summary>
    /// Event arguments which wraps <see cref="WorkflowApplicationUnhandledExceptionEventArgs"/>
    /// </summary>
    public class NinjectWorkflowApplicationUnhandledExceptionEventArgs : NinjectWorkflowApplicationEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectWorkflowApplicationUnhandledExceptionEventArgs"/> class.
        /// </summary>
        /// <param name="instanceId">The instance id.</param>
        /// <param name="unhandledException">The unhandled exception.</param>
        /// <param name="exceptionSource">The exception source.</param>
        /// <param name="exceptionSourceInstanceId">The exception source instance id.</param>
        public NinjectWorkflowApplicationUnhandledExceptionEventArgs(Guid instanceId, Exception unhandledException, Activity exceptionSource, string exceptionSourceInstanceId)
            : base(instanceId)
        {
            this.UnhandledException = unhandledException;
            this.ExceptionSource = exceptionSource;
            this.ExceptionSourceInstanceId = exceptionSourceInstanceId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectWorkflowApplicationUnhandledExceptionEventArgs"/> class.
        /// </summary>
        /// <param name="workflowApplicationUnhandledExceptionEventArgs">The <see cref="System.Activities.WorkflowApplicationUnhandledExceptionEventArgs"/> instance containing the event data.</param>
        public NinjectWorkflowApplicationUnhandledExceptionEventArgs(WorkflowApplicationUnhandledExceptionEventArgs workflowApplicationUnhandledExceptionEventArgs)
            : base(workflowApplicationUnhandledExceptionEventArgs)
        {
            this.UnhandledException = workflowApplicationUnhandledExceptionEventArgs.UnhandledException;
            this.ExceptionSource = workflowApplicationUnhandledExceptionEventArgs.ExceptionSource;
            this.ExceptionSourceInstanceId = workflowApplicationUnhandledExceptionEventArgs.ExceptionSourceInstanceId;
        }

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="P:System.Activities.WorkflowApplicationUnhandledExceptionEventArgs.UnhandledException"]/*' />
        public Exception UnhandledException { get; private set; }

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="P:System.Activities.WorkflowApplicationUnhandledExceptionEventArgs.ExceptionSource"]/*' />
        public Activity ExceptionSource { get; private set; }

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="P:System.Activities.WorkflowApplicationUnhandledExceptionEventArgs.ExceptionSourceInstanceId"]/*' />
        public string ExceptionSourceInstanceId { get; private set; }

        /// <summary>
        /// Gets the underlying <see cref="WorkflowApplicationUnhandledExceptionEventArgs"/>.
        /// </summary>
        /// <value>The <see cref="WorkflowApplicationUnhandledExceptionEventArgs"/>.</value>
        public new WorkflowApplicationUnhandledExceptionEventArgs Arguments
        {
            get { return (WorkflowApplicationUnhandledExceptionEventArgs)base.Arguments; }
        }
    }
}