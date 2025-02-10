namespace Vsk.VooDoo.Common.Extensions
{
    using Npgsql;
    using Vsk.VooDoo.Common.DAL.DataBase;

    public static class DataBaseSettingsExtensions
    {
        public static string GetConnectionString(this IDataBaseSettings settings)
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
