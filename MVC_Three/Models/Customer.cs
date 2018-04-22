using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Three.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required] /*make column name non nullable*/
        [StringLength(255)] /*limit string length*/
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        /*navi prop, to load an obj and its related obj from db*/
        public MembershipType MembershipType { get; set; }
        
        //foreign key to MembershipType table.
        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }

        //add birthdate
        [Display(Name="Date of birth")]
        public DateTime? BirthDate { get; set; }
    }
}