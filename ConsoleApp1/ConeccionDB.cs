
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAM.OOP
{
    public class Coneccion_DB
    {
        private string connectionString = "Data Source=UAM-HD-LBPF2-14;Initial Catalog=Progra3;User ID=UserP3;Password=5480593";
        public void ConexionSQLNoQuery(string sql)
        {
            SqlConnection cnn;
           SqlCommand cmd;
           

            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();
                //SqlDataReader resultado = cmd.ExecuteReader();
                cmd.Dispose();
                Console.WriteLine(" ExecuteNonQuery in SqlCommand executed !!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! " + ex.Message);
            }
            // Closing the connection  
            finally
            {
                cnn.Close();
            }
        }
        public void ConexionADO()
        {
            try
            {
                string querystring = "Select * from Items";
                SqlDataAdapter adapter = new SqlDataAdapter(querystring, connectionString);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Items");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! " + ex.Message);
            }
        }
    }

    
}

namespace UAM.OOP
{
    class SqlDataAdapter
    {
    }
}