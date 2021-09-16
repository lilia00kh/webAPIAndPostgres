using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DL.DomainModels;
using DL.Interfaces;
using DL.Providers;
using Npgsql;
using NpgsqlTypes;

namespace DL.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly NpgsqlConnection npgsqlConnection;

        public RepositoryBase(){}
        public RepositoryBase(INpgSqlProvider connectionProvider)
        {
            if (connectionProvider == null)
            {
                throw new ArgumentNullException(nameof(connectionProvider));
            }

            npgsqlConnection = connectionProvider.Connection;
        }
        public Task Create(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id, string tableName)
        {
            var queryString =
                $"DELETE FROM {tableName} Where \"Id\" = @id";
            await using var query = new NpgsqlCommand(queryString, npgsqlConnection);
            var ps = query.Parameters;
            ps.AddWithValue("@id", NpgsqlDbType.Uuid,id);
            var res = await query.ExecuteNonQueryAsync();
            if (res==0)
            {
                throw new ArgumentNullException("", $"Does not exist row in table {tableName} with id \"{id}\"");
            }
        }



        public Task<System.Linq.IQueryable<T>> FindAll(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<System.Linq.IQueryable<T>> FindByCondition(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
