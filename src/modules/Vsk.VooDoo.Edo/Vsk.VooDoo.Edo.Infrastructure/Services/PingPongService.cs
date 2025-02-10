namespace Vsk.VooDoo.Edo.Infrastructure.Services
{
    using AutoMapper;
    using Vsk.VooDoo.Adapters.API.Models;
    using Vsk.VooDoo.Adapters.API.WebApi;
    using Vsk.VooDoo.Edo.API.Models;
    using Vsk.VooDoo.Edo.Domain.Services;

    internal class PingPongService : IPingPongService
    {
        private readonly IAdaptersWebApiService _adaptersWebApiService;
        private readonly IMapper _mapper;

        public PingPongService(
            IAdaptersWebApiService adaptersWebApiService,
            IMapper mapper)
        {
            _adaptersWebApiService = adaptersWebApiService;
            _mapper = mapper;
        }

        public async Task<PongResponse> PingAsync(PingRequest request)
        {
            var result = await _adaptersWebApiService.HelloWorldAsync(new HelloWorldRequest { Name = request.PingName });

            return new PongResponse
            {
                PongName = result.HelloName
            };
        }
    }
}
