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
    [Authorize]
    public class HomeController : Controller
    {
        LibraryEntity enity = new LibraryEntity();
        // GET: Home
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        
        [AllowAnonymous]
        public ActionResult Room()
        {
            return View();
        }
        
        [AllowAnonymous]
        public ActionResult Rule()
        {
            return View();
        }
    }
}