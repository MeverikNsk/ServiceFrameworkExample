namespace Vsk.VooDoo.Adapters.Infrastructure.DAL.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
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

        public IQueryable<User> GetAll()
        {
            return _context.Users.Include(b => b.Roles);                
        }
    }
}
