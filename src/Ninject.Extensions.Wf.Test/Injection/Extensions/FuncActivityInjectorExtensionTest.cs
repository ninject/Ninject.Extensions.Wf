//-------------------------------------------------------------------------------
// <copyright file="FuncActivityInjectorExtensionTest.cs" company="bbv Software Services AG">
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
    using System;
    using System.Activities;
    using System.Activities.Statements;
    using Xunit;
    using Xunit.Extensions;

    public class FuncActivityInjectorExtensionTest
    {
        [Fact]
        public void CanProcess_WithActionOnlyConstructor_MustReturnTrue()
        {
            var testee = CreateTestee((a, r) => { });

            var result = testee.CanProcess(new WriteLine(), new Sequence());

            Assert.True(result);
        }

        [Fact]
        public void Process_WithActionOnlyConstructor_MustCallProcessDelegate()
        {
            bool wasCalled = false;

            var testee = CreateTestee((a, r) => { wasCalled = true; });

            testee.Process(new WriteLine(), new Sequence());

            Assert.True(wasCalled, "Process action was not called");
        }

        [Fact]
        public void CanProcess_WithConstructor_MustCallCanProcessDelegate()
        {
            var wasCalled = false;

            var testee = CreateTestee((a, r) => { wasCalled = true; return false; }, (a, r) => { });

            testee.CanProcess(new WriteLine(), new Sequence());

            Assert.True(wasCalled, "CanProcess action was not called");
        }

        [Fact]
        public void CanProcess_WithConstructor_MustPassActivityToCanProcessDelegate()
        {
            Activity activity = null;
            var writeLine = new WriteLine();

            var testee = CreateTestee((a, r) => { activity = a; return false; }, (a, r) => { });

            testee.CanProcess(writeLine, new Sequence());
            
            Assert.Same(writeLine, activity);
        }

        [Fact]
        public void CanProcess_WithConstructor_MustPassRootActivityToCanProcessDelegate()
        {
            Activity root = null;
            var sequence = new Sequence();

            var testee = CreateTestee((a, r) => { root = r; return false; }, (a, r) => { });

            testee.CanProcess(new WriteLine(), sequence);

            Assert.Same(sequence, root);
        }

        [Fact]
        public void Process_WithConstructor_MustCallProcessDelegate()
        {
            bool wasCalled = false;
            var testee = CreateTestee((a, r) => { return true; }, (a, r) => { wasCalled = true; });

            testee.Process(new WriteLine(), new Sequence());
        
            Assert.True(wasCalled);
        }

        [Fact]
        public void Process_WithConstructor_MustPassActivityToProcessDelegate()
        {
            Activity activity = null;
            var writeLine = new WriteLine();

            var testee = CreateTestee((a, r) => { return true; }, (a, r) => { activity = a; });

            testee.Process(writeLine, new Sequence());

            Assert.Same(writeLine, activity);
        }

        [Fact]
        public void Process_WithConstructor_MustPassRootActivityToProcessDelegate()
        {
            Activity root = null;
            var sequence = new Sequence();

            var testee = CreateTestee((a, r) => { return true; }, (a, r) => { root = r; });

            testee.Process(new WriteLine(), sequence);

            Assert.Same(sequence, root);
        }

        [Theory,
            InlineData(true),
            InlineData(false)]
        public void CanProcess_WithConstructor_MustReturnResultOfCanProcessDelegate(bool canProcessResult)
        {
            var testee = CreateTestee((a, r) => { return canProcessResult; }, (a, r) => { });

            var result = testee.CanProcess(new WriteLine(), new Sequence());

            Assert.Equal(canProcessResult, result);
        }

        private static IActivityInjectorExtension CreateTestee(Action<Activity, Activity> action)
        {
            return new FuncActivityInjectorExtension(action);
        }

        private static IActivityInjectorExtension CreateTestee(Func<Activity, Activity, bool> canProcess, Action<Activity, Activity> action)
        {
            return new FuncActivityInjectorExtension(canProcess, action);
        }
    }
}