//-------------------------------------------------------------------------------
// <copyright file="IResolveExtensions.cs" company="bbv Software Services AG">
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
    using System.Activities.Hosting;

    /// <summary>
    /// The implementor must be able to resolve extensions
    /// </summary>
    public interface IResolveExtensions
    {
        /// <summary>
        /// Adds an extension with a singleton scope to the underlying workflow.
        /// </summary>
        /// <remarks>This is independent from the scope defined on the ninject
        /// kernel. The scoping of the 
        /// <see cref="WorkflowInstanceExtensionManager"/> is applied.</remarks>
        /// <typeparam name="TExtension">The extension to add.</typeparam>
        void AddSingletonExtension<TExtension>() where TExtension : class;

        /// <summary>
        /// Adds an extension with a transient scope to the underlying workflow.
        /// </summary>
        /// <remarks>This is independent from the scope defined on the ninject
        /// kernel. The scoping of the 
        /// <see cref="WorkflowInstanceExtensionManager"/> is applied.</remarks>
        /// <typeparam name="TExtension">The extension to add.</typeparam>
        void AddTransientExtension<TExtension>() where TExtension : class;
    }
}