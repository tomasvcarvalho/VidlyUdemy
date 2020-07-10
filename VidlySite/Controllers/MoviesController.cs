using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VidlySite.Models;
using VidlySite.ViewModels;
using System.Data.Entity;

namespace VidlySite.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) 
        {
            _context.Dispose();
        }

        // GET: Movies/
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
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

        // GET: Movies/Details/{id}
        [Route("movies/details/{id}")]
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                id = 1;

            var selectedMovie = _context.Movies.Include(m => m.Genre).SingleOrDefault(c => c.Id == id);

            if (selectedMovie == null)
                return new HttpNotFoundResult();

            return View(selectedMovie);
        }
    }
}