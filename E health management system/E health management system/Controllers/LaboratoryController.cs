using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using DAL;

namespace E_Health.Controllers
{
    public class LaboratoryController : Controller
    {
        // GET: LaboratoryRegistration
        public ActionResult Index()
        {
            return View();
        }

        // GET: LaboratoryRegistration/Details/5
        public ActionResult Details(int id)
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
            if (LaboratoryDAL.ValidateUser(username,password))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Username OR Password");
                return View();
            }
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {    // Retrieve form data using form collection 
            Laboratory laboratory = new Laboratory();

            TryUpdateModel(laboratory);
            if (ModelState.IsValid)
            {
                LaboratoryDAL.Insert(laboratory);
                return RedirectToAction("Create");

            }
            else
            {
                return View();
            }


        }
    }
}
