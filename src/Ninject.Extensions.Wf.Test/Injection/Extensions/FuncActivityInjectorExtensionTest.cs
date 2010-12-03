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
            var testee = CreateTestee(a => { });

            var result = testee.CanProcess(new WriteLine());

            Assert.True(result);
        }

        [Fact]
        public void Process_WithActionOnlyConstructor_MustCallProcessDelegate()
        {
            bool wasCalled = false;

            var testee = CreateTestee(a => { wasCalled = true; });

            testee.Process(new WriteLine());

            Assert.True(wasCalled, "Process action was not called");
        }

        [Fact]
        public void CanProcess_WithConstructor_MustCallCanProcessDelegate()
        {
            var wasCalled = false;

            var testee = CreateTestee(a => { wasCalled = true; return false; }, a => { });

            testee.CanProcess(new WriteLine());

            Assert.True(wasCalled, "CanProcess action was not called");
        }

        [Fact]
        public void CanProcess_WithConstructor_MustPassActivityToCanProcessDelegate()
        {
            Activity activity = null;
            var writeLine = new WriteLine();

            var testee = CreateTestee(a => { activity = a; return false; }, a => { });

            testee.CanProcess(writeLine);
            
            Assert.Same(writeLine, activity);
        }

        [Fact]
        public void Process_WithConstructor_MustCallProcessDelegate()
        {
            bool wasCalled = false;
            var testee = CreateTestee(f => { return true; }, a => { wasCalled = true; });

            testee.Process(new WriteLine());
        
            Assert.True(wasCalled);
        }

        [Fact]
        public void Process_WithConstructor_MustPassActivityToProcessDelegate()
        {
            Activity activity = null;
            var writeLine = new WriteLine();

            var testee = CreateTestee(f => { return true; }, a => { activity = a; });

            testee.Process(writeLine);

            Assert.Same(writeLine, activity);
        }

        [Theory,
            InlineData(true),
            InlineData(false)]
        public void CanProcess_WithConstructor_MustReturnResultOfCanProcessDelegate(bool canProcessResult)
        {
            var testee = CreateTestee(f => { return canProcessResult; }, a => { });

            var result = testee.CanProcess(new WriteLine());

            Assert.Equal(canProcessResult, result);
        }

        private static IActivityInjectorExtension CreateTestee(Action<Activity> action)
        {
            return new FuncActivityInjectorExtension(action);
        }

        private static IActivityInjectorExtension CreateTestee(Func<Activity, bool> canProcess, Action<Activity> action)
        {
            return new FuncActivityInjectorExtension(canProcess, action);
        }
    }
}