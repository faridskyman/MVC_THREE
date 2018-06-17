using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Three.Models
{
    public class FeedbackType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } // name of the feedbck type
        public string ManagedBy { get; set; } //managed by
        public string ManagedByEmail { get; set; } //email of geoup that should get this type of feedback

        // values to be used in form or logic i think.
        public static readonly int General = 1;
        public static readonly int MobileApp = 2;
        public static readonly int WebApp = 3;
        public static readonly int Products = 4;


    }
}