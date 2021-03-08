using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MSSEntityFrame;
using System.Data;
using MSSwindow.Connection;
using System.Net;
using System.Net.Sockets;

namespace MSSwindow.CommonClass
{
    class Sales
    {
        //const string POINIT = "SPO";
        public string GenerateNewPoNO(int ShopID)
        {
            string PONO = string.Empty;
            string  POINIT = Helper.complaintInit;
            MSEntities DB = new MSEntities();
            // int Cnt = DB.SalesHeader.Where(X=>X.Shopid==ShopID).Count();
            //int Cnt = DB.SalesHeader.Where(X => X.ShopID == ShopID).Count();
            int Cnt = GetPOno(ShopID);

            Cnt = Cnt + 1;

            if (Cnt >= 0 && Cnt < 10)
                PONO = POINIT + "000000" + Cnt.ToString();
            else if (Cnt >= 10 && Cnt < 100)
                PONO = POINIT + "00000" + Cnt.ToString();
            else if (Cnt > 100 && Cnt < 1000)
                PONO = POINIT + "0000" + Cnt.ToString();
            else if (Cnt > 1000 && Cnt < 10000)
                PONO = POINIT + "000" + Cnt.ToString();
            else if (Cnt > 10000 && Cnt < 100000)
                PONO = POINIT + "00" + Cnt.ToString();
            else if (Cnt > 100000 && Cnt < 1000000)
                PONO = POINIT + "0" + Cnt.ToString();
            else if (Cnt > 1000000 && Cnt < 10000000)
                PONO = POINIT + Cnt.ToString();

            return PONO;
        }
        public void DeleteSalesOrder(bool IsEditMode = false, int phid = 0)
        {
            if (IsEditMode)
            {
                MSEntities db = new MSEntities();
                var tax = db.SalesItemDetail.Where(x => x.SAID == phid);
                foreach (var taxd in tax)
                {
                    db.SalesItemDetail.Remove(taxd);
                }
                var itemp = db.SalesItemTaxDetail.Where(x => x.SHID == phid);
                foreach (var p in itemp)
                {
                    db.SalesItemTaxDetail.Remove(p);
                }
                var itemAMC = db.AmcSchedule.Where(x => x.SalesheaderID == phid);
                foreach (var p in itemAMC)
                {
                    db.AmcSchedule.Remove(p);
                }

                var headerp = db.SalesHeader.Where(x => x.SAID == phid);
                foreach (var hp in headerp)
                {
                    db.SalesHeader.Remove(hp);
                }
                var PayDetail = db.Rec_Payment.Where(x => x.OrderID == phid);
                foreach (var hp in PayDetail)
                {
                    db.Rec_Payment.Remove(hp);
                }

                db.SaveChanges();
            }
        }
        public void UpdateSalesOrder(List<PurchaseBe> lstp, List<TaxBe> LstTax, List<ScheduleBE> LSTSchedule, out int Genid,bool IsEditMode = false, int phid = 0,string Userid="")
        {
            MSEntities db = new MSEntities();
            PurchaseBe Phead = new PurchaseBe();
            Phead = lstp.FirstOrDefault();
            Genid = phid;
            //var CC = db.SalesHeader.Count();
            //int LastID = 0;
            //if (CC != 0)
            //{
            //    LastID = db.SalesHeader.Max(X => X.SAID);
            //}
            //Genid = LastID + 1;
            var tax = db.SalesItemDetail.Where(x => x.SAID == phid);
            foreach (var taxd in tax)
            {
                db.SalesItemDetail.Remove(taxd);
            }
            //var itemp = db.SalesItemTaxDetail.Where(x => x.SHID == phid);
            //foreach (var p in itemp)
            //{
            //    db.SalesItemTaxDetail.Remove(p);
            //}
            //var itemAMC = db.AmcSchedule.Where(x => x.SalesheaderID == phid);
            //foreach (var p in itemAMC)
            //{
            //    db.AmcSchedule.Remove(p);
            //}

            //--------------Update Header Table--------------//
            var Sheader = db.SalesHeader.Where(x => x.SAID == phid);
            foreach (var SH in Sheader)
            {
                SH.PoNo = Phead.PONO;
                SH.BookNo = Phead.BookNO;
                SH.PoDate = Phead.PODate;
                SH.CustomerID = Phead.SupID;
                SH.IsActive = true;
                SH.PaidByID = Phead.Mode;
                SH.Remark = Phead.Remark;
                SH.Bankname = Phead.Bankname;
                SH.AccountNumber = Phead.Accountno;
                SH.IFSCCode = Phead.IfscCode;
                SH.vehicleno = Phead.Vechicleno;
                SH.ShopID = Phead.Shopid;
                SH.Is_War_Dur = Phead.IsWaranty;
                SH.War_Dur = Phead.WarDuration;
                SH.War_ExpDate = Phead.ExpDate;
                SH.RefBy = Phead.RefBy;
                SH.deliverymode = Phead.DelMode;
                SH.deliverby = Phead.DeliverBy;
                SH.PaidAmount = Phead.PaidAmt;
                SH.BalanceAmount = Phead.BalAmt;
                SH.PayStatus = Phead.PayStatus;
                SH.UpdatedDateTime = DateTime.Now;
                SH.IPAddress = GetLocalIPAddress();
                SH.UserID = Userid;
                
            }
            db.SaveChanges();
           
            foreach (PurchaseBe PBE in lstp)
            {
                db.SalesItemDetail.Add(new SalesItemDetail
                {
                    SAID = Sheader.FirstOrDefault().SAID,
                    ProductID = PBE.Productid,
                    UnitID = PBE.UnitID,
                    Qty = PBE.qty,
                    Rate = PBE.price,
                    ItemSrNo = PBE.ItemSrNo,
                    ModelNO = PBE.ModelNo,
                    Discount = PBE.disc,
                    NetPrice = PBE.amount,
                    HSNCode = PBE.HSNCode,
                    BasePrice = PBE.BasePrice,
                    IncludingTax = PBE.IsTaxIncluded,
                    CGSTPer = PBE.CGSTPer,
                    SGSTPer = PBE.SGSTPer,
                    IGSTPer = PBE.IGSTPer,
                    CGSTAmt = PBE.CGSTVal,
                    SGSTAmt = PBE.SGSTVal,
                    IGSTAmt = PBE.IGSTVal,
                    NetTax = PBE.NetTax,
                    NetAmt = PBE.NetAmt
                });
            }
            db.SaveChanges();

            //foreach (TaxBe PBE in LstTax)
            //{
            //    db.SalesItemTaxDetail.Add(new SalesItemTaxDetail
            //    {
            //        SHID = Sheader.FirstOrDefault().SAID,
            //        TaxID = PBE.TaxID,
            //        TaxOption = PBE.TaxName,
            //        TaxRate = (decimal)PBE.TaxRate,
            //        TaxAmount = (decimal)PBE.TaxAmount

            //    });
            //}
            //db.SaveChanges();
            foreach (ScheduleBE PBE in LSTSchedule)
            {
                db.AmcSchedule.Add(new AmcSchedule
                {

                    SalesheaderID = Sheader.FirstOrDefault().SAID,
                    Startdate = Convert.ToDateTime(PBE.AMCDate),
                    Entdate = Convert.ToDateTime(PBE.AMCDate),
                    IsActive = PBE.Status,
                    IsDelete = PBE.IgnoreStatus,
                    Remark = PBE.Remark

                });
            }
            db.SaveChanges();
            var headerPay = db.Rec_Payment.Where(x => x.OrderID == phid);
            foreach (var hp in headerPay)
            {
                hp.OrderID = Genid;
            }
            db.SaveChanges();
        }
        public  string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public void SaveSalesOrder(List<PurchaseBe> lstp, List<TaxBe> LstTax, List<ScheduleBE> LSTSchedule,out int GenID,bool IsEditMode = false, int phid = 0,string Userid = "")
        {
            MSEntities db = new MSEntities();
            PurchaseBe Phead = new PurchaseBe();
            Phead = lstp.FirstOrDefault();
            var CC = db.SalesHeader.Count();
            int LastID = 0;
            GenID = 0;
            if (CC != 0)
            {
                LastID = db.SalesHeader.Max(X => X.SAID);
                GenID = LastID + 1;
            }
             
            //-----End Delete
            db.SalesHeader.Add(new SalesHeader
            {
                PoNo = Phead.PONO,
                BookNo = Phead.BookNO,
                PoDate = Phead.PODate,
                CustomerID = Phead.SupID,
                IsActive = true,
                PaidByID = Phead.Mode,
                Remark = Phead.Remark,
                Bankname = Phead.Bankname,
                AccountNumber = Phead.Accountno,
                IFSCCode = Phead.IfscCode,
                vehicleno = Phead.Vechicleno,
                ShopID = Phead.Shopid,
                Is_War_Dur = Phead.IsWaranty,
                War_Dur = Phead.WarDuration,
                War_ExpDate = Phead.ExpDate,
                RefBy = Phead.RefBy,
                deliverymode = Phead.DelMode,
                deliverby = Phead.DeliverBy,
                PaidAmount=Phead.PaidAmt,
                BalanceAmount=Phead.BalAmt,
                PayStatus=Phead.PayStatus,
                InsertedDateTime = DateTime.Now,
                UpdatedDateTime = null,
                IPAddress = GetLocalIPAddress(),
                UserID = Userid,
                IsDelivered = Phead.IsDelivered,
                ExpDelDate = Phead.ExpDelDate.Value.Month==1?null: Phead.ExpDelDate


            });
            foreach (PurchaseBe PBE in lstp)
            {
                db.SalesItemDetail.Add(new SalesItemDetail
                {
                    SAID = LastID + 1,
                    ProductID = PBE.Productid,
                    UnitID = PBE.UnitID,
                    Qty = PBE.qty,
                    Rate = PBE.price,
                    ItemSrNo = PBE.ItemSrNo,
                    ModelNO  = PBE.ModelNo,
                    Discount = PBE.disc,
                    NetPrice = PBE.amount,
                    HSNCode = PBE.HSNCode,
                    BasePrice=PBE.BasePrice,
                    IncludingTax = PBE.IsTaxIncluded,
                    CGSTPer=PBE.CGSTPer,
                    SGSTPer = PBE.SGSTPer,
                    IGSTPer=PBE.IGSTPer,
                    CGSTAmt=PBE.CGSTVal,
                    SGSTAmt=PBE.SGSTVal,
                    IGSTAmt=PBE.IGSTVal,
                    NetTax=PBE.NetTax,
                    NetAmt=PBE.NetAmt
                });
            }

            foreach (TaxBe PBE in LstTax)
            {
                db.SalesItemTaxDetail.Add(new SalesItemTaxDetail
                {
                    SHID = LastID + 1,
                    TaxID = PBE.TaxID,
                    TaxOption = PBE.TaxName,
                    TaxRate = (decimal)PBE.TaxRate,
                    TaxAmount = (decimal)PBE.TaxAmount

                });
            }
            foreach (ScheduleBE PBE in LSTSchedule)
            {
                db.AmcSchedule.Add(new AmcSchedule
                {

                    SalesheaderID = LastID + 1,
                    Startdate = Convert.ToDateTime(PBE.AMCDate),
                    Entdate = Convert.ToDateTime(PBE.AMCDate),
                    IsActive = PBE.Status,
                    IsDelete = PBE.IgnoreStatus,
                    Remark = PBE.Remark

                });
            }
           
           db.SaveChanges();
        }

