using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSwindow.Connection;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace MSSwindow.CommonClass
{
    class LoginClass
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        SqlCommand cmd;


        public DataSet BindPlanDetails()
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

        public string GeneratePassword()
        {
            string PasswordLength = "8";
            string NewPassword = "";

            string allowedChars = "";
            allowedChars = "1,2,3,4,5,6,7,8,9,0";
            allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            // allowedChars += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";


            char[] sep = {  
            ','  
        };
            string[] arr = allowedChars.Split(sep);


            string IDString = "";
            string temp = "";

            Random rand = new Random();

            for (int i = 0; i < Convert.ToInt32(PasswordLength); i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                IDString += temp;
                NewPassword = IDString;

            }
            return NewPassword;
        }

        public int ForgotPassword(String Username, String Password)
        {
            string strNewPassword = Password;
            cmd = dbconn.ConnectionWithCommand("sp_ForgotPassword");
            cmd.Parameters.AddWithValue("@ShopUserid", Username);
            cmd.Parameters.AddWithValue("@ShopNewPassword", strNewPassword);
            int i = dbconn.Executenonquery(cmd);
            return i;
        }

        public DataTable UserAccess(int UserID)
        {
            DataTable dt = new DataTable();
            cmd = dbconn.ConnectionWithCommand("Spo_GetAccess");
            cmd.Parameters.AddWithValue("@UserID", UserID);
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }

        public DataTable shoploginsucess(string username, string Password)
        {
            DataTable dt = new DataTable();
            cmd = dbconn.ConnectionWithCommand("sp_ShopLogin");
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", Password);
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }

        public void SendEmail(string toaddress,string Subject,string Body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("us2.smtp.mailhostbox.com");
                mail.From = new MailAddress("support@my-pos-online.com");
                mail.To.Add(toaddress);
                mail.Subject = Subject;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("support@my-pos-online.com", "uYOV%wG1");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception)
            {
                
                
            }
          

           
            
        }
        public DataTable GetShopEmail(string username)
        {
            DataTable dt = new DataTable();
            cmd = dbconn.ConnectionWithCommand("Spo_GetShopEmail");
            cmd.Parameters.AddWithValue("@ShopUserID", username);
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }

        public int ChangeProfile(int ShopID)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_ChangeShopProfile");
            cmd.Parameters.AddWithValue("ShopID", ShopID);
            cmd.Parameters.AddWithValue("ShopName", Helper.ShopName);
            cmd.Parameters.AddWithValue("ShopAddress", Helper.ShopAddress);
            cmd.Parameters.AddWithValue("ShopDescription", Helper.ShopDescription);
            cmd.Parameters.AddWithValue("ShopGSTIN", Helper.ShopGSTIN);
            cmd.Parameters.AddWithValue("ShopTin", Helper.ShopTin);
            cmd.Parameters.AddWithValue("ShopCIN", Helper.ShopCIN);
            cmd.Parameters.AddWithValue("ShopRegNo", Helper.ShopRegNo);
            cmd.Parameters.AddWithValue("ShopOwner", Helper.ShopOwner);
            cmd.Parameters.AddWithValue("ShopOwnerPAN", Helper.ShopOwnerPAN);
            cmd.Parameters.AddWithValue("ShopOwnerMob", Helper.ShopOwnerMob);
            cmd.Parameters.AddWithValue("ShopOwnerOfficeContact", Helper.ShopOwnerOfficeContact);
            cmd.Parameters.AddWithValue("ShopEMail", Helper.ShopEMail);
            cmd.Parameters.AddWithValue("ReportName", Helper.ReportName);
            cmd.Parameters.AddWithValue("ApiUrl", Helper.ApiUrl);
            int i = dbconn.Executenonquery(cmd);
            return i;
        }
        public DataTable ChangePassword(LoginClassBe be)
        {
            DataTable dt = new DataTable();
            cmd = dbconn.ConnectionWithCommand("sp_ChangePassword");
            cmd.Parameters.AddWithValue("@ShopPwdHasKey", be.ShopPasswordHasKey);
            cmd.Parameters.AddWithValue("@ShopUsrid", be.Username);
            cmd.Parameters.AddWithValue("@ShopOldPassword", be.OldPassword);
            cmd.Parameters.AddWithValue("@NewPassword", be.Newpassword);
            dt = dbconn.ExecuteDataSet(cmd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

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

    }
}
