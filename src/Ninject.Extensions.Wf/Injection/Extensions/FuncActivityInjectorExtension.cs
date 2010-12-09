//-------------------------------------------------------------------------------
// <copyright file="FuncActivityInjectorExtension.cs" company="bbv Software Services AG">
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

namespace Ninject.Extensions.Wf.Injection.Extensions
{
    using System;
    using System.Activities;

    /// <summary>
    /// An injector extension which allows to use delegates.
    /// </summary>
    public class FuncActivityInjectorExtension : IActivityInjectorExtension
    {
        private readonly Func<Activity, bool> canProcess;

        private readonly Action<Activity> processAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="FuncActivityInjectorExtension"/> class.
        /// </summary>
        /// <param name="processAction">The process action.</param>
        public FuncActivityInjectorExtension(Action<Activity> processAction)
            : this(activity => true, processAction)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FuncActivityInjectorExtension"/> class.
        /// </summary>
        /// <param name="canProcess">The can process action.</param>
        /// <param name="processAction">The process action.</param>
        public FuncActivityInjectorExtension(Func<Activity, bool> canProcess, Action<Activity> processAction)
        {
            this.processAction = processAction;
            this.canProcess = canProcess;
        }

        /// <summary>
        /// Determines whether this instance can process the specified activity.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <returns>
        /// <c>true</c> if this instance can process the specified activity; otherwise, <c>false</c>.
        /// </returns>
        public bool CanProcess(Activity activity)
        {
            return this.canProcess(activity);
        }

        /// <summary>
        /// Processes the specified activity.
        /// </summary>
        /// <param name="activity">The activity.</param>
        public void Process(Activity activity)
        {
            this.processAction(activity);
        }
    }
}