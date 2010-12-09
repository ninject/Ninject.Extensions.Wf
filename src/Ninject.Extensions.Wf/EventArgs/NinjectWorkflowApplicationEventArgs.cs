//-------------------------------------------------------------------------------
// <copyright file="NinjectWorkflowApplicationEventArgs.cs" company="bbv Software Services AG">
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

    /// <summary>
    /// Wraps the <see cref="WorkflowApplicationEventArgs"/>.
    /// </summary>
    public class NinjectWorkflowApplicationEventArgs : EventArgs
    {
        private readonly WorkflowApplicationEventArgs workflowApplicationArguments;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectWorkflowApplicationEventArgs"/> class.
        /// </summary>
        /// <param name="instanceId">The instance id.</param>
        public NinjectWorkflowApplicationEventArgs(Guid instanceId)
        {
            this.InstanceId = instanceId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectWorkflowApplicationEventArgs"/> class.
        /// </summary>
        /// <param name="workflowApplicationArguments">The <see cref="System.Activities.WorkflowApplicationEventArgs"/> instance containing the event data.</param>
        internal NinjectWorkflowApplicationEventArgs(WorkflowApplicationEventArgs workflowApplicationArguments)
        {
            this.workflowApplicationArguments = workflowApplicationArguments;

            this.InstanceId = this.Arguments.InstanceId;
        }

        /// <summary>
        /// Gets the underlying <see cref="WorkflowApplicationEventArgs"/>.
        /// </summary>
        /// <value>The <see cref="WorkflowApplicationEventArgs"/>.</value>
        public WorkflowApplicationEventArgs Arguments
        {
            get { return this.workflowApplicationArguments; }
        }

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="P:System.Activities.WorkflowApplicationEventArgs.InstanceId"]/*' />
        public Guid InstanceId { get; private set; }
    }
}