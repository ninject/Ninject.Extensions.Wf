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

    /// <summary>
    /// Wraps the <see cref="WorkflowApplication"/>.
    /// </summary>
    public class NinjectWorkflowApplication : ExtensionResolver, IWorkflowApplication
    {
        private Action<NinjectWorkflowApplicationCompletedEventArgs> completedAction;

        private Action<NinjectWorkflowApplicationAbortedEventArgs> abortedAction;

        private Action<NinjectWorkflowApplicationEventArgs> unloadedAction;

        private Func<NinjectWorkflowApplicationIdleEventArgs, PersistableIdleAction> persistableIdleFunction;

        private Func<NinjectWorkflowApplicationUnhandledExceptionEventArgs, UnhandledExceptionAction> unhandledExceptionFunction;

        private Action<NinjectWorkflowApplicationIdleEventArgs> idleAction;

        private WorkflowApplication workflowApplication;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectWorkflowApplication"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public NinjectWorkflowApplication(IKernel kernel)
            : base(kernel)
        {
        }

        /// <inheritdoc />
        protected override WorkflowInstanceExtensionManager Extensions
        {
            get { return this.Application.Extensions; }
        }

        /// <summary>
        /// Gets or sets the application.
        /// </summary>
        /// <value>The application.</value>
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

        /// <inheritdoc />
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

        /// <inheritdoc />
        public Action<NinjectWorkflowApplicationEventArgs> Unloaded
        {
            get
            {
                return this.unloadedAction;
            }

            set
            {
                this.unloadedAction = value;
                this.Application.Unloaded = args => this.unloadedAction(new NinjectWorkflowApplicationEventArgs(args));
            }
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
        public InstanceStore InstanceStore
        {
            get { return this.Application.InstanceStore; }
            set { this.Application.InstanceStore = value; }
        }

        /// <inheritdoc />
        public Action<NinjectWorkflowApplicationIdleEventArgs> Idle
        {
            get
            {
                return this.idleAction;
            }

            set
            {
                this.idleAction = value;
                this.Application.Idle = args => this.idleAction(new NinjectWorkflowApplicationIdleEventArgs(args));
            }
        }

        /// <inheritdoc />
        public Guid Id
        {
            get { return this.Application.Id; }
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public void Initialize(Activity workflowDefinition)
        {
            this.Application = new WorkflowApplication(workflowDefinition);

            this.AddExtensions();
        }

        /// <inheritdoc />
        public void Initialize(Activity workflowDefinition, IDictionary<string, object> inputs)
        {
            this.Application = new WorkflowApplication(workflowDefinition, inputs);

            this.AddExtensions();
        }

        /// <inheritdoc />
        public void Unload()
        {
            this.Application.Unload();
        }

        /// <inheritdoc />
        public void Unload(TimeSpan timeout)
        {
            this.Application.Unload(timeout);
        }

        /// <inheritdoc />
        public void Terminate(string reason)
        {
            this.Application.Terminate(reason);
        }

        /// <inheritdoc />
        public void Terminate(Exception reason)
        {
            this.Application.Terminate(reason);
        }

        /// <inheritdoc />
        public void Terminate(string reason, TimeSpan timeout)
        {
            this.Application.Terminate(reason, timeout);
        }

        /// <inheritdoc />
        public void Terminate(Exception reason, TimeSpan timeout)
        {
            this.Application.Terminate(reason, timeout);
        }

        /// <inheritdoc />
        public void Run()
        {
            this.Application.Run();
        }

        /// <inheritdoc />
        public void Run(TimeSpan timeout)
        {
            this.Application.Run(timeout);
        }

        /// <inheritdoc />
        public BookmarkResumptionResult ResumeBookmark(string bookmarkName, object value)
        {
            return this.Application.ResumeBookmark(bookmarkName, value);
        }

        /// <inheritdoc />
        public BookmarkResumptionResult ResumeBookmark(Bookmark bookmark, object value)
        {
            return this.Application.ResumeBookmark(bookmark, value);
        }

        /// <inheritdoc />
        public BookmarkResumptionResult ResumeBookmark(string bookmarkName, object value, TimeSpan timeout)
        {
            return this.Application.ResumeBookmark(bookmarkName, value, timeout);
        }

        /// <inheritdoc />
        public BookmarkResumptionResult ResumeBookmark(Bookmark bookmark, object value, TimeSpan timeout)
        {
            return this.Application.ResumeBookmark(bookmark, value, timeout);
        }

        /// <inheritdoc />
        public void Persist()
        {
            this.Application.Persist();
        }

        /// <inheritdoc />
        public void Persist(TimeSpan timeout)
        {
            this.Application.Persist(timeout);
        }

        /// <inheritdoc />
        public void LoadRunnableInstance()
        {
            this.Application.LoadRunnableInstance();
        }

        /// <inheritdoc />
        public void LoadRunnableInstance(TimeSpan timeout)
        {
            this.Application.LoadRunnableInstance(timeout);
        }

        /// <inheritdoc />
        public void Load(Guid instanceId)
        {
            this.Application.Load(instanceId);
        }

        /// <inheritdoc />
        public void Load(Guid instanceId, TimeSpan timeout)
        {
            this.Application.Load(instanceId, timeout);
        }

        /// <inheritdoc />
        public ReadOnlyCollection<BookmarkInfo> GetBookmarks()
        {
            return this.Application.GetBookmarks();
        }

        /// <inheritdoc />
        public ReadOnlyCollection<BookmarkInfo> GetBookmarks(TimeSpan timeout)
        {
            return this.Application.GetBookmarks(timeout);
        }

        /// <inheritdoc />
        public void EndUnload(IAsyncResult result)
        {
            this.Application.EndUnload(result);
        }

        /// <inheritdoc />
        public void EndTerminate(IAsyncResult result)
        {
            this.Application.EndTerminate(result);
        }

        /// <inheritdoc />
        public void EndRun(IAsyncResult result)
        {
            this.Application.EndRun(result);
        }

        /// <inheritdoc />
        public BookmarkResumptionResult EndResumeBookmark(IAsyncResult result)
        {
            return this.Application.EndResumeBookmark(result);
        }

        /// <inheritdoc />
        public void EndPersist(IAsyncResult result)
        {
            this.Application.EndPersist(result);
        }

        /// <inheritdoc />
        public void EndLoadRunnableInstance(IAsyncResult result)
        {
            this.Application.EndLoadRunnableInstance(result);
        }

        /// <inheritdoc />
        public void EndLoad(IAsyncResult result)
        {
            this.Application.EndLoad(result);
        }

        /// <inheritdoc />
        public void EndCancel(IAsyncResult result)
        {
            this.Application.EndCancel(result);
        }

        /// <inheritdoc />
        public void Cancel()
        {
            this.Application.Cancel();
        }

        /// <inheritdoc />
        public void Cancel(TimeSpan timeout)
        {
            this.Application.Cancel(timeout);
        }

        /// <inheritdoc />
        public IAsyncResult BeginUnload(AsyncCallback callback, object state)
        {
            return this.Application.BeginUnload(callback, state);
        }

        /// <inheritdoc />
        public IAsyncResult BeginUnload(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.Application.BeginUnload(timeout, callback, state);
        }

        /// <inheritdoc />
        public IAsyncResult BeginTerminate(string reason, AsyncCallback callback, object state)
        {
            return this.Application.BeginTerminate(reason, callback, state);
        }

        /// <inheritdoc />
        public IAsyncResult BeginTerminate(Exception reason, AsyncCallback callback, object state)
        {
            return this.Application.BeginTerminate(reason, callback, state);
        }

        /// <inheritdoc />
        public IAsyncResult BeginTerminate(string reason, TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.Application.BeginTerminate(reason, timeout, callback, state);
        }

        /// <inheritdoc />
        public IAsyncResult BeginTerminate(Exception reason, TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.Application.BeginTerminate(reason, timeout, callback, state);
        }

        /// <inheritdoc />
        public IAsyncResult BeginRun(AsyncCallback callback, object state)
        {
            return this.Application.BeginRun(callback, state);
        }

        /// <inheritdoc />
        public IAsyncResult BeginRun(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.Application.BeginRun(callback, state);
        }

        /// <inheritdoc />
        public IAsyncResult BeginResumeBookmark(string bookmarkName, object value, AsyncCallback callback, object state)
        {
            return this.Application.BeginResumeBookmark(bookmarkName, value, callback, state);
        }

        /// <inheritdoc />
        public IAsyncResult BeginResumeBookmark(string bookmarkName, object value, TimeSpan timeout,
                                                AsyncCallback callback, object state)
        {
            return this.Application.BeginResumeBookmark(bookmarkName, value, timeout, callback, state);
        }

        /// <inheritdoc />
        public IAsyncResult BeginResumeBookmark(Bookmark bookmark, object value, AsyncCallback callback, object state)
        {
            return this.Application.BeginResumeBookmark(bookmark, value, callback, state);
        }

        /// <inheritdoc />
        public IAsyncResult BeginResumeBookmark(Bookmark bookmark, object value, TimeSpan timeout,
                                                AsyncCallback callback, object state)
        {
            return this.Application.BeginResumeBookmark(bookmark, value, timeout, callback, state);
        }

        /// <summary>
        /// Adds the extensions.
        /// </summary>
        private void AddExtensions()
        {
            this.AddSingletonExtension<ActivityDependencyInjection>();
        }
    }
}