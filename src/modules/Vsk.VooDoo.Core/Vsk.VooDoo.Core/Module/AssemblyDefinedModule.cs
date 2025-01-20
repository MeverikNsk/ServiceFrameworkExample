namespace Vsk.VooDoo.Core.Module
{
    using Microsoft.Extensions.DependencyInjection;

    public abstract class AssemblyDefinedModule
    {
        public abstract void Init(IServiceCollection services);
    }
}
