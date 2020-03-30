using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_new.Models;
using Vidly_new.ViewModels;

namespace Vidly_new.Controllers
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

        [Route("movies/random")]
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Avengers !" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Shubham"},
                new Customer { Name = "Ankit"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //--------------------These two methods are not good for use, 
            //--------------------coz once we change the string here, we need to change the name in VIEW also.
            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;

            return View(viewModel);

            //--------------Other things that we can return, these are the the sub types of ActionResult
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        [Route("Movies")]
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);

        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }

        public ActionResult New()
        {
            var genreTypes = _context.GenreTypes.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genre = genreTypes
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if(movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();
            
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genre = _context.GenreTypes.ToList()
            };

            return View("MovieForm", viewModel);
        }

        /* public ActionResult index(int? pageIndex, string sortBy)
         {
             if (!pageIndex.HasValue)
                 pageIndex = 1;

             if (String.IsNullOrWhiteSpace(sortBy))
                 sortBy = "Name";

             return Content(String.Format("pageIndex = {0} && sortBy = {1}", pageIndex, sortBy));
         }*/

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content("month = " + month + " && year = " + year);
        }
    }
}