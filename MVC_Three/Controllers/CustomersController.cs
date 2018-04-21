using MVC_Three.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MVC_Three.Controllers
{
    public class CustomersController : Controller
    {
        //declare dbcontext to connect to database
        private ApplicationDbContext _context;

        //ctor (shortcut to gen constructor)
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //dispose appdbcontext when no longer in use 
        //  need to override base class to do this.
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View(GetCustomers());
        }

        public ActionResult Details(int Id)
        {
            var customer = GetCustomers().SingleOrDefault(s => s.Id == Id);

            if (customer == null)
                return HttpNotFound();
            else
                return View(customer);
        }


        private IEnumerable<Customer> GetCustomers()
        {
            //  1. .ToList()
            //      when call toList when the dbcall is made
            //      else db call is defered till in view
            //  2. Eager Loading
            //      This is to load refence table along with customer object
            //      added the .Include() to EAGER LOAD MembershipType, 
            //      For it to work, we need to add reference to 'using System.Data.Entity;'
            var customers = _context.Customers.Include(c => c.MembershipType).ToList(); 
            return customers;
        }
    }
}