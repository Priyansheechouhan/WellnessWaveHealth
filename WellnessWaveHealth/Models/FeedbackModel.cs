using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WellnessWaveHealth.Models
{
    public class FeedbackModel
    {
        public string Name { get; set; }
        public long? Phone { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
        public string Department { get; set; }
        public string HospitalName { get; set; }
        public string Suggestion { get; set; }
        public List<string> DepartmentList { get; set; }
        public List<string> HospitalList { get; set; }
    }
}