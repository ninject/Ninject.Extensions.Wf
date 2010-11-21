using Xunit;

namespace Ninject.Extensions.Wf.XamlIntegration
{
    using System;
    using System.Activities;
    using System.Activities.XamlIntegration;
    using System.IO;
    using System.Text;
    using System.Xaml;
    using Injection.Model;
    using Xunit;

    public class NinjectActivityXamlServicesTest : KernelProvidingBase
    {
        private readonly string serializedTestActivityWithDependencyAndAttribute;

        private readonly string serializedTestActivityWithDependency;

        private readonly NinjectActivityXamlServices testee;

        public NinjectActivityXamlServicesTest()
        {
            this.testee = new NinjectActivityXamlServices(this.Kernel);

            this.serializedTestActivityWithDependencyAndAttribute = Serialize<TestActivityWithDependencyAndAttribute>();
            this.serializedTestActivityWithDependency = Serialize<TestActivityWithDependency>();
        }

        [Fact]
        public void Load_WhenBindingDefined_WhenInjectAttributeDefined_MustFullFillDependencyOnActivity()
        {
            this.SetupDependencyBinding();

            var ativity = (TestActivityWithDependencyAndAttribute)this.testee.Load(new StringReader(serializedTestActivityWithDependencyAndAttribute));

            Assert.NotNull(ativity.Dependency);
        }

        [Fact]
        public void Load_WhenBindingDefined_WhenInjectAttributeNotDefined_MustNotFullFillDependencyOnActivity()
        {
            this.SetupDependencyBinding();

            var activity = (TestActivityWithDependency)this.testee.Load(new StringReader(serializedTestActivityWithDependency));

            Assert.Null(activity.Dependency);
        }

        [Fact]
        public void Load_WhenBindingNotDefined_WhenInjectAttributeDefined_MustMustThrowActivationException()
        {
            Assert.Throws<ActivationException>(
                () => this.testee.Load(new StringReader(serializedTestActivityWithDependencyAndAttribute)));
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

        private static TActivity Deserialize<TActivity>(string activity)
            where TActivity : Activity
        {
            StringReader stringReader = new StringReader(activity);
            return (TActivity)ActivityXamlServices.Load(stringReader);
        }
    }
}