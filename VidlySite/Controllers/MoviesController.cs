using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlySite.Models;
using VidlySite.ViewModels;

namespace VidlySite.Controllers
{
    public class MoviesController : Controller
    {

        // GET: Movies/
        public ActionResult Index()
        {
            var movies = new List<Movie>()
            {
                new Movie() { Id = 1,  Name = "Shrek" },
                new Movie() { Id = 2,  Name = "Wall-e" }
            };
            var viewModel = new IndexMovieViewModel()
            {
                Movies = movies
            };
            return View(viewModel);
        }


        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };
            var viewModel  = new RandomMovieViewModel() 
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);

        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}