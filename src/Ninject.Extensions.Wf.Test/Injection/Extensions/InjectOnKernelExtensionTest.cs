//-------------------------------------------------------------------------------
// <copyright file="InjectOnKernelExtensionTest.cs" company="bbv Software Services AG">
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

namespace Ninject.Extensions.Wf.Injection.Extensions
{
    using Model;
    using Xunit;

    public class InjectOnKernelExtensionTest : KernelProvidingBase
    {
        private readonly InjectOnKernelExtension testee;

        public InjectOnKernelExtensionTest()
        {
            this.testee = new InjectOnKernelExtension(this.Kernel);
        }

        [Fact]
        public void Process_WhenBindingDefined_WhenInjectAttributeDefined_MustFullFillDependencyOnActivity()
        {
            this.SetupDependencyBinding();

            TestActivityWithDependencyAndAttribute activityWithDependencyAndAttribute = SetupActivityWithDependencyAttribute();

            this.testee.Process(activityWithDependencyAndAttribute);

            Assert.NotNull(activityWithDependencyAndAttribute.Dependency);
        }

        [Fact]
        public void Process_WhenBindingDefined_WhenInjectAttributeNotDefined_MustNotFullFillDependencyOnActivity()
        {
            this.SetupDependencyBinding();

            TestActivityWithDependency activityWithDependency = SetupActivityWithDependency();

            this.testee.Process(activityWithDependency);

            Assert.Null(activityWithDependency.Dependency);
        }

        [Fact]
        public void Process_WhenBindingNotDefined_WhenInjectAttributeDefined_MustMustThrowActivationException()
        {
            TestActivityWithDependencyAndAttribute activityWithDependencyAndAttribute = SetupActivityWithDependencyAttribute();

            Assert.Throws<ActivationException>(() => this.testee.Process(activityWithDependencyAndAttribute));
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