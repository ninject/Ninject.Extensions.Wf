//-------------------------------------------------------------------------------
// <copyright file="ExtensionResolverTest.cs" company="bbv Software Services AG">
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
    using System.Activities.Hosting;
    using Ninject.Extensions.Wf.Injection.Model;
    using Moq;
    using Moq.Protected;
    using Xunit;

    public class ExtensionResolverTest : KernelProvidingBase
    {
        private ExtensionResolver testee;

        private Mock<WorkflowInstanceExtensionManager> extensionManager;

        private Mock<ExtensionResolver> mockedTestee;

        public ExtensionResolverTest()
        {
            this.extensionManager = new Mock<WorkflowInstanceExtensionManager>();
            this.mockedTestee = new Mock<ExtensionResolver>(this.Kernel);

            this.testee = this.mockedTestee.Object;
        }

        [Fact]
        public void AddSingletonExtension_MustAddSingleton()
        {
            this.SetupDependencyBinding();
            this.SetupWorkflowInstanceExtensionManager();

            this.testee.AddSingletonExtension<IDependency>();

            this.extensionManager.Verify(mgr => mgr.Add(It.IsAny<IDependency>()));
        }

        [Fact]
        public void AddTransientExtension_MustAddKernelResolve()
        {
            this.SetupDependencyBinding();
            this.SetupWorkflowInstanceExtensionManager();

            this.testee.AddTransientExtension<IDependency>();

            this.extensionManager.Verify(mgr => mgr.Add(It.IsAny<Func<IDependency>>()));
        }

        private void SetupDependencyBinding()
        {
            this.Kernel.Bind<IDependency>().To<Dependency>();
        }

        private void SetupWorkflowInstanceExtensionManager()
        {
            this.mockedTestee.Protected().SetupGet<WorkflowInstanceExtensionManager>("Extensions").Returns(this.extensionManager.Object);
        }
    }
}