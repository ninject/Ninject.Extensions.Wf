//-------------------------------------------------------------------------------
// <copyright file="IDictionaryExtensionsTest.cs" company="bbv Software Services AG">
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

namespace Ninject.Extensions.Wf
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class IDictionaryExtensionsTest
    {

        [Fact]
        public void FromDictionary_WhenDictionaryIsNull_MustThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => IDictionaryExtensions.FromDict<Input>(null));
        }

        [Fact]
        public void FromDictionary_WhenDictionaryEmpty_MustReturnUninitializedObject()
        {
            Input input = new Dictionary<string, object>().FromDict<Input>();
            
            Assert.Null(input.Name);
            Assert.Null(input.Surname);
        }

        private class Input
        {
            public string Name { get; set; }

            public string Surname { get; set; }
        }
    }
}