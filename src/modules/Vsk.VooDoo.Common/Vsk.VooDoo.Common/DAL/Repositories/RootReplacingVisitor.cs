﻿namespace Vsk.VooDoo.Common.DAL.Repositories
{
    using System.Linq;
    using System.Linq.Expressions;

    internal class RootReplacingVisitor : ExpressionVisitor
    {
        private readonly IQueryable newRoot;
        public RootReplacingVisitor(IQueryable newRoot)
        {
            this.newRoot = newRoot;
        }
        protected override Expression VisitConstant(ConstantExpression node) =>
             node.Type.BaseType != null && node.Type.BaseType.IsGenericType && node.Type.BaseType.GetGenericTypeDefinition() == typeof(QueryableRepositoryBase<>) ? Expression.Constant(newRoot) : node;

    }
}
