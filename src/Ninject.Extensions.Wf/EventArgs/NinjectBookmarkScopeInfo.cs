//-------------------------------------------------------------------------------
// <copyright file="NinjectBookmarkScopeInfo.cs" company="bbv Software Services AG">
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
    using System.Activities.Hosting;

    /// <summary>
    /// Wraps the <see cref="BookmarkScopeInfo"/>.
    /// </summary>
    public class NinjectBookmarkScopeInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectBookmarkScopeInfo"/> class.
        /// </summary>
        /// <param name="isInitialized">if set to <c>true</c> the bookmark scope is initialized.</param>
        /// <param name="id">The id.</param>
        /// <param name="temporaryId">The temporary id.</param>
        public NinjectBookmarkScopeInfo(bool isInitialized, Guid id, string temporaryId)
        {
            this.IsInitialized = isInitialized;
            this.Id = id;
            this.TemporaryId = temporaryId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectBookmarkScopeInfo"/> class.
        /// </summary>
        /// <param name="bookmarkScopeInfo">The bookmark scope info.</param>
        public NinjectBookmarkScopeInfo(BookmarkScopeInfo bookmarkScopeInfo)
        {
            this.BookmarkScopeInfo = bookmarkScopeInfo;
            this.IsInitialized = bookmarkScopeInfo.IsInitialized;
            this.Id = bookmarkScopeInfo.Id;
            this.TemporaryId = bookmarkScopeInfo.TemporaryId;
        }

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="P:System.Activities.Hosting.BookmarkScopeInfo.IsInitialized"]/*' />
        public bool IsInitialized
        {
            get;
            private set;
        }

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="P:System.Activities.Hosting.BookmarkScopeInfo.Id"]/*' />
        public Guid Id
        {
            get; private set;
        }

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="P:System.Activities.Hosting.BookmarkScopeInfo.TemporaryId"]/*' />
        public string TemporaryId
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the underlying bookmark scope info.
        /// </summary>
        /// <value>The bookmark scope info.</value>
        public BookmarkScopeInfo BookmarkScopeInfo
        {
            get; private set;
        }
    }
}