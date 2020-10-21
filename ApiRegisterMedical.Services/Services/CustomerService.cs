using ApiRegisterMedical.Domain;
using ApiRegisterMedical.Repository.Interfaces;
using ApiRegisterMedical.Repository.Repository;
using ApiRegisterMedical.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiRegisterMedical.Services.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository _customerRepository)
        {
            this._customerRepository = _customerRepository;
        }

        public bool CustomerExists(int id)
        {
            return _customerRepository.CustomerExists(id);
        }

        public Task<Customer> DeleteCustomer(int id)
        {
            return _customerRepository.DeleteCustomer(id);
        }

        public Task<Customer> GetCustomer(int id)
        {
            return _customerRepository.GetCustomer(id);
        }

        public Task<IEnumerable<Customer>> GetcustomersAll()
        {
            return _customerRepository.Getcustomers();
        }

        public Task<Customer> PostCustomer(Customer customer)
        {
            return _customerRepository.PostCustomer(customer);
        }

        public Task PutCustomer(int id, Customer customer)
        {
            return _customerRepository.PutCustomer(id, customer);
        }
    }
}
