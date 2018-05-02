using AutoMapper;
using MVC_Three.DTO;
using MVC_Three.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC_Three.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList()
                .Select(Mapper.Map<Customer,CustomerDto>);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();
            //throw new HttpResponseException(HttpStatusCode.NotFound);

            //return Mapper.Map<Customer, CustomerDto>(customer);
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }


        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            //validate customer object
            if (!ModelState.IsValid)
                return BadRequest(); //return badreq results based on 'IHttpActionResult'
                                     //throw new HttpResponseException(HttpStatusCode.BadRequest);


            Customer customer = new Customer();
            //var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            Mapper.Map(customerDto, customer);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            //get the new ID and update DTO
            customerDto.Id = customer.Id;

            //return customerDto;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id)
                ,customerDto);
        }


        //PUT /api/customer/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            
            // get current rec from db
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            //if null 
            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDB);
            //if not null
            _context.SaveChanges();
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            // get current rec from db
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            //if null 
            if (customerInDB == null)
                return NotFound();

            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();
            return Ok();
        }

    }
}
