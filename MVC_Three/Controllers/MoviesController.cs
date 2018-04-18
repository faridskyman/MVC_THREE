using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Three.Models;
using MVC_Three.ViewModels;


namespace MVC_Three.Controllers
{
    public class MoviesController : Controller
    {
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