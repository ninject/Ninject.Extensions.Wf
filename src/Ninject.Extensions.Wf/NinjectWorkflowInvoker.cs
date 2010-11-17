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
    using System.Collections.Generic;
    using Infrastructure;

    public class NinjectWorkflowInvoker : IWorkflowInvoker, IHaveKernel
    {
        private WorkflowInvoker workflowInvoker;

        public NinjectWorkflowInvoker(Activity activity, IKernel kernel)
        {
            this.Kernel = kernel;

            this.workflowInvoker = new WorkflowInvoker(activity);
        }

        /// <summary>
        /// Gets the kernel.
        /// </summary>
        public IKernel Kernel { get; private set; }

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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
        }

        /// <summary>
        /// Invokes a workflow asynchronously with the specified time-out interval.
        /// </summary>
        /// <param name="timeout">The interval in which the workflow must complete before it is aborted and a System.TimeoutException is thrown.</param>
        public void InvokeAsync(TimeSpan timeout)
        {
        }

        /// <summary>
        /// Invokes a workflow asynchronously.
        /// </summary>
        public void InvokeAsync()
        {
        }
    }
}