using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccessLayer
{
    public class DepartmentRepository
    {
        public List<string> GetDepartment()
        {
            List<string> DepartmentList = new List<string>();

            string connection = "Data Source=.;Initial Catalog=HealthcareProject;Integrated Security=sspi";
            SqlConnection connect = new SqlConnection(connection);
            SqlCommand command = new SqlCommand("SP_DEPARTMENT", connect);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                connect.Open();
                SqlDataReader rd = command.ExecuteReader();
                while (rd.Read())
                {
                    DepartmentList.Add(rd["DEPARTMENT_NAME"].ToString());
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
            return DepartmentList;
        }
    }
}
