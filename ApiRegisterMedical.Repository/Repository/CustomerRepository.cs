using ApiRegisterMedical.Domain;
using ApiRegisterMedical.Repository.Interfaces;
using System;

namespace ApiRegisterMedical.Repository.Repository
{

    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(RegisterMedicalContext context) : base(context) { }
    }
}
