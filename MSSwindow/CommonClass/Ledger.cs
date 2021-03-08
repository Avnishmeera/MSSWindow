using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MSSwindow.CommonClass;
using MSSwindow.Connection;


namespace MSSwindow.CommonClass
{
    class Ledger
    {
        SqlCommand cmd;
        DatabaseConnection dbconn = new DatabaseConnection();
        public DataSet BindLedgerBalance(int Shopid,DateTime ? FromDate = null, DateTime? Todate=null,int? EmpID = null)
        {
            cmd = dbconn.ConnectionWithCommand("spo_LedgerBalance");
            cmd.Parameters.AddWithValue("@Shopid", Shopid);
            cmd.Parameters.AddWithValue("@Fdt", FromDate);
            cmd.Parameters.AddWithValue("@Tdt", Todate);
            cmd.Parameters.AddWithValue("@EmpID", EmpID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
            }
            catch (Exception)
            {
                throw;
            }
            return ds;
        }

        public DataSet BindLedgerByID(int Shopid,int TranID)
        {
            cmd = dbconn.ConnectionWithCommand("spo_LedgerDetails");
            cmd.Parameters.AddWithValue("@Shopid", Shopid);
            cmd.Parameters.AddWithValue("@TranID", TranID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
            }
            catch (Exception)
            {
                throw;
            }
            return ds;
        }
    }
}
