using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccessLayer
{
    public class LogInValidation
    {
        public bool CheckUserForLogin(string UserEmail,string Password)
        {
            string Email = null;
            string Pass = null;
            bool status = false;
            string connection = "Data Source=.;Initial Catalog=HealthcareProject;Integrated Security=sspi";
            SqlConnection connect = new SqlConnection(connection);
            SqlCommand command = new SqlCommand("select * from TBL_SIGNUP", connect);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                connect.Open();
                SqlDataReader rd = command.ExecuteReader();
                while (rd.Read())
                {
                    //Email = Add(rd["EMAIL"].ToString());
                    Email = Convert.ToString(rd["EMAIL"]);
                    Pass = Convert.ToString(rd["PASSWORD"]);
                    if(Email== UserEmail && Pass== Password)
                    {
                        status = true;
                        break;
                    }
                    else
                    {
                        status = false;
                    }
                    
                }
                rd.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                if (connect.State == System.Data.ConnectionState.Open)
                {
                    connect.Close();
                }
            }

            return status;
        }
    }
}
