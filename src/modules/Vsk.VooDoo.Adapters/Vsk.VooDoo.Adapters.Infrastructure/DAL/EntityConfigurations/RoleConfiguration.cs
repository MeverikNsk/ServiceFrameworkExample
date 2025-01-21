namespace Vsk.VooDoo.Adapters.Infrastructure.DAL.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Vsk.VooDoo.Adapters.Domain.Models;
    using Vsk.VooDoo.Adapters.Infrastructure.DAL.DataBase;

    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> roleBuilder)
        {
            roleBuilder.ToTable(nameof(Role), ApplicationDbContext.DEFAULT_SCHEMA);

            roleBuilder.HasKey(b => b.Id);

            roleBuilder.Property(b => b.Id)
                .UseHiLo("role_seq", ApplicationDbContext.DEFAULT_SCHEMA);

            roleBuilder.Property<long>("UserId")
                .IsRequired();

            roleBuilder.Property(b => b.RoleName);
        }
    }
}
