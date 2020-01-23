using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using DAL;

namespace E_Health.Controllers
{
    public class PatientController : Controller
    {
        // GET: PatientRegistration
        public ActionResult Index()
        {
            return View();
        }

        // GET: PatientRegistration/Details/5
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
            if (PatientDAL.ValidateUser(username,password))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Username OR Password");
                return View();
            }
        }

        // GET: PatientRegistration/Create
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        // POST: PatientRegistration/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post(FormCollection collection)
        {
            Patient patient = new Patient();

            TryUpdateModel(patient);
            if (ModelState.IsValid)
            {
                PatientDAL.Insert(patient);
                return RedirectToAction("Create");

            }
            else
            {
                return View();
            }
        }

        
    }
}
