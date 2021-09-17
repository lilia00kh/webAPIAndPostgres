using DL.DomainModels;
using DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DL.Exceptions;
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

        public async Task<WeatherAndCityDomainModel> GetById(Guid id){
            await using var reader = await GetReader(id, WeatherAndCityTable);
            WeatherAndCityDomainModel weatherAndCity = null;
            if (await reader.ReadAsync())
            {
                weatherAndCity = NewWeatherAndCityDomainModel(reader);
            }
            return weatherAndCity;
        }
        private static WeatherAndCityDomainModel NewWeatherAndCityDomainModel(NpgsqlDataReader reader)
        {
            return
                new WeatherAndCityDomainModel()
                {
                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                    CityId = reader.GetGuid(reader.GetOrdinal("CityId")),
                    WeatherId = reader.GetGuid(reader.GetOrdinal("WeatherId"))
                };
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
                    lstWeatherAndCity.Add(NewWeatherAndCityDomainModel(reader));
                }

                return lstWeatherAndCity;
            }
        }

        public new async Task Update(WeatherAndCityDomainModel weatherAndCityDomainModel)
        {
            try
            {
                await GetById(weatherAndCityDomainModel.Id);
                var queryString = $"Update {WeatherAndCityTable} SET \"WeatherId\"=@weatherId,\"CityId\"=@cityId where \"Id\"=@id";
                await ExecuteQuery(queryString, weatherAndCityDomainModel);
            }
            catch
            {
                throw new CustomException(
                    $"Row with id \"{weatherAndCityDomainModel.Id}\" in table {WeatherAndCityTable} does not exist");
            }

        }

        public new async Task Create(WeatherAndCityDomainModel weatherAndCityDomainModel)
        {
            try
            {
                if (await GetById(weatherAndCityDomainModel.Id) != null)
                    throw new CustomException(
                        $"Row with id \"{weatherAndCityDomainModel.Id}\" in table {WeatherAndCityTable} has already exist");
            }
            catch (ArgumentNullException)
            {
                var queryString = $"INSERT INTO {WeatherAndCityTable} (\"Id\",\"WeatherId\",\"CityId\") VALUES (@id,@weatherId,@cityId)";
                await ExecuteQuery(queryString, weatherAndCityDomainModel);
            }

        }

        private async Task ExecuteQuery(string queryString,WeatherAndCityDomainModel weatherAndCityDomainModel)
        {
            await using var query = new NpgsqlCommand(queryString, npgsqlConnection);
            query.Parameters.AddWithValue("@id", weatherAndCityDomainModel.Id);
            query.Parameters.AddWithValue("@weatherId", weatherAndCityDomainModel.WeatherId);
            query.Parameters.AddWithValue("@cityId", weatherAndCityDomainModel.CityId);
            query.ExecuteNonQuery();
        }

    }
}
