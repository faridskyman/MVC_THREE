using MVC_Three.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Three.Controllers
{
    public class CustomersController : Controller
    {
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
            return new List<Customer>
            {
                new Customer{ Id=1, Name = "John Smith" },
                new Customer{ Id=2, Name = "Mary Williams" }
            };
        }
    }
}