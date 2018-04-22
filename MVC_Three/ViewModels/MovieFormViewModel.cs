using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Three.Models;

namespace MVC_Three.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie movie{ get; set; }
        public List<Genre> genre { get; set; }
    }
}