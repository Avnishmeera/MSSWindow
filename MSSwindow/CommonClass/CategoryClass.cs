using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MSSwindow.CommonClass;
using MSSwindow.Connection;

namespace MSSwindow
{
    class CategoryClass
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        SqlCommand cmd;
        public DataSet BindCategory(int Shopid)
        {
            cmd = dbconn.ConnectionWithCommand("BindCategoryMaster");
            cmd.Parameters.AddWithValue("Shopid", Shopid);
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

        public DataSet BindComplaintStatusM(int Shopid)
        {
            cmd = dbconn.ConnectionWithCommand("BindComplaintStatusMaster");
            cmd.Parameters.AddWithValue("Shopid", Shopid);
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

        public DataSet BindDropDownCategory()
        {
            cmd = dbconn.ConnectionWithCommand("BindDDLCategoryMaster");
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

        public DataTable SearchDataGridviewRecord(CategoryclassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("SearchCategoryDetails");
            cmd.Parameters.AddWithValue("@CategoryName", be.Categoryname);
            DataTable dt = new DataTable();
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }

        public DataTable BindCategory1(CategoryclassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("BindCategoryMaster");
            cmd.Parameters.AddWithValue("@Shopid", be.Shopid);
            DataTable dt = new DataTable();
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }

        public DataTable BindComplaintstatus(CategoryclassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("Bindcomplaintstatus");
            cmd.Parameters.AddWithValue("@Shopid", be.Shopid);
            DataTable dt = new DataTable();
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }

        
        
        public DataTable BindDropDownCategory1(CategoryclassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("BindDDLCategoryMaster");
            cmd.Parameters.AddWithValue("@Shopid", be.Shopid);
            DataTable dt = new DataTable();
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }


        
        public DataTable BindCustomerDetails(int shopid,int ? catid)
        {
            cmd = dbconn.ConnectionWithCommand("spo_getcustomerContact");
            cmd.Parameters.AddWithValue("@Shopid", shopid);
            cmd.Parameters.AddWithValue("@CategoryID", catid);
            DataTable dt = new DataTable();
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }

        public void InsertUpdateCategory(CategoryclassBe be)
        {

            cmd = dbconn.ConnectionWithCommand("sp_InsertUpdateCategory");
            cmd.Parameters.AddWithValue("@Shopid", be.Shopid);
            cmd.Parameters.AddWithValue("@Categoryid", be.Categoryid);
            cmd.Parameters.AddWithValue("@Categoryname", be.Categoryname);
            cmd.Parameters.AddWithValue("@Description", be.Description);
            cmd.Parameters.AddWithValue("@IsActive", be.IsActive);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {

            }

        }

        public void InsertUpdateReasonCode(CategoryclassBe be)
        {

            cmd = dbconn.ConnectionWithCommand("sp_InsertUpdateReasonCode");
            cmd.Parameters.AddWithValue("@Shopid", be.Shopid);
            cmd.Parameters.AddWithValue("@CategoryID", be.Categoryid);
            cmd.Parameters.AddWithValue("@StatusID", be.StatusID);
            cmd.Parameters.AddWithValue("@StatusDescription", be.StatusDescription);
            cmd.Parameters.AddWithValue("@IsActive", be.IsActive);
            cmd.Parameters.AddWithValue("@TimeDuration", be.TimeDuration);
            cmd.Parameters.AddWithValue("@FDS1", be.FDS1);
            cmd.Parameters.AddWithValue("@FDS2", be.FDS2);
            cmd.Parameters.AddWithValue("@FDS3", be.FDS3);
            cmd.Parameters.AddWithValue("@FDS4", be.FDS4);
            cmd.Parameters.AddWithValue("@FDS5", be.FDS5);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {

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

        public void DeleteCompalintStatus(CategoryclassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("DeleteBindComplaintStatus");
            cmd.Parameters.AddWithValue("@Action", "Delete");
            cmd.Parameters.AddWithValue("@StatusId", be.Categoryid);
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



        public void InsertUpdateItemDetails(CategoryclassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_InsertUpdateItemsDetails");
            cmd.Parameters.AddWithValue("@Shopid", be.Shopid);
            cmd.Parameters.AddWithValue("@Itemid", be.Itemid);
            cmd.Parameters.AddWithValue("@Itemname", be.Itemname);
            cmd.Parameters.AddWithValue("@Charge", be.Charge);
            cmd.Parameters.AddWithValue("@IsActive", be.IsActive);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {

            }

        }



        public void DeleteItemDetails(CategoryclassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("DeleteBindItemDetails");
            cmd.Parameters.AddWithValue("@Action", "Delete");
            cmd.Parameters.AddWithValue("@ItemId", be.Categoryid);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {

            }
        }

        //--------Bind Item Master -----Date 09 Oct 2018 ---- Time : 01 :30 Am --------Vikash Tiwari------

        public DataSet BindItemDetails(int Shopid)
        {
            cmd = dbconn.ConnectionWithCommand("sp_BindItemMaster");
            cmd.Parameters.AddWithValue("Shopid", Shopid);
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

        //--------Bind Item Master -----Date 09 Oct 2018 ---- Time : 01 :30 Am --------Vikash Tiwari------

        public DataTable BindItemMaster(CategoryclassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_BindItemMaster");
            cmd.Parameters.AddWithValue("@Shopid", be.Shopid);
            DataTable dt = new DataTable();
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }
    }
}
