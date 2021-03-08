using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSSwindow.CommonClass;
using MSSEntityFrame;

namespace MSSwindow
{
    public partial class FrmAddStock : Form
    {

        DataSet dsCustDetail = new DataSet();
        DataSet dsProduct = new DataSet();
        string SelectedCustomerID = "0";
        string SelectedProductID = "0";
        DataTable dtProduct = new DataTable();
        public DataTable dtTax = new DataTable();
        public DataTable dtAMCSchedule = new DataTable();
        public DataTable dtUPAMCSchedule = new DataTable();
        private bool IsEdit = false;
        private bool IsEditMode = false;
        private int EditRowIndex = 0;
        private readonly int UniqueShopID = 0;
        DataTable dtListProduct = new DataTable();
        DataTable dtdbProduct = new DataTable();
        int? HeaderID;



        public FrmAddStock(bool IsEditm, int ShopID)
        {
            InitializeComponent();
            IsEditMode = IsEditm;
            UniqueShopID = ShopID;

            CustomerClass CSL = new CustomerClass();
            dsCustDetail = CSL.SearchVendor(UniqueShopID, TxtEmp.Text);
            ProductClass prod = new ProductClass();

            CategoryclassBe be = new CategoryclassBe();
            be.Shopid = UniqueShopID;
            CategoryClass cc = new CategoryClass();
            dtProduct = cc.BindItemMaster(be);

        }

        public FrmAddStock(bool IsEditm, int ShopID,int HeadID)
        {
            InitializeComponent();
            IsEditMode = IsEditm;
            UniqueShopID = ShopID;
            HeaderID = HeadID;
        }

        private void BindStockDetails(int Shopid,int? HeadID)
        {
            Stock stk = new Stock();
            DataSet ds = new DataSet();

            ds = stk.BindStock(Shopid, HeadID);

            DataTable DTHead = new DataTable();
            DataTable DTItem = new DataTable();
            DataTable DTDbitem = new DataTable();

            DTHead = ds.Tables[0];
            DTItem = ds.Tables[1];
            if (DTHead.Rows.Count > 0)
            {
                txtPono.Text = DTHead.Rows[0]["StockRef"].ToString();
                txtPurdate.Value = Convert.ToDateTime(DTHead.Rows[0]["stockdate"].ToString());
                SelectedCustomerID= DTHead.Rows[0]["SupplierID"].ToString();
                TxtEmp.Text = DTHead.Rows[0]["SupplierName"].ToString();
            }
            DTDbitem = ds.Tables[2];
            dtListProduct = DTItem;
            dtdbProduct = DTDbitem;
            dataGridViewItemDetails.DataSource = DTItem;






        }

        public void InitializeControl()
        {
            CustomerClass CSL = new CustomerClass();
            dsCustDetail = CSL.SearchVendor(UniqueShopID, TxtEmp.Text);
            BindSupplierDropDown();
        }

        public void BindSupplierDropDown()
        {
            SupplierClass sup = new SupplierClass();
            //cmbSupplierName.Items.Insert(0, "---Select----");
            cmbSupplierName.DataSource = sup.BindDropDownSuppliers(UniqueShopID).Tables[0];
            cmbSupplierName.DisplayMember = "Suppliername";
            cmbSupplierName.ValueMember = "Supplierid";
        }

        private void AddTaxDataTableColumn()
        {
            dtTax.Columns.Add("TaxID", typeof(System.Int32));
            dtTax.Columns.Add("TaxName", typeof(System.String));
            dtTax.Columns.Add("TaxRate", typeof(System.String));
            dtTax.Columns.Add("TaxOption", typeof(System.String));
            dtTax.Columns.Add("TaxAmount", typeof(System.Decimal));

        }

        private void AddAMCSchedule()
        {
            dtAMCSchedule.Columns.Add("AMCID", typeof(System.Int32));
            dtAMCSchedule.Columns.Add("ScheduleDate", typeof(System.DateTime));
            dtAMCSchedule.Columns.Add("Status", typeof(System.Boolean));
            dtAMCSchedule.Columns.Add("IgnoreStatus", typeof(System.Boolean));
            dtAMCSchedule.Columns.Add("Remark", typeof(System.String));

        }
        private void BindTaxesDropDown()
        {
            TaxesClass tc = new TaxesClass();
            //cmbTaxname.Items.Insert(0, "---Select----");
            //cmbTaxname.DataSource = tc.BindDropDownTaxes().Tables[0];
            //cmbTaxname.DisplayMember = "Taxname";
            //cmbTaxname.ValueMember = "Taxid";
        }

