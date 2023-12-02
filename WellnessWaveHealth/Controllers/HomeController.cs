using DataBaseAccessLayer;
using EmailHelper;
using SMSHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WellnessWaveHealth.List;
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
        [HttpPost]
        public ActionResult Enquiry(string Name,string Email,long Phone,string Doctor,string Remark)
        {
            ViewBag.returnStatus = null;
            ViewBag.returnmessage = null;
            DoctorRepository oDoctorRepository = new DoctorRepository();
            EnquiryModel oEnquiryModel = new EnquiryModel();
            oEnquiryModel.DoctorList = oDoctorRepository.GetDoctor();

            EnquiryRepository oEnquiryRepository = new EnquiryRepository();
            bool insertStatus = oEnquiryRepository.InsertDetails(Name, Email, Phone, Doctor, Remark);
            if (insertStatus == true)
            {
                string Enquirymsg = "Enquiry Submited Successfully.";
                EmailManager oEmailManager = new EmailManager();
                bool EmailStatus = oEmailManager.SendEnquiryConfirmation(Email, Enquirymsg);

                SMSManager oSMSManager = new SMSManager();
                oSMSManager.GetSMS(Phone); 

                if (EmailStatus == true)
                {
                    ViewBag.returnStatus = "Your Enquiry has been submited...";
                    ViewBag.returnmessage = "Thanks for coming to our website and make an enquiry";
                }
                else
                {
                    ViewBag.returnStatus = "Sending email is failed";

                }
            }
            else
            {
                ViewBag.returnStatus = "Sorry there is problem";
            }
            
            return View(oEnquiryModel);
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult Appointment()
        {
            //List<State> states = GetStates();
            //ViewBag.States = new SelectList(states, "Id", "Name");
            SpecialityList oSpecialityList = new SpecialityList();
            List<SpecialitiesModel> specialities = oSpecialityList.GetSpecialzationList();
            ViewBag.specialities = new SelectList(specialities, "speciality_id", "specialities");

            return View();
        }
        [HttpPost]
        public ActionResult Appointment(string Name,string Email,string speciality,long Phone,string Date,string Doctor,string Message)
        {
            //List<State> states = GetStates();
            //ViewBag.States = new SelectList(states, "Id", "Name");
            SpecialityList oSpecialityList = new SpecialityList();
            List<SpecialitiesModel> specialities = oSpecialityList.GetSpecialzationList();
            ViewBag.specialities = new SelectList(specialities, "speciality_id", "specialities");

            return View();
        }
        public ActionResult GetDoctor(int Speciality_Id)
        {

            DoctorList oDoctorList = new DoctorList();
            List<DoctorModel> doctor = oDoctorList.GetDoctorBySpeciality(Speciality_Id);
            ViewBag.Doctor = new SelectList(doctor, "Doctor_Id", "Doctor_Name");
            return PartialView("DisplayDoctor");
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
        [HttpPost]
        public ActionResult Feedback(string Name,string Email, long Phone,string Date,string HospitalName,string Department,string Suggestion)
        {
            DepartmentRepository oDepartmentRepository = new DepartmentRepository();
            HospitalRepository oHospitalRepository = new HospitalRepository();
            FeedbackModel oFeedbackModel = new FeedbackModel();
            oFeedbackModel.DepartmentList = oDepartmentRepository.GetDepartment();
            oFeedbackModel.HospitalList = oHospitalRepository.GetHospital();

            FeedbackRepository oFeedbackRepository = new FeedbackRepository();
            bool FeedbackStatus = oFeedbackRepository.InsertFeedbackDetails(Name, Email, Phone, Date, HospitalName, Department, Suggestion);
            ViewBag.FStatus = null;
            if (FeedbackStatus == true)
            {
                string Feedbackmsg = "Feedback Submited Successfully.";
                EmailManager oEmailManager = new EmailManager();
                bool EmailStatus = oEmailManager.SendEnquiryConfirmation(Email, Feedbackmsg);
                ViewBag.FStatus = "Your Feedback has been submited.";
                ViewBag.FstatusP = "Thank you for visiting us and giving the Feedback";
            }
            else
            {
                ViewBag.FStatus = "Sorry there is a Problem!!!";
            }

            ModelState.Clear();
            return View(oFeedbackModel);
        }

    }
}