namespace Vsk.VooDoo.Edo.Infrastructure
{
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using System.Net.Http.Headers;
    using Vsk.VooDoo.Adapters.API.WebApi;
    using Vsk.VooDoo.Core.Extensions;
    using Vsk.VooDoo.Core.Module;
    using Vsk.VooDoo.Edo.Domain.Services;
    using Vsk.VooDoo.Edo.Infrastructure.Services;

    public class VskVooDooEdoInfrastructureModule : AssemblyDefinedModule, IAutoMapperConfiguration
    {
        public override void Init(IServiceCollection services)
        {
            services.RegisterWebApiClient<IAdaptersWebApiService>()
                .ConfigureHttpClient(cfg =>
                {
                    cfg.BaseAddress = new Uri("https://localhost:7259");
                    cfg.Timeout = new TimeSpan(0, 0, 0, 0, 60000);
                    cfg.DefaultRequestHeaders.ExpectContinue = false;
                    cfg.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                });

            services.AddTransient<IPingPongService, PingPongService>();
        }

        public void RegisterMaps(IProfileExpression cfgMap)
        {
            // Nothing
        }
    }
}
