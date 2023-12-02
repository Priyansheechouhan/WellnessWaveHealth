using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WellnessWaveHealth.Models;

namespace WellnessWaveHealth.List
{
    public class DoctorList
    {
        public List<DoctorModel> GetDoctorBySpeciality(int Speciality_Id)
        {
            List<DoctorModel> DoctorList = new List<DoctorModel>();
            try
            {
                string connection = "Data Source=.;Initial Catalog=HealthcareProject;Integrated Security=sspi";
                SqlConnection connect = new SqlConnection(connection);
                connect.Open();
                using (SqlCommand command = new SqlCommand("sp_select_doctor_by_speciality", connect))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@speciality_id", Speciality_Id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DoctorList.Add(new DoctorModel
                            {
                                Doctor_Id = Convert.ToInt32(reader["DOCTOR_ID"]),
                                Doctor_Name = reader["DOCTOR_NAME"].ToString(),
                                
                            });
                        }
                    }
                }
            }
            catch(Exception exc)
            {

            }
            
            return DoctorList;
        }

    }
}