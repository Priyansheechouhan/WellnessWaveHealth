using DataBaseAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WellnessWaveHealth.Models;

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
            DoctorRepository oDoctorRepository = new DoctorRepository();
            EnquiryModel oEnquiryModel = new EnquiryModel();
            oEnquiryModel.DoctorList = oDoctorRepository.GetDoctor();
            return View(oEnquiryModel);
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult Appointment()
        {
            return View();
        }
        public ActionResult Feedback()
        {
            DepartmentRepository oDepartmentRepository = new DepartmentRepository();
            HospitalRepository oHospitalRepository = new HospitalRepository();
            FeedbackModel oFeedbackModel = new FeedbackModel();
            oFeedbackModel.DepartmentList = oDepartmentRepository.GetDepartment();
            oFeedbackModel.HospitalList = oHospitalRepository.GetHospital();
            return View(oFeedbackModel);
        }
    }
}