//-------------------------------------------------------------------------------
// <copyright file="INinjectActivityXamlServices.cs" company="bbv Software Services AG">
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
    using System.Activities;
    using System.IO;
    using System.Xaml;
    using System.Xml;

    /// <summary>
    /// Wraps the functionality of ActivityXamlServices.
    /// </summary>
    public interface INinjectActivityXamlServices
    {
        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.ActivityXamlServices.Load(System.IO.Stream)"]/*' />
        Activity Load(Stream stream);

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.ActivityXamlServices.Load(System.String)"]/*' />
        Activity Load(string fileName);

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.ActivityXamlServices.Load(System.IO.TextReader)"]/*' />
        Activity Load(TextReader textReader);

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.ActivityXamlServices.Load(System.Xml.XmlReader)"]/*' />
        Activity Load(XmlReader xmlReader);

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.ActivityXamlServices.Load(System.Xaml.XamlReader)"]/*' />
        Activity Load(XamlReader xamlReader);

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.ActivityXamlServices.CreateReader(System.IO.Stream)"]/*' />
        XamlReader CreateReader(Stream stream);

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.ActivityXamlServices.CreateReader(System.Xaml.XamlReader)"]/*' />
        XamlReader CreateReader(XamlReader innerReader);

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.ActivityXamlServices.CreateReader(System.Xaml.XamlReader,System.Xaml.XamlSchemaContext)"]/*' />
        XamlReader CreateReader(XamlReader innerReader, XamlSchemaContext schemaContext);

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.ActivityXamlServices.CreateBuilderReader(System.Xaml.XamlReader)"]/*' />
        XamlReader CreateBuilderReader(XamlReader innerReader);

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.ActivityXamlServices.CreateBuilderReader(System.Xaml.XamlReader,System.Xaml.XamlSchemaContext)"]/*' />
        XamlReader CreateBuilderReader(XamlReader innerReader, XamlSchemaContext schemaContext);

        /// <include file='../../System.Activities.xml' path='/doc/members/member[@name="M:System.Activities.ActivityXamlServices.CreateBuilderReader(System.Xaml.XamlWriter)"]/*' />
        XamlWriter CreateBuilderWriter(XamlWriter innerWriter);
    }
}