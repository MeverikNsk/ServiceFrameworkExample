namespace Vsk.VooDoo.Edo.Application.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Vsk.VooDoo.Edo.API.Models;
    using Vsk.VooDoo.Edo.API.WebApi;
    using Vsk.VooDoo.Edo.Domain.Services;

    public class EdoWebApiServiceController : ControllerBase, IEdoWebApiService
    {
        private readonly IPingPongService _pingPongService;

        public EdoWebApiServiceController(IPingPongService pingPongService)
        {
            _pingPongService = pingPongService;
        }

        public Task<PongResponse> PingAsync([FromBody] PingRequest request)
        {
            return _pingPongService.PingAsync(request);
        }
    }
}
