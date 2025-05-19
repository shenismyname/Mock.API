using Mock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Domain.Interface
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        public Task<T?> GetAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> AddAsync(T item);
        public Task UpdateAsync(T item);
        public Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);
    }
}
