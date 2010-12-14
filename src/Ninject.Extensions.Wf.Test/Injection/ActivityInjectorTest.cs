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
    using System.Activities.Statements;
    using System.Collections.Generic;
    using System.Text;
    using Extensions;
    using Model;
    using Moq;
    using Xunit;

    public class ActivityInjectorTest : KernelProvidingBase
    {
        private readonly Mock<IActivityResolver> activityResolver;

        private readonly Mock<IActivityInjectorExtension> extension;

        private readonly Mock<IActivityInjectorExtension> anotherExtension;

        private readonly Mock<IInjectOnKernelExtension> injectOnKernelExtension;

        private readonly Sequence rootActivity;

        private readonly TestActivityWithDependencyAndAttribute childActivity;

        private readonly ActivityInjector testee;

        public ActivityInjectorTest()
        {
            this.extension = new Mock<IActivityInjectorExtension>();
            this.anotherExtension = new Mock<IActivityInjectorExtension>();
            this.injectOnKernelExtension = new Mock<IInjectOnKernelExtension>();

            this.activityResolver = new Mock<IActivityResolver>();

            this.rootActivity = new Sequence();
            this.childActivity = new TestActivityWithDependencyAndAttribute();

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
        public void Inject_WhenCanProcessIndicatesTrue_MustProcessActivityWithRootOnExtension()
        {
            this.SetupDependencyBinding();
            this.SetupActivityResolver();

            this.extension.Setup(e => e.CanProcess(It.IsAny<Activity>(), It.IsAny<Activity>())).Returns(true);

            this.testee.Inject(this.rootActivity);

            this.extension.Verify(e => e.Process(this.rootActivity, this.rootActivity));
            this.extension.Verify(e => e.Process(this.childActivity, this.rootActivity));
        }

        [Fact]
        public void Inject_WhenCanProcessIndicatesFalse_MustNotProcessActivityWithRootOnExtension()
        {
            this.SetupDependencyBinding();
            this.SetupActivityResolver();

            this.extension.Setup(e => e.CanProcess(It.IsAny<Activity>(), It.IsAny<Activity>())).Returns(false);

            this.testee.Inject(this.rootActivity);

            this.extension.Verify(e => e.Process(It.IsAny<Activity>(), It.IsAny<Activity>()), Times.Never());
        }

        [Fact]
        public void Inject_MustFirstProcessIInjectOnKernelExtension()
        {
            var builder = new StringBuilder();
            
            this.SetupDependencyBinding();
            this.SetupActivityResolver();

            this.extension.Setup(e => e.CanProcess(It.IsAny<Activity>(), It.IsAny<Activity>())).Returns(true);
            this.extension.Setup(e => e.Process(It.IsAny<Activity>(), It.IsAny<Activity>())).Callback<Activity, Activity>((a, r) => builder.AppendLine("Extension"));

            this.anotherExtension.Setup(e => e.CanProcess(It.IsAny<Activity>(), It.IsAny<Activity>())).Returns(true);
            this.anotherExtension.Setup(e => e.Process(It.IsAny<Activity>(), It.IsAny<Activity>())).Callback<Activity, Activity>((a, r) => builder.AppendLine("AnotherExtension"));

            this.injectOnKernelExtension.Setup(e => e.CanProcess(It.IsAny<Activity>(), It.IsAny<Activity>())).Returns(true);
            this.injectOnKernelExtension.Setup(e => e.Process(It.IsAny<Activity>(), It.IsAny<Activity>())).Callback<Activity, Activity>((a, r) => builder.AppendLine("InjectOnKernelExtension"));

            this.testee.Inject(this.rootActivity);

            Assert.Equal("InjectOnKernelExtension\r\nExtension\r\nAnotherExtension\r\nInjectOnKernelExtension\r\nExtension\r\nAnotherExtension\r\n", builder.ToString());
        }

        private void SetupActivityResolver()
        {
            var activities = new List<Activity>
                                            {
                                                this.rootActivity,
                                                this.childActivity,
                                            };

            this.activityResolver.Setup(resolver => resolver.GetActivities(this.rootActivity))
                .Returns(activities);
        }
    }
}