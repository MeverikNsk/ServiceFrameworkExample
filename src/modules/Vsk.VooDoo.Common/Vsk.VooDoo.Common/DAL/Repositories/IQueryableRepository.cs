namespace Vsk.VooDoo.Common.DAL.Repositories
{
    using System.Linq;

    public interface IQueryableRepository<T> : IOrderedQueryable<T>
        where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
