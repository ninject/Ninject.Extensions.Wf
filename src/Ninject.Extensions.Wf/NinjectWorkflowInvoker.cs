//-------------------------------------------------------------------------------
// <copyright file="NinjectWorkflowInvoker.cs" company="bbv Software Services AG">
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
    using Extensions;


    /// <summary>
    /// Wraps the <see cref="WorkflowInvoker"/>.
    /// </summary>
    public class NinjectWorkflowInvoker : ExtensionResolver, IWorkflowInvoker
    {
        private WorkflowInvoker workflowInvoker;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectWorkflowInvoker"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public NinjectWorkflowInvoker(IKernel kernel)
            : base(kernel)
        {
        }

        /// <inheritdoc/>
        protected override WorkflowInstanceExtensionManager Extensions
        {
            get { return this.Invoker.Extensions; }
        }

        /// <inheritdoc/>
        private WorkflowInvoker Invoker
        {
            get
            {
                if (this.workflowInvoker == null)
                {
                    throw new InvalidOperationException("The WorkflowInvoker must be initialized first!");
                }

                return this.workflowInvoker;
            }

            set
            {
                this.workflowInvoker = value;
            }
        }

        /// <inheritdoc/>
        public void InvokeAsync(IDictionary<string, object> inputs, TimeSpan timeout, object userState)
        {
            this.Invoker.InvokeAsync(inputs, timeout, userState);
        }

        /// <inheritdoc/>
        public void InvokeAsync(IDictionary<string, object> inputs, object userState)
        {
            this.Invoker.InvokeAsync(inputs, userState);
        }

        /// <inheritdoc/>
        public void InvokeAsync(IDictionary<string, object> inputs, TimeSpan timeout)
        {
            this.Invoker.InvokeAsync(inputs, timeout);
        }

        /// <inheritdoc/>
        public void InvokeAsync(IDictionary<string, object> inputs)
        {
            this.Invoker.InvokeAsync(inputs);
        }

        /// <inheritdoc/>
        public void InvokeAsync(TimeSpan timeout, object userState)
        {
            this.Invoker.InvokeAsync(timeout, userState);
        }

        /// <inheritdoc/>
        public void InvokeAsync(TimeSpan timeout)
        {
            this.Invoker.InvokeAsync(timeout);
        }

        /// <inheritdoc/>
        public void InvokeAsync()
        {
            this.Invoker.InvokeAsync();
        }

        /// <inheritdoc/>
        public IDictionary<string,object> Invoke()
        {
            return this.Invoker.Invoke();
        }

        /// <inheritdoc/>
        public IDictionary<string,object> Invoke(TimeSpan timeout)
        {
            return this.Invoker.Invoke(timeout);
        }

        /// <inheritdoc/>
        public IDictionary<string,object> Invoke(IDictionary<string,object> inputs)
        {
            return this.Invoker.Invoke(inputs);
        }

        /// <inheritdoc/>
        public IDictionary<string,object> Invoke(IDictionary<string,object> inputs, TimeSpan timeout)
        {
            return this.Invoker.Invoke(inputs, timeout);
        }

        /// <inheritdoc/>
        public IDictionary<string,object> EndInvoke(IAsyncResult result)
        {
            return this.Invoker.EndInvoke(result);
        }

        /// <inheritdoc/>
        public void CancelAsync(object userState)
        {
            this.Invoker.CancelAsync(userState);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginInvoke(AsyncCallback callback, object state)
        {
            return this.Invoker.BeginInvoke(callback, state);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginInvoke(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.Invoker.BeginInvoke(timeout, callback, state);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginInvoke(IDictionary<string,object> inputs, AsyncCallback callback, object state)
        {
            return this.Invoker.BeginInvoke(inputs, callback, state);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginInvoke(IDictionary<string,object> inputs, TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.Invoker.BeginInvoke(inputs, timeout, callback, state);
        }

        /// <inheritdoc/>
        public void Initialize(Activity workflowDefinition)
        {
            this.Invoker = new WorkflowInvoker(workflowDefinition);

            this.AddSingletonExtension<ActivityDependencyInjection>();
        }
    }
}