using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Three.Models;

namespace MVC_Three.ViewModels
{
    public class NewFeedbackViewModel
    {
        public List<FeedbackType> feedbackTypes { get; set; }
        public Feedback feedback { get; set; }
    }
}