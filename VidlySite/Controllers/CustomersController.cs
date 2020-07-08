using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlySite.Models;
using VidlySite.ViewModels;

namespace VidlySite.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Customer>()
            {
                new Customer(){ Id = 1, Name = "John Smith" },
                new Customer(){ Id = 1, Name = "Mary Williams" }
            };

            var viewModel = new IndexCustomerViewModel()
            {
                Customers = customers
            };
            
            return View(viewModel);
        }
    }
}