        private void BindProductsDropDown()
        {
            //ProductClass PC = new ProductClass();
            //cmbProductname.Items.Insert(0, "---Select----");
            //cmbProductname.DataSource = PC.BindDropDownProducts().Tables[0];
            //cmbProductname.DisplayMember = "Productname";
            //cmbProductname.ValueMember = "Productid";

        }

        private void PurchaseDetails_Load(object sender, EventArgs e)
        {
            if (IsEditMode)
            {
                txtPono.Enabled = true;
                txtPono.ReadOnly = false;
            }
            BindSupplierDropDown();
            BindUnitDropdown();
            AddTableColumn();
            GeneratePoNo();
            if (IsEditMode)
                BindStockDetails(UniqueShopID, HeaderID);
        }
        private void BindTaxValue(int TaxID)
        {
            //TxtGST.Text = string.Empty;
            //MSEntities db = new MSEntities();
            //List<TaxesMaster> tx = new List<TaxesMaster>();
            //tx = db.TaxesMaster.Where(x => x.Taxid == TaxID).ToList();
            //foreach (TaxesMaster TX in tx)
            //{
            //    TxtGST.Text = Convert.ToDecimal(TX.Rate).ToString();
            //}


        }
        private void BindPaymentMode()
        {
            List<PaymentModeBe> paym = new List<PaymentModeBe>();
            Purchase p = new Purchase();
            paym = p.GetPaymentMode();


        }

        private void GeneratePoNo()
        {
            string pono = string.Empty;
            //CustomerClass cls = new CustomerClass();
            //txtPono.Text = cls.GenerateComplaint(UniqueShopID).Tables[0].Rows[0][0].ToString();
            //txtPono.Text = pono;
            Purchase P = new Purchase();
            pono = P.GenerateNewPoNO(UniqueShopID);
            txtPono.Text = pono;
        }
        public void CalculateTaxAmount(DataTable dt, bool? IsTaxIncluded = false)
        {
            dtTax = dt;
            List<TaxBe> lp = new List<TaxBe>();
            lp = (from a in dtTax.AsEnumerable()
                  select new TaxBe
                  {
                      TaxAmount = Convert.ToDecimal(a["TaxAmount"].ToString()),
                  }).ToList();

            ShowItemSummary();

        }
        public void CalculateTaxAmount(DataTable dt, decimal NetAmount, bool? IsTaxIncluded = false)
        {
            dtTax = dt;
            foreach (DataRow item in dtTax.Rows)
            {
                if (item["TaxOption"].ToString() == "%")
                    item["TaxAmount"] = ((Convert.ToDecimal(item["TaxRate"]) * NetAmount) / 100).ToString();
                if (item["TaxOption"].ToString() == "Rs.")
                    item["TaxAmount"] = (Convert.ToDecimal(item["TaxRate"]) + NetAmount).ToString();
            }
            dtTax.AcceptChanges();
            List<TaxBe> lp = new List<TaxBe>();
            lp = (from a in dtTax.AsEnumerable()
                  select new TaxBe
                  {
                      TaxAmount = Convert.ToDecimal(a["TaxAmount"].ToString())

                  }).ToList();

            ShowItemSummary();

        }

        private void AddTableColumn()
        {

            dtListProduct.Columns.Add("Sno", typeof(System.Int32));
            dtListProduct.Columns.Add("dbid", typeof(System.Int32));
            dtListProduct.Columns.Add("ProductID", typeof(System.Int32));
            dtListProduct.Columns.Add("ItemName", typeof(System.String));
            dtListProduct.Columns.Add("UnitID", typeof(System.Int32));
            dtListProduct.Columns.Add("UnitName", typeof(System.String));
            dtListProduct.Columns.Add("Qty", typeof(System.Int32));
            dtListProduct.Columns.Add("Price", typeof(System.Int32));
            dtListProduct.Columns.Add("Total", typeof(System.Int32));

            dtdbProduct.Columns.Add("StockID", typeof(System.Int32));
            dtdbProduct.Columns.Add("ItemID", typeof(System.Int32));
            dtdbProduct.Columns.Add("UnitID", typeof(System.Int32));
            dtdbProduct.Columns.Add("Qty", typeof(System.Int32));
            dtdbProduct.Columns.Add("Price", typeof(System.Int32));
            dtdbProduct.Columns.Add("Total", typeof(System.Int32));
            dtdbProduct.Columns.Add("IsActive", typeof(System.Boolean));

        }

