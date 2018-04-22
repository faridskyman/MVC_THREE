using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Three.Models;

namespace MVC_Three.ViewModels
{
    public class CustomerFormVideoModel
    {
        public List<MembershipType> membershipTypes{ get; set; }
        public Customer Customer { get; set; }

    }
}