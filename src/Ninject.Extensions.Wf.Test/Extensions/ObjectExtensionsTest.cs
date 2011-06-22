//-------------------------------------------------------------------------------
// <copyright file="ObjectExtensionsTest.cs" company="bbv Software Services AG">
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
    using FluentAssertions;

    using Xunit;

    public class ObjectExtensionsTest
    {
        [Fact]
        public void ToDictionary_WhenNoPropertiesDefined_MustReturnEmptyDictionary()
        {
            new Empty().ToDict().Should().BeEmpty();
        }

        [Fact]
        public void ToDictionary_WhenOnlyProperties_MustReturnDictionaryFilledWithPropertyNameAndValue()
        {
            var result = new PropertyOnly { SomeData = "Foo", SomeInt = 2 }.ToDict();

            result.Count.Should().Be(2);
            result["SomeData"].Should().Be("Foo");
            result["SomeInt"].Should().Be(2);
        }

        [Fact]
        public void ToDictionary_WhenInheritedProperties_MustReturnDictionaryFilledAlsoWithInheritedPropertiesAndValues()
        {
            var result = new Inherited { SomeData = "Foo", SomeInt = 2, SomeDouble = 1.0d }.ToDict();

            result.Count.Should().Be(3);
            result["SomeData"].Should().Be("Foo");
            result["SomeInt"].Should().Be(2);
            result["SomeDouble"].Should().Be(1.0d);
        }

        private class Empty
        {
        }

        private class PropertyOnly
        {
            public string SomeData { get; set; }

            public int SomeInt { get; set; }
        }

        private class Inherited : PropertyOnly
        {
            public double SomeDouble { get; set; }
        }
    }
}