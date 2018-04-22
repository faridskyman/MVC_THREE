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


        
        public Genre Genre { get; set; } /*navi prop to genre*/

        [Required]
        [Display(Name ="Genre")]
        public Byte GenreId { get; set; } /* foreign key */

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name="Release Date")]
        public DateTime ReleasedDate { get; set; }

        [Display(Name="No. in stock")]
        public byte NumberInStock { get; set; }

 


    }
}