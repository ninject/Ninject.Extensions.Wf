//-------------------------------------------------------------------------------
// <copyright file="ActivityInjectorTest.cs" company="bbv Software Services AG">
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
    using Model;
    using Moq;
    using Xunit;

    public class ActivityInjectorTest : KernelProvidingBase
    {
        private Mock<IActivityResolver> activityResolver;
        private ActivityInjector testee;

        public ActivityInjectorTest()
        {
            this.activityResolver = new Mock<IActivityResolver>();

            this.testee = new ActivityInjector(this.Kernel, this.activityResolver.Object);
        }

        [Fact]
        public void Inject_WhenBindingDefined_WhenInjectAttributeDefined_MustFullFillDependencyOnActivity()
        {
            this.SetupDependencyBinding();

            TestActivityWithDependencyAndAttribute activityWithDependencyAndAttribute = SetupActivityWithDependencyAttribute();
            this.SetupActivityResolver(activityWithDependencyAndAttribute);

            this.testee.Inject(activityWithDependencyAndAttribute);

            Assert.NotNull(activityWithDependencyAndAttribute.Dependency);
        }

        [Fact]
        public void Inject_WhenBindingDefined_WhenInjectAttributeNotDefined_MustNotFullFillDependencyOnActivity()
        {
            this.SetupDependencyBinding();

            TestActivityWithDependency activityWithDependency = SetupActivityWithDependency();
            this.SetupActivityResolver(activityWithDependency);

            this.testee.Inject(activityWithDependency);

            Assert.Null(activityWithDependency.Dependency);
        }

        [Fact]
        public void Inject_WhenBindingNotDefined_WhenInjectAttributeDefined_MustMustThrowActivationException()
        {
            TestActivityWithDependencyAndAttribute activityWithDependencyAndAttribute = SetupActivityWithDependencyAttribute();
            this.SetupActivityResolver(activityWithDependencyAndAttribute);

            Assert.Throws<ActivationException>(() => this.testee.Inject(activityWithDependencyAndAttribute));
        }

        private void SetupActivityResolver(Activity activity)
        {
            var activities = new List<Activity>
                                            {
                                                activity
                                            };

            this.activityResolver.Setup(resolver => resolver.GetActivities(activity))
                .Returns(activities);
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