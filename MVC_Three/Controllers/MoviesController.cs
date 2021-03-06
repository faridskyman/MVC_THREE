﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Three.Models;
using MVC_Three.ViewModels;
using System.Data.Entity;


namespace MVC_Three.Controllers
{
    public class MoviesController : Controller
    {
        //dbconnection setup
        private ApplicationDbContext _context;

        /// <summary>
        /// instantiate this object on load of this object
        /// this is the constructor
        /// </summary>
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        
        

        /// <summary>
        /// clean up and close connection to db after done
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ViewResult Index()
        {
            //var movies = _context.Movies.Include(m => m.Genre).ToList();
            //return View(movies);

            //only allow user with canModifyMovie to see list page
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            // dont need else as if match role already at list and if dont match will read last line.
            return View("ReadOnlyList");
        }
        
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var _genre = _context.Genres.ToList();

            var movieFormViewModel = new MovieFormViewModel()
            {
                movie = new Movie(),
                genre = _genre
            };
            return View("MovieForm", movieFormViewModel);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var moviefrmVMdl = new MovieFormViewModel()
                {
                    movie = new Movie(),
                    genre = _context.Genres.ToList()
                };
                return View("MovieForm", moviefrmVMdl);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                Movie _movieFromDB = _context.Movies.Single(m => m.Id == movie.Id);
                _movieFromDB.Name = movie.Name;
                _movieFromDB.NumberInStock = movie.NumberInStock;
                _movieFromDB.ReleasedDate = movie.ReleasedDate;
                _movieFromDB.GenreId = movie.GenreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }


        public ActionResult Edit(int Id)
        {
            var _movie = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (_movie == null)
                return HttpNotFound();

            MovieFormViewModel viewModel = new MovieFormViewModel()
            {
                movie = _movie,
                genre = _context.Genres.ToList()
            };

            return View("MovieForm",viewModel);
        }



        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Id = 1, Name = "Star Wars" };
            var customers = new List<Customer>
            {
                new Customer{ Name = "Customer 1" },
                new Customer{ Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //ViewData["Movie"] = movie; //this is one approach to passing object, but uses string and needs casting
            //ViewBag.Movie = movie; //this is an improved approach. but i do not get context .Name in view
            //return View(movie); // returns model

            return View(viewModel);

            #region Other action results examples

            //example sending movie as return value to view
            //return View(movie);


            //return Content("hello");

            // return HttpNotFound();  // 404 err pg

            //return new EmptyResult(); //blank page

            //return RedirectToAction("Index","Home"); //goes to home controller and index action

            // return RedirectToAction("Index", "Home", new { page = 1, sortby = "name" }); //with passing params
            // this directs to http://localhost:12788/?page=1&sortby=name 
            #endregion
        }

        //type 'mvcaction4' + [tab] to quickly generate this action
        //constraints that we can apply incl (min, max, minlength, maxlength, int, float, guid)
        // google "asp.net ,vc attribute route constraints" for more info.
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}