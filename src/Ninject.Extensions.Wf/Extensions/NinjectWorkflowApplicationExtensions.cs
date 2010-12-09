//-------------------------------------------------------------------------------
// <copyright file="NinjectWorkflowApplicationExtensions.cs" company="bbv Software Services AG">
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
    using System.Activities;

    /// <summary>
    /// Contains extension methods for the <see cref="IWorkflowApplication"/>.
    /// </summary>
    public static class NinjectWorkflowApplicationExtensions
    {
        /// <summary>
        /// Initializes the specified application.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <param name="application">The application.</param>
        /// <param name="workflowDefinition">The workflow definition.</param>
        /// <param name="inputs">The inputs.</param>
        public static void Initialize<TInput>(this IWorkflowApplication application, Activity workflowDefinition, TInput inputs)
            where TInput : class
        {
            application.Initialize(workflowDefinition, inputs.ToDict());
        }
    }
}