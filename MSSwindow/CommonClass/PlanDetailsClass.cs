using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MSSwindow.CommonClass;
using MSSwindow.Connection;


namespace MSSwindow.CommonClass
{
    class PlanDetailsClass
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        SqlCommand cmd;

        public DataSet BindPlanDetails1()
        {
            cmd = dbconn.ConnectionWithCommand("sp_PlanDetailsData");
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

        public DataSet BindPaymentMode()
        {
            cmd = dbconn.ConnectionWithCommand("sp_BindPaymentMode");
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

        public DataSet BindMonths()
        {
            cmd = dbconn.ConnectionWithCommand("sp_BindMonths");
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

        public DataSet BindYear()
        {
            cmd = dbconn.ConnectionWithCommand("sp_BindYear");
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


        public DataSet BindProofDetails()
        {
            cmd = dbconn.ConnectionWithCommand("sp_BindProofDetails");
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

        public DataTable BindPlanDetails(PlanDetailsbe be)
        {
            DataTable dt = new DataTable();
            cmd = dbconn.ConnectionWithCommand("sp_PlanDetailsData");
            cmd.Parameters.AddWithValue("@shopid", be.Shopid);          
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }


        public void DeletePlanDetials(PlanDetailsbe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_deletePlandetails");
            cmd.Parameters.AddWithValue("@shopid", be.Shopid);
            cmd.Parameters.AddWithValue("@id", be.Planid);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {

            }
        }
       

        public int InsertUpdatePlanDetails(PlanDetailsbe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_InsertUpdatePlanDetails");
            cmd.Parameters.AddWithValue("@Shopid", be.Shopid);
            cmd.Parameters.AddWithValue("@Planid", be.Planid);
            cmd.Parameters.AddWithValue("@PlanName", be.Planname);
            cmd.Parameters.AddWithValue("@PlanDetail", be.PlanDetails);
            cmd.Parameters.AddWithValue("@Days", be.@Days);
            cmd.Parameters.AddWithValue("@Price", be.@Price);
            cmd.Parameters.AddWithValue("@Remarks", be.@Remarks);   
                    
            int Results = dbconn.Executenonquery(cmd);
            return Results;
        }


       
    }
}
