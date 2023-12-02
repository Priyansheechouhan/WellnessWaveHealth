using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WellnessWaveHealth.Models;

namespace WellnessWaveHealth.List
{
    public class SpecialityList
    {

        public List<SpecialitiesModel> GetSpecialzationList()
        {
            List<SpecialitiesModel> SpecializationList = new List<SpecialitiesModel>();

            string connection = "Data Source=.;Initial Catalog=HealthcareProject;Integrated Security=sspi";
            SqlConnection connect = new SqlConnection(connection);
            SqlCommand command = new SqlCommand("select speciality_id,specialities from tbl_Specialization", connect);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                connect.Open();
                SqlDataReader rd = command.ExecuteReader();
                while (rd.Read())
                {
                    SpecializationList.Add(new SpecialitiesModel
                    {
                        Speciality_Id = Convert.ToInt32(rd["speciality_id"]),
                        Specialities = rd["specialities"].ToString()
                    });


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
            return SpecializationList;
        }
    }
}