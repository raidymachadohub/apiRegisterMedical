using ApiRegisterMedical.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRegisterMedical.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> Getcustomers();
        Task<Customer> GetCustomer(int id);
        Task PutCustomer(int id, Customer customer);
        Task<Customer> PostCustomer(Customer customer);
        Task<Customer> DeleteCustomer(int id);
        bool CustomerExists(int id);

    }
}
