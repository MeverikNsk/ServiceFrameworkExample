namespace Vsk.VooDoo.Adapters.Infrastructure.Settings
{
    using Vsk.VooDoo.Common.DAL.DataBase;

    internal class DataBaseSettings : IDataBaseSettings
    {
        public string Host => "localhost";

        public string Database => "postgres";

        public int Port => 5432;

        public string Username => "postgres";

        public string Password => "qwerty";
    }
}
