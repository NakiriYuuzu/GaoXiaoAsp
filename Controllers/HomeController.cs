using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FinalProjects.Models;
using GaoXiaoAsp.Models;

namespace GaoXiaoAsp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Room()
        {
            return View();
        }
        
        public ActionResult Rule()
        {
            return View();
        }
        public ActionResult RuleAudio()
        {
            return View();
        }
        public ActionResult RuleDiscussion()
        {
            return View();
        }
        public ActionResult RuleCarrel()
        {
            return View();
        }
    }
}