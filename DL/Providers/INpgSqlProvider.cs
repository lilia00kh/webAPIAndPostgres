using Npgsql;

namespace DL.Providers
{

    public interface INpgSqlProvider
    {
        public NpgsqlConnection Connection { get; }
    }
}
