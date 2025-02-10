namespace Vsk.VooDoo.Adapters.Domain.Models
{
    using Vsk.VooDoo.Common.DAL.Repositories;

    public class User : Entity, IAggregateRoot
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public IEnumerable<Role> Roles { get; set; }
    }
}
