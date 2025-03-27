using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBSLoginApp.DAL;
namespace DBSLoginApp.Controllers
{
    public class AccountController : Controller
    {
        UserDAL userDAL = new UserDAL();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (userDAL.ValidateUser(username, password))
            {
                Session["Username"] = username;
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View();
            }
        }

        // GET: Dashboard
        public ActionResult Dashboard()
        {
            if (Session["Username"] != null)
            {
                ViewBag.Username = Session["Username"].ToString();
                return View();
            }
            return RedirectToAction("Login");
        }

        // Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

    }
}