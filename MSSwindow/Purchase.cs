using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MSSEntityFrame;
using System.Data;
using MSSwindow.Connection;

namespace MSSwindow.CommonClass
{
    class Purchase
    {
       // const string POINIT = "SPO";
        
        public string GenerateNewPoNO(int ShopID)
        {
            string PONO = string.Empty;
            string POINIT = Helper.complaintInit;
            MSEntities DB = new MSEntities();
            // int Cnt = DB.SalesHeader.Where(X=>X.Shopid==ShopID).Count();
            //int Cnt = DB.SalesHeader.Where(X => X.ShopID == ShopID).Count();
            int Cnt = GetStockPOno(ShopID);

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
        public void DeletePurchaseOrder(bool IsEditMode=false,int phid = 0)
        {
            if (IsEditMode)
            {
                MSEntities db = new MSEntities();
                var tax = db.PurchaseItemDetail.Where(x => x.SAID == phid);
                foreach (var taxd in tax)
                {
                    db.PurchaseItemDetail.Remove(taxd);
                }
                var itemp = db.PurchaseItemTaxDetail.Where(x => x.SHID == phid);
                foreach (var p in itemp)
                {
                    db.PurchaseItemTaxDetail.Remove(p);
                }


                var headerp = db.purchaseheader.Where(x => x.SAID == phid);
                foreach (var hp in headerp)
                {
                    db.purchaseheader.Remove(hp);
                }
                db.SaveChanges();
            }
        }
        public void SaveSalesOrder(List<PurchaseBe> lstp, List<TaxBe> LstTax, List<ScheduleBE> LSTSchedule, bool IsEditMode = false, int phid = 0)
        {
            MSEntities db = new MSEntities();
            PurchaseBe Phead = new PurchaseBe();
            Phead = lstp.FirstOrDefault();
            var CC = db.purchaseheader.Count();
            int LastID = 0;
            if (CC!=0)
            {
                LastID = db.purchaseheader.Max(X => X.SAID);
            }

            //Delete existing row while save or update
            if (IsEditMode)
            {
                var tax = db.PurchaseItemDetail.Where(x => x.SAID == phid);
                foreach (var taxd in tax)
                {
                    db.PurchaseItemDetail.Remove(taxd);
                }
                var itemp = db.PurchaseItemTaxDetail.Where(x => x.SHID == phid);
                foreach (var p in itemp)
                {
                    db.PurchaseItemTaxDetail.Remove(p);
                }
               

                var headerp = db.purchaseheader.Where(x => x.SAID == phid);
                foreach (var hp in headerp)
                {
                    db.purchaseheader.Remove(hp);
                }




            }
            //-----End Delete
            db.purchaseheader.Add(new purchaseheader
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
                War_ExpDate = Phead.ExpDate

            });
           
            foreach (PurchaseBe PBE in lstp)
            {
                db.PurchaseItemDetail.Add(new PurchaseItemDetail
                {
                    SAID = LastID + 1,
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

            foreach (TaxBe PBE in LstTax)
            {
                db.PurchaseItemTaxDetail.Add(new PurchaseItemTaxDetail
                {
                    SHID = LastID + 1,
                    TaxID = PBE.TaxID,
                    TaxOption = PBE.TaxName,
                    TaxRate = (decimal)PBE.TaxRate,
                    TaxAmount = (decimal)PBE.TaxAmount

                });
            }
           
            db.SaveChanges();
            MoveItemtoMainStore(lstp);

        }

        private void MoveItemtoMainStore(List<PurchaseBe> pur)
        {
            foreach (PurchaseBe item in pur)
            {
                MoveStockIntoMainStore(item.Productid, item.price, item.UnitID, item.Shopid, Helper.ShopUserID,item.qty);
            }
            
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
        public DataSet BindPODetails(string pono, int Shopid)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand cmd;
            cmd = dbconn.ConnectionWithCommand("spo_GetSalesDetail1");
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
 
        public DataSet MoveStockIntoMainStore(int ProductID, decimal ProductPrice,int ProductUnit,int ShopID,string UserID, int ProductQty)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand cmd;
            cmd = dbconn.ConnectionWithCommand("Spo_MoveItemToMainStock");
            cmd.Parameters.AddWithValue("@ProductPrice", ProductPrice);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.Parameters.AddWithValue("@ProductQty", ProductQty);
            cmd.Parameters.AddWithValue("@ProductUnit", ProductUnit);
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
               
            }
            return ds;
        }

        public string GetItemHSNCode(int id, out int unitid, out int Price)
        {
            string address = string.Empty;
            string hsncode = string.Empty;
            // string barcode = string.Empty;
            unitid = 0;
            Price = 0;
            MSEntities db = new MSEntities();
            var ad = db.ProductsMaster.Where(x => x.Productid == id).FirstOrDefault();
            if (ad != null)
            {
                hsncode = ad.HSNCode;

                unitid = ad.Unit == null ? 0 : ad.Unit.Value;
                Price = ad.Price.Value;
            }
            return hsncode;

        }

        public string GetItemHSNCode(int Shopid, int id, out int unitid, out int Price, out string ModelNo, out double CGST, out double SGST, out double IGST)
        {
            string address = string.Empty;
            string hsncode = string.Empty;
            CGST = 0.00;
            SGST = 0.00;
            IGST = 0.00;
            ModelNo = string.Empty;
            unitid = 0;
            Price = 0;
            ProductClass prod = new ProductClass();
            DataSet dsp = new DataSet();
            dsp = prod.BindProducts(Shopid);
            DataView dv = new DataView(dsp.Tables[0]);
            dv.RowFilter = "Productid='" + id + "'";
            hsncode =  dv.ToTable().Rows[0]["HSNCode"].ToString();
            unitid = Convert.ToInt32(dv.ToTable().Rows[0]["unitid"].ToString());
            Price = Convert.ToInt32(dv.ToTable().Rows[0]["price"].ToString());
            ModelNo = dv.ToTable().Rows[0]["ModalNo"].ToString();
            CGST = Convert.ToDouble(dv.ToTable().Rows[0]["CGST"].ToString());
            SGST = Convert.ToDouble(dv.ToTable().Rows[0]["SGST"].ToString());
            IGST = Convert.ToDouble(dv.ToTable().Rows[0]["IGST"].ToString());
            return hsncode;

        }

        public List<PaymentModeBe> GetPaymentMode()
        {
            List<PaymentModeBe> pm = new List<PaymentModeBe>();

            MSEntities db = new MSEntities();

            var ad = (from a in db.PaymentMode
                      where a.IsActive == true
                      select new PaymentModeBe
                      {
                          ID = a.id,
                          Mode = a.Mode
                      }).ToList();


            if (ad != null)
            {
                pm = ad;
            }
            return pm;

        }

        public string GetProductsDetails(string Barcode, out int Productid, out int unitid, out int Price)
        {
            string hsncode = string.Empty;
            string barcode = string.Empty;
            Productid = 0;
            unitid = 0;
            Price = 0;
            MSEntities db = new MSEntities();
            var ad = db.ProductsMaster.Where(x => x.Barcode == Barcode).FirstOrDefault();
            if (ad != null)
            {
                hsncode = ad.HSNCode;
                Productid = ad.Productid == null ? 0 : ad.Productid;
                barcode = ad.Barcode;
                unitid = ad.Unit == null ? 0 : ad.Unit.Value;
                Price = ad.Price.Value;
            }
            return hsncode;

        }
        public int GetPOno(int Shopid)
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

        public int GetStockPOno(int Shopid)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand cmd;
            int PONO = 0;
            cmd = dbconn.ConnectionWithCommand("spo_getStockRefNo");
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
            catch (Exception ex)
            {
                
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
        public DataSet CompleteAMC(int RowID, string Reason)
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
        public DataSet IgnoreAMC(int RowID, string Reason)
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

        public DataSet GetPendingAMC(DateTime StartDate, int ShopID, int? Customerid = 0)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand cmd;

            cmd = dbconn.ConnectionWithCommand("Spo_GetPendingAMC");
            cmd.Parameters.AddWithValue("@ShopID", ShopID);
            cmd.Parameters.AddWithValue("@Date", StartDate);
            cmd.Parameters.AddWithValue("@Customerid", Customerid);
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

        public DataSet BindSMSSchedule(DateTime StartDate, DateTime EndDate, int Dur, string TextSMS)
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
