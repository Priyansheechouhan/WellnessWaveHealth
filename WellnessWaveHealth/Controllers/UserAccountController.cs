using DataBaseAccessLayer;
using EmailHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WellnessWaveHealth.Models;
using System.Web.Security;
using System.Data.SqlClient;

namespace WellnessWaveHealth.Controllers
{
    public class UserAccountController : Controller
    {
        // GET: UserAccount
        public ActionResult SignUp()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(string FirstName,string LastName,string Email,long Phone,string Password,string ConfirmPassword)
        {
            SignUpRepository oSignUpRepository = new SignUpRepository();
            bool SignUpResult = oSignUpRepository.InsertSignUpDetails(FirstName, LastName, Email, Phone, Password, ConfirmPassword);
            if (SignUpResult == true)
            {
                string Signupmessage = "You are Registered Successfully.Thanks for visiting us";
                EmailManager oEmailManager = new EmailManager();
                bool EmailStatus = oEmailManager.SendEnquiryConfirmation(Email, Signupmessage);
                if (EmailStatus == true)
                {
                    ViewBag.status = "Successfully Registered.";
                }
                else
                {
                    ViewBag.status = "You are Registered successfully but there is problem in sending email please check your email..";
                }
                return RedirectToAction("LogIN");
            }
            else
            {
                ViewBag.status = "Sorry there us problem!!!";
                return View();
            }
            
        }
        [AllowAnonymous]
        public ActionResult LogIN(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIN(LogINModel oLogIn)
        {
            LogInValidation oLogInValidation = new LogInValidation();
            if (ModelState.IsValid)
            {
                bool IsValid = oLogInValidation.CheckUserForLogin(oLogIn.Email, oLogIn.Password);
                if (IsValid)
                {
                    FormsAuthentication.SetAuthCookie(oLogIn.Email, false);
                    return RedirectToAction("Index","User");
                }
                else
                {
                    ModelState.AddModelError("", "Email and password are not valid please check");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(ForgotPassword oforgotpass)
        {
            EmailCheckRepository oEmailCheckRepository = new EmailCheckRepository();
            bool EmailValidation = oEmailCheckRepository.CheckEmail(oforgotpass.Email);
            if (EmailValidation)
            {
                string myGUID = Guid.NewGuid().ToString();

            }
            return View();
        }
    }

    
}