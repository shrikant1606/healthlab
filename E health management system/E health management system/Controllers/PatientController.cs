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
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ListDoctors()
        {
            List<Doctor> doctorList = new List<Doctor>();
            doctorList = DoctorDAL.GetAll();
            return View(doctorList);
        }

        // GET: Patient/Details/5
        public ActionResult Details(string name)
        {
            Doctor doctor = DoctorDAL.Get(name);
            return View(doctor);
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

        // GET: Patient/Create
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        // POST: Patient/Create
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

        // GET: Patient/BookAppointment 
        [ActionName("BookAppointment")]
        public ActionResult BookAppointment_Get(string dname)
        {
            return View(dname);
        }

        // POST: Patient/Create
        [HttpPost]
        [ActionName("BookAppointment")]
        public ActionResult BookAppointment_Post(FormCollection collection)
        {
            Appointment appointment = new Appointment();

            TryUpdateModel(appointment);
            if (ModelState.IsValid)
            {
                appointment.Dinfoid = 0;
                appointment.Pinfoid = 0;
                appointment.Status = 0;
                AppointmentDAL.BookAppointment(appointment);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult History()
        {
            int patientid = 0;
            List<Appointment> history = new List<Appointment>();
            history = AppointmentDAL.History(patientid);
            return View(history);
        }
    }
}
