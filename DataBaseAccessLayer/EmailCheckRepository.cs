using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccessLayer
{
    public class EmailCheckRepository
    {
        public bool CheckEmail(string UserEmail)
        {
            string Email = null;
            bool status = false;
            string connection = "Data Source=.;Initial Catalog=HealthcareProject;Integrated Security=sspi";
            SqlConnection connect = new SqlConnection(connection);
            SqlCommand command = new SqlCommand("SELECT EMAIL FROM TBL_SIGNUP", connect);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                connect.Open();
                SqlDataReader rd = command.ExecuteReader();
                while (rd.Read())
                {
                    //Email = Add(rd["EMAIL"].ToString());
                    Email = Convert.ToString(rd["EMAIL"]);
                    if (Email == UserEmail)
                    {
                        status = true;
                    }
                }
                rd.Close();
            }
            catch (Exception e)
            {
                status = false;
            }
            return status;
        }
    }
}
