using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DL.Interfaces
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public Task Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<System.Linq.IQueryable<T>> FindAll(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<System.Linq.IQueryable<T>> FindByCondition(System.Linq.Expressions.Expression<Func<T, bool>> expression, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
