namespace Vsk.VooDoo.Adapters.Domain
{
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using Vsk.VooDoo.Adapters.Domain.Services;
    using Vsk.VooDoo.Adapters.Domain.Services.Interfaces;
    using Vsk.VooDoo.Core.Module;

    public class VskVooDooAdaptersDomainModule : AssemblyDefinedModule, IAutoMapperConfiguration
    {
        public override void Init(IServiceCollection services)
        {
            services.AddTransient<IHelloWorlDomainService, HelloWorlDomainService>();
        }

        public void RegisterMaps(IProfileExpression cfgMap)
        {
            // Nothing
        }
    }
}
