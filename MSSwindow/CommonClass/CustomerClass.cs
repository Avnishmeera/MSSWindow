using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MSSwindow.CommonClass;
using MSSwindow.Connection;

namespace MSSwindow.CommonClass
{
    class CustomerClass
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        SqlCommand cmd;

        public DataSet BindCustomers(int ShopID)
        {
            cmd = dbconn.ConnectionWithCommand("BindCustomerMaster");
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


        public DataSet CountRecords(int ShopID)
        {
            cmd = dbconn.ConnectionWithCommand("sp_CountDetails");
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


        public DataTable EmployeeNotificationLog(int CompID)
        {
            cmd = dbconn.ConnectionWithCommand("dbo.sp_NotificationLog");
            cmd.Parameters.AddWithValue("@CompID", CompID);
            DataTable DT = new DataTable();
            DT = dbconn.ExecuteDataSet(cmd);
            return DT;

        }

        public DataTable RentDetails(int ShopID,string Search)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_GetRentDetails");
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
            cmd.Parameters.AddWithValue("@SearchText", Search);
            DataTable DT = new DataTable();
            DT = dbconn.ExecuteDataSet(cmd);
            return DT;

        }

        public DataTable GetFeedBackByOwner(int CompID)
        {
            cmd = dbconn.ConnectionWithCommand("dbo.Spo_GetFeedBackByOwner");
            cmd.Parameters.AddWithValue("@CompID", CompID);
            DataTable DT = new DataTable();
            DT = dbconn.ExecuteDataSet(cmd);
            return DT;

        }

        public int InsertUpdateFeedBackByOwner(OwnerFeedBack be)
        {
            cmd = dbconn.ConnectionWithCommand("Dbo.Spo_SaveComplaintFeedbackByOwner");
            cmd.Parameters.AddWithValue("@FBID", be.FBID);
            cmd.Parameters.AddWithValue("@Charges_iwow", be.Charges_iwow);
            cmd.Parameters.AddWithValue("@CompID", be.CompID);
            cmd.Parameters.AddWithValue("@EMP_BehaviourRating", be.EMP_BehaviourRating);
            cmd.Parameters.AddWithValue("@ServiceQualityRating", be.ServiceQualityRating);
            cmd.Parameters.AddWithValue("@Remark", be.Remark);
            cmd.Parameters.AddWithValue("@NextServiceReminder", be.NextServiceReminder);
            cmd.Parameters.AddWithValue("@NextSerDate", be.NextSerDate);
            int Results = dbconn.Executenonquery(cmd);
            return Results;
        }
        public int NotifyEmployee(NotifyEmployee be)
        {
            cmd = dbconn.ConnectionWithCommand("Dbo.Spo_SendNotificationToEmployee");
            cmd.Parameters.AddWithValue("@NotID", be.NotID);
            cmd.Parameters.AddWithValue("@Details", be.Details);
            cmd.Parameters.AddWithValue("@CompID", be.CompID);
            int Results = dbconn.Executenonquery(cmd);
            return Results;
        }


        public DataSet BindCustomerWarranty(int ShopID,int Customerid)
        {
            cmd = dbconn.ConnectionWithCommand("SPO_GetAMC_Warranty");
            cmd.Parameters.AddWithValue("@Shopid", ShopID);
            cmd.Parameters.AddWithValue("@CustomerID", Customerid);
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

        public DataSet SearchVendor(int ShopID, string Cst)
        {
            cmd = dbconn.ConnectionWithCommand("ashish123.Spo_SearchVendor");
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
            cmd.Parameters.AddWithValue("@init", Cst);
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

        public DataSet SearchCustomers(int ShopID, string Cst)
        {
            cmd = dbconn.ConnectionWithCommand("ashish123.Spo_SearchCustomer");
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
            cmd.Parameters.AddWithValue("@init", Cst);
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


        public DataSet GetCustomersummary(int CstID)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_GetCustomerSummary");
            
            cmd.Parameters.AddWithValue("@CustomerID", CstID);
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

        public DataSet GetCustomerComplaintDetails(int CstID)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_GetComplaintHistory");

            cmd.Parameters.AddWithValue("@CompID", CstID);
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

        public DataSet GetSaleDetails(int CstID)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_GetSaleSummary");

            cmd.Parameters.AddWithValue("@SAID", CstID);
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


        public DataSet GetTotalCharges(int cmpid)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_GetSumCharge");
            cmd.Parameters.AddWithValue("@Complainid", cmpid);
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

        public DataSet CreateRent(Rent Rnt)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_CreateRent");
            cmd.Parameters.AddWithValue("@rentid", Rnt.rentid);
            cmd.Parameters.AddWithValue("@Invoiceid", Rnt.Invoiceid);
            cmd.Parameters.AddWithValue("@productid", Rnt.productid);
            cmd.Parameters.AddWithValue("@customerid", Rnt.customerid);
            cmd.Parameters.AddWithValue("@rentstartdate", Rnt.rentstartdate);
            cmd.Parameters.AddWithValue("@rentenddate", Rnt.rentenddate);
            cmd.Parameters.AddWithValue("@securityAmount", Rnt.securityAmount);
            cmd.Parameters.AddWithValue("@Daliyrentamount", Rnt.Daliyrentamount);
            cmd.Parameters.AddWithValue("@Monthlyrentamount", Rnt.Monthlyrentamount);
            cmd.Parameters.AddWithValue("@Yearlyrentamount", Rnt.Yearlyrentamount);
            cmd.Parameters.AddWithValue("@penaltycharge", Rnt.penaltycharge);
            cmd.Parameters.AddWithValue("@bouncecharge", Rnt.bouncecharge);
            cmd.Parameters.AddWithValue("@policy", Rnt.policy);
            cmd.Parameters.AddWithValue("@servicestartdate", Rnt.servicestartdate);
            cmd.Parameters.AddWithValue("@remserday", Rnt.remserday);
            cmd.Parameters.AddWithValue("@noofser", Rnt.noofser);
            cmd.Parameters.AddWithValue("@remrentday", Rnt.remrentday);
            cmd.Parameters.AddWithValue("@rentcoldays", Rnt.rentcoldays);
            cmd.Parameters.AddWithValue("@isactive", Rnt.isactive);
            cmd.Parameters.AddWithValue("@Price", Rnt.Price);
            cmd.Parameters.AddWithValue("@Qty", Rnt.Qty);
            cmd.Parameters.AddWithValue("@ShopID", Rnt.ShopID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
            }
            catch (Exception)
            {
                
            }
            return ds;
        }

        public DataSet GetAllComplaintStatus(int ShopID,int Catid)
        {
            cmd = dbconn.ConnectionWithCommand("spo_getallcomplaintStatus");
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
            cmd.Parameters.AddWithValue("@CatID", Catid);
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

        public DataSet GetAllComplaintType()
        {
            cmd = dbconn.ConnectionWithCommand("spo_LogType");
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


        public DataSet GetAllItemMaster(int uniqueShopid)
        {
            cmd = dbconn.ConnectionWithCommand("spo_BindItemMaster");
            cmd.Parameters.AddWithValue("@Shopid", uniqueShopid);
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
        public DataSet GetAllComplaintResolutionStatus()
        {
            cmd = dbconn.ConnectionWithCommand("spo_getallcomplaintResolutionStatus");

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

        public DataSet GetAllComplaintResolutionStatus_Summary(int shopid)
        {
            cmd = dbconn.ConnectionWithCommand("spo_getallcomplaintResolutionStatus_Summary");
            cmd.Parameters.AddWithValue("@ShopID", shopid);
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

        public DataSet GenerateComplaint(int ShopID)
        {
            cmd = dbconn.ConnectionWithCommand("SPO_GENERATEComplaintNO");
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
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



        public DataSet GenerateEnquiry(int ShopID)
        {
            cmd = dbconn.ConnectionWithCommand("SPO_GENERATEEnquiryNO");
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
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
        public DataSet SearchCustomerComplaint(string SearchText, int ShopID)
        {
            cmd = dbconn.ConnectionWithCommand("SPO_GETAllComplaint");
            cmd.Parameters.AddWithValue("@SearchText", SearchText);
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
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

        public DataSet SearchCustomerComplaint(string SearchText, int ShopID,string StatusID)
        {
            cmd = dbconn.ConnectionWithCommand("SPO_GETAllComplaint");
            cmd.Parameters.AddWithValue("@SearchText", SearchText);
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
            cmd.Parameters.AddWithValue("@ComplaintStatusIds", StatusID);
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
        public DataSet SearchCustomerEnquiry(string SearchText, int ShopID)
        {
            cmd = dbconn.ConnectionWithCommand("SPO_GETAllEnquiry");
            cmd.Parameters.AddWithValue("@SearchText", SearchText);
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
            }
            catch
            {

            }
            return ds;
        }
        public DataSet DailyFollowup(DateTime SearchText, int ShopID)
        {
            cmd = dbconn.ConnectionWithCommand("SPO_GETDailyEnquiry");
            cmd.Parameters.AddWithValue("@Date", SearchText);
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
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
        public DataSet SearchCustomerAMC(int ShopID, int CstID)
        {
            cmd = dbconn.ConnectionWithCommand("AMCDetails");
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
            cmd.Parameters.AddWithValue("@CustomerID", CstID);
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

        public DataSet SearchCustomerRefNo(int CstID)
        {
            cmd = dbconn.ConnectionWithCommand("sp_GetCustomerMapping");
            cmd.Parameters.AddWithValue("@Customer_id", CstID);
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




        public DataSet GetItemServicesChargeDetails(int Complainid, string CompalinNo)
        {
            cmd = dbconn.ConnectionWithCommand("sp_BindItemServiceCharge");
            cmd.Parameters.AddWithValue("@Complainid", Complainid);
            cmd.Parameters.AddWithValue("@CompalinNo", CompalinNo);
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
        public DataSet GetReceivedAmount(int? Compid=null, int? OrderID=null)
        {
            cmd = dbconn.ConnectionWithCommand("spo_GetPaymentDetails");
            cmd.Parameters.AddWithValue("@CompID", Compid);
            cmd.Parameters.AddWithValue("@OrderID", OrderID);
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
        public DataSet GetItemTotalChargeValue(int ItmID,int CustomerID)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_GetSumCharge");
            cmd.Parameters.AddWithValue("@Complainid", ItmID);
            cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
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

        public DataSet GetPaymentStatus()
        {
            cmd = dbconn.ConnectionWithCommand("Spo_PaymentStatus");
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


        public DataSet GetItemChargeValue(int ItmID)
        {
            cmd = dbconn.ConnectionWithCommand("sp_BindChargeDetails");
            cmd.Parameters.AddWithValue("@Itemid", ItmID);
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

        public DataSet InsertEmiDetails(EMI emobject)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_CreateCustomerEMI");
            cmd.Parameters.AddWithValue("@Shopid", emobject.shopid);
            cmd.Parameters.AddWithValue("@Emi_id", emobject.emiid);
            cmd.Parameters.AddWithValue("@InvoiceID", emobject.invoiceid);
            cmd.Parameters.AddWithValue("@TotalAmount", emobject.TotalAmount);
            cmd.Parameters.AddWithValue("@DownPayment", emobject.DownPayment);
            cmd.Parameters.AddWithValue("@Remaingamount", emobject.TotalAmount);
            cmd.Parameters.AddWithValue("@NOE", emobject.Noemi);
            cmd.Parameters.AddWithValue("@NOD", emobject.Emiduration);
            cmd.Parameters.AddWithValue("@EMIDate", emobject.dateofemi);
            cmd.Parameters.AddWithValue("@RateofInterest", emobject.RateofInterest);
            cmd.Parameters.AddWithValue("@EnableReminder", emobject.EnableReminder);
            cmd.Parameters.AddWithValue("@ReminderBeforeDays", emobject.ReminderBeforeDays);
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

        public DataSet BindEmiDetails(int Invoiceid)
        {
            cmd = dbconn.ConnectionWithCommand("sp_GetEMIDetails");
            cmd.Parameters.AddWithValue("@Invoiceid", Invoiceid);
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




        public int DeleteServiceCharge(int srno)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_DeleteCharge");
            cmd.Parameters.AddWithValue("@Itemsrid", srno);

            int Results = dbconn.Executenonquery(cmd);
            return Results;

        }

        public int DeleteReceivePay(int srno)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_DeleteRecPayment");
            cmd.Parameters.AddWithValue("@PayID", srno);
            int Results = dbconn.Executenonquery(cmd);
            return Results;

        }

        /// <summary>
        /// Show Customer Message Detail
        /// </summary>
        /// <param name="ShopID"></param>
        /// <param name="CstID"></param>
        /// <returns></returns>
        /// 

        public DataSet ShowMessageDetail(int ShopID, string Contactno, DateTime? Fdate = null, DateTime? Todate = null)
        {
            cmd = dbconn.ConnectionWithCommand("dbo.Spo_GetAllMessageList");
            cmd.Parameters.AddWithValue("@FrmDate", Fdate);
            cmd.Parameters.AddWithValue("@ToDate", Todate);
            cmd.Parameters.AddWithValue("@CustomerContact", Contactno);
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
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
        public DataSet ShowpaidDetail(int ShopID, string CustomerID,string EmployeeID,string AdminID,DateTime Fdt,DateTime Tdt)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_GetPaymentList");
            cmd.Parameters.AddWithValue("@Customerid", CustomerID);
            cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmd.Parameters.AddWithValue("@AdminID", AdminID);
            cmd.Parameters.AddWithValue("@Shopid", ShopID);
            cmd.Parameters.AddWithValue("@FrmDate", Fdt);
            cmd.Parameters.AddWithValue("@ToDate", Tdt);
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

        public DataSet ShowUnpaidDetail(int ShopID, string CustomerID)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_GetUnpaidList");
            cmd.Parameters.AddWithValue("@Customerid", CustomerID);
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


        public DataSet ShowUnpaidSalesDetail(int ShopID, string CustomerID)
        {
            cmd = dbconn.ConnectionWithCommand("SearchSalesInvoice");
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
            cmd.Parameters.AddWithValue("@SearchText", CustomerID);
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

        public DataSet ShowEnquiryDetail(int ShopID, string Custid, DateTime? Fdate = null, DateTime? Tdate = null)
        {
            cmd = dbconn.ConnectionWithCommand("SPO_GETCustomerEnquiryDetails");
            cmd.Parameters.AddWithValue("@CustID", Custid);
            cmd.Parameters.AddWithValue("@FDate", Fdate);
            cmd.Parameters.AddWithValue("@TDate", Tdate);
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
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


        public DataSet ShowEmployeeServiceRecord(int ShopID, string EmpID, DateTime? Fdate = null, DateTime? Todate = null)
        {
            cmd = dbconn.ConnectionWithCommand("dbo.Spo_GetServicePerformance");
            cmd.Parameters.AddWithValue("@FrmDate", Fdate);
            cmd.Parameters.AddWithValue("@ToDate", Todate);
            cmd.Parameters.AddWithValue("@EmpID", EmpID);
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
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

        public DataSet ShowEmployeeServiceSummary(int ShopID, string EmpID, DateTime Date)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_GetEmployeeComplaintSummary");
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@EmployeeID", EmpID);
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
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



        public DataSet BindDropDownCustomers(int ShopID)
        {
            cmd = dbconn.ConnectionWithCommand("BindDDLCustomerMaster");
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

        public DataSet BindDelMode()
        {
            cmd = dbconn.ConnectionWithCommand("sp_DelMode");
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

        //------------Attachment Details-----------

        public int InsertUpdateAttachment(int? AttachID, int RefID, string AttachDescription, string FiName)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_InsertAttachment");
            cmd.Parameters.AddWithValue("@AttachID", AttachID);
            cmd.Parameters.AddWithValue("@RefID", RefID);
            cmd.Parameters.AddWithValue("@AttachDescription", AttachDescription);
            cmd.Parameters.AddWithValue("@FiName", FiName);
            int Results = dbconn.Executenonquery(cmd);
            return Results;

        }

        public int DeleteAttachment(int AttachID)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_DeleteUploadFile");
            cmd.Parameters.AddWithValue("@AttachID", AttachID);
            int Results = dbconn.Executenonquery(cmd);
            return Results;

        }

        public DataSet GetAttachMent(int RefID)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_GetUploadFile");
            cmd.Parameters.AddWithValue("@RefID", RefID);
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

        //-------Attachment Upload-----------------

        public void InsertUpdateCustomer(CustomerClassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("sp_InsertUpdateCustomers");
            cmd.Parameters.AddWithValue("@Customerid", be.CustomerId);
            cmd.Parameters.AddWithValue("@Customername", be.CustomerName);
            cmd.Parameters.AddWithValue("@City", be.City);
            cmd.Parameters.AddWithValue("@States", be.State);
            cmd.Parameters.AddWithValue("@StateCode", be.StateCode);
            cmd.Parameters.AddWithValue("@Country", be.Country);
            cmd.Parameters.AddWithValue("@Pincode", be.Pincode);
            cmd.Parameters.AddWithValue("@Emailid", be.Emailid);
            cmd.Parameters.AddWithValue("@Contact", be.Contact);
            cmd.Parameters.AddWithValue("@AltContact", be.AltContact);
            cmd.Parameters.AddWithValue("@Address", be.Address);
            cmd.Parameters.AddWithValue("@Descriptions", be.Descriptions);
            cmd.Parameters.AddWithValue("@Birthdate", be.Birthdate);
            cmd.Parameters.AddWithValue("@Aniversarydate", be.Aniversarydate);
            cmd.Parameters.AddWithValue("@IsActive", be.IsActive);
            cmd.Parameters.AddWithValue("@ShopID", be.ShopID);
            cmd.Parameters.AddWithValue("@MaritalStatus", be.MaritalStatus);
            cmd.Parameters.AddWithValue("@Gender", be.Gender);
            cmd.Parameters.AddWithValue("@ShippingAddress", be.ShippingAddress);
            cmd.Parameters.AddWithValue("@ShippingCity", be.ShippingCity);
            cmd.Parameters.AddWithValue("@ShippingState", be.ShippingState);
            cmd.Parameters.AddWithValue("@ShippingStateCode", be.ShippingStateCode);
            cmd.Parameters.AddWithValue("@ShippingCountry", be.ShippingCountry);
            cmd.Parameters.AddWithValue("@ShippingPinCode", be.ShippingPincode);
            cmd.Parameters.AddWithValue("@SameAsBilling", be.SameAsBilling);
            cmd.Parameters.AddWithValue("@ZoneID", be.ZoneID);
            cmd.Parameters.AddWithValue("@Customertype", be.CustomerType);
            cmd.Parameters.AddWithValue("@Gstin", be.GSTIN);
            SqlParameter param = new SqlParameter();
            param.Direction = ParameterDirection.Output;
            param.DbType = DbType.Int32;
            param.ParameterName = "@GenCustomerID";
            cmd.Parameters.Add(param);

            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {
                be.CustomerId = Convert.ToInt32(cmd.Parameters["@GenCustomerID"].Value);
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess","hhjjj", true);
            }
        }

        public int InsertUpdateCustomerCmplaint(CustomerComplaint be)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_InsertUpdateComplaint");//Using Procedure Pentacare(Spo_InsertUpdateComplaint)
           // cmd = dbconn.ConnectionWithCommand("Spo_InsertUpdateComplaint_test_2");
            cmd.Parameters.AddWithValue("@CompID", be.CompID);
            cmd.Parameters.AddWithValue("@ComplaintID", be.ComplaintID);
            cmd.Parameters.AddWithValue("@ComplaintDate", be.ComplaintDate);
            cmd.Parameters.AddWithValue("@CustomerID", be.CustomerID);
            cmd.Parameters.AddWithValue("@CustomerName", be.CustomerName);
            cmd.Parameters.AddWithValue("@Customeradd", be.CustomerAddress);
            cmd.Parameters.AddWithValue("@CustomerContact", be.CustomerContact);
            cmd.Parameters.AddWithValue("@StatusID", be.StatusID);
            cmd.Parameters.AddWithValue("@EmpID", be.EmpID);
            cmd.Parameters.AddWithValue("@VisitDate", be.VisitDate);
            cmd.Parameters.AddWithValue("@CloseDate", be.CloseDate);
            cmd.Parameters.AddWithValue("@ShopID", be.ShopID);
            cmd.Parameters.AddWithValue("@Remark", be.Remark);
            cmd.Parameters.AddWithValue("@IsNew", be.IsNewCustomer);
            cmd.Parameters.AddWithValue("@ResolutionStatus", be.ResolutionStatusID);
            cmd.Parameters.AddWithValue("@CompStartTime", be.StartTime);
            cmd.Parameters.AddWithValue("@CompEndTime", be.EndTime);
            cmd.Parameters.AddWithValue("@SubmittedBY", be.SubmittedBY);
            cmd.Parameters.AddWithValue("@ReferenceNo", be.ReferenceNo);
            cmd.Parameters.AddWithValue("@LogType", be.ComplaintLogType);
            cmd.Parameters.AddWithValue("@ServiceDate", be.ServiceDate);
            cmd.Parameters.AddWithValue("@ActServiceDate", be.ActualServiceDate);
            cmd.Parameters.AddWithValue("@PayStatus", be.PayStatus);
            cmd.Parameters.AddWithValue("@PrevDuePaid", be.PrevDue);
            cmd.Parameters.AddWithValue("@CurrentChargePaid", be.CurrentCharge);
            cmd.Parameters.AddWithValue("@PaidAmt", be.PaidAmt);
            cmd.Parameters.AddWithValue("@BalAmt", be.BalAmt);
            cmd.Parameters.AddWithValue("@ZoneID", be.ZoneID);
            cmd.Parameters.AddWithValue("@ProductModelNo", be.PModelNo);
            cmd.Parameters.AddWithValue("@ProductExpDate", be.WEXPDate);
            cmd.Parameters.AddWithValue("@WarantyStatus", be.WExpStatus);
            cmd.Parameters.AddWithValue("@AltContact", be.AltContact);
            cmd.Parameters.AddWithValue("@NextServiceCat", be.NextCategoryID);
            int Results = dbconn.Executenonquery(cmd);
            return Results;
        }





        //@Shopid int
        public int SendEmpSMS(CustomerComplaint be)
        {
            cmd = dbconn.ConnectionWithCommand("ashish123.Spo_SendEmpSMS");
            cmd.Parameters.AddWithValue("@ComplaintID", be.ComplaintID);//1
            cmd.Parameters.AddWithValue("@ComplaintDate", be.ComplaintDate);//4
            cmd.Parameters.AddWithValue("@CustomerID", be.CustomerID);//2
            cmd.Parameters.AddWithValue("@StatusID", be.StatusID);//5
            cmd.Parameters.AddWithValue("@empcontact", be.EmpID);//3
            cmd.Parameters.AddWithValue("@ShopID", be.ShopID);//6
            cmd.Parameters.AddWithValue("@compstarttime", be.StartTime);//6
            int Results = dbconn.Executenonquery(cmd);
            return Results;
        }

        public int SendChargeSMS(int CompID)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_BillSummary");
            cmd.Parameters.AddWithValue("@Compid", CompID);//1
            int Results = dbconn.Executenonquery(cmd);
            return Results;
        }

        public int SendHappyCodeSMS(int CompID)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_ResendHappyCode");
            cmd.Parameters.AddWithValue("@Compid", CompID);//1
            int Results = dbconn.Executenonquery(cmd);
            return Results;
        }

        public int InsertUpdateCustomerEnquiry(CustomerComplaint be)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_InsertUpdateEnquiry");
            cmd.Parameters.AddWithValue("@CompID", be.CompID);
            cmd.Parameters.AddWithValue("@ComplaintID", be.ComplaintID);
            cmd.Parameters.AddWithValue("@ComplaintDate", be.ComplaintDate);
            cmd.Parameters.AddWithValue("@CustomerID", be.CustomerID);
            cmd.Parameters.AddWithValue("@CustomerName", be.CustomerName);
            cmd.Parameters.AddWithValue("@Customeradd", be.CustomerAddress);
            cmd.Parameters.AddWithValue("@CustomerContact", be.CustomerContact);
            cmd.Parameters.AddWithValue("@StatusID", be.StatusID);
            cmd.Parameters.AddWithValue("@EmpID", be.EmpID);
            cmd.Parameters.AddWithValue("@VisitDate", be.VisitDate);
            cmd.Parameters.AddWithValue("@CloseDate", be.CloseDate);
            cmd.Parameters.AddWithValue("@ShopID", be.ShopID);
            cmd.Parameters.AddWithValue("@Remark", be.Remark);
            cmd.Parameters.AddWithValue("@IsNew", be.IsNewCustomer);
            cmd.Parameters.AddWithValue("@ResolutionStatus", be.ResolutionStatusID);

            int Results = dbconn.Executenonquery(cmd);
            return Results;
        }

        public DataTable InsertNotification(string Contact, string SMSText, int ShopID, DateTime ScheduedDate)
        {
            cmd = dbconn.ConnectionWithCommand("SP_insertNotification");
            cmd.Parameters.AddWithValue("@Contact", Contact);
            cmd.Parameters.AddWithValue("@MessageText", SMSText);
            cmd.Parameters.AddWithValue("@Shopid", ShopID);
            cmd.Parameters.AddWithValue("@ScheduledDate", ScheduedDate);
            DataTable DT = new DataTable();
            DT = dbconn.ExecuteDataSet(cmd);
            return DT;

        }



        public void DeleteCustomer(CustomerClassBe be)
        {
            // cmd = dbconn.ConnectionWithCommand("DeleteSuppliersDetails");
            cmd = dbconn.ConnectionWithCommand("DeleteBindCustomersDetails");
            cmd.Parameters.AddWithValue("@Action", "Delete");
            cmd.Parameters.AddWithValue("@CustomerId", be.CustomerId);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess","hhjjj", true);
            }
        }

        public DataTable BindTextBoxCustomer(CustomerClassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("DeleteBindCustomersDetails");
            cmd.Parameters.AddWithValue("@Action", "BindTextBoxValues");
            cmd.Parameters.AddWithValue("@CustomerId",be.CustomerId);
            DataTable dt = new DataTable();
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }





        public int InsertUpdateServiceCharge(int Cmpid, string ComplainNo, int Serviceid, int Amount,int Qty,int TotalCharge)
        {
            cmd = dbconn.ConnectionWithCommand("sp_ItemServiceCharge");
            cmd.Parameters.AddWithValue("@Complainid", Cmpid);
            cmd.Parameters.AddWithValue("@CompalinNo", ComplainNo);
            cmd.Parameters.AddWithValue("@ServiceID", Serviceid);
            cmd.Parameters.AddWithValue("@ServiceCharge", Amount);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.Parameters.AddWithValue("@TotalCharge", TotalCharge);
            int Results = dbconn.Executenonquery(cmd);
            return Results;
        }

        public int InsertUpdateReceivePayment(int? OrderID, int? CompID, int ModeID, int Amount, DateTime PayDate, int PaymentType,string Remark)
        {
            cmd = dbconn.ConnectionWithCommand("spo_insertPayment");
            cmd.Parameters.AddWithValue("@OrderID", OrderID);
            cmd.Parameters.AddWithValue("@CompID", CompID);
            cmd.Parameters.AddWithValue("@ModeID", ModeID);
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.Parameters.AddWithValue("@PayDate", PayDate);
            cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
            cmd.Parameters.AddWithValue("@Remark", Remark);
            int Results = dbconn.Executenonquery(cmd);
            return Results;
        }

        public int InsertEmiPayment(int? EmiDetailsid, int? Invoceid, int Paymode,string Remark)
        {
            cmd = dbconn.ConnectionWithCommand("sp_UpdateEmiDetails");
            cmd.Parameters.AddWithValue("@EmiDetailsid", EmiDetailsid);
            cmd.Parameters.AddWithValue("@Invoceid", Invoceid);
            cmd.Parameters.AddWithValue("@Paymode", Paymode);
            cmd.Parameters.AddWithValue("@Remarks", Remark);          
            int Results = dbconn.Executenonquery(cmd);
            return Results;
        }

        public int InsertUpdateStock(StockBE ST)
        {
  
           cmd = dbconn.ConnectionWithCommand("Spo_AddItemToStock");
            cmd.Parameters.AddWithValue("@StockID", ST.StockID);
            cmd.Parameters.AddWithValue("@StockDate", ST.StockDate);
            cmd.Parameters.AddWithValue("@StockRef", ST.StockRef);
            cmd.Parameters.AddWithValue("@SupplierID", ST.SupplierID);
            cmd.Parameters.AddWithValue("@ReceivedBy", ST.ReceivedBy);
            cmd.Parameters.AddWithValue("@ShopID", ST.ShopID);
            cmd.Parameters.AddWithValue("@ItemDetail", ST.ItemDetail);
            int Results = dbconn.Executenonquery(cmd);
            return Results;
        }

        public int DeleteNotification(int NotID)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_DeleteNotification");
            cmd.Parameters.AddWithValue("@NotID", NotID);
            int Results = dbconn.Executenonquery(cmd);
            return Results;
        }

        public DataTable BindCustomerNotification(DateTime Date, string ContactNo,int ShopID)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_GetAllNotification");
            cmd.Parameters.AddWithValue("@NotificationDate", Date);
            cmd.Parameters.AddWithValue("@ContactNo", ContactNo);
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
            DataTable dt = new DataTable();
            dt = dbconn.ExecuteDataSet(cmd);
            return dt;
        }


    }
}

