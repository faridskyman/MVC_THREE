using MVC_Three.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVC_Three.ViewModels;

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


        public ActionResult New()
        {
            var _membershipType = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormVideoModel
            {
                membershipTypes = _membershipType
            };
            return View("CustomerForm", viewModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewMode">mvc wil then sort out from view and send back data in this format, model binding</param>
        /// <param name="viewMode">from NewCustomerViewMode we can also use Customer, MVC will be able to modelbind</param>
        /// <returns></returns>
        [HttpPost] //only allow post 
        public ActionResult Save(Customer customer)
        {
            // use mode state property to get access to state data
            // if the model is not valid due to not meeting the 'data annotation' 
            //      in the model then isvalid is false, 
            //      so we return the customer back to the customer form.

            // i needed to to do this as during validaiton modelstate is always false as
            //  id is 0 and thats seems to fail validation. Hence if its a new record, 
            //  remove Id from validation.
            if (customer.Id == 0)
                ModelState.Remove("Customer.Id");


            if (!ModelState.IsValid)
            {
                var custfmVModel = new CustomerFormVideoModel
                {
                    Customer = customer,
                    membershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", custfmVModel);
                
            }
            


            if (customer.Id == 0)
            {
                _context.Customers.Add(customer); //saved in memory, not yet in db
            }
            else
            {
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDB.Name = customer.Name;
                customerInDB.BirthDate= customer.BirthDate;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }
            
            _context.SaveChanges(); //now then its saved to DB

            return RedirectToAction("Index", "Customers"); //redirect to index/customer
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


        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(s => s.Id == Id);

            if (customer == null)
                return HttpNotFound();

            //New form requires NewCustomerViewMode, so we will create that before going to "CustomerForm"
            CustomerFormVideoModel viewModel = new CustomerFormVideoModel
            {
                Customer = customer,
                membershipTypes = _context.MembershipTypes.ToList()
            };
                return View("CustomerForm", viewModel); //redirect users to "New" action in customers
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