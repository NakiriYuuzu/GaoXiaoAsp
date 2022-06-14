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
    public class AdminController : Controller
    {
        LibraryEntity entity = new LibraryEntity();
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(LoginViewModel signIn)
        {
            bool isExist = entity.Librarians.Any(u => u.Email == signIn.Email && u.Password == signIn.Password);
            Librarian librarian = entity.Librarians.FirstOrDefault(u => u.Email == signIn.Email && u.Password == signIn.Password);

            if (isExist)
            {
                FormsAuthentication.SetAuthCookie(librarian.Name, false);
                TempData["SignIn"] = "admin";
                Session["user"] = "admin";
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Username or Password incorrect");
            TempData["SignInError"] = "SignIn Error";
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session["user"] = null;
            TempData["SignOut"] = "SignOut Success!";
            return RedirectToAction("SignIn");
        }
    }
}