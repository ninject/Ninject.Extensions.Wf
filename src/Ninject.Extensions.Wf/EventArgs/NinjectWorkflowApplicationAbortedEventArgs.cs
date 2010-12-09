//-------------------------------------------------------------------------------
// <copyright file="NinjectWorkflowApplicationAbortedEventArgs.cs" company="bbv Software Services AG">
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
    /// Wraps the <see cref="WorkflowApplicationAbortedEventArgs"/>.
    /// </summary>
    public class NinjectWorkflowApplicationAbortedEventArgs : NinjectWorkflowApplicationEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectWorkflowApplicationAbortedEventArgs"/> class.
        /// </summary>
        /// <param name="instanceId">The instance id.</param>
        /// <param name="reason">The reason.</param>
        public NinjectWorkflowApplicationAbortedEventArgs(Guid instanceId, Exception reason) : base(instanceId)
        {
            this.Reason = reason;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectWorkflowApplicationAbortedEventArgs"/> class.
        /// </summary>
        /// <param name="workflowApplicationAbortedEventArgs">The <see cref="System.Activities.WorkflowApplicationAbortedEventArgs"/> instance containing the event data.</param>
        public NinjectWorkflowApplicationAbortedEventArgs(WorkflowApplicationAbortedEventArgs workflowApplicationAbortedEventArgs) : base(workflowApplicationAbortedEventArgs)
        {
            this.Reason = workflowApplicationAbortedEventArgs.Reason;
        }

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="P:System.Activities.WorkflowApplicationAbortedEventArgs.Reason"]/*' />
        public Exception Reason
        {
            get; private set;
        }

        /// <summary>
        /// Gets the underlying <see cref="WorkflowApplicationAbortedEventArgs"/>.
        /// </summary>
        /// <value>The <see cref="WorkflowApplicationAbortedEventArgs"/>.</value>
        public new WorkflowApplicationAbortedEventArgs Arguments
        {
            get { return (WorkflowApplicationAbortedEventArgs) base.Arguments; }
        }
    }
}