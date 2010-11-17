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

namespace Ninject.Extensions.Wf.Extensions
{
    using System.Activities;
    using System.Collections.Generic;

    public class ActivityResolver : IActivityResolver
    {
        public IEnumerable<Activity> GetActivities(Activity root)
        {
            var activities = new List<Activity> { root };

            this.GetActivities(root, activities);

            return activities;
        }

        private void GetActivities(Activity root, ICollection<Activity> collectedActivities)
        {
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