using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WellnessWaveHealth.Models
{
    public class EnquiryModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public long? Phone { get; set; }
        public string Remark { get; set; }
        public string Doctor { get; set; }
        public List<string> DoctorList { get; set; }
        public bool isActive { get; set; }
    }
}