using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Three.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        public FeedbackType FeedbackType { get; set; }

        [Required]
        [Range(1,5,ErrorMessage = "Allowed range is between 1 to 5 only")]
        public int FeedbackTypeId { get; set; }

        [Required]
        public String Description { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime DateAdded { get; set; }

    }
}