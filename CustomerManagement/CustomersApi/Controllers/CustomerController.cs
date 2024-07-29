using CustomersApi.Data;
using CustomersApi.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomersApi.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("get")]
        [HttpGet]
        public IActionResult Get()
        {
            var customers = _context.Customers.ToList();
            return Ok(customers);
        }

        [Route("get")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) return NotFound("Customer not found");
            return Ok(customer);
        }

        [Route("post")]
        [HttpPost]
        public IActionResult Post(Customer model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("Customer added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [Route("put")]
        [HttpPut]
        public IActionResult Put(Customer model)
        {
            try
            {
                if (model.Id == 0) return BadRequest("Invalid customer data");
                var customer = _context.Customers.Find(model.Id);
                if (customer == null) return NotFound("Customer not found");
                customer.Email = model.Email;
                customer.FirstName = model.FirstName;
                customer.LastName = model.LastName;
                customer.Telephone = model.Telephone;
                _context.SaveChanges();
                return Ok("Customer updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[Route("delete")]
        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    var customer = _context.Customers.Find(id);
        //    if (customer == null) return NotFound("Customer not found");
        //    _context.Customers.del
        //    return Ok(customer);
        //}
    }
}