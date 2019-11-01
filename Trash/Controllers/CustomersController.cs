using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trash.Models;

namespace Trash.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,StreetAddress,City,State,ZipCode,PickUpConfirmed")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.ApplicationId = User.Identity.GetUserId();
                customer.MonthlyCharge = 40;
                customer.Balance = 0;
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index", "User");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit()
        {
            
            string userId = User.Identity.GetUserId();
            Customer customer = db.Customers.FirstOrDefault(c => c.ApplicationId == userId);
            
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                Customer customerFromDb = db.Customers.FirstOrDefault(c => c.Id == customer.Id);
                customerFromDb.FirstName = customer.FirstName;
                customerFromDb.LastName = customer.LastName;
                customerFromDb.StreetAddress = customer.StreetAddress;
                customerFromDb.City = customer.City;
                customerFromDb.State = customer.State;
                customerFromDb.ZipCode = customer.ZipCode;
                
                

                db.SaveChanges();
                return RedirectToAction("Index", "User");
            }
            return View(customer);
        }

        public ActionResult EditPickup()
        {

            string userId = User.Identity.GetUserId();
            Customer customer = db.Customers.FirstOrDefault(c => c.ApplicationId == userId);

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPickUp(Customer customer)
        {
            if (ModelState.IsValid)
            {
                Customer customerFromDb = db.Customers.FirstOrDefault(c => c.Id == customer.Id);
               
                customerFromDb.PickUpDay = customer.PickUpDay;
               


                db.SaveChanges();
                return RedirectToAction("Index", "User");
            }
            return View(customer);
        }

        public ActionResult OneTimePickUp()
        {

            string userId = User.Identity.GetUserId();
            Customer customer = db.Customers.FirstOrDefault(c => c.ApplicationId == userId);

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OneTimePickUp(Customer customer)
        {
            if (ModelState.IsValid)
            {
                Customer customerFromDb = db.Customers.FirstOrDefault(c => c.Id == customer.Id);
                customerFromDb.ForTheOneTime = customer.ForTheOneTime;

                db.SaveChanges();
                return RedirectToAction("Index", "User");
            }
            return View(customer);
        }

        public ActionResult CheckBalance()
        {

            string userId = User.Identity.GetUserId();
            Customer customer = db.Customers.FirstOrDefault(c => c.ApplicationId == userId);

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckBalance(Customer customer)
        {

            Customer customerFromDb = db.Customers.FirstOrDefault(c => c.Id == customer.Id);

            return View(customer);
        }

        public ActionResult PausePickUps()
        {

            string userId = User.Identity.GetUserId();
            Customer customer = db.Customers.FirstOrDefault(c => c.ApplicationId == userId);

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PausePickUps(Customer customer)
        {
            if (ModelState.IsValid)
            {
                Customer customerFromDb = db.Customers.FirstOrDefault(c => c.Id == customer.Id);
                customerFromDb.Start = customer.Start;
                customerFromDb.End = customer.End;

                db.SaveChanges();
                return RedirectToAction("Index", "User");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete()
        {

            string userId = User.Identity.GetUserId();
            Customer customer = db.Customers.FirstOrDefault(c => c.ApplicationId == userId);
            
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed()
        {
            string userId = User.Identity.GetUserId();
            Customer customer = db.Customers.FirstOrDefault(c => c.ApplicationId == userId);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index", "User");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
