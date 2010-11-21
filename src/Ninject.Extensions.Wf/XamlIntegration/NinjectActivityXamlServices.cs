//-------------------------------------------------------------------------------
// <copyright file="NinjectActivityXamlServices.cs" company="bbv Software Services AG">
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

namespace Ninject.Extensions.Wf.XamlIntegration
{
    using System;
    using System.Activities;
    using System.Activities.XamlIntegration;
    using System.IO;
    using System.Xaml;
    using System.Xml;

    /// <summary>
    /// Wraps the functionality of the ActivityXamlServices
    /// </summary>
    public class NinjectActivityXamlServices : INinjectActivityXamlServices
    {
        private readonly IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectActivityXamlServices"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public NinjectActivityXamlServices(IKernel kernel)
        {
            this.kernel = kernel;
        }

        /// <inheritdoc />
        public Activity Load(Stream stream)
        {
            return this.BuildActivity(() => ActivityXamlServices.Load(stream));
        }

        /// <inheritdoc />
        public Activity Load(string fileName)
        {
            return this.BuildActivity(() => ActivityXamlServices.Load(fileName));
        }

        /// <inheritdoc />
        public Activity Load(TextReader textReader)
        {
            return this.BuildActivity(() => ActivityXamlServices.Load(textReader));
        }

        /// <inheritdoc />
        public Activity Load(XmlReader xmlReader)
        {
            return this.BuildActivity(() => ActivityXamlServices.Load(xmlReader));
        }

        /// <inheritdoc />
        public Activity Load(XamlReader xamlReader)
        {
            return this.BuildActivity(() => ActivityXamlServices.Load(xamlReader));
        }

        /// <inheritdoc />
        public XamlReader CreateReader(Stream stream)
        {
            return ActivityXamlServices.CreateReader(stream);
        }

        /// <inheritdoc />
        public XamlReader CreateReader(XamlReader innerReader)
        {
            return ActivityXamlServices.CreateReader(innerReader);
        }

        /// <inheritdoc />
        public XamlReader CreateReader(XamlReader innerReader, XamlSchemaContext schemaContext)
        {
            return ActivityXamlServices.CreateReader(innerReader, schemaContext);
        }

        /// <inheritdoc />
        public XamlReader CreateBuilderReader(XamlReader innerReader)
        {
            return ActivityXamlServices.CreateBuilderReader(innerReader);
        }

        /// <inheritdoc />
        public XamlReader CreateBuilderReader(XamlReader innerReader, XamlSchemaContext schemaContext)
        {
            return ActivityXamlServices.CreateBuilderReader(innerReader, schemaContext);
        }

        /// <inheritdoc />
        public XamlWriter CreateBuilderWriter(XamlWriter innerWriter)
        {
            throw new NotImplementedException();
        }

        private Activity BuildActivity(Func<Activity> activityLoader)
        {
            var activity = activityLoader();

            this.kernel.Inject(activity);

            return activity;
        }
    }
}