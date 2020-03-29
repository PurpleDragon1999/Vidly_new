using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_new.Models;

namespace Vidly_new.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Cutomers
        [Route("Customers")]
        public ActionResult Index()
        {
            //Here query will be executed when it will be iterated in HTML, _context.Customers;.
            //Whereas, to immediately execute the query, _context.Customers.ToList();
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);

        }

        //[Route("Customers/Details/:id")]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

    }
}