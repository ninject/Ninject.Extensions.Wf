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

    public class NinjectBookmarkScopeInfo
    {
        public NinjectBookmarkScopeInfo(bool isInitialized, Guid id, string temporaryId)
        {
            this.IsInitialized = isInitialized;
            this.Id = id;
            this.TemporaryId = temporaryId;
        }

        public NinjectBookmarkScopeInfo(BookmarkScopeInfo bookmarkScopeInfo)
        {
            this.ScopeInfo = bookmarkScopeInfo;
            this.IsInitialized = bookmarkScopeInfo.IsInitialized;
            this.Id = bookmarkScopeInfo.Id;
            this.TemporaryId = bookmarkScopeInfo.TemporaryId;
        }

        public bool IsInitialized
        {
            get;
            private set;
        }

        public Guid Id
        {
            get; private set;
        }

        public string TemporaryId
        {
            get;
            private set;
        }

        public BookmarkScopeInfo ScopeInfo
        {
            get; private set;
        }
    }
}