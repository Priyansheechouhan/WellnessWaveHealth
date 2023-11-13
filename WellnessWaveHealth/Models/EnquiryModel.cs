using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WellnessWaveHealth.Models
{
    public class EnquiryModel
    {
        public string Username { get; set; }
        public string UserEmail { get; set; }
        public long? ContactNumber { get; set; }
        public string UserRemark { get; set; }
        public string DoctorName { get; set; }
        public List<string> DoctorList { get; set; }
        public bool isActive { get; set; }
    }
}