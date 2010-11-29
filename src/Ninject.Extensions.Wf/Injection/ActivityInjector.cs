//-------------------------------------------------------------------------------
// <copyright file="ActivityInjector.cs" company="bbv Software Services AG">
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
    using System.Activities;
    using Infrastructure;

    public class ActivityInjector : IActivityInjector, IHaveKernel
    {
        private readonly IKernel kernel;
        private readonly IActivityResolver activityResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityInjector"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        /// <param name="activityResolver">The activity resolver.</param>
        public ActivityInjector(IKernel kernel, IActivityResolver activityResolver)
        {
            this.activityResolver = activityResolver;
            this.kernel = kernel;
        }

        public void Inject(Activity root)
        {
            var activities = this.activityResolver.GetActivities(root);

            foreach (Activity activity in activities)
            {
                this.kernel.Inject(activity);
            }
        }

        public IKernel Kernel
        {
            get { return this.kernel; }
        }
    }
}