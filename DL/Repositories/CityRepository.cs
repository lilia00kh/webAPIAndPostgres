using DL.DomainModels;
using DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using DL.Providers;
using DL.Utility;
using Npgsql;
using NpgsqlTypes;

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
            string queryString =
                $@"SELECT *
                FROM {CityTable}";

            using (var query = new NpgsqlCommand(queryString, npgsqlConnection))
            {

                var ps = query.Parameters;
                using NpgsqlDataReader reader =
                    await query.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    lstCity.Add(
                        new CityDomainModel()
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name"))
                        });
                }

                return lstCity;
            }
        }
        public async Task DeleteById(Guid id)
        {
            await Delete(id, CityTable);
        }
        public async Task<CityDomainModel> GetById(Guid id)
        {
            var queryString =
                $"SELECT * FROM {CityTable} Where \"Id\" = @id";

            await using var query = new NpgsqlCommand(queryString, npgsqlConnection);
            var ps = query.Parameters;
            ps.AddWithValue("@id", NpgsqlDbType.Uuid, id);
            await using var reader = await query.ExecuteReaderAsync();
            CityDomainModel city = null;
            if (!reader.HasRows)
            {
                throw new ArgumentNullException("", $"Does not exist city with id {id}");
            }
            if(await reader.ReadAsync())
            {
                city = new CityDomainModel()
                {
                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name"))
                };
            }

            return city;
        }
    }
}
