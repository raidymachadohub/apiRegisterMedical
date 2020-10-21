using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRegisterMedical.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Put(int id, T obj);
        Task<T> Post(T obj);
        Task<T> Delete(int id);
    }
}
