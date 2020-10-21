using ApiRegisterMedical.Domain;
using ApiRegisterMedical.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRegisterMedical.Repository.Repository
{

    public class CustomerRepository : ICustomerRepository
    {
        private readonly RegisterMedicalContext _context;

        public CustomerRepository(RegisterMedicalContext context)
        {
            _context = context;
        }

        public bool CustomerExists(int id)
        {
            return _context.customers.Any(e => e.id == id);
        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            var customer = await _context.customers.FindAsync(id);
            if (customer == null)
            {
                throw new NotImplementedException();
            }

            _context.customers.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var customer = await _context.customers.FindAsync(id);

            if (customer == null)
            {
                return null;
            }

            return customer;
        }

        public async Task<IEnumerable<Customer>> Getcustomers()
        {
            return await _context.customers.ToListAsync();
        }

        public async Task<Customer> PostCustomer(Customer customer)
        {
            _context.customers.Add(customer);
            await _context.SaveChangesAsync();

            return _context.customers.FirstOrDefault(x => x.id == customer.id);
        }

        public async Task PutCustomer(int id, Customer customer)
        {
            if (id != customer.id)
            {
                throw new NotImplementedException();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    throw new NotImplementedException();
                }
                else
                {
                    throw new NotImplementedException(); ;
                }
            }

        }
    }
}
