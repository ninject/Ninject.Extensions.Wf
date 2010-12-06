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
    using System;
    using System.Activities;
    using System.Collections.Generic;
    using System.Text;
    using Extensions;
    using Model;
    using Moq;
    using Xunit;

    public class ActivityInjectorTest : KernelProvidingBase
    {
        private Mock<IActivityResolver> activityResolver;

        private Mock<IActivityInjectorExtension> extension;

        private Mock<IActivityInjectorExtension> anotherExtension;

        private Mock<IInjectOnKernelExtension> injectOnKernelExtension;

        private ActivityInjector testee;

        public ActivityInjectorTest()
        {
            this.extension = new Mock<IActivityInjectorExtension>();
            this.anotherExtension = new Mock<IActivityInjectorExtension>();
            this.injectOnKernelExtension = new Mock<IInjectOnKernelExtension>();

            this.activityResolver = new Mock<IActivityResolver>();

            this.testee = new ActivityInjector(this.activityResolver.Object, new List<IActivityInjectorExtension> { this.extension.Object, this.injectOnKernelExtension.Object, this.anotherExtension.Object });
        }

        [Fact]
        public void Constructor_MustThrowExceptionWhenNoInjectOnKernelExtensionContained()
        {
            Assert.Throws<InvalidOperationException>(
                () =>
                    {
                        var extensions = new List<IActivityInjectorExtension>
                                             {
                                                 this.extension.Object,
                                                 this.anotherExtension.Object
                                             };
                        new ActivityInjector(this.activityResolver.Object, extensions);
                    });
        }

        [Fact]
        public void Inject_WhenCanProcessIndicatesTrue_MustProcessActivityOnExtension()
        {
            this.SetupDependencyBinding();

            var activity = this.SetupActivityResolver();
            this.extension.Setup(e => e.CanProcess(activity)).Returns(true);

            this.testee.Inject(activity);

            this.extension.Verify(e => e.Process(activity));
        }

        [Fact]
        public void Inject_WhenCanProcessIndicatesFalse_MustNotProcessActivityOnExtension()
        {
            this.SetupDependencyBinding();

            var activity = this.SetupActivityResolver();
            this.extension.Setup(e => e.CanProcess(activity)).Returns(false);

            this.testee.Inject(activity);

            this.extension.Verify(e => e.Process(activity), Times.Never());
        }

        [Fact]
        public void Inject_MustFirstProcessIInjectOnKernelExtension()
        {
            var builder = new StringBuilder();
            
            this.SetupDependencyBinding();

            var activity = this.SetupActivityResolver();
            this.extension.Setup(e => e.CanProcess(activity)).Returns(true);
            this.extension.Setup(e => e.Process(activity)).Callback<Activity>(a => builder.AppendLine("Extension"));

            this.anotherExtension.Setup(e => e.CanProcess(activity)).Returns(true);
            this.anotherExtension.Setup(e => e.Process(activity)).Callback<Activity>(a => builder.AppendLine("AnotherExtension"));

            this.injectOnKernelExtension.Setup(e => e.CanProcess(activity)).Returns(true);
            this.injectOnKernelExtension.Setup(e => e.Process(activity)).Callback<Activity>(a => builder.AppendLine("InjectOnKernelExtension"));

            this.testee.Inject(activity);

            Assert.Equal("InjectOnKernelExtension\r\nExtension\r\nAnotherExtension\r\n", builder.ToString());
        }

        private TestActivityWithDependencyAndAttribute SetupActivityResolver()
        {
            TestActivityWithDependencyAndAttribute activityWithDependencyAndAttribute = SetupActivityWithDependencyAttribute();
            this.SetupActivityResolver(activityWithDependencyAndAttribute);
            return activityWithDependencyAndAttribute;
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