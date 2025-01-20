namespace Vsk.VooDoo.Adapters.Infrastructure
{
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using Vsk.VooDoo.Adapters.Domain.Repositoryes;
    using Vsk.VooDoo.Adapters.Infrastructure.Database;
    using Vsk.VooDoo.Core.Module;

    public class VskVooDooAdaptersInfrastructureModule : AssemblyDefinedModule, IAutoMapperConfiguration
    {
        public override void Init(IServiceCollection services)
        {
            services.AddTransient<IAdaptersRepository, AdaptersRepository>();
        }

        public void RegisterMaps(IProfileExpression cfgMap)
        {
            // Nothing
        }
    }
}
