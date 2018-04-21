using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Three.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        [Required]
        public Genre Genre { get; set; } /*navi prop to genre*/
        public Byte GenreId { get; set; } /* foreign key */


        public DateTime DateAdded { get; set; }

        public DateTime ReleasedDate { get; set; }

        public byte NumberInStock { get; set; }

 


    }
}