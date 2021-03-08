using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;


namespace MSSwindow.Connection
{
    class DatabaseConnection
    {
        SqlConnection con;
        String StringConnection;

        public SqlConnection Connection()
        {
            StringConnection = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;         
            con = new SqlConnection(StringConnection);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return con;

        }

        public int Executenonquery(SqlCommand cmd)
        {
            int j = 0;
            try
            {

                cmd.Connection.Open();
                j = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return j;
            }
            catch (Exception ex)
            {

                con.Close();
            }
            finally
            {
                con.Close();

            }
            return j;

        }


        public DataTable ExecuteDataSet(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Tables1");
                if (ds.Tables.Count > 0)
                    dt = ds.Tables[0];

            }
            catch (Exception)
            {

                MessageBox.Show("Network Connection Issue", "Connectivity Issue", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            return dt;
        }






        public SqlCommand ConnectionWithCommand(String command)
        {
            con = Connection();
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
    }
}
