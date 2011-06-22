//-------------------------------------------------------------------------------
// <copyright file="ActivityDependencyInjectionTest.cs" company="bbv Software Services AG">
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
    using System.Activities.Statements;

    using FluentAssertions;

    using Moq;
    using Xunit;

    public class ActivityDependencyInjectionTest
    {
        private ActivityDependencyInjection testee;
        private Mock<IActivityInjector> activityInjector;

        public ActivityDependencyInjectionTest()
        {
            this.activityInjector = new Mock<IActivityInjector>();

            this.testee = new ActivityDependencyInjection(this.activityInjector.Object);
        }

        [Fact]
        public void GetAdditionalExtensions_MustReturnEmptyEnumerable()
        {
            this.testee.GetAdditionalExtensions().Should().BeEmpty();
        }

        [Fact]
        public void SetInstance_MustInjectWithWorkflowDefinition()
        {
            var activity = new WriteLine();
            WorkflowInvoker invoker = this.SetupWorkflowInvoker(activity);

            invoker.Invoke();

            this.activityInjector.Verify(injector => injector.Inject(activity));
        }

        private WorkflowInvoker SetupWorkflowInvoker(Activity activity)
        {
            WorkflowInvoker invoker = new WorkflowInvoker(activity);
            invoker.Extensions.Add(this.testee);
            return invoker;
        }
    }
}