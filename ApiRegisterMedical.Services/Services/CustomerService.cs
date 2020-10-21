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
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        private readonly IBaseRepository<Customer> _baseRepository;

        public CustomerService(IBaseRepository<Customer> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }

    }
}
