using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WellnessWaveHealth.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "First Name is required!!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required!!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required!!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email id is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Number is required!!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})", ErrorMessage = "Entered phone format is not valid.")]
        [DataType(DataType.PhoneNumber)]
        public long Phone { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} characters", MinimumLength = 8)]
        [RegularExpression(@"^([a-zA-Z0-9@*#]{8,15})$", ErrorMessage = "Password must contain: Minimum 8 characters")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter confirm password")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
    public class LogINModel
    {
        [Required(ErrorMessage = "Email is required!!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email id is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public class ForgotPassword
    {
        [Required(ErrorMessage = "Email is required!!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email id is not valid")]
        public string Email { get; set; }
    }
}