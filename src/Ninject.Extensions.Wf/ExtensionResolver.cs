namespace Ninject.Extensions.Wf
{
    using System;
    using System.Activities.Hosting;
    using Infrastructure;

    public abstract class ExtensionResolver : IResolveExtensions, IHaveKernel
    {
        protected ExtensionResolver(IKernel kernel)
        {
            this.Kernel = kernel;
        }

        protected abstract WorkflowInstanceExtensionManager Extensions
        {
            get;
        }

        public void AddSingletonExtension<TExtension>() where TExtension : class
        {
            this.Extensions.Add(this.Kernel.Get<TExtension>());
        }

        public void AddTransientExtension<TExtension>() where TExtension : class
        {
            this.Extensions.Add(() => this.Kernel.Get<TExtension>());
        }

        /// <summary>
        /// Gets the kernel.
        /// </summary>
        public IKernel Kernel { get; private set; }
    }
}