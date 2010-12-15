//-------------------------------------------------------------------------------
// <copyright file="RootActivityParameter.cs" company="bbv Software Services AG">
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
    using System.Activities;
    using Ninject.Parameters;

    /// <summary>
    /// Parameter which provides access to the root activity.
    /// </summary>
    public class RootActivityParameter : Parameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RootActivityParameter"/> class.
        /// </summary>
        /// <param name="root">The root activity.</param>
        public RootActivityParameter(Activity root)
            : base("RootActivity", ctx => null, true)
        {
            this.Root = root;
        }

        /// <summary>
        /// Gets the root activity of the current request.
        /// </summary>
        public Activity Root { get; private set; }
    }
}