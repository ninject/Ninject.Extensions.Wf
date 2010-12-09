//-------------------------------------------------------------------------------
// <copyright file="IWorkflowApplication.cs" company="bbv Software Services AG">
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
    /// Interface definition for the workflow application.
    /// </summary>
    public interface IWorkflowApplication : IResolveExtensions
    {
#pragma warning disable 1584,1658
        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="P:System.Activities.WorkflowApplication.Unloaded"]/*' />
        /// <remarks>Underlying event arguments are wrapped for testing purpose.</remarks>
        Action<NinjectWorkflowApplicationEventArgs> Unloaded { get; set; }

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="P:System.Activities.WorkflowApplication.PersistableIdle"]/*' />
        /// <remarks>Underlying event arguments are wrapped for testing purpose.</remarks>
        Func<NinjectWorkflowApplicationIdleEventArgs, PersistableIdleAction> PersistableIdle { get; set; }

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="P:System.Activities.WorkflowApplication.OnUnhandledException"]/*' />
        /// <remarks>Underlying event arguments are wrapped for testing purpose.</remarks>
        Func<NinjectWorkflowApplicationUnhandledExceptionEventArgs, UnhandledExceptionAction> OnUnhandledException { get; set; }

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="P:System.Activities.WorkflowApplication.InstanceStore"]/*' />
        InstanceStore InstanceStore { get; set; }

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="P:System.Activities.WorkflowApplication.Idle"]/*' />
        /// <remarks>Underlying event arguments are wrapped for testing purpose.</remarks>
        Action<NinjectWorkflowApplicationIdleEventArgs> Idle { get; set; }

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="P:System.Activities.WorkflowApplication.Id"]/*' />
        Guid Id { get; }

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="P:System.Activities.WorkflowApplication.Completed"]/*' />
        /// <remarks>Underlying event arguments are wrapped for testing purpose.</remarks>
        Action<NinjectWorkflowApplicationCompletedEventArgs> Completed { get; set; }

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="P:System.Activities.WorkflowApplication.Aborted"]/*' />
        /// <remarks>Underlying event arguments are wrapped for testing purpose.</remarks>
        Action<NinjectWorkflowApplicationAbortedEventArgs> Aborted { get; set; }

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.#ctor(System.Activities.Activity)"]/*' />
        /// <remarks>Adds the necessary extensions to build up workflows with ninject.</remarks>
        void Initialize(Activity workflowDefinition);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.#ctor(System.Activities.Activity,System.Collections.Generic.IDictionary{System.String,System.Object})"]/*' />
        /// <remarks>Adds the necessary extensions to build up workflows with ninject.</remarks>
        void Initialize(Activity workflowDefinition, IDictionary<string, object> inputs);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.Unload"]/*' />
        void Unload();

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.Unload(System.TimeSpan)"]/*' />
        void Unload(TimeSpan timeout);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.Terminate(System.String)"]/*' />
        void Terminate(string reason);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.Terminate(System.Exception)"]/*' />
        void Terminate(Exception reason);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.Terminate(System.String,System.TimeSpan)"]/*' />
        void Terminate(string reason, TimeSpan timeout);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.Run"]/*' />
        void Run();

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.Run(System.TimeSpan)"]/*' />
        void Run(TimeSpan timeout);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.ResumeBookmark(System.String,System.Object)"]/*' />
        BookmarkResumptionResult ResumeBookmark(string bookmarkName, object value);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.ResumeBookmark(System.Activities.Bookmark,System.Object)"]/*' />
        BookmarkResumptionResult ResumeBookmark(Bookmark bookmark, object value);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.ResumeBookmark(System.String,System.Object,System.TimeSpan)"]/*' />
        BookmarkResumptionResult ResumeBookmark(string bookmarkName, object value, TimeSpan timeout);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.ResumeBookmark(System.Activities.Bookmark,System.Object,System.TimeSpan)"]/*' />
        BookmarkResumptionResult ResumeBookmark(Bookmark bookmark, object value, TimeSpan timeout);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.Persist"]/*' />
        void Persist();

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.Persist(System.TimeSpan)"]/*' />
        void Persist(TimeSpan timeout);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.LoadRunnableInstance"]/*' />
        void LoadRunnableInstance();

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.LoadRunnableInstance(System.TimeSpan)"]/*' />
        void LoadRunnableInstance(TimeSpan timeout);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.Load(System.Guid)"]/*' />
        void Load(Guid instanceId);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.Load(System.Guid,System.TimeSpan)"]/*' />
        void Load(Guid instanceId, TimeSpan timeout);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.GetBookmarks"]/*' />
        ReadOnlyCollection<BookmarkInfo> GetBookmarks();

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.GetBookmarks(System.TimeSpan)"]/*' />
        ReadOnlyCollection<BookmarkInfo> GetBookmarks(TimeSpan timeout);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.EndUnload(System.IAsyncResult)"]/*' />
        void EndUnload(IAsyncResult result);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.EndTerminate(System.IAsyncResult)"]/*' />
        void EndTerminate(IAsyncResult result);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.EndRun(System.IAsyncResult)"]/*' />
        void EndRun(IAsyncResult result);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.EndResumeBookmark(System.IAsyncResult)"]/*' />
        BookmarkResumptionResult EndResumeBookmark(IAsyncResult result);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.EndPersist(System.IAsyncResult)"]/*' />
        void EndPersist(IAsyncResult result);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.EndLoadRunnableInstance(System.IAsyncResult)"]/*' />
        void EndLoadRunnableInstance(IAsyncResult result);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.EndLoad(System.IAsyncResult)"]/*' />
        void EndLoad(IAsyncResult result);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.EndCancel(System.IAsyncResult)"]/*' />
        void EndCancel(IAsyncResult result);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.Cancel"]/*' />
        void Cancel();

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.Cancel(System.TimeSpan)"]/*' />
        void Cancel(TimeSpan timeout);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.BeginUnload(System.AsyncCallback,System.Object)"]/*' />
        IAsyncResult BeginUnload(AsyncCallback callback, object state);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.BeginUnload(System.TimeSpan,System.AsyncCallback,System.Object)"]/*' />
        IAsyncResult BeginUnload(TimeSpan timeout, AsyncCallback callback, object state);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.BeginTerminate(System.String,System.AsyncCallback,System.Object)"]/*' />
        IAsyncResult BeginTerminate(string reason, AsyncCallback callback, object state);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.BeginTerminate(System.Exception,System.AsyncCallback,System.Object)"]/*' />
        IAsyncResult BeginTerminate(Exception reason, AsyncCallback callback, object state);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.BeginTerminate(System.String,System.TimeSpan,System.AsyncCallback,System.Object)"]/*' />
        IAsyncResult BeginTerminate(string reason, TimeSpan timeout, AsyncCallback callback, object state);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.BeginTerminate(System.Exception,System.TimeSpan,System.AsyncCallback,System.Object)"]/*' />
        IAsyncResult BeginTerminate(Exception reason, TimeSpan timeout, AsyncCallback callback, object state);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.BeginRun(System.AsyncCallback,System.Object)"]/*' />
        IAsyncResult BeginRun(AsyncCallback callback, object state);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.BeginRun(System.TimeSpan,System.AsyncCallback,System.Object)"]/*' />
        IAsyncResult BeginRun(TimeSpan timeout, AsyncCallback callback, object state);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.BeginResumeBookmark(System.String,System.Object,System.AsyncCallback,System.Object)"]/*' />
        IAsyncResult BeginResumeBookmark(string bookmarkName, object value, AsyncCallback callback, object state);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.BeginResumeBookmark(System.String,System.Object,System.TimeSpan,System.AsyncCallback,System.Object)"]/*' />
        IAsyncResult BeginResumeBookmark(string bookmarkName, object value, TimeSpan timeout,
                                                         AsyncCallback callback, object state);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.BeginResumeBookmark(System.Activities.Bookmark,System.Object,System.AsyncCallback,System.Object)"]/*' />
        IAsyncResult BeginResumeBookmark(Bookmark bookmark, object value, AsyncCallback callback, object state);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowApplication.BeginResumeBookmark(System.Activities.Bookmark,System.Object,System.TimeSpan,System.AsyncCallback,System.Object)"]/*' />
        IAsyncResult BeginResumeBookmark(Bookmark bookmark, object value, TimeSpan timeout,
                                                         AsyncCallback callback, object state);
#pragma warning restore 1584,1658
    }
}