using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRegisterMedical.Domain;
using ApiRegisterMedical.Services.Services;
using ApiRegisterMedical.Services.Interfaces;

namespace ApiRegisterMedical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly RegisterMedicalContext _context;

        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService _customerService)
        {
            this._customerService = _customerService;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Getcustomers()
        {
            var result = await _customerService.GetcustomersAll();
            return result.ToList();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.id)
            {
                return BadRequest();
            }
            try
            {
                await _customerService.PutCustomer(id, customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_customerService.CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            var customer_ = await _customerService.PostCustomer(customer);

            return CreatedAtAction("GetCustomer", new { id = customer_.id }, customer_);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var customer = await _customerService.DeleteCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }
    }
}
