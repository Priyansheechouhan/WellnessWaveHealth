using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccessLayer
{
    public class HospitalRepository
    {
        public List<string> GetHospital()
        {
            List<string> HospitalList = new List<string>();

            string connection = "Data Source=.;Initial Catalog=HealthcareProject;Integrated Security=sspi";
            SqlConnection connect = new SqlConnection(connection);
            SqlCommand command = new SqlCommand("SP_HOSPITAL", connect);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                connect.Open();
                SqlDataReader rd = command.ExecuteReader();
                while (rd.Read())
                {
                    HospitalList.Add(rd["HOSPITAL_NAME"].ToString());
                }
                rd.Close();
            }
            catch (Exception e)
            {

            }
            finally
            {
                if (connect.State == System.Data.ConnectionState.Open)
                {
                    connect.Close();
                }
            }
            return HospitalList;
        }
    }
}
