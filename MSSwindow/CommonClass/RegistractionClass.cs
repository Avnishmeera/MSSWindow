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
    class RegistractionClass
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        SqlCommand cmd;

       

      
        public void DeleteMemberDetails(RegistarctionClassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_deleteMemberDetails");
            cmd.Parameters.AddWithValue("@shopid", be.Shopid);
            cmd.Parameters.AddWithValue("@id", be.membershipid);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {

            }
        }


        public DataTable BindDetailsMemberPerMonths(RegistarctionClassBe be)
        {
            DataTable dt = new DataTable();
            cmd = dbconn.ConnectionWithCommand("sp_MemberPerMonth");
            cmd.Parameters.AddWithValue("@fromdate", be.Fromdate);
            cmd.Parameters.AddWithValue("@todate", be.ToDate);
            int Results = dbconn.Executenonquery(cmd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(dt);
            }
            catch (Exception)
            {
                throw;
            }
           return dt;


            //if (Results == 1)
            //{

            //}
        }

        public DataSet BindEndingMemberDeteails()
        {
            cmd = dbconn.ConnectionWithCommand("sp_EndingPlanMember");           
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

        public DataSet BindAccessRight(int ShopID,int UserID)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_GetAllModule");
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
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


        public void ChangePassword(RegistarctionClassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_deleteMemberDetails");
            cmd.Parameters.AddWithValue("@shopid", be.Shopid);
            cmd.Parameters.AddWithValue("@id", be.membershipid);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {

            }
        }

        public DataSet BindFeesDetails(int Planid)
        {
            cmd = dbconn.ConnectionWithCommand("BindfeesDetails");
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

        public DataSet BindMemberDetails(int Shopid,string Membername,int? MemberID = null)
        {
            cmd = dbconn.ConnectionWithCommand("sp_BindMemberDetails");
            cmd.Parameters.AddWithValue("@Shopid", Shopid);
            cmd.Parameters.AddWithValue("@MemberName", Membername);
            cmd.Parameters.AddWithValue("@MemberID", MemberID);
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

        public DataSet BindAdminMemberDetails(int Shopid, string Membername, int? MemberID = null)
        {
            cmd = dbconn.ConnectionWithCommand("sp_BindAdminMemberDetails");
            cmd.Parameters.AddWithValue("@Shopid", Shopid);
            cmd.Parameters.AddWithValue("@MemberName", Membername);
            cmd.Parameters.AddWithValue("@MemberID", MemberID);
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


        public DataSet ShowMemberDetails(int Shopid, string Membername, int? MemberID = null)
        {
            cmd = dbconn.ConnectionWithCommand("sp_ShowMemberDetails");
            cmd.Parameters.AddWithValue("@Shopid", Shopid);
            cmd.Parameters.AddWithValue("@MemberName", Membername);
            cmd.Parameters.AddWithValue("@MemberID", MemberID);
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

        public  DataTable TotalMemberDetails(RegistarctionClassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_CountTotalMember");
            cmd.Parameters.AddWithValue("@shopid", be.Shopid);
            cmd.Parameters.AddWithValue("@Action", "TotalMember");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
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

        public DataTable TotalInquiryDetails(RegistarctionClassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_CountTotalMember");
            cmd.Parameters.AddWithValue("@shopid", be.Shopid);
            cmd.Parameters.AddWithValue("@Action", "TotalInquiry");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
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


        public DataTable TotalIncomeDetails(RegistarctionClassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_CountTotalMember");
            cmd.Parameters.AddWithValue("@shopid", be.Shopid);
            cmd.Parameters.AddWithValue("@Action", "TotalIncome");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
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



        public DataTable BindPlanDetails(RegistarctionClassBe be)
        {
            DataTable dt = new DataTable();
            cmd = dbconn.ConnectionWithCommand("BindfeesDetails");
            cmd.Parameters.AddWithValue("@Planid",be.Plan);
            dt  = dbconn.ExecuteDataSet(cmd);
            return dt;
        }

        public DataTable BindTextboxValues(RegistarctionClassBe be)
        {
            DataTable dt = new DataTable();
            cmd = dbconn.ConnectionWithCommand("SP_BindMenberRegistraction");
            cmd.Parameters.AddWithValue("@MEMid", be.membershipid);
           // cmd.Parameters.AddWithValue("@SHOPID", be.Shopid);
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }

        public DataSet GenerateMemberShipid(int Shopid)
        {
            cmd = dbconn.ConnectionWithCommand("sp_GetMembershipid");
            cmd.Parameters.AddWithValue("@Shopid", Shopid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            try
            {
                da.Fill(dt);
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable BindStoreInformation(RegistarctionClassBe be)
        {
            DataTable dt = new DataTable();
            cmd = dbconn.ConnectionWithCommand("SP_BondStoreRegistraction");
            cmd.Parameters.AddWithValue("@shopid", be.Shopid);
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }

        public DataTable BindRegistrationInformation(RegistarctionClassBe be)
        {
            DataTable dt = new DataTable();
            cmd = dbconn.ConnectionWithCommand("sp_BindMemberDetailsByid");
            cmd.Parameters.AddWithValue("@shopid", be.Shopid);
            cmd.Parameters.AddWithValue("@Membershipid", be.membershipid);
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }

        public DataTable DeleteRegistrationInformation(RegistarctionClassBe be)
        {
            DataTable dt = new DataTable();
            cmd = dbconn.ConnectionWithCommand("sp_deleteMemberDetails");
            cmd.Parameters.AddWithValue("@shopid", be.Shopid);
            cmd.Parameters.AddWithValue("@id", be.membershipid);
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }

        public int InsertUpdateMemberRegistraction(RegistarctionClassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_insertupdateMemberRegistraction");
            cmd.Parameters.AddWithValue("@Shopid", be.Shopid);
            cmd.Parameters.AddWithValue("@Memberid", be.membershipid);
            cmd.Parameters.AddWithValue("@AdmissionDate", be.AdmissionDate);
            cmd.Parameters.AddWithValue("@Firstname", be.Firstname);
            cmd.Parameters.AddWithValue("@Lastname", be.Lastname);
            cmd.Parameters.AddWithValue("@Contact", be.Contact);
            cmd.Parameters.AddWithValue("@Email", be.Email);
            cmd.Parameters.AddWithValue("@Gender", be.Gender);
            cmd.Parameters.AddWithValue("@DateofBirth", be.DateofBirth);           
            cmd.Parameters.AddWithValue("@ProofGiven", be.ProofGiven);
            cmd.Parameters.AddWithValue("@ProofDetails", be.ProofDetails);
            cmd.Parameters.AddWithValue("@Salary", be.Salary);
            cmd.Parameters.AddWithValue("@Address", be.Address);
            cmd.Parameters.AddWithValue("@EmployeeID", be.memberid);
            cmd.Parameters.AddWithValue("@Role", be.Role);
            cmd.Parameters.AddWithValue("@UserID", be.Userid);
            cmd.Parameters.AddWithValue("@Pwd", be.NewPassword);
            int Results = dbconn.Executenonquery(cmd);
            return Results;
        }

        public int InsertUpdateAccessRight(DataTable dt)
        {
            cmd = dbconn.ConnectionWithCommand("spo_InsertIntoAccessRight");
            cmd.Parameters.AddWithValue("@USer_Access", dt);
            //cmd.Parameters.AddWithValue("@Images", be.Images);
            int Results = dbconn.Executenonquery(cmd);
            return Results;
        }
    }
}
