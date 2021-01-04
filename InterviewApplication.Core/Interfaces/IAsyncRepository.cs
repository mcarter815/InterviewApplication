using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;
using InterviewApplication.Core.Entities;

namespace InterviewApplication.Core.Interfaces
{
    public interface IAsyncRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(List<T> entityList);
        Task DeleteRangeAsync(IEnumerable<T> entityList);
        Task DeleteAsync(T entity);
        Task<int> CountAsync(ISpecification<T> spec);
    }
}
