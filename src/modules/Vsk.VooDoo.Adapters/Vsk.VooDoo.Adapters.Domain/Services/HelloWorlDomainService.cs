namespace Vsk.VooDoo.Adapters.Domain.Services
{
    using Microsoft.EntityFrameworkCore;
    using Vsk.VooDoo.Adapters.API.Models;
    using Vsk.VooDoo.Adapters.Domain.Repositoryes;
    using Vsk.VooDoo.Adapters.Domain.Services.Interfaces;

    internal class HelloWorlDomainService : IHelloWorlDomainService
    {
        private readonly IUserRepository _userRepository;
        private readonly IQueryableUserRepository _queryableUserRepository;
        public HelloWorlDomainService(
            IUserRepository userRepository,
            IQueryableUserRepository queryableUserRepository)
        {
            _userRepository = userRepository;
            _queryableUserRepository = queryableUserRepository;
        }

        public async Task<HelloWorldResponse> HelloWorldAsync(HelloWorldRequest request)
        {
            var usersAll = _userRepository.GetAll();
            var queryableUsersAll = _queryableUserRepository.Include(i => i.Roles).ToList();

            return await Task.FromResult(new HelloWorldResponse { HelloName = $"Hello, {request.Name}" });
        }
    }
}
