namespace Vsk.VooDoo.Common.DAL.DataBase
{
    public interface IDataBaseSettings
    {
        string Host { get; }

        string Database { get; }

        int Port { get; }

        string Username { get; }

        string Password { get; }
    }
}
