using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSwindow.CommonClass;
using MSSwindow.Connection;
using System.Data.SqlClient;
using System.Data;

namespace MSSwindow.CommonClass
{
    class UnitClass
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        SqlCommand cmd;

        public DataSet BindUnit(int Shopid)
        {
            cmd = dbconn.ConnectionWithCommand("BindUnitMaster");
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

        public DataSet BindDropDownUnit(int Shopid)
        {
            cmd = dbconn.ConnectionWithCommand("BindDDLUnitMaster");
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



        public void InsertUpdateUnit(UnitClassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_InsertUpdateUnit");
            cmd.Parameters.AddWithValue("@Shopid", be.Shopid);
            cmd.Parameters.AddWithValue("@Unitid", be.Unitid);
            cmd.Parameters.AddWithValue("@Unitname", be.UnitName);
            cmd.Parameters.AddWithValue("@Description", be.Description);
            cmd.Parameters.AddWithValue("@IsActive", be.IsActive);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess","hhjjj", true);
            }
        }


        public void DeleteUnit(UnitClassBe be)
        {
            // cmd = dbconn.ConnectionWithCommand("DeleteSuppliersDetails");
            cmd = dbconn.ConnectionWithCommand("DeleteBindUnitDetails");
            cmd.Parameters.AddWithValue("@Action", "Delete");
            cmd.Parameters.AddWithValue("@Unitid", be.Unitid);
            int Results = dbconn.Executenonquery(cmd);           
            if (Results == 1)
            {
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess","hhjjj", true);
            }
        }

        public DataTable BindTextBoxUnit(SupplierClassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("DeleteBindSuppliersDetails");
            cmd.Parameters.AddWithValue("@Action", "BindTextBoxValues");
            cmd.Parameters.AddWithValue("@SupplierId", be.SupplierId);
            DataTable dt = new DataTable();
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }

    }
}
