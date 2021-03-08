using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MSSwindow.CommonClass;
using MSSwindow.Connection;
using MSSEntityFrame;

namespace MSSwindow.CommonClass
{
    class ProductClass
    {
        SqlCommand cmd;
        DatabaseConnection dbconn = new DatabaseConnection();

        public DataSet BindProducts(int shopid)
        {

            cmd = dbconn.ConnectionWithCommand("BindProductMaster");
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

        public DataSet BindProductOnSale(int shopid)
        {

            cmd = dbconn.ConnectionWithCommand("BindProductMaster_Sale");
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


        public DataSet ProductDetailsReport(int ShopID)
        {
            cmd = dbconn.ConnectionWithCommand("ProductMasterReport");
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

        public DataSet PurchaseDailyReport(int ShopID)
        {
            cmd = dbconn.ConnectionWithCommand("DailyPurchaseReport");
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

        public DataSet DailyPurchaseReport(int ShopID,DateTime? FrmDate = null,DateTime? Todate = null)
        {
            cmd = dbconn.ConnectionWithCommand("DailyPurchaseReport");
            cmd.Parameters.AddWithValue("@FromDate", FrmDate);
            cmd.Parameters.AddWithValue("@ToDate", Todate);
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

  

        public DataSet AvailableInventory(int ShopID,string Productid,string ItemSrno = null)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_GetItemStock");
            cmd.Parameters.AddWithValue("@ItemSrno", ItemSrno);
            cmd.Parameters.AddWithValue("@ProductID", Productid);
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


        public DataSet DailyPurchaseItemSrNoReport(int ShopID, DateTime? FrmDate = null, DateTime? Todate = null)
        {
            cmd = dbconn.ConnectionWithCommand("DailyPurchaseReport_Item");
            cmd.Parameters.AddWithValue("@FromDate", FrmDate);
            cmd.Parameters.AddWithValue("@ToDate", Todate);
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

        public DataSet DailySalesReport(int ShopID,DateTime? FrmDate = null, DateTime? Todate = null,int? ProdID = null, int? BrandID = null, int? CategoryID = null)
        {
            cmd = dbconn.ConnectionWithCommand("DailySalesReport");
            cmd.Parameters.AddWithValue("@FromDate", FrmDate);
            cmd.Parameters.AddWithValue("@ToDate", Todate);
            cmd.Parameters.AddWithValue("@Shopid", ShopID);
            cmd.Parameters.AddWithValue("@Prodid", ProdID);
            cmd.Parameters.AddWithValue("@BrandID", BrandID);
            cmd.Parameters.AddWithValue("@CategoryID", CategoryID);



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

        public DataSet InvoiceSearch(int ShopID, string TxtSearch)
        {
            cmd = dbconn.ConnectionWithCommand("SearchInvoice");
            cmd.Parameters.AddWithValue("@Shopid", ShopID);
            cmd.Parameters.AddWithValue("@SearchText", TxtSearch);
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

        public DataSet CustomerSlip(int CompID)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_GetCustomerSlip");
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

        public DataSet ShowBarcode(int Shopid,DateTime? FrmDate = null, DateTime? Todate = null)
        {
            cmd = dbconn.ConnectionWithCommand("spo_GenerateBarCode");
            cmd.Parameters.AddWithValue("@Fromdate", FrmDate);
            cmd.Parameters.AddWithValue("@ToDate", Todate);
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
        public DataSet BindDropDownProducts()
        {
            cmd = dbconn.ConnectionWithCommand("BindDDLProductMaster");
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

        public List<ProductClassBe> BrandWiseProduct(int Brandid)
        {
            MSEntities DB = new MSEntities();
            List<ProductClassBe> pm1 = new List<ProductClassBe>();
            pm1 = (from A in DB.ProductsMaster
                   where A.ShopID == Brandid
                   select new ProductClassBe
                   {
                        ProductID = A.Productid ,
                        ProductName = A.Productname
                   }).ToList();
            
            return pm1;
        }

        public List<ProductClassBe> BarcodeWiseProduct(String Barcode)
        {
            MSEntities DB = new MSEntities();
            List<ProductClassBe> pm1 = new List<ProductClassBe>();
            pm1 = (from A in DB.ProductsMaster
                   select new ProductClassBe
                   {
                       ProductID = A.Productid,
                       ProductName = A.Productname
                   }).ToList();

            return pm1;
        }

       

        //public DataTable CategoryWiseBrand(string CategoryName,int ? Shopid = 0)
        //{
        //    DataTable DT = BindProducts(UNI).Tables[0];
        //    DT.Rows.Add("0", "Select", "Select", string.Empty, 1);
        //    DataView DV = new DataView(DT);
        //    DV.RowFilter = "CategoryName = '" + CategoryName + "'";
        //    DataTable dt = new DataTable();
        //    dt = DV.ToTable();
        //    return dt;

        //}
        public DataSet TaxInvoice(string InvoiceNo,int ShopID)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_TaxInvoice_POS");
            cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
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

        public DataSet PurchaseTaxInvoice(string InvoiceNo, int ShopID)
        {
            cmd = dbconn.ConnectionWithCommand("Spo_PurchaseInvoice_POS");
            cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
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
        
        public void InsertUpdateProducts(ProductClassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("dbo.sp_InsertUpdateProducts");
            cmd.Parameters.AddWithValue("@Shopid", be.Shopid);
            cmd.Parameters.AddWithValue("@Productid", be.ProductID);
            cmd.Parameters.AddWithValue("@CategoryProductId", be.CategoryPID);
            cmd.Parameters.AddWithValue("@BrandProductId", be.BrandPID);
            cmd.Parameters.AddWithValue("@ProductCode", be.ProductCode);
            cmd.Parameters.AddWithValue("@Productname", be.ProductName);
            cmd.Parameters.AddWithValue("@Price", be.Price);
            cmd.Parameters.AddWithValue("@Unit", be.Unit);
            cmd.Parameters.AddWithValue("@CGST", be.CGST);
            cmd.Parameters.AddWithValue("@SGST", be.SGST);
            cmd.Parameters.AddWithValue("@IGST", be.IGST);
            cmd.Parameters.AddWithValue("@Barcode", be.Barcode);
            cmd.Parameters.AddWithValue("@HSNCode", be.HSNCode);
            cmd.Parameters.AddWithValue("@ModelNo", be.ModelNo);
            cmd.Parameters.AddWithValue("@Description", be.Description);
            cmd.Parameters.AddWithValue("@IsActive", be.IsActive);
            SqlParameter param = new SqlParameter();
            param.Direction = ParameterDirection.Output;
            param.DbType = DbType.Int32;
            param.ParameterName = "@GenProductID";
            cmd.Parameters.Add(param);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {
                be.ProductID = Convert.ToInt32(cmd.Parameters["@GenProductID"].Value);
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



        public void DeleteProduct(ProductClassBe be)
        {
            cmd = dbconn.ConnectionWithCommand("DeleteBindProductsDetails");
            cmd.Parameters.AddWithValue("@Action", "Delete");
            cmd.Parameters.AddWithValue("@ProductId", be.ProductID);
            int Results = dbconn.Executenonquery(cmd);
            if (Results == 1)
            {
                
            }
        }

    }
}
