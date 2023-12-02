﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccessLayer
{
    public class EnquiryRepository
    {
        public bool InsertDetails(string Username, string UserEmail, long ContactNumber, string DoctorName, string UserRemark)
        {
            try
            {
                
                string connectionstring = "Data Source=.;Initial Catalog=HealthcareProject;Integrated Security=sspi";
                SqlConnection connection1 = new SqlConnection(connectionstring);
                string query = "Insert_userdetails";
                SqlCommand cmd = new SqlCommand(query, connection1);
                cmd.Parameters.AddWithValue("@USER_NAME", Username);
                cmd.Parameters.AddWithValue("@USER_EMAIL", UserEmail);
                cmd.Parameters.AddWithValue("@USER_CONTACT_NUMBER", ContactNumber);
                cmd.Parameters.AddWithValue("@USER_REMARK", UserRemark);
                cmd.Parameters.AddWithValue("@DOCTOR_NAME", DoctorName);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection1.Open();
                int result=cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception execp)
            {
                return false;
            }

        }
    }
}
