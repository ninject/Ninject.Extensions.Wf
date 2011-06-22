//-------------------------------------------------------------------------------
// <copyright file="ActivityResolverTest.cs" company="bbv Software Services AG">
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
    using System.Activities.Expressions;
    using System.Activities.Statements;
    using System.Linq;

    using FluentAssertions;

    using Xunit;

    public class ActivityResolverTest
    {
        private ActivityResolver testee;

        public ActivityResolverTest()
        {
            this.testee = new ActivityResolver();
        }

        [Fact]
        public void GetActivites_MustGetActiviesInHierarchy()
        {
            SimpleHierarchy hierarchy = new SimpleHierarchy();

            var result = this.testee.GetActivities(hierarchy);

            result.ElementAt(0).Should().BeOfType<SimpleHierarchy>();
            result.ElementAt(1).Should().BeOfType<Sequence>();
            result.ElementAt(2).Should().BeOfType<If>();
            result.ElementAt(3).Should().BeOfType<LambdaValue<bool>>();
            result.ElementAt(4).Should().BeAssignableTo<CodeActivity<string>>();
            result.ElementAt(5).Should().BeOfType<Parallel>();
            result.ElementAt(6).Should().BeOfType<WriteLine>();
            result.ElementAt(7).Should().BeOfType<WriteLine>();
            result.ElementAt(8).Should().BeOfType<Sequence>();
            result.ElementAt(9).Should().BeOfType<WriteLine>();
            result.ElementAt(10).Should().BeOfType<WriteLine>();
        }

        [Fact]
        public void GetActivies_WhenRootIsNull_MustThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this.testee.GetActivities(null));
        }
    }
}