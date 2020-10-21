using ApiRegisterMedical.Domain;
using ApiRegisterMedical.Repository.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRegisterMedical.Repository.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
    }
}
