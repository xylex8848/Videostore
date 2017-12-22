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

        public ActionResult Details(int id)
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


        public ActionResult Delete(int id)
        {
            VideoStoreDbContext context = new VideoStoreDbContext();
            Customer customer = repository.Get(id);


            if (customer == null || context.VideoFilms.Where(x => x.CustomerId == customer.Id).ToList().Count != 0)
                return HttpNotFound();
            else               
                return View(customer);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = repository.Get(id);

            VideoStoreDbContext context = new VideoStoreDbContext();

            if (customer == null || context.VideoFilms.Where(x => x.CustomerId == customer.Id).ToList().Count != 0)
            {
               return HttpNotFound("Can't delete customer, either customer do not exist in database or customer has videofilms rented");
            }
            else
            {
                repository.Remove(customer);
                repository.SaveChanges();
                return RedirectToAction("index");
            }
        }
        

        public ActionResult Edit(int id)
        {
            Customer customer = repository.Get(id);

            if (customer == null)
                return HttpNotFound();
            else
                return View(customer);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirmed(Customer customer)
        {
            if (customer == null)
                return HttpNotFound();
            else
            {
                repository.Edit(customer);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Errormessage(string message)
        {
            ViewBag.message = message;
            return View();
        }


    }
}