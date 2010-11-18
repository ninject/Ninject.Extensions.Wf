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
    using System.Activities.Statements;
    using System.Linq;
    using Microsoft.VisualBasic.Activities;
    using Xunit;

    public class ActivityResolverTest
    {
        private ActivityResolver testee;

        public ActivityResolverTest()
        {
            this.testee = new ActivityResolver();
        }

        [Fact]
        public void GetActivies_MustGetActiviesInFlatWorkflow()
        {
            SimpleFlat flat = new SimpleFlat();

            var result = this.testee.GetActivities(flat);

            Assert.IsType(typeof(SimpleFlat), result.ElementAt(0));
            Assert.IsType(typeof(Sequence), result.ElementAt(1));
            Assert.IsType(typeof(WriteLine), result.ElementAt(2));
            Assert.IsType(typeof(WriteLine), result.ElementAt(3));
            Assert.IsType(typeof(WriteLine), result.ElementAt(4));
        }

        [Fact]
        public void GetActivites_MustGetActiviesInHierarchy()
        {
            SimpleHierarchy hierarchy = new SimpleHierarchy();

            var result = this.testee.GetActivities(hierarchy);

            Assert.IsType(typeof(SimpleHierarchy), result.ElementAt(0));
            Assert.IsType(typeof(Sequence), result.ElementAt(1));
            Assert.IsType(typeof(If), result.ElementAt(2));
            Assert.IsType(typeof(VisualBasicValue<Boolean>), result.ElementAt(3));
            Assert.IsAssignableFrom(typeof(CodeActivity<string>), result.ElementAt(4));
            Assert.IsType(typeof(Parallel), result.ElementAt(5));
            Assert.IsType(typeof(WriteLine), result.ElementAt(6));
            Assert.IsType(typeof(WriteLine), result.ElementAt(7));
            Assert.IsType(typeof(Sequence), result.ElementAt(8));
            Assert.IsType(typeof(WriteLine), result.ElementAt(9));
            Assert.IsType(typeof(WriteLine), result.ElementAt(10));
        }

        [Fact]
        public void GetActivies_WhenRootIsNull_MustThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this.testee.GetActivities(null));
        }
    }
}