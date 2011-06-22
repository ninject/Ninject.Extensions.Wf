//-------------------------------------------------------------------------------
// <copyright file="RequestExtensionsTest.cs" company="bbv Software Services AG">
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
    using System.Activities.Statements;
    using System.Collections.Generic;
    using Activation;

    using FluentAssertions;

    using Moq;
    using Ninject.Parameters;
    using Parameters;
    using Xunit;

    public class RequestExtensionsTest
    {
        private Mock<IRequest> request;

        public RequestExtensionsTest()
        {
            this.request = new Mock<IRequest>();
        }

        [Fact]
        public void GetRootActivityParameter_WhenParameterDefined_ReturnsParameter()
        {
            this.request.Setup(r => r.Parameters).Returns(GetParameterListWithRootActivityParameter());

            var parameter = this.request.Object.GetRootActivityParameter();

            parameter.Should().NotBeNull();
        }

        [Fact]
        public void GetRootActivityParameter_WhenParameterNotDefined_ReturnsNull()
        {
            this.request.Setup(r => r.Parameters).Returns(new List<IParameter>());

            var parameter = this.request.Object.GetRootActivityParameter();

            parameter.Should().BeNull();
        }

        [Fact]
        public void HasRootActivityParameter_WhenParameterDefined_ReturnsTrue()
        {
            this.request.Setup(r => r.Parameters).Returns(GetParameterListWithRootActivityParameter());

            var result = this.request.Object.HasRootActivityParameter();

            result.Should().BeTrue();
        }

        [Fact]
        public void HasRootActivityParameter_WhenParameterNotDefined_ReturnsFalse()
        {
            this.request.Setup(r => r.Parameters).Returns(new List<IParameter>());

            var result = this.request.Object.HasRootActivityParameter();

            result.Should().BeFalse();
        }

        private static List<IParameter> GetParameterListWithRootActivityParameter()
        {
            return new List<IParameter>
                       {
                           new RootActivityParameter(new WriteLine()),
                       };
        }
    }
}