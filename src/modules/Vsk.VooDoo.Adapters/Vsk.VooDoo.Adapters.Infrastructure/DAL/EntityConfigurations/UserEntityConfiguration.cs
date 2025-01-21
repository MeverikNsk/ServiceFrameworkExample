namespace Vsk.VooDoo.Adapters.Infrastructure.DAL.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Vsk.VooDoo.Adapters.Domain.Models;
    using Vsk.VooDoo.Adapters.Infrastructure.DAL.DataBase;

    internal class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> userConfiguration)
        {
            userConfiguration.ToTable(nameof(User), ApplicationDbContext.DEFAULT_SCHEMA);

            userConfiguration.HasKey(b => b.Id);

            userConfiguration.Property(b => b.Id)
                .UseHiLo("user_seq", ApplicationDbContext.DEFAULT_SCHEMA);

            userConfiguration.Property(b => b.Name);

            userConfiguration.Property(b => b.Email);

            userConfiguration.HasMany(b => b.Roles)
               .WithOne()
               .HasForeignKey("UserId")
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
