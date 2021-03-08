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
    class Rentcls
    {



        DatabaseConnection dbconn = new DatabaseConnection();
        SqlCommand cmd;
        //
        public DataTable BindRentRefNo(int shopid)
        {
            cmd = dbconn.ConnectionWithCommand("sp_getRentRefrno");
            cmd.Parameters.AddWithValue("@Shopid",shopid);          
            DataTable dt = new DataTable();
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }

    }
}
