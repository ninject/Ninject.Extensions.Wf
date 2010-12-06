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

    public class NinjectWorkflowApplicationIdleEventArgs : NinjectWorkflowApplicationEventArgs
    {
        public NinjectWorkflowApplicationIdleEventArgs(Guid instanceId, ReadOnlyCollection<NinjectBookmarkInfo> bookmarks)
            : base(instanceId)
        {
            this.Bookmarks = bookmarks;
        }

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

        public new WorkflowApplicationIdleEventArgs Arguments
        {
            get { return (WorkflowApplicationIdleEventArgs) base.Arguments; }
        }
    }
}