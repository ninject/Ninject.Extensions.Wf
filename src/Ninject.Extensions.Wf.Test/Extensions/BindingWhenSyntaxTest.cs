//-------------------------------------------------------------------------------
// <copyright file="BindingWhenSyntaxTest.cs" company="bbv Software Services AG">
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
    using System;

    using FluentAssertions;

    using Injection.Model;
    using Parameters;
    using Xunit;

    public class BindingWhenSyntaxTest : KernelProvidingBase
    {
        [Fact]
        public void WhenInjectedIntoActivity_WithType_WhenTypeNotActivity_MustThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => this.Kernel.Bind<IDependency>().To<Dependency>()
                .WhenInjectedIntoActivity(typeof(string)));
        }

        [Fact]
        public void WhenInjectedIntoActivity_WithType_WhenTypeActivityAndRootActivityParameter_MustFulfillDependency()
        {
            this.Kernel.Bind<IDependency>().To<Dependency>()
                .WhenInjectedIntoActivity(typeof(TestActivityWithDependencyAndAttribute));

            TestActivityWithDependencyAndAttribute activity = new TestActivityWithDependencyAndAttribute();

            this.Kernel.Inject(activity, new RootActivityParameter(activity));

            activity.Dependency.Should().NotBeNull();
        }

        [Fact]
        public void WhenInjectedIntoActivity_WithType_WhenTypeActivityButNoRootActivityParameter_MustNotFulfillDependency()
        {
            this.Kernel.Bind<IDependency>().To<Dependency>()
                .WhenInjectedIntoActivity(typeof(TestActivityWithDependencyAndAttribute));

            TestActivityWithDependencyAndAttribute activity = new TestActivityWithDependencyAndAttribute();

            Assert.Throws<ActivationException>(() => this.Kernel.Inject(activity));
        }

        [Fact]
        public void WhenInjectedIntoActivity_WithType_WhenTypeActivityButRootActivityDoesNotMatch_MustNotFulfillDependency()
        {
            this.Kernel.Bind<IDependency>().To<Dependency>()
                .WhenInjectedIntoActivity(typeof(TestActivityWithDependency));

            TestActivityWithDependencyAndAttribute activity = new TestActivityWithDependencyAndAttribute();

            Assert.Throws<ActivationException>(() => this.Kernel.Inject(activity, new RootActivityParameter(activity)));
        }

        [Fact]
        public void WhenInjectedIntoActivity_WithFunc_WhenFuncDoesMatch_MustFulfillDependency()
        {
            this.Kernel.Bind<IDependency>().To<Dependency>()
                .WhenInjectedIntoActivity(a => true);

            TestActivityWithDependencyAndAttribute activity = new TestActivityWithDependencyAndAttribute();

            this.Kernel.Inject(activity, new RootActivityParameter(activity));

            activity.Dependency.Should().NotBeNull();
        }

        [Fact]
        public void WhenInjectedIntoActivity_WithFunc_WhenNoRootActivityParameter_MustNotFulfillDependency()
        {
            this.Kernel.Bind<IDependency>().To<Dependency>()
                .WhenInjectedIntoActivity(a => true);

            TestActivityWithDependencyAndAttribute activity = new TestActivityWithDependencyAndAttribute();

            Assert.Throws<ActivationException>(() => this.Kernel.Inject(activity));
        }

        [Fact]
        public void WhenInjectedIntoActivity_WithFunc_WhenFuncDoesNotMatch_MustNotFulfillDependency()
        {
            this.Kernel.Bind<IDependency>().To<Dependency>()
                .WhenInjectedIntoActivity(a => a.DisplayName == string.Empty);

            TestActivityWithDependencyAndAttribute activity = new TestActivityWithDependencyAndAttribute();

            Assert.Throws<ActivationException>(() => this.Kernel.Inject(activity, new RootActivityParameter(activity)));
        }
    }
}