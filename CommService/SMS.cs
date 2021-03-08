using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CommService
{
    class SMS
    {
        public string SMSTEXT { get; set; }
        public string Contact { get; set; }
        public bool IsSendSMS { get; set; }
        public int ShopID { get; set; }
    }

    class SMSTrans
    {
       
        public static SqlCommand cmd;
        public static DataTable InsertSmsNotification()
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            cmd = dbconn.ConnectionWithCommand("SPO_GetPending");
            //cmd.Parameters.AddWithValue("@Images", be.Images);
            DataTable DT = new DataTable();
            DT = dbconn.ExecuteDataSet(cmd);
            return DT;
        }

        public static DataTable UpdateSMSSend(int NotificationID,bool IsMessageSend,bool IsError,string ErrorMessage)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            cmd = dbconn.ConnectionWithCommand("UpdateNotification");
            cmd.Parameters.AddWithValue("@NotificationID", NotificationID);
            cmd.Parameters.AddWithValue("@IsMessageSend", IsMessageSend);
            cmd.Parameters.AddWithValue("@IsError", IsError);
            cmd.Parameters.AddWithValue("@ErrorMessage", ErrorMessage);
            DataTable DT = new DataTable();
            DT = dbconn.ExecuteDataSet(cmd);
            return DT;
        }
    }
}
