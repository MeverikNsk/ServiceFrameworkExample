namespace Vsk.VooDoo.Common.DAL.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;
    using System.Reflection;
    using Vsk.VooDoo.Common.Extensions;

    internal class QueryableRepositoryBaseQueryProvider<TEntity> : IQueryProvider where TEntity : class
    {
        private readonly Type queryType;
        private readonly DbSet<TEntity> targetDbSet;

        public QueryableRepositoryBaseQueryProvider(DbSet<TEntity> targetDbSet)
        {
            this.queryType = typeof(QueryableRepositoryBase<>);
            this.targetDbSet = targetDbSet;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            var elementType = expression.Type.GetElementTypeForExpression();
            try
            {
                return (IQueryable)Activator.CreateInstance(queryType.MakeGenericType(elementType), [this, expression]);
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }

        public object Execute(Expression expression)
        {
            try
            {
                return this.GetType().GetGenericMethod(nameof(Execute)).Invoke(this, [expression]);
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }

        // See https://msdn.microsoft.com/en-us/library/bb546158.aspx for more details
        public TResult Execute<TResult>(Expression expression)
        {
            IQueryable<TEntity> newRoot = targetDbSet;
            var treeCopier = new RootReplacingVisitor(newRoot);
            var newExpressionTree = treeCopier.Visit(expression);
            var isEnumerable = (typeof(TResult).IsGenericType && typeof(TResult).GetGenericTypeDefinition() == typeof(IEnumerable<>));
            if (isEnumerable)
            {
                return (TResult)newRoot.Provider.CreateQuery(newExpressionTree);
            }
            var result = newRoot.Provider.Execute(newExpressionTree);
            return (TResult)result;
        }

        public IQueryable<T> CreateQuery<T>(Expression expression)
        {
            var elementType = expression.Type.GetElementTypeForExpression();
            var type = queryType.MakeGenericType(elementType);
            return (IQueryable<T>)Activator.CreateInstance(type, [this, expression]);
        }
    }
}
