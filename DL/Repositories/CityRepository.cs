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
    public class CityRepository : RepositoryBase<CityDomainModel>, ICityRepository
    {
        private readonly NpgsqlConnection npgsqlConnection;
        private const string CityTable = @"""Cities""";
        public CityRepository(INpgSqlProvider connectionProvider):base(connectionProvider)
        {
            if (connectionProvider == null)
            {
                throw new ArgumentNullException(nameof(connectionProvider));
            }

            npgsqlConnection = connectionProvider.Connection;
        }

        

        public async Task<IEnumerable<CityDomainModel>> GetAllCities()
        {
            var lstCity = new List<CityDomainModel>();
            var queryString =
                $@"SELECT *
                FROM {CityTable}";

            await using var query = new NpgsqlCommand(queryString, npgsqlConnection);
            await using var reader = await query.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                lstCity.Add(NewCityDomainModel(reader));
            }

            return lstCity;
        }
        public async Task DeleteById(Guid id)
        {
            await Delete(id, CityTable);
        }
        public async Task<CityDomainModel> GetById(Guid id)
        {
            await using var reader = await GetReader(id, CityTable);
            CityDomainModel city = null;
            if(await reader.ReadAsync())
            {
                city = NewCityDomainModel( reader);
            }
            return city;
        }
        private static CityDomainModel NewCityDomainModel(NpgsqlDataReader reader)
        {
            return new CityDomainModel()
            {
                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                Name = reader.GetString(reader.GetOrdinal("Name"))
            };
        }

        public new async Task Update(CityDomainModel cityDomainModel)
        {
            try
            {
                await GetById(cityDomainModel.Id);

                var queryString = $"Update {CityTable} SET \"Name\"=@name where \"Id\"=@id";
                await ExecuteQuery(queryString, cityDomainModel);
            }
            catch
            {
                throw new CustomException(
                    $"Row with id \"{cityDomainModel.Id}\" in table {CityTable} does not exist");
            }

        }

        public async Task Add(CityDomainModel cityDomainModel)
        {

            try
            {
                await GetById(cityDomainModel.Id);
                throw new CustomException(
                    $"Row with id \"{cityDomainModel.Id}\" in table {CityTable} has already exist");
            }
            catch (ArgumentNullException)
            {
                var queryString = $"INSERT INTO {CityTable} (\"Id\",\"Name\") VALUES (@id,@name)";
                await ExecuteQuery(queryString, cityDomainModel);
            }
        }

        private async Task ExecuteQuery(string queryString, CityDomainModel cityDomainModel)
        {
            await using var query = new NpgsqlCommand(queryString, npgsqlConnection);
            query.Parameters.AddWithValue("@id", cityDomainModel.Id);
            query.Parameters.AddWithValue("@name", cityDomainModel.Name);
            query.ExecuteNonQuery();
        }
    }
}
