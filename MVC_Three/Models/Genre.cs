using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Three.Models
{
    public class Genre
    {
        public Byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}