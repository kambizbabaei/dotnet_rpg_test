using System.Collections.Generic;
using System.Threading.Tasks;
using pr.Models.baseClass;

namespace pr.Core.interfaces.IRepository
{
    public interface IGenericRepository<T> where T : entity
    {
        Task<IEnumerable<T>> All();
        Task<bool> Upsert(T entity);
        Task<T> Find(int id);
        Task<bool> Delete(int id);
        Task<bool> Add(T entity);

    }
}