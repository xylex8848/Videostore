using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;
using VideoStore.Models.Repositories;

namespace VideoStore.Controllers
{
    public class CustomerController : Controller
    {
        Repository<Customer> repository = new Repository<Customer>();

        public ActionResult CustomerDetails(int id)
        {
            Customer customer = repository.Get(id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            else
                return View(customer);
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }


        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
                return View("Customer");

            repository.Add(customer);
            repository.SaveChanges();
            return RedirectToAction("index");
        }



    }
}