        private void AddDataTableColumn()
        {
            dtTax.Columns.Add("TaxID", typeof(System.Int32));
            dtTax.Columns.Add("TaxName", typeof(System.String));
            dtTax.Columns.Add("TaxOption", typeof(System.String));
            dtTax.Columns.Add("TaxAmount", typeof(System.Decimal));

        }
        private void BindCategoryDropdown()
        {
            CategoryClass cc = new CategoryClass();
            DataTable dt = new DataTable();
            dt = cc.BindDropDownCategory().Tables[0];
            // dt.Rows.Add("0", "Select");           
            DataView dv = new DataView(dt);
            dv.Sort = "Categoryid desc";



        }


        private void BindBrandDropdown()
        {
            Brands brnd = new Brands();
            DataTable dt = new DataTable();
            int Uniqueshopid = 0;



        }
        #region Properties

        public string UnitName
        {
            get
            {
                if (cmbUnit.Text != string.Empty)
                {
                    return cmbUnit.Text;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        //public string PName
        //{
        //    get
        //    {
        //        if (cmbProductname.Text != string.Empty)
        //        {
        //            return cmbProductname.Text;
        //        }
        //        else
        //        {
        //            return string.Empty;
        //        }
        //    }
        //}


        public int UnitIDS
        {
            get
            {
                if (cmbUnit.SelectedValue != "0")
                {
                    return Convert.ToInt32(cmbUnit.SelectedValue);
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                cmbUnit.SelectedValue = value.ToString();
            }
        }


        public decimal ProductQuantity
        {
            get
            {
                if (txtQty.Text != string.Empty)
                {
                    return Convert.ToDecimal(txtQty.Text);
                }
                else
                {
                    return decimal.Zero;
                }
            }
            set
            {
                txtQty.Text = value.ToString();
            }
        }

        public decimal ProductPrice
        {
            get
            {
                if (txtPrice.Text != string.Empty)
                {
                    return Convert.ToDecimal(txtPrice.Text);
                }
                else
                {
                    return decimal.Zero;
                }
            }
            set
            {
                txtPrice.Text = value.ToString();
            }
        }


        public decimal ProductNetAmount
        {
            get
            {
                if (txtAmount.Text != string.Empty)
                {
                    return Convert.ToDecimal(txtAmount.Text);
                }
                else
                {
                    return decimal.Zero;
                }
            }
            set
            {
                txtAmount.Text = value.ToString();
            }
        }



        #endregion
        private void BindUnitDropdown()
        {

            UnitClass UC = new UnitClass();
            DataTable dt = new DataTable();
            dt = UC.BindDropDownUnit(UniqueShopID).Tables[0];
            dt.Rows.Add("0", "Select");
            DataView dv = new DataView(dt);
            dv.Sort = "Unitid asc";
            cmbUnit.DataSource = dv.ToTable();
            cmbUnit.DisplayMember = "Unitname";
            cmbUnit.ValueMember = "Unitid";
        }
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            SupplierDetails sup = new SupplierDetails(this, UniqueShopID);
            sup.ShowDialog();
            //CustomerDetails cd = new CustomerDetails(this, UniqueShopID);
            //cd.ShowDialog();
        }

        private void btnAddPurchaseItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedProductID))
            {
                MessageBox.Show(this, "Please Select Product.", "Stock Item", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                TxtProduct.Focus();
                return;
            }
            if (cmbUnit.SelectedValue == "0")
            {
                MessageBox.Show(this, "Please Enter Unit.", "Stock Item", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                cmbUnit.Focus();
                return;
            }
            if (IsEditMode == false)
            {
                dtListProduct.Rows.Add(dtListProduct.Rows.Count + 1, 0, Convert.ToInt32(SelectedProductID), TxtProduct.Text, Convert.ToInt32(cmbUnit.SelectedValue), cmbUnit.Text, Convert.ToInt32(txtQty.Text), Convert.ToInt32(txtPrice.Text), Convert.ToInt32(txtAmount.Text));
                dataGridViewItemDetails.DataSource = dtListProduct;
                dtdbProduct.Rows.Add(null, Convert.ToInt32(SelectedProductID), Convert.ToInt32(cmbUnit.SelectedValue), Convert.ToInt32(txtQty.Text), Convert.ToInt32(txtPrice.Text), Convert.ToInt32(txtAmount.Text), true);
                ResetItemControl();
            }

        }
        private void ResetItemControl()
        {
            SelectedProductID = "0";
            TxtProduct.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtAmount.Text = string.Empty;
            cmbUnit.SelectedValue = "0";
        }

        private void ResetAllControl()
        {
            SelectedProductID = "0";
            TxtProduct.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtAmount.Text = string.Empty;
            cmbUnit.SelectedValue = "0";
            SelectedCustomerID = "0";
            TxtEmp.Text = string.Empty;
            txtadd.Text = string.Empty;
            txtGstin.Text = string.Empty;
            TxtContact.Text = string.Empty;
            
        }
        private void AddOrder()
        {

        }

        private void ResetControl()
        {
            TxtProduct.Text = string.Empty;
            BrandWiseProduct(UniqueShopID);
            cmbUnit.SelectedValue = "0";
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCategoryname_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindBrandDropdown();
        }

        private void cmbBrandName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CalculateTaxByNewLogic(DataTable dtprod, decimal GST, string TypeTx)
        {
            foreach (DataRow item in dtprod.Rows)
            {
                if (Convert.ToBoolean(item["TaxIncluded"]) == true)
                {
                    decimal Namount = CalculateNetAmount(Convert.ToDecimal(item["BasePrice"]), GST);
                    item["Price"] = Math.Round(Namount, 2).ToString();
                    item["NetAmount"] = Math.Round((Namount * Convert.ToDecimal(item["Qty"])), 2).ToString();

                }
                else
                {
                    decimal Namount = Convert.ToDecimal(item["BasePrice"]);
                    item["Price"] = Convert.ToDecimal(item["BasePrice"]).ToString();
                    item["NetAmount"] = (Namount * Convert.ToDecimal(item["Qty"])).ToString();

                }

            }
            dtprod.AcceptChanges();
            dataGridViewItemDetails.DataSource = dtprod;
            ShowItemSummary(GST, TypeTx);

        }

        private decimal CalculateNetAmount(decimal NAmount, decimal Rate)
        {

            return (NAmount * 100) / (100 + Rate);


        }
        private void BrandWiseProduct(int BrandID)
        {
            ProductClass cls = new ProductClass();
            List<ProductClassBe> pm = new List<ProductClassBe>();
            pm = cls.BrandWiseProduct(UniqueShopID);
            DataTable DTP = new DataTable();
            DTP.Columns.Add("ProductID", typeof(System.Int32));
            DTP.Columns.Add("ProductName", typeof(System.String));
            DTP.Rows.Add(0, "Select");
            foreach (ProductClassBe item in pm)
            {
                DTP.Rows.Add(item.ProductID, item.ProductName);
            }

        }


        private void BarcodeWiseProduct(String Barcode)
        {
            ProductClass cls = new ProductClass();
            List<ProductClassBe> pm = new List<ProductClassBe>();
            pm = cls.BarcodeWiseProduct(Barcode);
            DataTable DTP = new DataTable();
            DTP.Columns.Add("ProductID", typeof(System.Int32));
            DTP.Columns.Add("ProductName", typeof(System.String));
            DTP.Rows.Add(0, "Select");
            foreach (ProductClassBe item in pm)
            {
                DTP.Rows.Add(item.ProductID, item.ProductName);
            }

        }

        private void ProductWiseHSNCODE(int Productid)
        {
            ProductClass cls = new ProductClass();
            List<ProductClassBe> pm = new List<ProductClassBe>();
            pm = cls.BrandWiseProduct(UniqueShopID);
            DataTable DTP = new DataTable();
            DTP.Columns.Add("ProductID", typeof(System.Int32));
            DTP.Columns.Add("HSNCode", typeof(System.String));
            foreach (ProductClassBe item in pm)
            {
                DTP.Rows.Add(item.ProductID, item.ProductName);
            }



        }
        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }
        private void BindTax()
        {
            //MSEntities db = new MSEntities();
            //List<TaxBe> tx = new List<TaxBe>();

            //tx = (from a in db.TaxesMaster
            //      where a.IsActive == true
            //      && a.Shopid == UniqueShopID
            //      select new TaxBe
            //      {
            //          TaxID = a.Taxid,
            //          TaxName = a.Taxname
            //      }).ToList();
            //tx.Add(new TaxBe { TaxID = 0, TaxName = "Select" });
            //CmbTax.DataSource = tx.OrderBy(x => x.TaxID).ToList();
            //CmbTax.ValueMember = "TaxID";

            //CmbTax.DisplayMember = "Taxname";


        }
        private void CalculatedValue()
        {


        }

        private bool CheckExistingProduct(int id)
        {
            bool exist = false;
            List<PurchaseBe> lp = new List<PurchaseBe>();
            lp = (from a in dtProduct.AsEnumerable()
                  select new PurchaseBe
                  {
                      Productid = Convert.ToInt32(a["Productid"].ToString())
                  }).ToList();
            var p = lp.Where(x => x.Productid == id).FirstOrDefault();
            if (p != null)
            {
                exist = true;
            }
            return exist;
        }

        private void ShowItemSummary()
        {
            List<PurchaseBe> lp = new List<PurchaseBe>();
            lp = (from a in dtProduct.AsEnumerable()
                  select new PurchaseBe
                  {
                      amount = Convert.ToDecimal(a["NetAmount"].ToString()),
                      price = Convert.ToDecimal(a["Price"].ToString()),
                      disc = Convert.ToDecimal(a["Discount"].ToString()),
                      qty = Convert.ToInt32(a["Qty"].ToString()),
                  }).ToList();
            var disct = lp.Sum(x => x.disc);
            var amountt = lp.Sum(x => x.amount);

        }

        private void ShowItemSummary(decimal Rate, string Typetx)
        {
            dtTax.Rows.Clear();
            List<PurchaseBe> lp = new List<PurchaseBe>();
            lp = (from a in dtProduct.AsEnumerable()
                  select new PurchaseBe
                  {
                      amount = Convert.ToDecimal(a["NetAmount"].ToString()),
                      price = Convert.ToDecimal(a["Price"].ToString()),
                      disc = Convert.ToDecimal(a["Discount"].ToString()),
                      qty = Convert.ToInt32(a["Qty"].ToString()),
                  }).ToList();
            var disct = lp.Sum(x => x.disc);
            var amountt = lp.Sum(x => x.amount);

            if (Typetx == "SC")
            {

                //      dtTax.Columns.Add("TaxID", typeof(System.Int32));
                //dtTax.Columns.Add("TaxName", typeof(System.String));
                //dtTax.Columns.Add("TaxRate", typeof(System.String));
                //dtTax.Columns.Add("TaxOption", typeof(System.String));
                //dtTax.Columns.Add("TaxAmount", typeof(System.Decimal));

            }
            else
            {

            }

        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (txtQty.Text == string.Empty)
            {
                txtAmount.Text = string.Empty;
            }
            else if (txtPrice.Text == string.Empty)
            {
                txtAmount.Text = string.Empty;
            }
            else
                txtAmount.Text = (Convert.ToInt32(txtQty.Text) * Convert.ToInt32(txtPrice.Text)).ToString();


        }
        private void ShowTaxValues()
        {
            double CGSTVal = 0.00;
            double SGSTVal = 0.00;
            double IGSTVal = 0.00;
            double BasePrice = 0.00;

            double CGST = 0.00;
            double SGST = 0.00;
            double IGST = 0.00;


            if (txtAmount.Text != string.Empty)
            {

            }

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtQty.Text == string.Empty)
            {
                txtAmount.Text = string.Empty;
            }
            else if (txtPrice.Text == string.Empty)
            {
                txtAmount.Text = string.Empty;
            }
            else
                txtAmount.Text = (Convert.ToInt32(txtQty.Text) * Convert.ToInt32(txtPrice.Text)).ToString();



        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculatedValue();
            ShowTaxValues();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (EditRowIndex > 0)
            {
                DataRow[] dr1 = dtProduct.Select("Sno='" + EditRowIndex + "'");
                dtProduct.Rows.Remove(dr1[0]);
                int i = 1;
                foreach (DataRow dr in dtListProduct.Rows)
                {
                    dr["Sno"] = 1;
                    i = i + 1;
                }
                dtListProduct.AcceptChanges();
                dataGridViewItemDetails.DataSource = dtListProduct;
                MessageBox.Show(this, "Item Removed Succesfully.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                ShowItemSummary();


            }
            else
            {
                MessageBox.Show(this, "Please Select a row in below list to delete.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnAddTax_Click(object sender, EventArgs e)
        {

        }



        private void dataGridViewItemDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Save Record?", "Service Item Stock", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CustomerClass CLS = new CustomerClass();
                StockBE stb = new StockBE();
                stb.StockRef = txtPono.Text;
                stb.SupplierID = Convert.ToInt32(SelectedCustomerID);
                stb.StockID = HeaderID;
                stb.StockDate = txtPurdate.Value;
                stb.ReceivedBy = 0;
                stb.ShopID = UniqueShopID;
                stb.ItemDetail = dtdbProduct;
                int i = CLS.InsertUpdateStock(stb);
                if (i > 0)
                {
                    MessageBox.Show(this, "Stock Added Successfully.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    ResetAllControl();
                    GeneratePoNo();
                }
                else
                {
                    MessageBox.Show(this, "Some thing Went Wrong.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                

            }
        }

        
        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }


        }

        private void cmbSupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sales p = new Sales();
            string GSTIN = string.Empty;
            int i = Convert.ToInt32(cmbSupplierName.SelectedIndex);
            if (i != 0)
            {
                txtadd.Text = p.GetVendorAddress(Convert.ToInt32(cmbSupplierName.SelectedValue), out GSTIN);
                txtGstin.Text = GSTIN;
            }

        }

        private void txtPono_Leave(object sender, EventArgs e)
        {
            if (IsEditMode)
            {
                Sales pe = new Sales();
                DataSet ds = new DataSet();
                ds = pe.BindPurchaseDetails(txtPono.Text, UniqueShopID);
                if (ds.Tables.Count > 0)
                {
                    DataTable dthead = new DataTable();
                    DataTable dtItem = new DataTable();
                    DataTable dttaxd = new DataTable();
                    //DataTable dtAMC = new DataTable();
                    dthead = ds.Tables[0];
                    dtItem = ds.Tables[1];
                    dttaxd = ds.Tables[2];
                    dtUPAMCSchedule = ds.Tables[3];

                    if (dthead.Rows.Count > 0)
                    {

                        txtPurdate.Text = Convert.ToDateTime(dthead.Rows[0]["PoDate"].ToString()).ToString();
                        cmbSupplierName.SelectedValue = dthead.Rows[0]["CustomerID"].ToString();
                        TxtEmp.Text = cmbSupplierName.Text;
                        LstEmp.Visible = false;

                    }
                    if (dtItem.Select("Productname='AMC'").Count() > 0)
                    {

                    }
                    else
                    {

                    }

                    dtProduct = dtItem;
                    dataGridViewItemDetails.DataSource = dtProduct;
                    dtTax = dttaxd;
                    ShowTaxOnEdit(dtTax);
                    CalculateTaxAmount(dtTax);

                }

            }
        }
        private void ShowTaxOnEdit(DataTable dtTax)
        {
            decimal Rate = decimal.Zero;


        }
        public void BindCustomerDropDownOnSales()
        {
            CustomerClass cup = new CustomerClass();
            DataTable dt = new DataTable();
            dt.Columns.Add("Customerid", typeof(System.Int32));
            dt.Columns.Add("Customername", typeof(System.String));
            dt = cup.BindDropDownCustomers(UniqueShopID).Tables[0];


            if (dt.Rows.Count > 0)
            {
                DataView dv = new DataView(dt);
                //dv.Sort = "Customerid desc";
                cmbSupplierName.DataSource = dv.ToTable();
                cmbSupplierName.DisplayMember = "Customername";
                cmbSupplierName.ValueMember = "Customerid";
                cmbSupplierName.SelectedIndex = 0;
                Sales p = new Sales();
                string GSTIN = string.Empty;
                txtadd.Text = p.GetSupplierAddress(Convert.ToInt32(cmbSupplierName.SelectedValue), out GSTIN);
                txtGstin.Text = GSTIN;
            }
            else
            {
                dt.Rows.Add(0, "NONE");
            }
            //cmbSupplierName.Items.Add(new ComboBox { 0, "Select Supplier" });
        }
        public void BindCustomerDropDown()
        {
            CustomerClass cup = new CustomerClass();
            DataTable dt = new DataTable();
            dt.Columns.Add("Customerid", typeof(System.Int32));
            dt.Columns.Add("Customername", typeof(System.String));
            dt = cup.BindDropDownCustomers(UniqueShopID).Tables[0];
            dt.Rows.Add(0, "Select Customer");
            DataView dv = new DataView(dt);
            dv.Sort = "Customerid";
            cmbSupplierName.DataSource = dv.ToTable();
            cmbSupplierName.DisplayMember = "Customername";
            cmbSupplierName.ValueMember = "Customerid";
            //cmbSupplierName.Items.Add(new ComboBox { 0, "Select Supplier" });
        }





        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbProductname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void TxtTotalAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textsumdisc_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridViewItemDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewItemDetails_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            int i = Convert.ToInt32(dataGridViewItemDetails.Rows[e.RowIndex].Cells[0].Value.ToString());
            EditRowIndex = i;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintInvoice_Click(object sender, EventArgs e)
        {
            Report.FrmPurchaseInvoice tx = new Report.FrmPurchaseInvoice(txtPono.Text, UniqueShopID);
            tx.ShowDialog();
        }

        private void btnAddnew_Click(object sender, EventArgs e)
        {

        }

        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {


        }

        private void txtBarCode_TextChanged_1(object sender, EventArgs e)
        {
            //// ProductClass pc = new ProductClass();
            //Purchase p = new Purchase();
            //string barcode = Convert.ToString(txtBarCode.Text);
            //int productid = 0;
            //string HSNCode = string.Empty;
            //int unitid = 0;
            //int price = 0;
            //if (barcode != string.Empty)
            //{
            //    p.GetProductsDetails(Convert.ToString(txtBarCode.Text), out productid, out unitid, out price);
            //    TxtHSNCode.Text = HSNCode.ToString();
            //    cmbProductname.SelectedValue = productid.ToString();
            //    cmbUnit.SelectedValue = unitid.ToString();
            //    txtPrice.Text = price.ToString();
            //}
        }

        private void btnAddAmcSchedule_Click(object sender, EventArgs e)
        {
            if (IsEditMode == true)
            {
                AmcScheduleFrm amc = new AmcScheduleFrm(txtPurdate.Value, dtUPAMCSchedule, dtAMCSchedule);
                amc.ShowDialog();
            }
            else
            {
                DateTime saledate = txtPurdate.Value;
                DateTime SaleExpDate = saledate.AddMonths(12);
                int duration = 2;
                AmcScheduleFrm amc = new AmcScheduleFrm(saledate, SaleExpDate, duration, dtAMCSchedule);
                amc.ShowDialog();
            }
        }

        public void SetNewSchedule(DataTable dtnewamc)
        {
            dtUPAMCSchedule = null;
            dtUPAMCSchedule = dtnewamc;
            //dtAMCSchedule = dtUPAMCSchedule;
            //dtAMCSchedule.AcceptChanges();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Report.AddViewCustomerAMC amcadd = new Report.AddViewCustomerAMC(dtUPAMCSchedule, this);
            //amcadd.ShowDialog();
        }

        private void lblHSNCode_Click(object sender, EventArgs e)
        {

        }

        private void CmbTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                //BindTaxValue(Convert.ToInt32(CmbTax.SelectedValue));
                //CalculatedValue();
            }
            catch (Exception)
            {


            }

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ChkWar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

        }

       

