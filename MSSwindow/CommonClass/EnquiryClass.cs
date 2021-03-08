using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MSSwindow.Connection;

namespace MSSwindow
{
    class EnquiryClass
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        SqlCommand cmd;

        public DataSet BindGender()
        {
            cmd = dbconn.ConnectionWithCommand("sp_BindGender");
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
        public DataSet BindCustomerType()
        {
            cmd = dbconn.ConnectionWithCommand("sp_BindCustomerType");
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


        public DataSet BindExpStatus()
        {
            cmd = dbconn.ConnectionWithCommand("spo_GetProductExpStatus");
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

        public DataSet BindZone(int Shopid)
        {
            cmd = dbconn.ConnectionWithCommand("sp_BindZone");
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

        public DataSet BindHappyCode(int CompID)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_GetHappyCode");
            cmd.Parameters.AddWithValue("@CompID", CompID);
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


        
        
        public DataSet BindMaritalStatus()
        {
            cmd = dbconn.ConnectionWithCommand("sp_BindMaritalStatus");

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

        public void InsertEnquiry(EnquiryClassbe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_InsertEnquiryform");
            cmd.Parameters.AddWithValue("@shopid", be.shopid);
            cmd.Parameters.AddWithValue("@Firstname", be.Firstname);
            cmd.Parameters.AddWithValue("@Lastname", be.Lastname);
            cmd.Parameters.AddWithValue("@Gender", be.Gender);
            cmd.Parameters.AddWithValue("@Mobile", be.Mobile);
            cmd.Parameters.AddWithValue("@Email", be.Email);
            cmd.Parameters.AddWithValue("@Date", be.Date);
            cmd.Parameters.AddWithValue("@Occupation", be.Occupation);
            cmd.Parameters.AddWithValue("@Address", be.Address);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {
               // System.Windows.Forms.MessageBox.Show("Enquiry submited Sucessfully");
            }
        }


        public void InsertUpdateEnquiry(Enquriryclsbe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_InsertupdateEnquiry");
            cmd.Parameters.AddWithValue("@Shopid", be.Shopid);
            cmd.Parameters.AddWithValue("@Enquiryid", be.Enquiryid);
            cmd.Parameters.AddWithValue("@Enquiryno", be.Enquiryno);
            cmd.Parameters.AddWithValue("@Enqurirydate", be.Enqurirydate);
            cmd.Parameters.AddWithValue("@Types", be.Types);
            cmd.Parameters.AddWithValue("@Customerid", be.Customerid);
            cmd.Parameters.AddWithValue("@Category", be.Category);
            cmd.Parameters.AddWithValue("@Product", be.Product);           
            cmd.Parameters.AddWithValue("@Vistitdate", be.Vistitdate);
            cmd.Parameters.AddWithValue("@Visittime", be.Visittime);
            cmd.Parameters.AddWithValue("@Source", be.Source);
            cmd.Parameters.AddWithValue("@CallBy", be.CallBy);
            cmd.Parameters.AddWithValue("@CallNumber", be.CallNumber);           
            cmd.Parameters.AddWithValue("@NextFollowupdate", be.NextFollowupdate);
            cmd.Parameters.AddWithValue("@Followupremarks", be.Followupremarks);
            cmd.Parameters.AddWithValue("@Followuplastremarks", be.Followuplastremarks);
            cmd.Parameters.AddWithValue("@SubmitBy", be.SubmitedBy);
            cmd.Parameters.AddWithValue("@Referenceno", be.Referenceno);
            cmd.Parameters.AddWithValue("@EnquiryStatus", be.EnqStatus);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {
                // System.Windows.Forms.MessageBox.Show("Enquiry submited Sucessfully");
            }
        }

        public int SendUserCredential(int CustomerID)
        {
           
            cmd = dbconn.ConnectionWithCommand("Spo_CreateCustomerCredential");
            cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {
                // System.Windows.Forms.MessageBox.Show("Enquiry submited Sucessfully");
            }
            return Results;
        }
    }



}
