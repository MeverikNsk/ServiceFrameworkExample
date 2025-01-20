namespace Vsk.VooDoo.Adapters.Domain.Repositoryes
{
    using Vsk.VooDoo.Adapters.Domain.Models;

    public interface IAdaptersRepository
    {
        public IQueryable<User> Users { get; }
    }
}
