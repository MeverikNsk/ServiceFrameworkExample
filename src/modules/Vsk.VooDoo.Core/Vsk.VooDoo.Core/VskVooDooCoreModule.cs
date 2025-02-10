namespace Vsk.VooDoo.Core
{
    using AutoMapper;
    using global::Vsk.VooDoo.Core.Routing;
    using Microsoft.AspNetCore.Mvc.ApplicationModels;
    using Microsoft.Extensions.DependencyInjection;

    public static class VskVooDooCoreModule
    {
        public static void Init(IServiceCollection services)
        {
            services.AddTransient<IApplicationModelProvider, VooDooApplicationModelProvider>();
        }

        public static void RegisterMaps(IProfileExpression cfgMap)
        {
            // Nothing
        }
    }
}
