//-------------------------------------------------------------------------------
// <copyright file="ActivityResolver.cs" company="bbv Software Services AG">
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
    using System.Collections.Generic;

    /// <summary>
    /// Resolves the activity tree by using <see cref="WorkflowInspectionServices"/>
    /// </summary>
    public class ActivityResolver : IActivityResolver
    {
        /// <summary>
        /// Gets the activities which are under a given root activity.
        /// </summary>
        /// <param name="root">The root activity.</param>
        /// <returns>All activities under root.</returns>
        public IEnumerable<Activity> GetActivities(Activity root)
        {
            var activities = new List<Activity> { root };

            this.GetActivities(root, activities);

            return activities;
        }

        /// <summary>
        /// Gets the activities recursively.
        /// </summary>
        /// <param name="root">The root activity to start with.</param>
        /// <param name="collectedActivities">The collected activities.</param>
        private void GetActivities(Activity root, ICollection<Activity> collectedActivities)
        {
            /*
             * To retrieve a specific activity instead of enumerating all of the activities, 
             * Resolve is used. Both Resolve and GetActivities perform metadata caching if
             * WorkflowInspectionServices.CacheMetadata has not been previously called. 
             * If CacheMetadata has been called then GetActivities is based on the existing metadata.
             * Therefore, if tree changes have been made since the last call to CacheMetadata, 
             * GetActivities might give unexpected results. If changes have been made to the workflow 
             * after calling GetActivities, metadata can be re-cached by calling the ActivityValidationServices Validate
             * method. Caching metadata is discussed in the next section.
             * */

            IEnumerable<Activity> activities =
                WorkflowInspectionServices.GetActivities(root);

            foreach (var activity in activities)
            {
                collectedActivities.Add(activity);

                this.GetActivities(activity, collectedActivities);
            }
        }
    }
}