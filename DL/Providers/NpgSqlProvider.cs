using System;
using Microsoft.Extensions.Configuration;
using Npgsql;
namespace DL.Providers
{

    public sealed class NpgSqlProvider : INpgSqlProvider, IDisposable
    {
        private const string DatabasePropertyGroup = "bm_tax_importexport_pg";

        public NpgSqlProvider(IConfiguration config)
        {
            Func<string, string> dbprop = prop => config[DatabasePropertyGroup + '.' + prop];
            var connstr = "Host=localhost;Port=5432;Database=weathersdb;Username=postgres;Password=1234";
            Connection = new NpgsqlConnection(connstr);
            Connection.Open();
        }
        public NpgsqlConnection Connection { get; }

        public void Dispose()
        {
            if (Connection != null)
            {
                Connection.Dispose();
            }
        }
    }
}
