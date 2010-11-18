//-------------------------------------------------------------------------------
// <copyright file="NinjectWorkflowInvokerExtensions.cs" company="bbv Software Services AG">
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


namespace Ninject.Extensions.Wf.Extensions
{
    using System;

    public static class NinjectWorkflowInvokerExtensions
    {
        /// <summary>
        /// Invokes a workflow asynchronously using the specified input object
        /// as input parameters.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <param name="invoker">The invoker.</param>
        /// <param name="inputs">The input object which is turned into a
        /// dictionary by <see cref="ObjectExtensions.ToDict"/>.</param>
        public static void InvokeAsync<TInput>(this IWorkflowInvoker invoker, TInput inputs)
            where TInput : class
        {
            invoker.InvokeAsync(inputs.ToDict());
        }

        /// <summary>
        /// Invokes a workflow asynchronously using the specified input object
        /// as input parameters and the specified time-out interval.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <param name="invoker">The invoker.</param>
        /// <param name="inputs">The input object which is turned into a
        /// dictionary by <see cref="ObjectExtensions.ToDict"/>.</param>
        /// <param name="timeout">The interval in which the workflow must
        /// complete before it is aborted and a System.TimeoutException is
        /// thrown.</param>
        public static void InvokeAsync<TInput>(this IWorkflowInvoker invoker, TInput inputs, TimeSpan timeout)
            where TInput : class
        {
            invoker.InvokeAsync(inputs.ToDict(), timeout);
        }

        /// <summary>
        /// Invokes a workflow asynchronously using the specified input object
        /// as input parameters and a unique identifier.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <param name="invoker">The invoker.</param>
        /// <param name="inputs">The input object which is turned into a
        /// dictionary by <see cref="ObjectExtensions.ToDict"/>.</param>
        /// <param name="userState">A user-provided object used to distinguish
        /// this particular asynchronous invoke operation from other current
        /// asynchronous invoke operations.</param>
        public static void InvokeAsync<TInput>(this IWorkflowInvoker invoker, TInput inputs, object userState)
        {
            invoker.InvokeAsync(inputs.ToDict(), userState);
        }

        /// <summary>
        /// Invokes a workflow asynchronously using the specified input object
        /// as input parameters, the specified time-out interval, and a unique
        /// identifier.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <param name="invoker">The invoker.</param>
        /// <param name="inputs">The input object which is turned into a
        /// dictionary by <see cref="ObjectExtensions.ToDict"/>.</param>
        /// <param name="timeout">The interval in which the workflow must
        /// complete before it is aborted and a System.TimeoutException is
        /// thrown.</param>
        /// <param name="userState">A user-provided object used to distinguish
        /// this particular asynchronous invoke operation from other current
        /// asynchronous invoke operations.</param>
        public static void InvokeAsync<TInput>(this IWorkflowInvoker invoker, TInput inputs, TimeSpan timeout, object userState)
            where TInput : class
        {
            invoker.InvokeAsync(inputs.ToDict(), timeout, userState);
        }
    }
}