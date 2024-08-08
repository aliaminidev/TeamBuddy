using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeamBuddy.Application.Persistence.Contracts
{
    public interface IGenericRepository<T, TId>
        where T : class
        where TId : struct
    {
        Task<T> Get(TId id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        Task<IReadOnlyList<T>> GetAll();
        Task<bool> IsExist(TId id);

    }
}
