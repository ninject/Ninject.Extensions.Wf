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

    public class NinjectWorkflowApplicationCompletedEventArgs : NinjectWorkflowApplicationEventArgs
    {
        public NinjectWorkflowApplicationCompletedEventArgs(Guid instanceId, ActivityInstanceState completionState, Exception terminationException, IDictionary<string, object > outputs) : base(instanceId)
        {
            this.CompletionState = completionState;
            this.Outputs = outputs;
            this.TerminationException = terminationException;
        }

        public NinjectWorkflowApplicationCompletedEventArgs(WorkflowApplicationCompletedEventArgs workflowApplicationCompletedEventArgs) : base(workflowApplicationCompletedEventArgs)
        {
            this.CompletionState = this.Arguments.CompletionState;
            this.Outputs = this.Arguments.Outputs;
            this.TerminationException = this.Arguments.TerminationException;
        }

        public new WorkflowApplicationCompletedEventArgs Arguments
        {
            get { return (WorkflowApplicationCompletedEventArgs)base.Arguments; }
        }

        public ActivityInstanceState CompletionState { get; private set; }

        public IDictionary<string, object> Outputs { get; private set; }

        public Exception TerminationException { get; private set; }
    }
}