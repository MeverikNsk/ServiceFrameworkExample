namespace Vsk.VooDoo.Adapters.Infrastructure.Database
{
    using System.Linq;
    using Vsk.VooDoo.Adapters.Domain.Models;
    using Vsk.VooDoo.Adapters.Domain.Repositoryes;
    using Vsk.VooDoo.Adapters.Infrastructure.Entityes;

    internal class AdaptersRepository : IAdaptersRepository
    {
        private Func<UserEntity, User> GetUser => x =>
            new User
            {
                Id = x.Id,
                Email = x.Email,
                Name = x.Name,
            };

        private Func<User, UserEntity> GetUserEntity => x =>
            new UserEntity
            {
                Id = x.Id,
                Email = x.Email,
                Name = x.Name,
            };

        public IQueryable<User> Users 
        {
            get
            {
                var users = new List<UserEntity> {
                    new() { Id = 1, Name = "Igor V. Kachev", Email = "kachev@vsk.ru"},
                    new() { Id = 2, Name = "Vasiliy P. Pupkin", Email = "pupkin@vsk.ru"},
                };

                return users.Select(GetUser).AsQueryable();
            }
        }

        public void AddUser(User user)
        {
            var u = GetUserEntity.Invoke(user);
        }
    }
}
