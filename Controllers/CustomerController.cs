using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Models;
using ContosoPizza.Services;
namespace  ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController: ControllerBase
    {
        public CustomerController()
        {}
        [HttpGet]
        public ActionResult<List<Customer>> GetAllCustomer() => 
        CustomerService.GetAllCustomers();
        //Get customer by Id
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer = CustomerService.GetCustomer(id);
            if(customer == null)
            return NotFound();
            return customer;
        }
        [HttpGet]
        public IActionResult CreateCustomer(Customer customer)
        {
            CustomerService.AddCustomer(customer);
            return CreatedAtAction(nameof(CreateCustomer), new {id = customer.Id}, customer);
        }
        public IActionResult Update(int id, Customer customer)
        {
            if (id != customer.Id)
            return BadRequest();
            var existingCustomer = CustomerService.GetCustomer(id);
            if(existingCustomer is null)
            return NotFound();
            CustomerService.UpdateCustomer(customer);
            return NoContent();
        }
        
    }
    
}