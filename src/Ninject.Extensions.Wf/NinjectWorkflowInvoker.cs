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

    public class NinjectWorkflowInvoker : ExtensionResolver, IWorkflowInvoker
    {
        private WorkflowInvoker workflowInvoker;

        public NinjectWorkflowInvoker(IKernel kernel)
            : base(kernel)
        {
        }

        protected override WorkflowInstanceExtensionManager Extensions
        {
            get { return this.Invoker.Extensions; }
        }

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

        /// <summary>
        /// Invokes a workflow asynchronously with the specified
        /// System.Collections.Generic.IDictionary{TKey,TValue} of input
        /// parameters, the specified time-out interval, and a unique
        /// identifier.
        /// </summary>
        /// <param name="inputs">The dictionary of input parameters to the
        /// workflow, keyed by argument name.</param>
        /// <param name="timeout">The interval in which the workflow must
        /// complete before it is aborted and a System.TimeoutException is
        /// thrown.</param>
        /// <param name="userState"> A user-provided object used to distinguish
        /// this particular asynchronous invoke operation from other current
        /// asynchronous invoke operations.</param>
        public void InvokeAsync(IDictionary<string, object> inputs, TimeSpan timeout, object userState)
        {
            this.Invoker.InvokeAsync(inputs, timeout, userState);
        }

        /// <summary>
        /// Invokes a workflow asynchronously using the specified input object
        /// as input parameters, the specified time-out interval, and a unique
        /// identifier.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <param name="inputs">The input object which is turned into a
        /// dictionary by <see cref="ObjectExtensions.ToDict"/>.</param>
        /// <param name="timeout">The interval in which the workflow must
        /// complete before it is aborted and a System.TimeoutException is
        /// thrown.</param>
        /// <param name="userState">A user-provided object used to distinguish
        /// this particular asynchronous invoke operation from other current
        /// asynchronous invoke operations.</param>
        public void InvokeAsync<TInput>(TInput inputs, TimeSpan timeout, object userState)
            where TInput : class
        {
            this.InvokeAsync(inputs.ToDict(), timeout, userState);
        }

        /// <summary>
        /// Invokes a workflow asynchronously using the specified
        /// System.Collections.Generic.IDictionary{TKey,TValue} of input
        /// parameters and a unique identifier.
        /// </summary>
        /// <param name="inputs">The dictionary of input parameters to the
        /// workflow, keyed by argument name.</param>
        /// <param name="userState">A user-provided object used to distinguish
        /// this particular asynchronous invoke operation from other current
        /// asynchronous invoke operations.</param>
        public void InvokeAsync(IDictionary<string, object> inputs, object userState)
        {
            this.Invoker.InvokeAsync(inputs, userState);
        }

        /// <summary>
        /// Invokes a workflow asynchronously using the specified input object
        /// as input parameters and a unique identifier.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <param name="inputs">The input object which is turned into a
        /// dictionary by <see cref="ObjectExtensions.ToDict"/>.</param>
        /// <param name="userState">A user-provided object used to distinguish
        /// this particular asynchronous invoke operation from other current
        /// asynchronous invoke operations.</param>
        public void InvokeAsync<TInput>(TInput inputs, object userState)
        {
            this.InvokeAsync(inputs.ToDict(), userState);
        }

        /// <summary>
        /// Invokes a workflow asynchronously with the specified
        /// System.Collections.Generic.IDictionary{TKey,TValue} of input
        /// parameters and the specified time-out interval.
        /// </summary>
        /// <param name="inputs">The dictionary of input parameters to the
        /// workflow, keyed by argument name.</param>
        /// <param name="timeout">The interval in which the workflow must
        /// complete before it is aborted and a System.TimeoutException is
        /// thrown.</param>
        public void InvokeAsync(IDictionary<string, object> inputs, TimeSpan timeout)
        {
            this.Invoker.InvokeAsync(inputs, timeout);
        }

        /// <summary>
        /// Invokes a workflow asynchronously using the specified input object
        /// as input parameters and the specified time-out interval.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <param name="inputs">The input object which is turned into a
        /// dictionary by <see cref="ObjectExtensions.ToDict"/>.</param>
        /// <param name="timeout">The interval in which the workflow must
        /// complete before it is aborted and a System.TimeoutException is
        /// thrown.</param>
        public void InvokeAsync<TInput>(TInput inputs, TimeSpan timeout)
            where TInput : class
        {
            this.InvokeAsync(inputs.ToDict(), timeout);
        }

        /// <summary>
        /// Invokes a workflow asynchronously using the specified
        /// System.Collections.Generic.IDictionary{TKey,TValue} of input
        /// parameters.
        /// </summary>
        /// <param name="inputs">The dictionary of input parameters to the
        /// workflow, keyed by argument name.</param>
        public void InvokeAsync(IDictionary<string, object> inputs)
        {
            this.Invoker.InvokeAsync(inputs);
        }

        /// <summary>
        /// Invokes a workflow asynchronously using the specified input object
        /// as input parameters.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <param name="inputs">The input object which is turned into a
        /// dictionary by <see cref="ObjectExtensions.ToDict"/>.</param>
        public void InvokeAsync<TInput>(TInput inputs)
            where TInput : class
        {
            this.InvokeAsync(inputs.ToDict());
        }

        /// <summary>
        /// Invokes a workflow asynchronously with the specified time-out
        /// interval and a unique identifier.
        /// </summary>
        /// <param name="timeout">The interval in which the workflow must
        /// complete before it is aborted and a System.TimeoutException is
        /// thrown.</param>
        /// <param name="userState">A user-provided object used to distinguish
        /// this particular asynchronous invoke operation from other current
        /// asynchronous invoke operations.</param>
        public void InvokeAsync(TimeSpan timeout, object userState)
        {
            this.Invoker.InvokeAsync(timeout, userState);
        }

        /// <summary>
        /// Invokes a workflow asynchronously with the specified time-out interval.
        /// </summary>
        /// <param name="timeout">The interval in which the workflow must complete before it is aborted and a System.TimeoutException is thrown.</param>
        public void InvokeAsync(TimeSpan timeout)
        {
            this.Invoker.InvokeAsync(timeout);
        }

        /// <summary>
        /// Invokes a workflow asynchronously.
        /// </summary>
        public void InvokeAsync()
        {
            this.Invoker.InvokeAsync();
        }

        public void Initialize(Activity workflowDefinition)
        {
            this.Invoker = new WorkflowInvoker(workflowDefinition);

            this.AddSingletonExtension<ActivityDependencyInjection>();
        }
    }
}