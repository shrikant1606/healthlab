using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using DAL;

namespace E_Health.Controllers
{
    public class PharmacyController : Controller
    {
        // GET: PharmacyRegistration
        public ActionResult Index()
        {
            return View();
        }

        // GET: PharmacyRegistration/Details/5
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
            if (PharmacyDAL.ValidateUser(username,password))
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

        public ActionResult PatientPrescription()
        {
            List<Prescription> prescriptions = new List<Prescription>();
            prescriptions = PharmacyDAL.GetAll();
            return View(prescriptions);
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
            Pharmacy pharmacy = new Pharmacy();

            TryUpdateModel(pharmacy);
            if (ModelState.IsValid)
            {
                if (PharmacyDAL.Insert(pharmacy))
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
