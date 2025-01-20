namespace Vsk.VooDoo.Core
{
    using AutoMapper;
    using global::Vsk.VooDoo.Core.Routing;
    using Microsoft.AspNetCore.Mvc.ApplicationModels;
    using Microsoft.Extensions.DependencyInjection;
    using Vsk.VooDoo.Core.Module;

    public class VskVooDooCoreModule : AssemblyDefinedModule, IAutoMapperConfiguration
    {
        public override void Init(IServiceCollection services)
        {
            services.AddTransient<IApplicationModelProvider, VooDooApplicationModelProvider>();
        }

        public void RegisterMaps(IProfileExpression cfgMap)
        {
            // Nothing
        }
    }
}
