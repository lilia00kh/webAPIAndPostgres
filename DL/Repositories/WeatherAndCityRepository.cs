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
    public class WeatherAndCityRepository : RepositoryBase<WeatherAndCityDomainModel>, IWeatherAndCityRepository
    {
        private readonly NpgsqlConnection npgsqlConnection;
        private const string WeatherAndCityTable = @"""WeathersAndCities""";
        public WeatherAndCityRepository(INpgSqlProvider connectionProvider) : base(connectionProvider)
        {
            if (connectionProvider == null)
            {
                throw new ArgumentNullException(nameof(connectionProvider));
            }

            npgsqlConnection = connectionProvider.Connection;
        }

        public async Task DeleteById(Guid id)
        {
            await Delete(id, WeatherAndCityTable);
        }

        public async Task<IEnumerable<WeatherAndCityDomainModel>> GetAllWeathersAndCities()
        {
            var lstWeatherAndCity = new List<WeatherAndCityDomainModel>();
            string queryString =
                $@"SELECT *
                FROM {WeatherAndCityTable}";

            using (var query = new NpgsqlCommand(queryString, npgsqlConnection))
            {
                var ps = query.Parameters;
                using NpgsqlDataReader reader = await query.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    lstWeatherAndCity.Add(
                        new WeatherAndCityDomainModel()
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            CityId = reader.GetGuid(reader.GetOrdinal("CityId")),
                            WeatherId = reader.GetGuid(reader.GetOrdinal("WeatherId"))
                        });
                }

                return lstWeatherAndCity;
            }
        }

    }
}
