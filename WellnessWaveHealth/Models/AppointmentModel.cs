using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WellnessWaveHealth.Models
{
    public class AppointmentModel
    {
        public string Name { get; set; }
        public long? Phone { get; set; }
        public string Date { get; set; }
        public string Eamil { get; set; }
        public string Department { get; set; }
        public List<string> DepartmentList { get; set; }
        public string Doctor { get; set; }
        public List<string> DoctorList { get; set; }
        public string Message { get; set; }
    }
}