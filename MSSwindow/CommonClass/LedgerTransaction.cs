using MSSwindow.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSwindow.CommonClass
{
    class LedgerTransaction
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        SqlCommand cmd;
        public DataTable LedgerSeries(LedgerBE be)
        {
            cmd = dbconn.ConnectionWithCommand("GenLedger");
            cmd.Parameters.AddWithValue("@Shopid", be.Shopid);
            DataTable dt = new DataTable();
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }

      
        public int DeleteLedger(LedgerBE lbe)
        {
            cmd = dbconn.ConnectionWithCommand("SPO_DeleteLedger");
            cmd.Parameters.AddWithValue("@LedID", lbe.TranID);
            cmd.Parameters.AddWithValue("@ShopID", lbe.Shopid);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess","hhjjj", true);
            }
            return Results;
        }
        public int InsertUpdateLedger(LedgerBE lbe)
        {
            cmd = dbconn.ConnectionWithCommand("SPO_LedgerTransaction");
            cmd.Parameters.AddWithValue("@TranID", lbe.TranID);
            cmd.Parameters.AddWithValue("@Shopid", lbe.Shopid);
            cmd.Parameters.AddWithValue("@LedgNO", lbe.LedgerNO);
            cmd.Parameters.AddWithValue("@PayType", lbe.PayType);
            cmd.Parameters.AddWithValue("@PayDt", lbe.PayDt);
            cmd.Parameters.AddWithValue("@CustID", lbe.CustID);
            cmd.Parameters.AddWithValue("@SupID", lbe.SupID);
            cmd.Parameters.AddWithValue("@AMT", lbe.Amt);
            cmd.Parameters.AddWithValue("@EmpID", lbe.EMPID);
            cmd.Parameters.AddWithValue("@Remark", lbe.remark);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess","hhjjj", true);
            }
            return Results;
        }
    }
}
