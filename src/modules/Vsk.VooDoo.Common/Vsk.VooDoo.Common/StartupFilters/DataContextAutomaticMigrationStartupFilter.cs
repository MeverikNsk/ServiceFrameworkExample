namespace Vsk.VooDoo.Adapters.Infrastructure.DAL.DataBase
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class DataContextAutomaticMigrationStartupFilter<T> : IStartupFilter
        where T : DbContext
    {
        /// <inheritdoc />
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    scope.ServiceProvider.GetRequiredService<T>().Database.SetCommandTimeout(160);
                    scope.ServiceProvider.GetRequiredService<T>().Database.Migrate();
                }
                next(app);
            };
        }
    }
}
