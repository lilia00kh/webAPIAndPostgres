﻿using DL.DomainModels;
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
                Date = reader.GetDateTime(reader.GetOrdinal("Date")),
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
    }
}
