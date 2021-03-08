using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSwindow.Connection;
using System.Data;
using System.Data.SqlClient;
using MSSwindow.CommonClass;

namespace MSSwindow
{
    class SupplierClass
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        SqlCommand cmd;

        public DataSet BindDebitor(int ShopID)
        {
            cmd = dbconn.ConnectionWithCommand("BindDebitor");
            cmd.Parameters.AddWithValue("@Shopid", ShopID);
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
        public DataSet BindSuppliers(int ShopID)
        {
            cmd = dbconn.ConnectionWithCommand("BindSupplierMaster");
            cmd.Parameters.AddWithValue("@Shopid", ShopID);
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

        public DataSet BindDropDownSuppliers(int shopid)
        {
            
            cmd = dbconn.ConnectionWithCommand("BindDDLSupplierMaster");
            cmd.Parameters.AddWithValue("@Shopid", shopid);
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



        public void InsertUpdateSuppliers(SupplierClassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_InsertUpdateSuppliers");
            cmd.Parameters.AddWithValue("@Supplierid", be.SupplierId);
            cmd.Parameters.AddWithValue("@Suppliername", be.SupplierName);
            cmd.Parameters.AddWithValue("@City", be.City);
            cmd.Parameters.AddWithValue("@States", be.State);
            cmd.Parameters.AddWithValue("@Country", be.Country);
            cmd.Parameters.AddWithValue("@Pincode", be.Pincode);
            cmd.Parameters.AddWithValue("@Emailid", be.Emailid);
            cmd.Parameters.AddWithValue("@Contact", be.Contact);
            cmd.Parameters.AddWithValue("@AltContact", be.AltContact);
            cmd.Parameters.AddWithValue("@Address", be.Address);
            cmd.Parameters.AddWithValue("@Descriptions", be.Descriptions);
            cmd.Parameters.AddWithValue("@IsActive", be.IsActive);
            cmd.Parameters.AddWithValue("@ShopID", be.Shopid);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess","hhjjj", true);
            }
        }


        public void DeleteSuppliers(SupplierClassBe be)
        {
            // cmd = dbconn.ConnectionWithCommand("DeleteSuppliersDetails");
            cmd = dbconn.ConnectionWithCommand("DeleteBindSuppliersDetails");
            cmd.Parameters.AddWithValue("@Action", "Delete");
            cmd.Parameters.AddWithValue("@SupplierId", be.SupplierId);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess","hhjjj", true);
            }
        }

        public DataTable BindTextBoxSuppliers(SupplierClassBe be)
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