        public string GetSupplierAddress(int id, out string GSTIN)
        {
            string address = string.Empty;
            GSTIN = string.Empty;
            MSEntities db = new MSEntities();
            var ad = db.CustomerMaster.Where(x => x.Customerid == id).FirstOrDefault();
            if (ad != null)
            {
                address = ad.Address + ' ' + ad.City + ' ' + ad.States + ' ' + ad.Country + ' ' + ad.Pincode;
                GSTIN = ad.GSTIN;
            }

            return address;

        }

        public string GetVendorAddress(int id, out string GSTIN)
        {
            string address = string.Empty;
            GSTIN = string.Empty;
            MSEntities db = new MSEntities();
            var ad = db.SupplierMaster.Where(x => x.Supplierid == id).FirstOrDefault();
            if (ad != null)
            {
                address = ad.Address + ' ' + ad.City + ' ' + ad.States + ' ' + ad.Country + ' ' + ad.Pincode;
                GSTIN = ad.GSTIN;
            }

            return address;

        }

        public string GetSupplierAddressWithContact(int id, out string contact)
        {
            string address = string.Empty;
            contact = string.Empty;
            MSEntities db = new MSEntities();
            var ad = db.CustomerMaster.Where(x => x.Customerid == id).FirstOrDefault();
            if (ad != null)
            {
                address = ad.Address + ' ' + ad.City + ' ' + ad.States + ' ' + ad.Country + ' ' + ad.Pincode;
                contact = ad.Contact;
            }

            return address;

        }

