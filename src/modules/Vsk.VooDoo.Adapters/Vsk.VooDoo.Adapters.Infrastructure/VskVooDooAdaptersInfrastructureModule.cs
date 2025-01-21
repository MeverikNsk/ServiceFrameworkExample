namespace Vsk.VooDoo.Adapters.Infrastructure
{
    using AutoMapper;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Migrations;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Vsk.VooDoo.Adapters.Domain.Repositoryes;
    using Vsk.VooDoo.Adapters.Infrastructure.DAL.DataBase;
    using Vsk.VooDoo.Adapters.Infrastructure.DAL.Extensions;
    using Vsk.VooDoo.Adapters.Infrastructure.DAL.Repositories;
    using Vsk.VooDoo.Core.Module;

    public class VskVooDooAdaptersInfrastructureModule : AssemblyDefinedModule, IAutoMapperConfiguration
    {
        public override void Init(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connection = new DataBaseSettings().GetConnectionString();
                options.UseNpgsql(connection, opt =>
                {
                    opt.MigrationsHistoryTable(HistoryRepository.DefaultTableName, ApplicationDbContext.DEFAULT_SCHEMA);
                });
                options.EnableSensitiveDataLogging(true);
        });
            
            services.AddTransient<IStartupFilter, DataContextAutomaticMigrationStartupFilter<ApplicationDbContext>>();
        }

        public void RegisterMaps(IProfileExpression cfgMap)
        {
            // Nothing
        }
    }
}
