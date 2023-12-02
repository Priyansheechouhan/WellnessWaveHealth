using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccessLayer
{
    public class FeedbackRepository
    {
        public bool InsertFeedbackDetails(string Name, string Email, long Phone, string Date, string HospitalName, string Department, string Suggestion)
        {
            try
            {

                string connectionstring = "Data Source=.;Initial Catalog=HealthcareProject;Integrated Security=sspi";
                SqlConnection connection1 = new SqlConnection(connectionstring);
                string query = "sp_insert_into_feedback";
                SqlCommand cmd = new SqlCommand(query, connection1);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@contact", Phone);
                cmd.Parameters.AddWithValue("@email", Email);
                cmd.Parameters.AddWithValue("@department", Department);
                cmd.Parameters.AddWithValue("@HName", HospitalName);
                cmd.Parameters.AddWithValue("@date", Date);
                cmd.Parameters.AddWithValue("@suggestion", Suggestion);

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
