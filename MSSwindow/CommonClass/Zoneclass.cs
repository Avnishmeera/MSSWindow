
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
    class Zoneclass
    {
        SqlCommand cmd;
        DatabaseConnection dbconn = new DatabaseConnection();

        public DataSet BindZone(int Shopid)
        {
            cmd = dbconn.ConnectionWithCommand("sp_BindZone");
            cmd.Parameters.AddWithValue("@Shopid", Shopid);
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


        public void InsertUpdateZone(Zonebe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_InsertUpdateZone");
            cmd.Parameters.AddWithValue("@Shopid", be.Shopid);
            cmd.Parameters.AddWithValue("@Zoneid", be.ZoneID);
            cmd.Parameters.AddWithValue("@Zonename", be.ZoneName);
            cmd.Parameters.AddWithValue("@Pincode", be.pincode);          
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess","hhjjj", true);
            }
        }


        public void DeletedZone(Zonebe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_DeleteZone");
            cmd.Parameters.AddWithValue("@Shopid",be.Shopid);
            cmd.Parameters.AddWithValue("@Zoneid",be.ZoneID);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {

            }
        }
    }
}
