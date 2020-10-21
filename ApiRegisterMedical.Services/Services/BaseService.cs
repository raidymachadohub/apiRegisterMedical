using ApiRegisterMedical.Repository.Interfaces;
using ApiRegisterMedical.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRegisterMedical.Services.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _baseRepository;
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<T> Delete(int id)
        {
            return await _baseRepository.Delete(id);
        }


        public async Task<T> GetById(int id)
        {
            return await _baseRepository.GetById(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _baseRepository.GetAll();
        }

        public async Task<T> Post(T obj)
        {
            return await _baseRepository.Post(obj);
        }

        public async Task Put(int id, T obj)
        {
            await _baseRepository.Put(id, obj);
        }
    }
}
