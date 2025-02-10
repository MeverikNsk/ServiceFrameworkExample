namespace Vsk.VooDoo.Adapters.Infrastructure.DAL.Repositories
{
    using System;
    using Vsk.VooDoo.Adapters.Domain.Models;
    using Vsk.VooDoo.Adapters.Domain.Repositoryes;
    using Vsk.VooDoo.Adapters.Infrastructure.DAL.DataBase;
    using Vsk.VooDoo.Common.DAL.Repositories;

    internal class QueryableUserRepository : QueryableRepositoryBase<User>, IQueryableUserRepository
    {
        private readonly ApplicationDbContext _context;

        public override IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public QueryableUserRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
