using ApiRegisterMedical.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRegisterMedical.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetcustomersAll();
        Task<Customer> GetCustomer(int id);
        Task PutCustomer(int id, Customer customer);
        Task<Customer> PostCustomer(Customer customer);
        Task<Customer> DeleteCustomer(int id);
        bool CustomerExists(int id);
    }
}
