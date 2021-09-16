using DL.DomainModels;
using DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DL.Providers;
using Npgsql;

namespace DL.Repositories
{
    public class WeatherRepository: RepositoryBase<WeatherDomainModel>, IWeatherRepository
    {
        private readonly NpgsqlConnection npgsqlConnection;
        private const string WeatherTable = @"""Weathers""";
        public WeatherRepository(INpgSqlProvider connectionProvider)
        {
            if (connectionProvider == null)
            {
                throw new ArgumentNullException(nameof(connectionProvider));
            }

            npgsqlConnection = connectionProvider.Connection;
        }



        public async Task<IEnumerable<WeatherDomainModel>> GetAllWeathers()
        {
            var lstWeather = new List<WeatherDomainModel>();
            string queryString =
                $@"SELECT *
                FROM {WeatherTable}";

            using (var query = new NpgsqlCommand(queryString, npgsqlConnection))
            {
                var ps = query.Parameters;
                using NpgsqlDataReader reader = await query.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    lstWeather.Add(
                        new WeatherDomainModel()
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                            TemperatureC = reader.GetInt32(reader.GetOrdinal("TemperatureC")),
                            Summary = reader.GetString(reader.GetOrdinal("Summary"))
                        });
                }

                return lstWeather;
            }
        }
    }
}
