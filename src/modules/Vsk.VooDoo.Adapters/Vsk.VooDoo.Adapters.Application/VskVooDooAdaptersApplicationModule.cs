namespace Vsk.VooDoo.Adapters.Application
{
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using Vsk.VooDoo.Adapters.API.WebApi;
    using Vsk.VooDoo.Adapters.Application.Controllers;
    using Vsk.VooDoo.Core.Extensions;
    using Vsk.VooDoo.Core.Module;

    internal class VskVooDooAdaptersApplicationModule : AssemblyDefinedModule, IAutoMapperConfiguration
    {
        public override void Init(IServiceCollection services)
        {
            services.RegisterWebApiService<IAdaptersWebApiService, AdaptersWebApiServiceController>();
        }

        public void RegisterMaps(IProfileExpression cfgMap)
        {
            // Nothing
        }
    }
}