        private void txtbaseprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

       
        private void TxtEmp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtEmp.Text == string.Empty)
                {
                    LstEmp.Visible = false;
                    return;
                }
                if (dsCustDetail.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(dsCustDetail.Tables[0]);
                    dv.RowFilter = "Name like '%" + TxtEmp.Text + "%'";
                    LstEmp.Visible = true;
                    LstEmp.DataSource = dv.ToTable();
                    LstEmp.DisplayMember = "Name";
                    LstEmp.ValueMember = "Customerid";
                }
            }
            catch (Exception)
            {


            }

        }

        private void LstEmp_Click(object sender, EventArgs e)
        {
            SelectedCustomerID = LstEmp.GetItemText(LstEmp.SelectedValue);
            if (!string.IsNullOrEmpty(SelectedCustomerID))
            {
                TxtEmp.Text = LstEmp.GetItemText(LstEmp.SelectedItem);
                SupplierClass p = new SupplierClass();
                string CustomerContact = string.Empty;
                int i = Convert.ToInt32(SelectedCustomerID);
                if (i != 0)
                {
                    DataView dv = new DataView(p.BindSuppliers(UniqueShopID).Tables[0]);
                    dv.RowFilter = "SupplierID = '" + SelectedCustomerID + "'";

                    txtadd.Text = dv.ToTable().Rows[0]["Address"].ToString() + " " + dv.ToTable().Rows[0]["City"].ToString() + " " + dv.ToTable().Rows[0]["States"].ToString() + " " + dv.ToTable().Rows[0]["Country"].ToString() + " " + dv.ToTable().Rows[0]["Pincode"].ToString();
                    TxtContact.Text = dv.ToTable().Rows[0]["Contact"].ToString();
                    txtGstin.Text = dv.ToTable().Rows[0]["GSTIN"].ToString();
                    LstEmp.Visible = false;
                    cmbSupplierName.SelectedValue = SelectedCustomerID;

                }
            }
        }



        private void LstEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SelectedCustomerID = LstEmp.GetItemText(LstEmp.SelectedValue);
                if (!string.IsNullOrEmpty(SelectedCustomerID))
                {
                    TxtEmp.Text = LstEmp.GetItemText(LstEmp.SelectedItem);
                    SupplierClass p = new SupplierClass();
                    string CustomerContact = string.Empty;
                    int i = Convert.ToInt32(SelectedCustomerID);
                    if (i != 0)
                    {
                        DataView dv = new DataView(p.BindDropDownSuppliers(UniqueShopID).Tables[0]);
                        dv.RowFilter = "Supplierid = '" + SelectedCustomerID + "'";

                        txtadd.Text = dv.ToTable().Rows[0]["Address"].ToString();
                        TxtContact.Text = dv.ToTable().Rows[0]["Contact"].ToString();
                        txtGstin.Text = dv.ToTable().Rows[0]["GSTIN"].ToString();
                        LstEmp.Visible = false;
                        cmbSupplierName.SelectedValue = SelectedCustomerID;

                    }
                }
            }
        }

      
        private void TxtProduct_TextChanged(object sender, EventArgs e)
        {
            if (TxtProduct.Text == string.Empty)
            {
                LstProduct.Visible = false;
                return;
            }
            if (dtProduct.Rows.Count > 0)
            {
                DataView dv = new DataView(dtProduct);
                dv.RowFilter = "ItemName like '%" + TxtProduct.Text + "%'";
                LstProduct.Visible = true;
                LstProduct.DataSource = dv.ToTable();
                LstProduct.DisplayMember = "ItemName";
                LstProduct.ValueMember = "ItemID";
                txtPrice.Text = string.Empty;
            }
        }

        private void LstProduct_Click(object sender, EventArgs e)
        {
            SelectedProductID = LstProduct.GetItemText(LstProduct.SelectedValue);
            if (!string.IsNullOrEmpty(SelectedProductID))
            {
                TxtProduct.Text = LstProduct.GetItemText(LstProduct.SelectedItem);
                LstProduct.Visible = false;
            }
        }

     

        private void LstProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SelectedProductID = LstProduct.GetItemText(LstProduct.SelectedValue);
                if (!string.IsNullOrEmpty(SelectedProductID))
                {
                    TxtProduct.Text = LstProduct.GetItemText(LstProduct.SelectedItem);
                    LstProduct.Visible = false;
                }
            }
        }

       

        private void TxtSearchBarCode_TextChanged(object sender, EventArgs e)
        {

            DataView dv = new DataView(dtProduct);
            dv.RowFilter = "Productname like '%" + TxtSearchBarCode.Text + "%'";
            dataGridViewItemDetails.DataSource = dv.ToTable();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAllControl();
        }

      
        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Delete Record?", "Purchase Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Purchase PUR = new Purchase();
                int phid = 0;
                if (IsEditMode)
                {
                    MSEntities db = new MSEntities();
                    string pono = txtPono.Text;
                    phid = db.purchaseheader.Where(x => x.PoNo == pono && x.ShopID == UniqueShopID).Select(x => x.SAID).FirstOrDefault();
                }
                PUR.DeletePurchaseOrder(IsEditMode, phid);
                MessageBox.Show(this, "Record Deleted Successfully.", "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       
    }
}
