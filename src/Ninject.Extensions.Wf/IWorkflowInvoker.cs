//-------------------------------------------------------------------------------
// <copyright file="IWorkflowInvoker.cs" company="bbv Software Services AG">
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
    using Extensions;

    public interface IWorkflowInvoker : IResolveExtensions
    {
        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowInvoker.InvokeAsync(System.Collections.Generic.IDictionary{System.String,System.Object},System.TimeSpan,System.Object)"]/*' />
        void InvokeAsync(IDictionary<string, object> inputs, TimeSpan timeout, object userState);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowInvoker.InvokeAsync(System.Collections.Generic.IDictionary{System.String,System.Object},System.Object)"]/*' />
        void InvokeAsync(IDictionary<string, object> inputs, object userState);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowInvoker.InvokeAsync(System.Collections.Generic.IDictionary{System.String,System.Object},System.TimeSpan)"]/*' />
        void InvokeAsync(IDictionary<string, object> inputs, TimeSpan timeout);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowInvoker.InvokeAsync(System.Collections.Generic.IDictionary{System.String,System.Object})"]/*' />
        void InvokeAsync(IDictionary<string, object> inputs);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowInvoker.InvokeAsync(System.TimeSpan,System.Object)"]/*' />
        void InvokeAsync(TimeSpan timeout, object userState);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowInvoker.InvokeAsync(System.TimeSpan)"]/*' />
        void InvokeAsync(TimeSpan timeout);

        /// <include file='../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.WorkflowInvoker.InvokeAsync"]/*' />
        void InvokeAsync();

        void Initialize(Activity workflowDefinition);
        IDictionary<string,object> Invoke();
        IDictionary<string,object> Invoke(TimeSpan timeout);
        IDictionary<string,object> Invoke(IDictionary<string,object> inputs);
        IDictionary<string,object> Invoke(IDictionary<string,object> inputs, TimeSpan timeout);
        IDictionary<string,object> EndInvoke(IAsyncResult result);
        void CancelAsync(object userState);
        IAsyncResult BeginInvoke(AsyncCallback callback, object state);
        IAsyncResult BeginInvoke(TimeSpan timeout, AsyncCallback callback, object state);
        IAsyncResult BeginInvoke(IDictionary<string,object> inputs, AsyncCallback callback, object state);
        IAsyncResult BeginInvoke(IDictionary<string,object> inputs, TimeSpan timeout, AsyncCallback callback, object state);
    }
}