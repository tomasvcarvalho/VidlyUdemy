﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VidlySite.Models;
using System.Data.Entity;
using VidlySite.ViewModels;

namespace VidlySite.Controllers
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

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            
            
            
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else 
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //var mapper = new Mapper();
                //mapper.Map(customer, customerInDb);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }


        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customers/Details/{id}
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                id = 1;

            var selectedCustomer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (selectedCustomer == null)
                return new HttpNotFoundResult();

            return View(selectedCustomer);
        }

        public ActionResult Edit(int id) 
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}