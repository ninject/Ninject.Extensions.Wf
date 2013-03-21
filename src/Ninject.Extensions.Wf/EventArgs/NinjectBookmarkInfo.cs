//-------------------------------------------------------------------------------
// <copyright file="NinjectBookmarkInfo.cs" company="bbv Software Services AG">
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
    using System.Activities.Hosting;

    /// <summary>
    /// Wraps the <see cref="BookmarkInfo"/>.
    /// </summary>
    public class NinjectBookmarkInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectBookmarkInfo"/> class.
        /// </summary>
        /// <param name="bookmarkName">Name of the bookmark.</param>
        /// <param name="ownerDisplayName">Display name of the owner.</param>
        /// <param name="bookmarkScopeInfo">The bookmark scope info.</param>
        public NinjectBookmarkInfo(string bookmarkName, string ownerDisplayName, NinjectBookmarkScopeInfo bookmarkScopeInfo)
        {
            this.BookmarkName = bookmarkName;
            this.OwnerDisplayName = ownerDisplayName;
            this.ScopeInfo = bookmarkScopeInfo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectBookmarkInfo"/> class.
        /// </summary>
        /// <param name="bookmarkInfo">The bookmark info.</param>
        public NinjectBookmarkInfo(BookmarkInfo bookmarkInfo)
        {
            this.BookmarkInfo = bookmarkInfo;
            this.BookmarkName = this.BookmarkInfo.BookmarkName;
            this.OwnerDisplayName = this.BookmarkInfo.OwnerDisplayName;

            if (this.BookmarkInfo.ScopeInfo != null)
            {
                this.ScopeInfo = new NinjectBookmarkScopeInfo(this.BookmarkInfo.ScopeInfo);
            }
        }

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="P:System.Activities.Hosting.BookmarkInfo.BookmarkName"]/*' />
        public string BookmarkName
        {
            get; private set;
        }

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="P:System.Activities.Hosting.BookmarkInfo.OwnerDisplayName"]/*' />
        public string OwnerDisplayName
        {
            get; private set;
        }

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="P:System.Activities.Hosting.BookmarkInfo.ScopeInfo"]/*' />
        public NinjectBookmarkScopeInfo ScopeInfo
        {
            get; private set;
        }

        /// <summary>
        /// Gets the underlying bookmark info.
        /// </summary>
        /// <value>The bookmark info.</value>
        public BookmarkInfo BookmarkInfo { get; private set; }
    }
}