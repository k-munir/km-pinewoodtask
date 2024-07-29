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
    }
}