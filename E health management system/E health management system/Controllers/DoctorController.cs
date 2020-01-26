using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using DAL;

namespace E_health.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult PatientAppointment()
        {
            List<Appointment> patientsList = new List<Appointment>();
            patientsList = AppointmentDAL.GetAll();
            return View(patientsList);
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
            Doctor doctor = new Doctor();
            
            TryUpdateModel(doctor);
            if (ModelState.IsValid)
            {
                DoctorDAL.Insert(doctor);
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }
        //GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (DoctorDAL.ValidateUser(username, password))
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
        
        public ActionResult Search()
        {
            return View();
        }
      
        public ActionResult Details(int appointmentid, string firstName,string lastName, string timeslot, string date)
        {
            TempData["appointmentid"] = appointmentid;
            TempData["firstname"] = firstName;
            TempData["lastname"] = lastName;
            TempData["timeslot"] = timeslot;
            TempData["date"] = date;
            Patient patient = PatientDAL.PatientDetail(firstName,lastName);
            return View(patient);
        }

        [HttpGet]
        [ActionName("CreatePrescription")]
        public ActionResult CreatePrescription_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("CreatePrescription")]
        public ActionResult CreatePrescription_Post(string pfirstname, string plastname, string date, string timeslot)
        {    // Retrieve form data using form collection 
            Doctor doctor = new Doctor();
            
            TryUpdateModel(doctor);
            if (ModelState.IsValid)
            {
                DoctorDAL.Insert(doctor);
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }
    }
}
