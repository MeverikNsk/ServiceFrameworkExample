namespace Vsk.VooDoo.Adapters.Domain.Repositoryes
{
    public interface IRepository<T> 
        where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
