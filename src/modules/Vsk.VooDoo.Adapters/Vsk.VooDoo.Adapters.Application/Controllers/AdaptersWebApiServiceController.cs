namespace Vsk.VooDoo.Adapters.Application.Controllers
{
    using Microsoft.AspNetCore.Mvc;    
    using Vsk.VooDoo.Adapters.API.Models;
    using Vsk.VooDoo.Adapters.API.WebApi;
    using Vsk.VooDoo.Adapters.Domain.Services.Interfaces;

    public class AdaptersWebApiServiceController : ControllerBase, IAdaptersWebApiService
    {
        private readonly IHelloWorlDomainService _helloWorlDomainService;

        public AdaptersWebApiServiceController(IHelloWorlDomainService helloWorlDomainService)
        {
            _helloWorlDomainService = helloWorlDomainService;
        }

        public Task<HelloWorldResponse> HelloWorldAsync([FromBody] HelloWorldRequest request)
        {
            return _helloWorlDomainService.HelloWorldAsync(request);
        }
    }
}
