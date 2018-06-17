using MVC_Three.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Three.ViewModels;
using System.Data.Entity;
namespace MVC_Three.Controllers
{
    [AllowAnonymous]
    public class FeedbackController : Controller
    {
        //db conn
        private ApplicationDbContext _context;

        // init db context for feedback constructor
        public FeedbackController()
        {
            _context = new ApplicationDbContext();
        }

        // close connecction to db
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Feedback, show list of feedback
        public ActionResult Index()
        {
            return View(GetFeedbacks());
        }

        private IEnumerable<Feedback> GetFeedbacks()
        {
            var feedbacks = _context.Feedbacks.Include(c => c.FeedbackType).OrderByDescending(c => c.DateAdded).ToList();
            return feedbacks;
        }

        /// <summary>
        /// befor loading new feedback form, this is the pre-req step to prep models for the new fb form
        /// </summary>
        /// <returns></returns>
        public ActionResult New()
        {
            var _feedbackType = _context.feedbackTypes.ToList(); //get all records from fb-type
            var viewModel = new NewFeedbackViewModel
            {
                feedback = new Feedback(),
                feedbackTypes = _feedbackType
            };
            return View(viewName: "FeedbackForm", model: viewModel);
        }

       

        [HttpPost]
        public ActionResult Save(NewFeedbackViewModel nfvmodel)
        {
            Feedback _feedback = nfvmodel.feedback;
            _feedback.DateAdded = DateTime.Now;

            if(!ModelState.IsValid)
            {
                var feedbackViewModel = new NewFeedbackViewModel
                {
                    feedback = _feedback,
                    feedbackTypes = _context.feedbackTypes.ToList()
                };
                return View(viewName: "FeedbackForm", model: feedbackViewModel);
            }

            if (_feedback.Id == 0)
                _context.Feedbacks.Add(_feedback);
            else
            {
                // no action for handling editing a feedback for now.
            }

            _context.SaveChanges();

            return RedirectToAction(actionName: "Index", controllerName: "Feedback");
        }
    }
}