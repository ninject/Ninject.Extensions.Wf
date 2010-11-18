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
    using System;
    using System.Activities;
    using System.Collections.Generic;
    using Model;
    using Moq;
    using Xunit;

    public class ActivityDependencyInjectionTest : KernelProvidingBase
    {
        private ActivityDependencyInjection testee;
        private Mock<IActivityResolver> activityResolver;

        public ActivityDependencyInjectionTest()
        {
            this.activityResolver = new Mock<IActivityResolver>();
            this.Kernel.Bind<IActivityResolver>().ToConstant(this.activityResolver.Object);


            this.testee = new ActivityDependencyInjection(this.Kernel);
        }

        [Fact]
        public void Constructor_MustThrowInvalidOperationExceptionWhenRequiredBindingsNotDefined()
        {
            var k = new StandardKernel(new NinjectSettings { LoadExtensions = false });
            Assert.Throws<InvalidOperationException>(() => new ActivityDependencyInjection(k));
        }

        [Fact]
        public void GetAdditionalExtensions_MustReturnEmptyEnumerable()
        {
            Assert.Empty(this.testee.GetAdditionalExtensions());
        }

        [Fact]
        public void SetInstance_MustResolveActivitiesWithWorkflowDefinition()
        {
            TestActivityWithDependencyAndAttribute activityWithDependencyAndAttribute = SetupActivityWithDependencyAttribute();
            WorkflowInvoker invoker = this.SetupWorkflowInvoker(activityWithDependencyAndAttribute);

            invoker.Invoke();

            this.activityResolver.Verify(resolver => resolver.GetActivities(activityWithDependencyAndAttribute));
        }

        [Fact]
        public void SetInstance_WhenBindingDefined_WhenInjectAttributeDefined_MustFullFillDependencyOnActivity()
        {
            this.SetupDependencyBinding();

            TestActivityWithDependencyAndAttribute activityWithDependencyAndAttribute = SetupActivityWithDependencyAttribute();

            this.SetupResolver(activityWithDependencyAndAttribute);

            WorkflowInvoker invoker = this.SetupWorkflowInvoker(activityWithDependencyAndAttribute);

            invoker.Invoke();

            Assert.NotNull(activityWithDependencyAndAttribute.Dependency);
        }

        [Fact]
        public void SetInstance_WhenBindingDefined_WhenInjectAttributeNotDefined_MustNotFullFillDependencyOnActivity()
        {
            this.SetupDependencyBinding();

            TestActivityWithDependency activityWithDependency = SetupActivityWithDependency();

            this.SetupResolver(activityWithDependency);

            WorkflowInvoker invoker = this.SetupWorkflowInvoker(activityWithDependency);

            invoker.Invoke();

            Assert.Null(activityWithDependency.Dependency);
        }

        [Fact]
        public void SetInstance_WhenBindingNotDefined_WhenInjectAttributeDefined_MustMustThrowActivationException()
        {
            TestActivityWithDependencyAndAttribute activityWithDependencyAndAttribute = SetupActivityWithDependencyAttribute();

            this.SetupResolver(activityWithDependencyAndAttribute);

            WorkflowInvoker invoker = this.SetupWorkflowInvoker(activityWithDependencyAndAttribute);

            Assert.Throws<ActivationException>(() => invoker.Invoke());
        }

        private void SetupResolver(Activity root)
        {
            this.activityResolver.Setup(resolver => resolver.GetActivities(root))
                .Returns(new List<Activity> { root });
        }

        private void SetupDependencyBinding()
        {
            this.Kernel.Bind<IDependency>().To<Dependency>();
        }

        private WorkflowInvoker SetupWorkflowInvoker(Activity activity)
        {
            WorkflowInvoker invoker = new WorkflowInvoker(activity);
            invoker.Extensions.Add(this.testee);
            return invoker;
        }

        private static TestActivityWithDependencyAndAttribute SetupActivityWithDependencyAttribute()
        {
            return new TestActivityWithDependencyAndAttribute();
        }

        private static TestActivityWithDependency SetupActivityWithDependency()
        {
            return new TestActivityWithDependency();
        }
    }
}