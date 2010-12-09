//-------------------------------------------------------------------------------
// <copyright file="IDictionaryExtensions.cs" company="bbv Software Services AG">
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
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Contains extensions for dictionaries.
    /// </summary>
    public static class IDictionaryExtensions
    {
        /// <summary>
        /// Turns a given dictionary into an object by assigning the values of
        /// the keys in the dictionary to the public properties of the provided
        /// type.
        /// </summary>
        /// <typeparam name="T">The type to be used for deserialization.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns>The deserialized object.</returns>
        public static T ToObject<T>(this IDictionary<string, object> dictionary)
            where T : class, new()
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException("dictionary");
            }

            var t = new T();

            var publicProperties = t.GetType().GetProperties().ToDictionary(k => k.Name, v => v);

            if (SizeIsNotEqual(dictionary, publicProperties) || KeysAreNotEqual(dictionary, publicProperties))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Provided dictionary cannot to mapped to target {0}", typeof(T).FullName));
            }

            foreach (KeyValuePair<string, object> pair in dictionary)
            {
                PropertyInfo propertyInfo = publicProperties[pair.Key];
                propertyInfo.SetValue(t, pair.Value, null);
            }

            return t;
        }

        /// <summary>
        /// Determines whether the keys presented in the dictionary are matching to the public properties.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="publicProperties">The public properties.</param>
        /// <returns><see langword="true"/> if they are matching; otherwise <see langword="false"/>.</returns>
        private static bool KeysAreNotEqual(IDictionary<string, object> dictionary, Dictionary<string, PropertyInfo> publicProperties)
        {
            return publicProperties.Keys.Except(dictionary.Keys).Count() != 0;
        }

        /// <summary>
        /// Determines whether the sizes are equal.
        /// </summary>
        /// <param name="dictionary">The dictionary</param>
        /// <param name="publicProperties">The public properties</param>
        /// <returns>true if the sizes are equal; otherwise false.</returns>
        private static bool SizeIsNotEqual(IDictionary<string, object> dictionary, Dictionary<string, PropertyInfo> publicProperties)
        {
            return publicProperties.Count() != dictionary.Count();
        }
    }
}