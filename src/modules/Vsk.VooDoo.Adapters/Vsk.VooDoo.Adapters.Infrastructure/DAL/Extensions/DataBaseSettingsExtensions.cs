namespace Vsk.VooDoo.Adapters.Infrastructure.DAL.Extensions
{
    using Npgsql;
    using Vsk.VooDoo.Adapters.Infrastructure.DAL.DataBase;

    internal static class DataBaseSettingsExtensions
    {
        public static string GetConnectionString(this DataBaseSettings settings)
        {
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = settings.Host,
                Database = settings.Database,
                Port = settings.Port,
                Username = settings.Username,
                Password = settings.Password,
            };
            return builder.ToString();
        }
    }
}
