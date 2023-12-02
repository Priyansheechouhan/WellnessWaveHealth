using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WellnessWaveHealth.Models
{
    public class DoctorModel
    {
        public int Doctor_Id { get; set; }
        public string  Doctor_Name { get; set; }
        public int Speciality_Id { get; set; }
    }
}