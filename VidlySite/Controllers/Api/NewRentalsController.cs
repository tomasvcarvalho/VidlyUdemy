using System;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using VidlySite.Dtos;
using VidlySite.Models;

namespace VidlySite.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;


        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/newrentals
        public IHttpActionResult GetNewRentals()
        {
            var rentals = _context.Rentals
                .Include(nr => nr.Customer)
                .Include(nr => nr.Movie)
                .ToList();

            return Ok(rentals);
        }

        // POST /api/newrentals
        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRentalDto)
        {

            if (newRentalDto.MovieIds.Count() == 0)
                return BadRequest("No Movie Ids have been given.");


            var customer = _context.Customers.SingleOrDefault(
                c => c.Id == newRentalDto.CustomerId);

            if (customer == null)
                return BadRequest("CustomerId is not valid.");

            var movies = _context.Movies
               .Where(m => newRentalDto.MovieIds.Contains(m.Id))
               .ToList();

            if (movies.Count() != newRentalDto.MovieIds.Count())
                return BadRequest("One or more MovieIds are invalid.");


            foreach (var movie in movies) 
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }

    }
}
