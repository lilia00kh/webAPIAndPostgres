// <copyright file="NpgSqlProvider.cs" company="Thomson Reuters">
// Copyright (c) Thomson Reuters. All Rights Reserved. Proprietary and Confidential information of Thomson Reuters. Disclosure, Use or Reproduction without the written authorization of Thomson Reuters is prohibited.
// </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Npgsql.Json.NET;
using Npgsql.NameTranslation;
namespace DL.Providers
{
    /// <summary>
    /// Postgresql connection provider
    /// </summary>
    public sealed class NpgSqlProvider : INpgSqlProvider, IDisposable
    {
        // prefix used to group database properties
        private const string DatabasePropertyGroup = "bm_tax_importexport_pg";

        /// <summary>
        /// Initializes a new instance of the <see cref="NpgSqlProvider" /> class.
        /// </summary>
        /// <param name="config"> Configuration instance </param>
        public NpgSqlProvider(IConfiguration config)
        {
            Func<string, string> dbprop = prop => config[DatabasePropertyGroup + '.' + prop];
            var connstr = "Host=localhost;Port=5432;Database=weathersdb;Username=postgres;Password=1234";
            //var connstr = new NpgsqlConnectionStringBuilder
            //{
            //    Host = dbprop("Server"),
            //    Port = int.Parse(dbprop("Port"), CultureInfo.CurrentCulture),
            //    Username = dbprop("User Id"),
            //    Password = dbprop("Password"),
            //    Database = dbprop("Database"),
            //    SearchPath = dbprop("Searchpath"),
            //    Timeout = int.Parse(dbprop("Timeout"), CultureInfo.CurrentCulture),
            //    CommandTimeout = int.Parse(dbprop("CommandTimeout"), CultureInfo.CurrentCulture),
            //    Pooling = bool.Parse(dbprop("Pooling")),
            //    MinPoolSize = int.Parse(dbprop("MinPoolSize"), CultureInfo.CurrentCulture),
            //    MaxPoolSize = int.Parse(dbprop("MaxPoolSize"), CultureInfo.CurrentCulture),
            //    ConnectionIdleLifetime = int.Parse(dbprop("ConnectionIdleLifetime"), CultureInfo.CurrentCulture),
            //};

            Connection = new NpgsqlConnection(connstr);
           // NpgsqlConnection.GlobalTypeMapper.MapEnum<ExportJobStatus>("export_job_status", new NpgsqlNullNameTranslator());
           // NpgsqlConnection.GlobalTypeMapper.MapEnum<KeyType>("key_type", new NpgsqlNullNameTranslator());
           // NpgsqlConnection.GlobalTypeMapper.MapEnum<ExportJobReturnDetailStatus>("export_job_return_detail_status", new NpgsqlNullNameTranslator());
           // NpgsqlConnection.GlobalTypeMapper.UseJsonNet(new[] { typeof(ExportData) });
           // NpgsqlConnection.GlobalTypeMapper.MapEnum<ImportJobStatus>("import_job_status", new NpgsqlNullNameTranslator());
           // NpgsqlConnection.GlobalTypeMapper.MapEnum<ImportJobReturnDetailOperationRequested>("import_job_return_detail_operation_requested", new NpgsqlNullNameTranslator());
           // NpgsqlConnection.GlobalTypeMapper.MapEnum<ImportJobReturnDetailStatus>("import_job_return_detail_status", new NpgsqlNullNameTranslator());

            Connection.Open();
        }

        /// <summary>
        ///  Gets connection object
        /// </summary>
        public NpgsqlConnection Connection { get; }

        /// <summary>
        /// Disposes the connection
        /// </summary>
        public void Dispose()
        {
            if (Connection != null)
            {
                Connection.Dispose();
            }
        }
    }
}
