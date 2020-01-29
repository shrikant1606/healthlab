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
        
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post(FormCollection collection)
        {    // Retrieve form data using form collection 
            Doctor doctor = new Doctor();
            
            TryUpdateModel(doctor);
            if (ModelState.IsValid)
            {
                if (DoctorDAL.Insert(doctor))
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
        
        public ActionResult AppointmentSummary()
        {
            return View();
        }

        public ActionResult PatientAppointment(string date)
        {
            string username = TempData["username"].ToString();
            TempData.Keep();
            if (ModelState.IsValid)
            {
                List<Appointment> patientsList = new List<Appointment>();
                patientsList = AppointmentDAL.GetAll(username,date);
                return View(patientsList);
            }
            else
            {
                ModelState.AddModelError("", "Enter valid date..!!");
                return View();
            } 
        }
        
        public ActionResult Search()
        {
            return View();
        }
        
        public ActionResult Details(string firstName,string lastName, string timeslot, string date)
        {
            if (ModelState.IsValid)
            {
                List<Patient> patientList = new List<Patient>();
                patientList = PatientDAL.PatientDetail(firstName, lastName);
                return View(patientList);
            }
            else
            {
                ModelState.AddModelError("", "Enter valid Patient Name..!!");
                return View();
            }
        }
        
        [HttpGet]
        [ActionName("CreatePrescription")]
        public ActionResult CreatePrescription_Get()
        {
            return View();
        }
        
        [HttpPost]
        [ActionName("CreatePrescription")]
        public ActionResult CreatePrescription_Post()
        {    // Retrieve form data using form collection 
            
            Prescription prescription = new Prescription();
            prescription.Appointmentid = int.Parse(TempData["appointmentid"].ToString());
            prescription.Dusername = TempData["username"].ToString();
            TempData.Keep();
            prescription.Pfirstname = TempData["firstname"].ToString();
            prescription.Plastname = TempData["lastname"].ToString();
            prescription.Timeslot = TempData["timeslot"].ToString();
            prescription.Date = TempData["date"].ToString();

            TryUpdateModel(prescription);
            if (ModelState.IsValid)
            {
                PrescriptionDAL.CreatePrescription(prescription);
                return RedirectToAction("Index","Doctor");
            }
            else
            {
                return View();
            }
        }
        
        [HttpGet]
        [ActionName("UpdateTime")]
        public ActionResult UpdateTime_Get()
        {
            return View();
        }
        
        [HttpPost]
        [ActionName("UpdateTime")]
        public ActionResult UpdateTime_Post(string checkin, string checkout)
        {    // Retrieve form data using form collection 
            string username = TempData["username"].ToString();
            TempData.Keep();
            if (ModelState.IsValid)
            {
                DoctorDAL.UpdateTime(username, checkin, checkout);
                return RedirectToAction("Index", "Doctor");
            }
            else
            {
                return View();
            }
        }
    }
}
