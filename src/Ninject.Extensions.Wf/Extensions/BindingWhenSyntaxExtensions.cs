//-------------------------------------------------------------------------------
// <copyright file="BindingWhenSyntaxExtensions.cs" company="bbv Software Services AG">
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
    using System.Activities;
    using Syntax;

    /// <summary>
    /// Contains extension methods for the <see cref="IBindingWhenSyntax{T}"/>
    /// </summary>
    public static class BindingWhenSyntaxExtensions
    {
        /// <summary>
        /// Indicates that the binding should be used only for requests that support the specified condition.
        /// </summary>
        /// <typeparam name="T">The type used in the binding.</typeparam>
        /// <param name="whenSyntax">The when syntax.</param>
        /// <param name="condition">The condition.</param>
        /// <returns>The syntax</returns>
        public static IBindingInNamedWithOrOnSyntax<T> WhenInjectedIntoActivity<T>(this IBindingWhenSyntax<T> whenSyntax, Func<Activity, bool> condition)
        {
            return whenSyntax.When(request => request.HasRootActivityParameter()
                 && condition(request.GetRootActivityParameter().Root));
        }

        /// <summary>
        /// Indicates that the binding should be used only for injections on the specified activity type.
        /// </summary>
        /// <typeparam name="T">The type used in the binding.</typeparam>
        /// <param name="whenSyntax">The when syntax.</param>
        /// <param name="parent">The type.</param>
        /// <returns>The syntax.</returns>
        public static IBindingInNamedWithOrOnSyntax<T> WhenInjectedIntoActivity<T>(this IBindingWhenSyntax<T> whenSyntax, Type parent)
        {
            if (!typeof(Activity).IsAssignableFrom(parent))
            {
                throw new ArgumentException("Provided type must be an activity!", "parent");
            }

            return whenSyntax.WhenInjectedIntoActivity(activity => activity.GetType().Equals(parent));
        }
    }
}