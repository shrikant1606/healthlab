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
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (LaboratoryDAL.ValidateUser(username,password))
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
                if (LaboratoryDAL.Insert(laboratory))
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Username already exists");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Details(string firstName, string lastName)
        {
            TempData["pfirstname"] = firstName;
            TempData["plastname"] = lastName;
            if (ModelState.IsValid)
            {
                List<Prescription> prescriptions = new List<Prescription>();
                prescriptions = PrescriptionDAL.GetPrescriptions(firstName, lastName);
                return View(prescriptions);
            }
            else
            {
                ModelState.AddModelError("", "Enter valid Patient Name..!!");
                return View();
            }
        }
    }
}
