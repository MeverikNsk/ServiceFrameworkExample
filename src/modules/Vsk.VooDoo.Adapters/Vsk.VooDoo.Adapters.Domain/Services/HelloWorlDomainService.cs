namespace Vsk.VooDoo.Adapters.Domain.Services
{
    using Vsk.VooDoo.Adapters.API.Models;
    using Vsk.VooDoo.Adapters.Domain.Repositoryes;
    using Vsk.VooDoo.Adapters.Domain.Services.Interfaces;

    internal class HelloWorlDomainService : IHelloWorlDomainService
    {
        private readonly IUserRepository _userRepository;
        public HelloWorlDomainService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<HelloWorldResponse> HelloWorldAsync(HelloWorldRequest request)
        {
            //var usersAll = await _userRepository.GetAllAsync(orderByKeySelector: k => k.Name);
            //var users = await _userRepository.GetAllAsync(u => u.Roles.Any(r => r.Id == 2));            

            return new HelloWorldResponse { HelloName = $"Hello, {request.Name}" };
        }
    }
}
