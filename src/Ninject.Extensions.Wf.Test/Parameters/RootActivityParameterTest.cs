//-------------------------------------------------------------------------------
// <copyright file="RootActivityParameterTest.cs" company="bbv Software Services AG">
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


namespace Ninject.Extensions.Wf.Parameters
{
    using System.Activities.Statements;
    using Xunit;

    public class RootActivityParameterTest
    {
        [Fact]
        public void Constructor_MustUseConstantName()
        {
            var testee = new RootActivityParameter(new WriteLine());

            Assert.Equal("RootActivity", testee.Name);
        }

        [Fact]
        public void Root_MustBeSetToRootActivity()
        {
            WriteLine writeLine = new WriteLine();

            var testee = new RootActivityParameter(writeLine);

            Assert.Same(writeLine, testee.Root);
        }

        [Fact]
        public void ShouldInherit_MustReturnTrue()
        {
            var testee = new RootActivityParameter(new WriteLine());

            Assert.True(testee.ShouldInherit);
        }
    }
}