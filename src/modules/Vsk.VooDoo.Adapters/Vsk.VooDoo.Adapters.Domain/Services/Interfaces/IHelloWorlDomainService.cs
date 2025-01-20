namespace Vsk.VooDoo.Adapters.Domain.Services.Interfaces
{
    using Vsk.VooDoo.Adapters.API.Models;

    public interface IHelloWorlDomainService
    {
        Task<HelloWorldResponse> HelloWorldAsync(HelloWorldRequest request);
    }
}
