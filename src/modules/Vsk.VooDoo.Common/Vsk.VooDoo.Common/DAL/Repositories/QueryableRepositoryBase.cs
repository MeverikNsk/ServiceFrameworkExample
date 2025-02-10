namespace Vsk.VooDoo.Common.DAL.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections;
    using System.Linq;
    using System.Linq.Expressions;

    public abstract class QueryableRepositoryBase<T> : IQueryableRepository<T> where T : class, IAggregateRoot
    {
        private readonly DbContext dbContext;
        private readonly DbSet<T> targetDbSet;
        public QueryableRepositoryBase(DbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            targetDbSet = dbContext.Set<T>();
            Expression = Expression.Constant(this);
            Provider = new QueryableRepositoryBaseQueryProvider<T>(targetDbSet);
        }
        public QueryableRepositoryBase(IQueryProvider provider, Expression expression)
        {
            Provider = provider;
            Expression = expression;
        }

        public Type ElementType => typeof(T);

        public Expression Expression { get; }

        public IQueryProvider Provider { get; }

        public abstract IUnitOfWork UnitOfWork { get; }

        public IEnumerator<T> GetEnumerator() => Provider.Execute<IEnumerable<T>>(Expression).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(T entity)
        {
            targetDbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            var entry = dbContext.Entry(entity);

            if (entry == null || entry.State == EntityState.Detached)
            {
                targetDbSet.Attach(entity);
            }

            entry.State = EntityState.Deleted;
        }

        public void Update(T entity)
        {
            var entry = dbContext.Entry(entity);

            if (entry == null || entry.State == EntityState.Detached)
            {
                targetDbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }
    }
}
