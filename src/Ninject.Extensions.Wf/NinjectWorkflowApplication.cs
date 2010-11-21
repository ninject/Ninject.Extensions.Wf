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
    using System.Collections.ObjectModel;
    using System.Runtime.DurableInstancing;
    using Extensions;
    using Injection;

    public class NinjectWorkflowApplication : ExtensionResolver, IWorkflowApplication
    {
        private Action<NinjectWorkflowApplicationCompletedEventArgs> completedAction;

        private Action<NinjectWorkflowApplicationAbortedEventArgs> abortedAction;

        private Action<NinjectWorkflowApplicationEventArgs> unloadedAction;

        private Func<NinjectWorkflowApplicationIdleEventArgs, PersistableIdleAction> persistableIdleFunction;

        private Func<NinjectWorkflowApplicationUnhandledExceptionEventArgs, UnhandledExceptionAction> unhandledExceptionFunction;

        private Action<NinjectWorkflowApplicationIdleEventArgs> idleAction;

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

        public Action<NinjectWorkflowApplicationAbortedEventArgs> Aborted
        {
            get
            {
                return this.abortedAction;
            }

            set
            {
                this.abortedAction = value;
                this.Application.Aborted = args => this.abortedAction(new NinjectWorkflowApplicationAbortedEventArgs(args));
            }
        }

        public Action<NinjectWorkflowApplicationEventArgs> Unloaded
        {
            get { return this.unloadedAction; }
            set
            {
                this.unloadedAction = value;
                this.Application.Unloaded = args => this.unloadedAction(new NinjectWorkflowApplicationEventArgs(args));
            }
        }

        public Func<NinjectWorkflowApplicationIdleEventArgs, PersistableIdleAction> PersistableIdle
        {
            get
            {
                return this.persistableIdleFunction;
            }

            set
            {
                this.persistableIdleFunction = value;
                this.Application.PersistableIdle = args => this.persistableIdleFunction(new NinjectWorkflowApplicationIdleEventArgs(args));
            }
        }

        public Func<NinjectWorkflowApplicationUnhandledExceptionEventArgs, UnhandledExceptionAction> OnUnhandledException
        {
            get
            {
                return this.unhandledExceptionFunction;
            }

            set
            {
                this.unhandledExceptionFunction = value;
                this.Application.OnUnhandledException = args => this.unhandledExceptionFunction(new NinjectWorkflowApplicationUnhandledExceptionEventArgs(args));
            }
        }

        public InstanceStore InstanceStore
        {
            get { return this.Application.InstanceStore; }
            set { this.Application.InstanceStore = value; }
        }

        public Action<NinjectWorkflowApplicationIdleEventArgs> Idle
        {
            get { return this.idleAction; }
            set
            {
                this.idleAction = value;
                this.Application.Idle = args => this.idleAction(new NinjectWorkflowApplicationIdleEventArgs(args));
            }
        }

        public Guid Id
        {
            get { return this.Application.Id; }
        }

        public Action<NinjectWorkflowApplicationCompletedEventArgs> Completed
        {
            get
            {
                return this.completedAction;
            }

            set
            {
                this.completedAction = value;
                this.Application.Completed = args => this.completedAction(new NinjectWorkflowApplicationCompletedEventArgs(args));
            }
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

        public BookmarkResumptionResult ResumeBookmark(string bookmarkName, object value)
        {
            return this.Application.ResumeBookmark(bookmarkName, value);
        }

        public BookmarkResumptionResult ResumeBookmark(Bookmark bookmark, object value)
        {
            return this.Application.ResumeBookmark(bookmark, value);
        }

        public BookmarkResumptionResult ResumeBookmark(string bookmarkName, object value, TimeSpan timeout)
        {
            return this.Application.ResumeBookmark(bookmarkName, value, timeout);
        }

        public BookmarkResumptionResult ResumeBookmark(Bookmark bookmark, object value, TimeSpan timeout)
        {
            return this.Application.ResumeBookmark(bookmark, value, timeout);
        }

        public void Persist()
        {
            this.Application.Persist();
        }

        public void Persist(TimeSpan timeout)
        {
            this.Application.Persist(timeout);
        }

        public void LoadRunnableInstance()
        {
            this.Application.LoadRunnableInstance();
        }

        public void LoadRunnableInstance(TimeSpan timeout)
        {
            this.Application.LoadRunnableInstance(timeout);
        }

        public void Load(Guid instanceId)
        {
            this.Application.Load(instanceId);
        }

        public void Load(Guid instanceId, TimeSpan timeout)
        {
            this.Application.Load(instanceId, timeout);
        }

        public ReadOnlyCollection<BookmarkInfo> GetBookmarks()
        {
            return this.Application.GetBookmarks();
        }

        public ReadOnlyCollection<BookmarkInfo> GetBookmarks(TimeSpan timeout)
        {
            return this.Application.GetBookmarks(timeout);
        }

        public void EndUnload(IAsyncResult result)
        {
            this.Application.EndUnload(result);
        }

        public void EndTerminate(IAsyncResult result)
        {
            this.Application.EndTerminate(result);
        }

        public void EndRun(IAsyncResult result)
        {
            this.Application.EndRun(result);
        }

        public BookmarkResumptionResult EndResumeBookmark(IAsyncResult result)
        {
            return this.Application.EndResumeBookmark(result);
        }

        public void EndPersist(IAsyncResult result)
        {
            this.Application.EndPersist(result);
        }

        public void EndLoadRunnableInstance(IAsyncResult result)
        {
            this.Application.EndLoadRunnableInstance(result);
        }

        public void EndLoad(IAsyncResult result)
        {
            this.Application.EndLoad(result);
        }

        public void EndCancel(IAsyncResult result)
        {
            this.Application.EndCancel(result);
        }

        private void AddExtensions()
        {
            this.AddSingletonExtension<ActivityDependencyInjection>();
        }
    }
}