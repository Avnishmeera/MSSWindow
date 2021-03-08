using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSwindow.Connection;
using System.Data;
using System.Data.SqlClient;

namespace MSSwindow
{
    class Brands
    {
        SqlCommand cmd;
        DatabaseConnection dbconn = new DatabaseConnection();

        public DataSet BindBrands(int Shopid)
        {
            cmd = dbconn.ConnectionWithCommand("BindBrandMaster");
            cmd.Parameters.AddWithValue("@Shopid",Shopid);
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

        public DataTable BindBrands1(BrandsBe be)
        {
            cmd = dbconn.ConnectionWithCommand("BindBrandMaster");
            cmd.Parameters.AddWithValue("@Shopid", be.Shopid);
            DataTable dt = new DataTable();
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }
        public DataTable GetBrandByCategory(int CategoryID)
        {
            cmd = dbconn.ConnectionWithCommand("GetBrandByCategory");
            cmd.Parameters.AddWithValue("@categoryid", CategoryID);
            DataTable dt = new DataTable();
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }
        public DataTable CategoryWiseBrand(string CategoryName, int shopid)
        {
            BrandsBe be = new BrandsBe();
            be.Shopid = shopid;
            // be.Shopid=
            DataTable DT = BindBrands1(be);
            DT.Rows.Add("0","0" ,"Select", "Select", string.Empty, 1, shopid);
            DataView DV = new DataView(DT);
            DV.RowFilter = "CategoryName = '" + CategoryName + "' and ShopID = '" + shopid + "'";
            DataTable dt = new DataTable();
            dt = DV.ToTable();
            return dt;

        }

        public DataTable CategoryWiseBrand(int CategoryID)
        {
            DataTable DT = GetBrandByCategory(CategoryID);
            return DT;

        }
        public void InsertUpdateBrands(BrandsBe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_InsertUpdateBrands");
            cmd.Parameters.AddWithValue("@Shopid", be.Shopid);
            cmd.Parameters.AddWithValue("@Brandid", be.BrandID);
            cmd.Parameters.AddWithValue("@CategoryBrandID", be.CategoryBrandID);
            cmd.Parameters.AddWithValue("@Brandname", be.BrandName);
            cmd.Parameters.AddWithValue("@Description", be.Description);
            cmd.Parameters.AddWithValue("@IsActive", be.IsActive);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess","hhjjj", true);
            }
        }

        public void DeleteBrands(BrandsBe be)
        {
            cmd = dbconn.ConnectionWithCommand("DeleteBindBrandsDetails");
            cmd.Parameters.AddWithValue("@Action", "Delete");
            cmd.Parameters.AddWithValue("@BrandId", be.BrandID);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {

            }
        }


    }
}

