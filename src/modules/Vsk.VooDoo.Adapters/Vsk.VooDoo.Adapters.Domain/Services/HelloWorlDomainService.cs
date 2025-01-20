namespace Vsk.VooDoo.Adapters.Domain.Services
{
    using Vsk.VooDoo.Adapters.API.Models;
    using Vsk.VooDoo.Adapters.Domain.Repositoryes;
    using Vsk.VooDoo.Adapters.Domain.Services.Interfaces;

    internal class HelloWorlDomainService : IHelloWorlDomainService
    {
        private readonly IAdaptersRepository _adaptersRepository;
        public HelloWorlDomainService(IAdaptersRepository adaptersRepository)
        {
            _adaptersRepository = adaptersRepository;
        }

        public async Task<HelloWorldResponse> HelloWorldAsync(HelloWorldRequest request)
        {
            var user = _adaptersRepository.Users.Where(c => c.Id == 2).Single();

            return await Task.FromResult(new HelloWorldResponse { HelloName = $"Hello, {request.Name}" });
        }
    }
}
