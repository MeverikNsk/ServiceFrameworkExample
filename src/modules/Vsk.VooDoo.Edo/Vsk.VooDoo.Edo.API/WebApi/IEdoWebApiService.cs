namespace Vsk.VooDoo.Edo.API.WebApi
{
    using Microsoft.AspNetCore.Mvc;
    using Refit;
    using Vsk.VooDoo.Core.Attributes;
    using Vsk.VooDoo.Core.Services;
    using Vsk.VooDoo.Edo.API.Models;

    /// <summary>
    /// Интерфейс REST API взаимодействия с модулем "ЭДО"
    /// </summary>
    [InterfaceRoute($"edo/api/v1")]
    public interface IEdoWebApiService : IWebApiService
    {
        [Post("/edo/api/v1/Ping")]
        [HttpPost]
        [RouteWithoutAsync(nameof(PingAsync))]
        public Task<PongResponse> PingAsync([FromBody] PingRequest request);
    }
}
