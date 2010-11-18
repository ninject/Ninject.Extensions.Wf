namespace Ninject.Extensions.Wf
{
    public interface IResolveExtensions
    {
        void AddSingletonExtension<TExtension>() where TExtension : class;
        void AddTransientExtension<TExtension>() where TExtension : class;
    }
}