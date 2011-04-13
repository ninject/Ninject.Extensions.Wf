//-------------------------------------------------------------------------------
// <copyright file="SimpleHierarchy.cs" company="bbv Software Services AG">
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

namespace Ninject.Extensions.Wf.Injection
{
    using System;
    using System.Activities;
    using System.Activities.Statements;

    /// <summary>
    /// Simple hierarchy example.
    /// </summary>
    public partial class SimpleHierarchy : Activity
    {
        /// <summary>
        /// Gets or sets the delegate that returns an <see cref="T:System.Activities.Activity"/> that contains the execution logic.
        /// </summary>
        /// <returns>The delegate that contains the execution logic.</returns>
        protected override Func<Activity> Implementation
        {
            get
            {
                var condition = new Variable<string>(string.Empty);

                return () => new Sequence
                                 {
                                     Variables =
                                         {
                                             condition,
                                         },
                                     Activities =
                                         {
                                             new If
                                                 {
                                                     Condition =
                                                         new InArgument<bool>(
                                                         ctx => string.IsNullOrEmpty(condition.Get(ctx))),
                                                     Then = new Parallel
                                                                {
                                                                    Branches =
                                                                        {
                                                                            new WriteLine(), new WriteLine()
                                                                        }
                                                                },
                                                     Else = new Sequence
                                                                {
                                                                    Activities =
                                                                        {
                                                                            new WriteLine(), new WriteLine()
                                                                        }
                                                                }
                                                 }
                                         }
                                 };
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}