//-------------------------------------------------------------------------------
// <copyright file="ActivityDependencyInjection.cs" company="bbv Software Services AG">
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

namespace Ninject.Extensions.Wf.Injection
{
    using System;
    using System.Activities.Hosting;
    using System.Collections.Generic;
    using System.Linq;
    using Ninject.Infrastructure;

    /// <summary>
    /// Extension which resolves all activities recursively and builds them up
    /// with the provided kernel.
    /// </summary>
    public class ActivityDependencyInjection : IWorkflowInstanceExtension, IHaveKernel
    {
        /// <summary>
        /// The kernel
        /// </summary>
        private readonly IKernel kernel;

        /// <summary>
        /// Enables to extension to inject dependencies into activities
        /// </summary>
        private readonly IActivityInjector activityInjector;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityDependencyInjection"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public ActivityDependencyInjection(IKernel kernel)
        {
            this.kernel = kernel;

            this.activityInjector = this.kernel.TryGet<IActivityInjector>();

            if (this.activityInjector == null)
            {
                throw new InvalidOperationException("WfExtensionModule must be loaded!");
            }
        }

        /// <summary>
        /// Gets the kernel.
        /// </summary>
        public IKernel Kernel
        {
            get { return this.kernel; }
        }

        /// <summary>
        /// When implemented, returns any additional extensions the implementing class requires.
        /// </summary>
        /// <returns>
        /// A collection of additional workflow extensions.
        /// </returns>
        public IEnumerable<object> GetAdditionalExtensions()
        {
            return Enumerable.Empty<object>();
        }

        /// <summary>
        /// Sets the specified target <see cref="T:System.Activities.Hosting.WorkflowInstanceProxy"/>.
        /// </summary>
        /// <param name="instance">The target workflow instance to set.</param>
        public void SetInstance(WorkflowInstanceProxy instance)
        {
            this.activityInjector.Inject(instance.WorkflowDefinition);
        }
    }
}