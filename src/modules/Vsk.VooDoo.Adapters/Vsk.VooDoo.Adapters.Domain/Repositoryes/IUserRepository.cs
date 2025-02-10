namespace Vsk.VooDoo.Adapters.Domain.Repositoryes
{
    using Vsk.VooDoo.Adapters.Domain.Models;
    using Vsk.VooDoo.Common.DAL.Repositories;

    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAll();
    }
}
