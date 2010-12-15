//-------------------------------------------------------------------------------
// <copyright file="RequestExtensions.cs" company="bbv Software Services AG">
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
    using System.Linq;
    using Activation;
    using Parameters;

    /// <summary>
    /// Contains extension methods for the <see cref="IRequest"/>.
    /// </summary>
    public static class RequestExtensions
    {
        /// <summary>
        /// Gets the root activity parameter on the <see cref="IRequest"/> if any.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The root activity parameter or <see langword="null"/>.</returns>
        public static RootActivityParameter GetRootActivityParameter(this IRequest request)
        {
            return request.Parameters.OfType<RootActivityParameter>().SingleOrDefault();
        }

        /// <summary>
        /// Determines whether the request contains a <see cref="RootActivityParameter"/>.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// <c>true</c> if the request contains a <see cref="RootActivityParameter"/>; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasRootActivityParameter(this IRequest request)
        {
            return GetRootActivityParameter(request) != null;
        }
    }
}