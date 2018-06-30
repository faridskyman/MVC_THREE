using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Three.Models
{
    public class Audit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AuditEventId { get; set; }

        public String AdditionalInfo { get; set; }

        [Required]
        public string UserID { get; set; }

        public DateTime DateAdded { get; set; }
    }

    public static class AuditEvents
    {
        public enum Events
        {
            AddFeedback = 1,
            ViewFeedbackList = 2
        }
    }
}