//-------------------------------------------------------------------------------
// <copyright file="NinjectActivityXamlServicesTest.cs" company="bbv Software Services AG">
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
    using System.Activities.Statements;
    using System.Activities.XamlIntegration;
    using System.IO;
    using System.Text;
    using System.Xaml;
    using Injection;
    using Moq;
    using Xunit;

    public class NinjectActivityXamlServicesTest
    {
        private readonly string serializedActivity;

        private readonly Mock<IActivityInjector> activityInjector;

        private readonly NinjectActivityXamlServices testee;

        public NinjectActivityXamlServicesTest()
        {
            this.activityInjector = new Mock<IActivityInjector>();

            this.testee = new NinjectActivityXamlServices(this.activityInjector.Object);

            this.serializedActivity = Serialize<WriteLine>();
        }

        [Fact]
        public void Load_MustInjectDependenciesIntoActivityWithActivityInjector()
        {
            var activity = (WriteLine)this.testee.Load(new StringReader(this.serializedActivity));

            this.activityInjector.Verify(injector => injector.Inject(activity));
        }

        private static string Serialize<TActivity>() where TActivity : Activity, new()
        {
            return Serialize(new TActivity());
        }

        private static string Serialize<TActivity>(TActivity activity) where TActivity : Activity
        {
            StringBuilder sb = new StringBuilder();
            StringWriter tw = new StringWriter(sb);
            XamlWriter xw = ActivityXamlServices.CreateBuilderWriter(new XamlXmlWriter(tw, new XamlSchemaContext()));
            XamlServices.Save(xw, activity);
            return sb.ToString();
        }
    }
}