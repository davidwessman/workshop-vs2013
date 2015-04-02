using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verkstadsprogram_2014
{
    class DatabasConnection
    {
        public static SqlConnection GetConnection()
        {
            try{
            SqlConnection kunddatabas = new SqlConnection();
            kunddatabas.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Verkstadsprogram_2014.Properties.Settings.Database1ConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand("Select * FROM Kunder WHERE customerID = 14001");
            SqlDataReader reader = cmd.ExecuteReader();
            Customer testets;
            while (reader.Read())
            {
                
            }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
