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

    public class NinjectBookmarkInfo
    {
        public NinjectBookmarkInfo(string bookmarkName, string ownerDisplayName, NinjectBookmarkScopeInfo bookmarkScopeInfo)
        {
            this.BookmarkName = bookmarkName;
            this.OwnerDisplayName = ownerDisplayName;
            this.ScopeInfo = bookmarkScopeInfo;
        }

        public NinjectBookmarkInfo(BookmarkInfo bookmarkInfo)
        {
            this.BookmarkName = bookmarkInfo.BookmarkName;
            this.OwnerDisplayName = bookmarkInfo.OwnerDisplayName;
            this.ScopeInfo = new NinjectBookmarkScopeInfo(bookmarkInfo.ScopeInfo);
        }

        public string BookmarkName
        {
            get; private set;
        }

        public string OwnerDisplayName
        {
            get; private set;
        }

        public NinjectBookmarkScopeInfo ScopeInfo
        {
            get; private set;
        }
    }
}