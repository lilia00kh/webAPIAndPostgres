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
    public class WeatherRepository: RepositoryBase<WeatherDomainModel>, IWeatherRepository
    {
        private readonly NpgsqlConnection npgsqlConnection;
        private const string WeatherTable = @"""Weathers""";
        public WeatherRepository(INpgSqlProvider connectionProvider) : base(connectionProvider)
        {
            if (connectionProvider == null)
            {
                throw new ArgumentNullException(nameof(connectionProvider));
            }

            npgsqlConnection = connectionProvider.Connection;
        }

        public async Task DeleteById(Guid id)
        {
            await Delete(id, WeatherTable);
        }

        public async Task<IEnumerable<WeatherDomainModel>> GetAllWeathers()
        {
            var lstWeather = new List<WeatherDomainModel>();
            string queryString =
                $@"SELECT *
                FROM {WeatherTable}";

            await using var query = new NpgsqlCommand(queryString, npgsqlConnection);
            var ps = query.Parameters;
            await using var reader = await query.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                lstWeather.Add(NewWeatherDomainModel(reader));
            }

            return lstWeather;
        }

        private static WeatherDomainModel NewWeatherDomainModel(NpgsqlDataReader reader)
        {
            return new WeatherDomainModel()
            {
                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                //Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                TemperatureC = reader.GetInt32(reader.GetOrdinal("TemperatureC")),
                Summary = reader.GetString(reader.GetOrdinal("Summary"))
            };
        }

        public async Task<WeatherDomainModel> GetById(Guid id)
        {
            await using var reader = await GetReader(id, WeatherTable);
            WeatherDomainModel weather = null;
            if (await reader.ReadAsync())
            {
                weather = NewWeatherDomainModel(reader);
            }
            return weather;
        }
        public new async Task Update(WeatherDomainModel weatherDomainModel)
        {
            try
            {
                await GetById(weatherDomainModel.Id);
                var queryString =
                    $"Update {WeatherTable} SET \"Id\"=@id,\"Date\"=@date,\"TemperatureC\"=@temperatureC,\"TemperatureF\"=@temperatureF,\"Summary\"=@summary where \"Id\"=@id";

                await ExecuteQuery(queryString, weatherDomainModel);
            }
            catch
            {
                throw new CustomException(
                    $"Row with id \"{weatherDomainModel.Id}\" in table {WeatherTable} does not exist");
            }
            
        }

        public new async Task Create(WeatherDomainModel weatherDomainModel)
        {
            try
            {
                if (await GetById(weatherDomainModel.Id) != null)
                    throw new CustomException(
                        $"Row with id \"{weatherDomainModel.Id}\" in table {WeatherTable} has already exist");
            }
            catch(ArgumentNullException)
            {
                var queryString =
                    $"INSERT INTO {WeatherTable} (\"Id\",\"Date\",\"TemperatureC\",\"TemperatureF\",\"Summary\") VALUES (@id,@date,@temperatureC,@temperatureF,@summary)";
                await ExecuteQuery(queryString, weatherDomainModel);
            }
        }

        private async Task ExecuteQuery(string queryString, WeatherDomainModel weatherDomainModel)
        {
            await using var query = new NpgsqlCommand(queryString, npgsqlConnection);
            query.Parameters.AddWithValue("@id", weatherDomainModel.Id);
            query.Parameters.AddWithValue("@date", weatherDomainModel.Date);
            query.Parameters.AddWithValue("@temperatureC", weatherDomainModel.TemperatureC);
            query.Parameters.AddWithValue("@temperatureF", weatherDomainModel.TemperatureF);
            query.Parameters.AddWithValue("@summary", weatherDomainModel.Summary);
            query.ExecuteNonQuery();
        }
    }
}
