using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MSSwindow.Connection;

namespace MSSwindow.CommonClass
{
    class Stock
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        SqlCommand cmd;
       
        public DataSet BindStock(int ShopID,int? HeadID = null)
        {
            cmd = dbconn.ConnectionWithCommand("sp_BindStockheader");
            cmd.Parameters.AddWithValue("@Shopid",ShopID);
            cmd.Parameters.AddWithValue("@HeadID", HeadID);
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

        public void InsertUpdateStockLocation(int shopid ,int locationid,string locationname, int type, string Initial,int status)
        {

            cmd = dbconn.ConnectionWithCommand("sp_insertupdateStockLocationMaster");
            cmd.Parameters.AddWithValue("@shopid", shopid);
            cmd.Parameters.AddWithValue("@Locationid", locationid);
            cmd.Parameters.AddWithValue("@Locationname", locationname);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@Initial", Initial);
            cmd.Parameters.AddWithValue("@Status", status);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {

            }

        }



        public DataSet BindTypes()
        {
            cmd = dbconn.ConnectionWithCommand("sp_bindlocationtype");       
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


        public DataSet BindLocation(int shopid)
        {
            cmd = dbconn.ConnectionWithCommand("sp_getLocationMaster");
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

        public DataSet BindFromLocation(Stockbe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_getLocationMaster");           
            cmd.Parameters.AddWithValue("@Shopid",be.Shopid);
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



        public DataSet BindGridLocation(int shopid)
        {
            cmd = dbconn.ConnectionWithCommand("sp_BindLocationDetails");
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


        public DataSet BindToLocation(Stockbe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_getStockLocationMaster");
            cmd.Parameters.AddWithValue("@Shopid", be.Shopid);
            cmd.Parameters.AddWithValue("@Locationid", be.Locationid);           
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


        //sp_getRentRefrno
        public DataTable BindRefNo(Stockbe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_getRefrno");
            cmd.Parameters.AddWithValue("@Shopid", be.Shopid);
            cmd.Parameters.AddWithValue("@Locationid", be.Locationid);
            DataTable dt = new DataTable();
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }


        public DataTable BindToLocation1(Stockbe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_getStockLocationMaster");
            cmd.Parameters.AddWithValue("@Shopid", be.Shopid);
            cmd.Parameters.AddWithValue("@Locationid", be.Locationid);
            DataTable dt = new DataTable();
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }


        public DataTable Bind_StockDetails(Stockbe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_GetStocksDetails");
            cmd.Parameters.AddWithValue("@Locationid", be.Locationid);
            cmd.Parameters.AddWithValue("@Productid", be.Productid);
            DataTable dt = new DataTable();
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }

        
        public DataTable BindStockDetails(Stockbe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_GetStocksDetails");
            cmd.Parameters.AddWithValue("@Shopid", be.Shopid);
            cmd.Parameters.AddWithValue("@Locationid", be.Locationid);
            cmd.Parameters.AddWithValue("@Productid", be.Productid);
            DataTable dt = new DataTable();
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }



        public int InsertUpdateStocks(Stockbe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_StoreStockDetails");       
            cmd.Parameters.AddWithValue("@TransferRefNo", be.TransferRefNo);
            cmd.Parameters.AddWithValue("@Transferfrom", be.fromlocation);
            cmd.Parameters.AddWithValue("@Transferto", be.tolocation);
            cmd.Parameters.AddWithValue("@Productid", be.Productid);
            cmd.Parameters.AddWithValue("@Price", be.Price);
            cmd.Parameters.AddWithValue("@Qty", be.Qty);
            cmd.Parameters.AddWithValue("@Unit", be.Unit);
            cmd.Parameters.AddWithValue("@Tranferdate", be.Tranferdate);
            int Results = dbconn.Executenonquery(cmd);
            return Results;
        }

    }
}
