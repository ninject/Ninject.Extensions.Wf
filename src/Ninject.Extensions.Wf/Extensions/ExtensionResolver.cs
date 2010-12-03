//-------------------------------------------------------------------------------
// <copyright file="ExtensionResolver.cs" company="bbv Software Services AG">
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
    using System.Activities.Hosting;
    using Ninject.Infrastructure;

    /// <summary>
    /// Base class which provides extension on kernel resolving ability.
    /// </summary>
    public abstract class ExtensionResolver : IResolveExtensions, IHaveKernel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionResolver"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        protected ExtensionResolver(IKernel kernel)
        {
            this.Kernel = kernel;
        }

        /// <summary>
        /// Gets the kernel.
        /// </summary>
        public IKernel Kernel { get; private set; }

        /// <summary>
        /// Gets the extensions. The inheritor must return the used extension manager.
        /// </summary>
        /// <value>The extensions.</value>
        protected abstract WorkflowInstanceExtensionManager Extensions
        {
            get;
        }

        /// <summary>
        /// Adds an extension with a singleton scope to the underlying workflow.
        /// </summary>
        /// <typeparam name="TExtension">The extension to add.</typeparam>
        /// <remarks>This is independent from the scope defined on the ninject
        /// kernel. The scoping of the
        /// <see cref="WorkflowInstanceExtensionManager"/> is applied.</remarks>
        public void AddSingletonExtension<TExtension>() where TExtension : class
        {
            this.Extensions.Add(this.Kernel.Get<TExtension>());
        }

        /// <summary>
        /// Adds an extension with a transient scope to the underlying workflow.
        /// </summary>
        /// <typeparam name="TExtension">The extension to add.</typeparam>
        /// <remarks>This is independent from the scope defined on the ninject
        /// kernel. The scoping of the
        /// <see cref="WorkflowInstanceExtensionManager"/> is applied.</remarks>
        public void AddTransientExtension<TExtension>() where TExtension : class
        {
            this.Extensions.Add(() => this.Kernel.Get<TExtension>());
        }
    }
}