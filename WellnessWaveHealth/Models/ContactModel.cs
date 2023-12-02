using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WellnessWaveHealth.Models
{
    public class ContactModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public long? Phone { get; set; }
        public string Message { get; set; }
    }
}