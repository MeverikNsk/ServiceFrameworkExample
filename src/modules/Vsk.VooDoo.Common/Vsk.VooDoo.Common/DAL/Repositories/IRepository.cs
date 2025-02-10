namespace Vsk.VooDoo.Common.DAL.Repositories
{
    public interface IRepository<T>
        where T : IAggregateRoot
    {
        IEnumerable<T> GetAll();

        IUnitOfWork UnitOfWork { get; }
    }
}
