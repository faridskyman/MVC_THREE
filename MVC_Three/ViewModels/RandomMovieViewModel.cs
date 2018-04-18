using MVC_Three.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Three.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}