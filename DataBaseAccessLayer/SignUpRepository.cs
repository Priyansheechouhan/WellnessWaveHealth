using EmailHelper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccessLayer
{
    public class SignUpRepository
    {
        public bool InsertSignUpDetails(string FirstName, string LastName, string Email, long Phone, string Password, string ConfirmPassword)
        {
            bool Status = false;
            try
            {

                string connectionstring = "Data Source=.;Initial Catalog=HealthcareProject;Integrated Security=sspi";
                SqlConnection connection1 = new SqlConnection(connectionstring);
                string query = "SP_INSERT_SIGNUPDETAILS";
                SqlCommand cmd = new SqlCommand(query, connection1);
                cmd.Parameters.AddWithValue("@FNAME", FirstName);
                cmd.Parameters.AddWithValue("@LNAME", LastName);
                cmd.Parameters.AddWithValue("@EMAIL", Email);
                cmd.Parameters.AddWithValue("@PHONE", Phone);
                cmd.Parameters.AddWithValue("@PASSWORD", Password);
                cmd.Parameters.AddWithValue("@CPASSWORD", ConfirmPassword);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection1.Open();
                int result = cmd.ExecuteNonQuery();
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
