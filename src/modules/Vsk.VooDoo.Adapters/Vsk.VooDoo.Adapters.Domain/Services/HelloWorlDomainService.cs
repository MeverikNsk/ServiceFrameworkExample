namespace Vsk.VooDoo.Adapters.Domain.Services
{
    using Vsk.VooDoo.Adapters.API.Models;
    using Vsk.VooDoo.Adapters.Domain.Services.Interfaces;

    internal class HelloWorlDomainService : IHelloWorlDomainService
    {
        public async Task<HelloWorldResponse> HelloWorldAsync(HelloWorldRequest request)
        {
            return await Task.FromResult(new HelloWorldResponse { HelloName = $"Hello, {request.Name}" });
        }
    }
}