        public string GetCustomerGSTIN(int id)
        {
            string GST = string.Empty;
            MSEntities db = new MSEntities();

            var ad = db.CustomerMaster.Where(x => x.Customerid == id).FirstOrDefault();

            if (ad != null)
                GST = ad.GSTIN;
            return GST;

        }
        public DataSet BindPODetails(string pono, int Shopid,int GenID)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand cmd;
            cmd = dbconn.ConnectionWithCommand("spo_GetSalesDetail1");
            cmd.Parameters.AddWithValue("@Shopid", Shopid);
            cmd.Parameters.AddWithValue("@SONO", pono);
            cmd.Parameters.AddWithValue("@POID", GenID);
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

        public DataSet BindPurchaseDetails(string pono, int Shopid)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand cmd;
            cmd = dbconn.ConnectionWithCommand("spo_GetPurchaseDetail1");
            cmd.Parameters.AddWithValue("@Shopid", Shopid);
            cmd.Parameters.AddWithValue("@SONO", pono);
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

        public int GetPOno(int Shopid)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand cmd;
            int PONO = 0;
            cmd = dbconn.ConnectionWithCommand("spo_getOrderNo");
            cmd.Parameters.AddWithValue("@Shopid", Shopid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    PONO = Convert.ToInt32(ds.Tables[0].Rows[0]["Num"].ToString()); 
                }
            }
            catch (Exception)
            {
                throw;
            }
            return PONO;
        }



        public int GetPurchaseOrderno(int Shopid)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand cmd;
            int PONO = 0;
            cmd = dbconn.ConnectionWithCommand("spo_getPurchaseOrderNo");
            cmd.Parameters.AddWithValue("@Shopid", Shopid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    PONO = Convert.ToInt32(ds.Tables[0].Rows[0]["Num"].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
            return PONO;
        }
        
        public DataSet GetPendingAMCReport(DateTime StartDate, int ShopID)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand cmd;

            cmd = dbconn.ConnectionWithCommand("Spo_GetPendingAMCReport");
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
            cmd.Parameters.AddWithValue("@Date", StartDate);


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
        public DataSet CompleteAMC(int RowID,string Reason)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand cmd;

            cmd = dbconn.ConnectionWithCommand("Spo_MakeAMCCompleted");
            cmd.Parameters.AddWithValue("@RowID", RowID);
            cmd.Parameters.AddWithValue("@Reason", Reason);
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
        public DataSet IgnoreAMC(int RowID,string Reason)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand cmd;
            cmd = dbconn.ConnectionWithCommand("Spo_IgnoreAMC");
            cmd.Parameters.AddWithValue("@RowID", RowID);
            cmd.Parameters.AddWithValue("@Reason", Reason);
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

        public DataSet GetPendingAMC(DateTime StartDate, int ShopID,DateTime? EndDate=null, int? Customerid = 0)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand cmd;

            cmd = dbconn.ConnectionWithCommand("Spo_GetPendingAMC");
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
            cmd.Parameters.AddWithValue("@Date", StartDate);
            cmd.Parameters.AddWithValue("@Customerid", Customerid);
            cmd.Parameters.AddWithValue("@TDate", EndDate);
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

        public DataSet GetCustomerHistory(string Complaintid)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand cmd;
            cmd = dbconn.ConnectionWithCommand("Spo_GetCustomerComplaintHistory");
            cmd.Parameters.AddWithValue("@ComplaintID", Complaintid);
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

        public DataSet GetPendingServices(DateTime StartDate, int ShopID, DateTime? EndDate = null, int? Customerid = 0)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand cmd;

            cmd = dbconn.ConnectionWithCommand("Spo_GetPendingServices");
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
            cmd.Parameters.AddWithValue("@Date", StartDate);
            cmd.Parameters.AddWithValue("@Customerid", Customerid);
            cmd.Parameters.AddWithValue("@TDate", EndDate);
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

        public DataSet GetExpiredWarantyReport(DateTime StartDate, int ShopID)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand cmd;
            cmd = dbconn.ConnectionWithCommand("Spo_GetExpiredWaranty_Repo");
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
            cmd.Parameters.AddWithValue("@Date", StartDate);
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
        public DataSet GetExpiredWaranty(DateTime StartDate, int ShopID)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand cmd;

            cmd = dbconn.ConnectionWithCommand("Spo_GetExpiredWaranty");
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
            cmd.Parameters.AddWithValue("@Date", StartDate);

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
        public DataSet BindAMCSchedule(DateTime StartDate, DateTime EndDate, int Dur)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand cmd;

            cmd = dbconn.ConnectionWithCommand("Spo_GetAMCSchedule");
            cmd.Parameters.AddWithValue("@StartDate", StartDate);
            cmd.Parameters.AddWithValue("@EndDate", EndDate);
            cmd.Parameters.AddWithValue("@Duration", Dur);

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

        public DataSet BindSMSSchedule(DateTime StartDate, DateTime EndDate, int Dur,string TextSMS)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand cmd;

            cmd = dbconn.ConnectionWithCommand("Spo_GetSMSSchedule");
            cmd.Parameters.AddWithValue("@StartDate", StartDate);
            cmd.Parameters.AddWithValue("@EndDate", EndDate);
            cmd.Parameters.AddWithValue("@Duration", Dur);
            cmd.Parameters.AddWithValue("@SMSText", TextSMS);

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
    }
}
