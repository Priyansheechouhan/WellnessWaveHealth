using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WellnessWaveHealth.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Enquiry()
        {
            //RegistrationModel obj1 = new RegistrationModel();
            //DoctorRepository obj2 = new DoctorRepository();
            //obj1.DoctorList = obj2.GetDoctor();

            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult Appointment()
        {
            return View();
        }

    }
}