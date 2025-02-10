namespace Vsk.VooDoo.Adapters.Infrastructure.DAL.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Vsk.VooDoo.Adapters.Domain.Models;
    using Vsk.VooDoo.Adapters.Domain.Repositoryes;
    using Vsk.VooDoo.Adapters.Infrastructure.DAL.DataBase;

    internal class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public UserRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<User>> GetAllAsync(
            Expression<Func<User, bool>>? wherePredicate = null, 
            Expression<Func<User, User>>? orderByKeySelector = null)
        {
            var query = _context
                .Users
                .Include(b => b.Roles)
                .AsQueryable();

            if (wherePredicate != null)
            {
                query = query.Where(wherePredicate);
            };

            if (orderByKeySelector != null)
            {
                query = query.OrderBy(orderByKeySelector);
            };

            return await query.ToListAsync();
        }
    }
}
