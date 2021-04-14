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
    class ShopMaster
    {
      
        public static SqlCommand cmd;
        public static DataSet SetShopProperty(int ShopID)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            cmd = dbconn.ConnectionWithCommand("ashish123.spo_getShopRegistration");
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
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


        public  DataSet SetMessagePatamNotification()
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            cmd = dbconn.ConnectionWithCommand("sp_BindNotificationParameter");         
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


        public DataSet GetNotificationMaster()
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            cmd = dbconn.ConnectionWithCommand("sp_BindNotificationParameter");
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


        public DataSet GetSMSCategory()
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            cmd = dbconn.ConnectionWithCommand("sp_BindMSGCategory");
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

        public DataSet GetMessageType(int MsgTypeid)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            cmd = dbconn.ConnectionWithCommand("sp_BindMessageType");
            cmd.Parameters.AddWithValue("@Categoryid", MsgTypeid);
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



        public DataSet GetNotificationMaster(int MsgTypeid,int Shopid)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            cmd = dbconn.ConnectionWithCommand("sp_BindNotificationMaster");
            cmd.Parameters.AddWithValue("@Msgtypeid", MsgTypeid);
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



        public void InsertUpdateSHOPWISEMessageDetail(int Shopid, int Notid,int Detailsid ,string Messagetext,bool Status,string TempID)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            cmd = dbconn.ConnectionWithCommand("sp_InsertUpdateSHOPWISEMessageDetail");
            cmd.Parameters.AddWithValue("@Shopid", Shopid);
            cmd.Parameters.AddWithValue("@Notid", Notid);
            cmd.Parameters.AddWithValue("@Detailsid", Detailsid);
            cmd.Parameters.AddWithValue("@Messagetext",Messagetext);
            cmd.Parameters.AddWithValue("@IsActive", Status);
            cmd.Parameters.AddWithValue("@TempID", TempID);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {
               
            }
        }        
    }
}
  