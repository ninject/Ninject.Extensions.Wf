//-------------------------------------------------------------------------------
// <copyright file="NinjectWorkflowApplicationIdleEventArgs.cs" company="bbv Software Services AG">
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
    using System;
    using System.Activities;
    using System.Collections.ObjectModel;
    using System.Linq;

    /// <summary>
    /// Wraps the <see cref="WorkflowApplicationIdleEventArgs"/>.
    /// </summary>
    public class NinjectWorkflowApplicationIdleEventArgs : NinjectWorkflowApplicationEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectWorkflowApplicationIdleEventArgs"/> class.
        /// </summary>
        /// <param name="instanceId">The instance id.</param>
        /// <param name="bookmarks">The bookmarks.</param>
        public NinjectWorkflowApplicationIdleEventArgs(Guid instanceId, ReadOnlyCollection<NinjectBookmarkInfo> bookmarks)
            : base(instanceId)
        {
            this.Bookmarks = bookmarks;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectWorkflowApplicationIdleEventArgs"/> class.
        /// </summary>
        /// <param name="workflowApplicationIdleEventArgs">The <see cref="System.Activities.WorkflowApplicationIdleEventArgs"/> instance containing the event data.</param>
        public NinjectWorkflowApplicationIdleEventArgs(WorkflowApplicationIdleEventArgs workflowApplicationIdleEventArgs)
            : base(workflowApplicationIdleEventArgs)
        {
            this.Bookmarks = workflowApplicationIdleEventArgs.Bookmarks
                .Select(info => new NinjectBookmarkInfo(info)).ToList().AsReadOnly();
        }

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="P:System.Activities.WorkflowApplicationIdleEventArgs.Bookmarks"]/*' />
        public ReadOnlyCollection<NinjectBookmarkInfo> Bookmarks
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the underlying <see cref="WorkflowApplicationIdleEventArgs"/>.
        /// </summary>
        /// <value>The <see cref="WorkflowApplicationIdleEventArgs"/>.</value>
        public new WorkflowApplicationIdleEventArgs Arguments
        {
            get { return (WorkflowApplicationIdleEventArgs) base.Arguments; }
        }
    }
}