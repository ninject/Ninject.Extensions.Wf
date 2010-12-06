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
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;

    public class ActivityInjector : IActivityInjector
    {
        private readonly IActivityResolver activityResolver;

        private readonly IEnumerable<IActivityInjectorExtension> extensions;
        private readonly IInjectOnKernelExtension injectOnKernelExtension;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityInjector"/> class.
        /// </summary>
        /// <param name="activityResolver">The activity resolver.</param>
        /// <param name="extensions">The extensions.</param>
        public ActivityInjector(IActivityResolver activityResolver, IEnumerable<IActivityInjectorExtension> extensions)
        {
            this.extensions = extensions;
            this.activityResolver = activityResolver;
            this.injectOnKernelExtension = extensions.OfType<IInjectOnKernelExtension>().SingleOrDefault();

            if (this.injectOnKernelExtension == null)
            {
                throw new InvalidOperationException("IInjectOnKernelExtension not found!");
            }

            this.extensions = extensions.Where(e => !e.Equals(this.injectOnKernelExtension));
        }

        /// <summary>
        /// Begins the injection process starting from the root activity.
        /// </summary>
        /// <param name="root">The root activity.</param>
        public void Inject(Activity root)
        {
            var activities = this.activityResolver.GetActivities(root);

            foreach (Activity activity in activities)
            {
                Activity activity1 = activity;

                this.injectOnKernelExtension.Process(activity1);

                this.extensions.Where(e => e.CanProcess(activity1)).ToList().ForEach(e => e.Process(activity1));
            }
        }
    }
}