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

namespace Ninject.Extensions.Wf.Extensions
{
    using System;
    using System.Collections.Generic;

    using FluentAssertions;

    using Xunit;

    public class IDictionaryExtensionsTest
    {

        [Fact]
        public void ToObject_WhenDictionaryIsNull_MustThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => IDictionaryExtensions.ToObject<Input>(null));
        }

        [Fact]
        public void ToObject_WhenDictionaryContainsExactMatch_MustReturnInitializedObject()
        {
            Input input = new Dictionary<string, object> { { "Name", "Marbach" }, { "Surname", "Daniel" } }.ToObject<Input>();

            input.Name.Should().Be("Marbach");
            input.Surname.Should().Be("Daniel");
        }

        [Fact]
        public void ToObject_WhenDictionaryContainsDataWhichCannotBeMatched_MustThrowInvalidOperationException()
        {
            var dictionary = new Dictionary<string, object> {{"Name", "Marbach"}, {"Surname", "Daniel"}, {"Street", "Elsewhere"}};

            Assert.Throws<InvalidOperationException>(() => dictionary.ToObject<Input>());
        }

        [Fact]
        public void ToObject_WhenDictionaryContainsDataWhichCannotBeMatched2_MustThrowInvalidOperationException()
        {
            var dictionary = new Dictionary<string, object> { { "Name", "Marbach" }, { "Street", "Elsewhere" }};

            Assert.Throws<InvalidOperationException>(() => dictionary.ToObject<Input>());
        }

        private class Input
        {
            public string Name { get; set; }

            public string Surname { get; set; }
        }
    }
}