using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using FinalProjects.Models;
using GaoXiaoAsp.Models;

namespace GaoXiaoAsp.Controllers
{
    public class AccountController : Controller
    {
        LibraryEntity entity = new LibraryEntity();
        // GET: Account
        public ActionResult SignIn()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(LoginViewModel signIn, string returnUrl)
        {
            bool isExist = entity.Users.Any(u => u.Email == signIn.Email && u.Password == signIn.Password);
            User user = entity.Users.FirstOrDefault(u => u.Email == signIn.Email && u.Password == signIn.Password);

            Console.WriteLine(returnUrl);
            if (isExist)
            {
                FormsAuthentication.SetAuthCookie(user.Name, false);
                TempData["SignIn"] = "user";
                Session["user"] = "user";
                if (returnUrl != null)
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            
            ModelState.AddModelError("", "Username or Password incorrect");
            TempData["SignInError"] = "SignIn Error";
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            int uid = entity.Users.Count() + 1;
            user.Uid = uid;
            entity.Users.Add(user);
            entity.SaveChanges();
            
            TempData["SignUp"] = "SignUp Success!";

            return RedirectToAction("SignIn");
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