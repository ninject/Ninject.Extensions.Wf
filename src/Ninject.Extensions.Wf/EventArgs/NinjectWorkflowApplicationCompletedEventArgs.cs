//-------------------------------------------------------------------------------
// <copyright file="NinjectWorkflowApplicationCompletedEventArgs.cs" company="bbv Software Services AG">
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
    using System.Collections.Generic;

    /// <summary>
    /// Wraps the <see cref="WorkflowApplicationCompletedEventArgs"/>.
    /// </summary>
    public class NinjectWorkflowApplicationCompletedEventArgs : NinjectWorkflowApplicationEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectWorkflowApplicationCompletedEventArgs"/> class.
        /// </summary>
        /// <param name="instanceId">The instance id.</param>
        /// <param name="completionState">State of the completion.</param>
        /// <param name="terminationException">The termination exception.</param>
        /// <param name="outputs">The outputs.</param>
        public NinjectWorkflowApplicationCompletedEventArgs(Guid instanceId, ActivityInstanceState completionState, Exception terminationException, IDictionary<string, object > outputs) : base(instanceId)
        {
            this.CompletionState = completionState;
            this.Outputs = outputs;
            this.TerminationException = terminationException;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectWorkflowApplicationCompletedEventArgs"/> class.
        /// </summary>
        /// <param name="workflowApplicationCompletedEventArgs">The <see cref="System.Activities.WorkflowApplicationCompletedEventArgs"/> instance containing the event data.</param>
        public NinjectWorkflowApplicationCompletedEventArgs(WorkflowApplicationCompletedEventArgs workflowApplicationCompletedEventArgs) : base(workflowApplicationCompletedEventArgs)
        {
            this.CompletionState = this.Arguments.CompletionState;
            this.Outputs = this.Arguments.Outputs;
            this.TerminationException = this.Arguments.TerminationException;
        }

        /// <summary>
        /// Gets the underlying <see cref="WorkflowApplicationCompletedEventArgs"/>.
        /// </summary>
        /// <value>The <see cref="WorkflowApplicationCompletedEventArgs"/>.</value>
        public new WorkflowApplicationCompletedEventArgs Arguments
        {
            get { return (WorkflowApplicationCompletedEventArgs)base.Arguments; }
        }

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="P:System.Activities.WorkflowApplicationCompletedEventArgs.CompletionState"]/*' />
        public ActivityInstanceState CompletionState { get; private set; }

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="P:System.Activities.WorkflowApplicationCompletedEventArgs.Outputs"]/*' />
        public IDictionary<string, object> Outputs { get; private set; }

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="P:System.Activities.WorkflowApplicationCompletedEventArgs.TerminationException"]/*' />
        public Exception TerminationException { get; private set; }
    }
}