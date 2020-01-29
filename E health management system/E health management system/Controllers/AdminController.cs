using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BOL;
using DAL;

namespace E_health_management_system.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (AdminDAL.ValidateUser(username, password))
            {
                TempData["username"] = username;
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Username OR Password");
                return View();
            }
        }
    }
}