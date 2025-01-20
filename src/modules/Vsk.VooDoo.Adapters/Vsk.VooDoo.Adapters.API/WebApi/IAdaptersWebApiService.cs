namespace Vsk.VooDoo.Adapters.API.WebApi
{
    using Microsoft.AspNetCore.Mvc;
    using Refit;
    using Vsk.VooDoo.Adapters.API.Models;
    using Vsk.VooDoo.Core.Attributes;
    using Vsk.VooDoo.Core.Services;

    /// <summary>
    /// Интерфейс REST API взаимодействия с модулем "Адаптеры"
    /// </summary>
    [InterfaceRoute($"adapters/api/v1")]
    public interface IAdaptersWebApiService : IWebApiService
    {
        /// <summary>
        /// Тестовый метод HelloWorld
        /// </summary>        
        [Post("/adapters/api/v1/HelloWorld")]
        [HttpPost]
        [RouteWithoutAsync(nameof(HelloWorldAsync))]
        public Task<HelloWorldResponse> HelloWorldAsync([FromBody] HelloWorldRequest request);
    }
}
