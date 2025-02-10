namespace Vsk.VooDoo.Common.DAL.Repositories
{
    public interface IRepository<T>
        where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
