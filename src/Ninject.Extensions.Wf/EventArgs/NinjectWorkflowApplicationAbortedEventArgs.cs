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

    public class NinjectWorkflowApplicationAbortedEventArgs : NinjectWorkflowApplicationEventArgs
    {
        public NinjectWorkflowApplicationAbortedEventArgs(Guid instanceId, Exception reason) : base(instanceId)
        {
            this.Reason = reason;
        }

        public NinjectWorkflowApplicationAbortedEventArgs(WorkflowApplicationAbortedEventArgs workflowApplicationAbortedEventArgs) : base(workflowApplicationAbortedEventArgs)
        {
            this.Reason = workflowApplicationAbortedEventArgs.Reason;
        }

        public Exception Reason
        {
            get; private set;
        }

        public new WorkflowApplicationAbortedEventArgs Arguments
        {
            get { return (WorkflowApplicationAbortedEventArgs) base.Arguments; }
        }
    }
}