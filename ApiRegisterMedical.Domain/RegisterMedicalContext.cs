using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiRegisterMedical.Domain
{
    public class RegisterMedicalContext : DbContext
    {
        public DbSet<Customer> customers { get; set; }
        public RegisterMedicalContext(DbContextOptions<RegisterMedicalContext> options) : base(options) { }
    }
}
