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
    using Extensions;

    public class NinjectWorkflowApplication : ExtensionResolver, IWorkflowApplication
    {
        private WorkflowApplication workflowApplication;

        public NinjectWorkflowApplication(IKernel kernel)
            : base(kernel)
        {
        }

        protected override WorkflowInstanceExtensionManager Extensions
        {
            get { return this.Application.Extensions; }
        }

        private WorkflowApplication Application
        {
            get
            {
                if (this.workflowApplication == null)
                {
                    throw new InvalidOperationException("The WorkflowApplication must be initialized first!");
                }

                return this.workflowApplication;
            }

            set
            {
                this.workflowApplication = value;
            }
        }

        public Action<WorkflowApplicationAbortedEventArgs> Aborted
        {
            get { return this.Application.Aborted; }
            set { this.Application.Aborted = value; }
        }

        public Action<WorkflowApplicationEventArgs> Unloaded
        {
            get { return this.Application.Unloaded; }
            set { this.Application.Unloaded = value; }
        }

        public Func<WorkflowApplicationIdleEventArgs, PersistableIdleAction> PersistableIdle
        {
            get { return this.Application.PersistableIdle; }
            set { this.Application.PersistableIdle = value; }
        }

        public Func<WorkflowApplicationUnhandledExceptionEventArgs, UnhandledExceptionAction> OnUnhandledException
        {
            get { return this.Application.OnUnhandledException; }
            set { this.Application.OnUnhandledException = value; }
        }

        public InstanceStore InstanceStore
        {
            get { return this.Application.InstanceStore; }
            set { this.Application.InstanceStore = value; }
        }

        public Action<WorkflowApplicationIdleEventArgs> Idle
        {
            get { return this.Application.Idle; }
            set { this.Application.Idle = value; }
        }

        public Guid Id
        {
            get { return this.Application.Id; }
        }

        public Action<WorkflowApplicationCompletedEventArgs> Completed
        {
            get { return this.Application.Completed; }
            set { this.Application.Completed = value; }
        }

        public void Initialize(Activity workflowDefinition)
        {
            this.Application = new WorkflowApplication(workflowDefinition);

            this.AddExtensions();
        }

        public void Initialize(Activity workflowDefinition, IDictionary<string, object> inputs)
        {
            this.Application = new WorkflowApplication(workflowDefinition, inputs);

            this.AddExtensions();
        }

        public void Unload()
        {
            this.Application.Unload();
        }

        public void Unload(TimeSpan timeout)
        {
            this.Application.Unload(timeout);
        }

        public void Terminate(string reason)
        {
            this.Application.Terminate(reason);
        }

        public void Terminate(Exception reason)
        {
            this.Application.Terminate(reason);
        }

        public void Terminate(string reason, TimeSpan timeout)
        {
            this.Application.Terminate(reason, timeout);
        }

        public void Terminate(Exception reason, TimeSpan timeout)
        {
            this.Application.Terminate(reason, timeout);
        }

        public void Run()
        {
            this.Application.Run();
        }

        public void Run(TimeSpan timeout)
        {
            this.Application.Run(timeout);
        }

        private void AddExtensions()
        {
            this.AddSingletonExtension<ActivityDependencyInjection>();
        }
    }
}