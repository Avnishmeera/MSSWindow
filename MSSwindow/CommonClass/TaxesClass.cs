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
    class TaxesClass
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        SqlCommand cmd;
        public DataSet BindTaxes(int Shopid)
        {
            cmd = dbconn.ConnectionWithCommand("BindTaxesMaster");
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

        public DataSet BindDropDownTaxes()
        {
            cmd = dbconn.ConnectionWithCommand("BindDDLTaxesMaster");
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



        public void InsertUpdateTaxes(TaxesClassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_InsertUpdateTaxesMaster");
            cmd.Parameters.AddWithValue("@Taxid", be.Taxid);
            cmd.Parameters.AddWithValue("@Taxname", be.Taxname);
            cmd.Parameters.AddWithValue("@Rate", be.Rate);
            cmd.Parameters.AddWithValue("@Description", be.Description);
            cmd.Parameters.AddWithValue("@IsActive", be.IsActive);
            cmd.Parameters.AddWithValue("@Shopid", be.Shopid);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess","hhjjj", true);
            }
        }


        public void DeleteCategory(CategoryclassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("DeleteBindCategoryDetails");
            cmd.Parameters.AddWithValue("@Action", "Delete");
            cmd.Parameters.AddWithValue("@CategoryId", be.Categoryid);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {

            }
        }

        public DataTable BindTextBoxCategory(CategoryclassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("DeleteBindCategoryDetails");
            cmd.Parameters.AddWithValue("@Action", "BindTextBoxValues");
            cmd.Parameters.AddWithValue("@CategoryId", be.Categoryid);
            DataTable dt = new DataTable();
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }
    }
}
