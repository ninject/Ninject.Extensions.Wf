//-------------------------------------------------------------------------------
// <copyright file="NinjectWorkflowApplication.cs" company="bbv Software Services AG">
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
    using System.Activities.Hosting;
    using System.Collections.Generic;
    using System.Runtime.DurableInstancing;

    public class NinjectWorkflowApplication : ExtensionResolver, IWorkflowApplication
    {
        private readonly WorkflowApplication workflowApplication;

        public NinjectWorkflowApplication(Activity workflowDefinition, IKernel kernel)
            : base(kernel)
        {
            this.workflowApplication = new WorkflowApplication(workflowDefinition);
        }

        public NinjectWorkflowApplication(Activity workflowDefinition, IDictionary<string, object> inputs, IKernel kernel)
            : base(kernel)
        {
            this.workflowApplication = new WorkflowApplication(workflowDefinition, inputs);
        }

        protected override WorkflowInstanceExtensionManager Extensions
        {
            get { return this.workflowApplication.Extensions; }
        }

        public Action<WorkflowApplicationAbortedEventArgs> Aborted
        {
            get { return this.workflowApplication.Aborted; }
            set { this.workflowApplication.Aborted = value; }
        }

        public Action<WorkflowApplicationEventArgs> Unloaded
        {
            get { return this.workflowApplication.Unloaded; }
            set { this.workflowApplication.Unloaded = value; }
        }

        public Func<WorkflowApplicationIdleEventArgs, PersistableIdleAction> PersistableIdle
        {
            get { return this.workflowApplication.PersistableIdle; }
            set { this.workflowApplication.PersistableIdle = value; }
        }

        public Func<WorkflowApplicationUnhandledExceptionEventArgs, UnhandledExceptionAction> OnUnhandledException
        {
            get { return this.workflowApplication.OnUnhandledException; }
            set { this.workflowApplication.OnUnhandledException = value; }
        }

        public InstanceStore InstanceStore
        {
            get { return this.workflowApplication.InstanceStore; }
            set { this.workflowApplication.InstanceStore = value; }
        }

        public Action<WorkflowApplicationIdleEventArgs> Idle
        {
            get { return this.workflowApplication.Idle; }
            set { this.workflowApplication.Idle = value; }
        }

        public Guid Id
        {
            get { return this.workflowApplication.Id; }
        }

        public Action<WorkflowApplicationCompletedEventArgs> Completed
        {
            get { return this.workflowApplication.Completed; }
            set { this.workflowApplication.Completed = value; }
        }
    }
}