using MVC_Three.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Three.Controllers
{
    public class AuditController : Controller
    {
        private ApplicationDbContext _context;

        public AuditController()
        {
            _context = new ApplicationDbContext();
        }

        // close connecction to db
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public bool AddAudit(int auditEvent, string addInfo, string userid)
        {
            Audit au = new Audit();
            au.AuditEventId = auditEvent;
            au.AdditionalInfo = addInfo;
            au.UserID = userid;
            au.DateAdded = DateTime.Now;

            _context.Audits.Add(au);
            _context.SaveChanges();
            return true;
        }


    }
}
 