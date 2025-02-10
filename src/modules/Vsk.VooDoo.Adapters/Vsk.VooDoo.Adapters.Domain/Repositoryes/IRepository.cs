namespace Vsk.VooDoo.Adapters.Domain.Repositoryes
{
    using System.Linq.Expressions;
    using Vsk.VooDoo.Adapters.Domain.Models;

    public interface IRepository<T> 
        where T : IAggregateRoot
    {
        Task<IEnumerable<User>> GetAllAsync(
            Expression<Func<User, bool>>? wherePredicate = null,
            Expression<Func<User, User>>? orderByKeySelector = null);

        IUnitOfWork UnitOfWork { get; }
    }
}
