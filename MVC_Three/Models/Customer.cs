using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Three.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        /*navi prop, to load an obj and its related obj from db*/
        public MembershipType MembershipType { get; set; }
        //foreign key to MembershipType table.
        public byte MembershipTypeId { get; set; }
    }
}