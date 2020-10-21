using ApiRegisterMedical.Domain;
using ApiRegisterMedical.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRegisterMedical.Repository.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly RegisterMedicalContext _context;

        private bool disposed = false;

        public BaseRepository(RegisterMedicalContext context)
        {
            _context = context;
            _context.Set<T>();
        }

        public async Task<T> Delete(int id)
        {
            var obj = await _context.Set<T>().FindAsync(id);

            if (obj == null)
            {
                throw new NotImplementedException();
            }

            _context.Set<T>().Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }



        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Post(T obj)
        {
            _context.Set<T>().Add(obj);
            var rs = await _context.SaveChangesAsync();

            return _context.Set<T>().Find(rs);
        }

        public async Task Put(int id, T obj)
        {
            if (id > 0)
            {
                _context.Entry(obj).State = EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw new NotImplementedException();

            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
