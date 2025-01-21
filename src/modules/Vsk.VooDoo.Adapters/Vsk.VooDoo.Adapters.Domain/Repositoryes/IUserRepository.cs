namespace Vsk.VooDoo.Adapters.Domain.Repositoryes
{
    using System.Linq;
    using Vsk.VooDoo.Adapters.Domain.Models;

    public interface IUserRepository : IRepository<User>
    {
        IQueryable<User> GetAll();
    }
}
