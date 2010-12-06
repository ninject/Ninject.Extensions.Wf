//-------------------------------------------------------------------------------
// <copyright file="IActivityInjectorExtension.cs" company="bbv Software Services AG">
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
    using System.Activities;

    /// <summary>
    /// An activity injector extension allows to hook into the injection
    /// process. Registered activity injector extensions are processed after the
    /// the internal extensions.
    /// </summary>
    public interface IActivityInjectorExtension
    {
        /// <summary>
        /// Determines whether this instance can process the specified activity.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <returns>
        /// <c>true</c> if this instance can process the specified activity; otherwise, <c>false</c>.
        /// </returns>
        bool CanProcess(Activity activity);

        /// <summary>
        /// Processes the specified activity.
        /// </summary>
        /// <param name="activity">The activity.</param>
        void Process(Activity activity);
    }
}