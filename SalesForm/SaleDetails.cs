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
    public partial class SaleDetails : Form
    {
        DataTable dtProduct = new DataTable();
        public DataTable dtTax = new DataTable();
        public DataTable dtAMCSchedule = new DataTable();
        public DataTable dtUPAMCSchedule = new DataTable();
        private bool IsEdit = false;
        private bool IsEditMode = false;
        private int EditRowIndex = 0;
        private readonly int UniqueShopID = 0;
        public SaleDetails(bool IsEditm,int ShopID)
        {
            InitializeComponent();
            IsEditMode = IsEditm;
            UniqueShopID = ShopID;
           
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
            ProductClass PC = new ProductClass();
            cmbProductname.Items.Insert(0, "---Select----");
            cmbProductname.DataSource = PC.BindDropDownProducts().Tables[0];
            cmbProductname.DisplayMember = "Productname";
            cmbProductname.ValueMember = "Productid";

        }

        private void PurchaseDetails_Load(object sender, EventArgs e)
        {
            if (IsEditMode)
            {
                txtPono.Enabled = true;
                txtPono.ReadOnly = false;
            }
            BindCustomerDropDown();
            BindTaxesDropDown();
            BindUnitDropdown();
            AddTableColumn();
            AddTaxDataTableColumn();
            AddAMCSchedule();
            GeneratePoNo();
            BindPaymentMode();
            BrandWiseProduct(UniqueShopID);
            //TxtBookNO.Focus();
            TxtBookNO.Focus();
            btnAddAmcSchedule.Visible = false;
        }

        private void BindPaymentMode()
        {
            List<PaymentModeBe> paym = new List<PaymentModeBe>();
            Purchase p = new Purchase();
            paym = p.GetPaymentMode();
            CmbPaidBy.DataSource = paym;
            CmbPaidBy.DisplayMember = "Mode";
            CmbPaidBy.ValueMember = "ID";

        }

        private void GeneratePoNo()
        {
            string pono = string.Empty;
            Sales P = new Sales();
            pono = P.GenerateNewPoNO(UniqueShopID);
            txtPono.Text = pono;
        }
        public void CalculateTaxAmount(DataTable dt)
        {
            dtTax = dt;
            List<TaxBe> lp = new List<TaxBe>();
            lp = (from a in dtTax.AsEnumerable()
                  select new TaxBe
                  {
                      TaxAmount = Convert.ToDecimal(a["TaxAmount"].ToString()),
                  }).ToList();
            ProductSumTaxAmt = Convert.ToDecimal(lp.Sum(x => x.TaxAmount).ToString());
            ShowItemSummary();
            txtsumnet.Text = (Convert.ToDecimal(TxtNetAmount.Text) + ProductSumTaxAmt).ToString();
        }
        public void CalculateTaxAmount(DataTable dt, decimal NetAmount)
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
            ProductSumTaxAmt = Convert.ToDecimal(lp.Sum(x => x.TaxAmount).ToString());
            ShowItemSummary();
            txtsumnet.Text = (Convert.ToDecimal(TxtNetAmount.Text) + ProductSumTaxAmt).ToString();
        }
        private void AddTableColumn()
        {
            dtProduct.Columns.Add("Sno", typeof(System.Int32));
            // dtProduct.Columns.Add("Barcode", typeof(System.Int32));
            dtProduct.Columns.Add("dbid", typeof(System.Int32));
            dtProduct.Columns.Add("Categoryid", typeof(System.Int32));
            dtProduct.Columns.Add("Brandid", typeof(System.Int32));
            dtProduct.Columns.Add("Productid", typeof(System.Int32));
            dtProduct.Columns.Add("UnitID", typeof(System.Int32));
            dtProduct.Columns.Add("Productname", typeof(System.String));
            dtProduct.Columns.Add("Qty", typeof(System.Double));
            dtProduct.Columns.Add("UnitName", typeof(System.String));
            dtProduct.Columns.Add("HSNCodeVal", typeof(System.String));
            dtProduct.Columns.Add("Price", typeof(System.Double));
            dtProduct.Columns.Add("Discount", typeof(System.Int32));
            dtProduct.Columns.Add("NetAmount", typeof(System.Int32));
            dtProduct.Columns.Add("Bankname", typeof(System.Int32));
            dtProduct.Columns.Add("AccountNumber", typeof(System.Int32));
            dtProduct.Columns.Add("IFSCCode", typeof(System.Int32));
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
            cmbCategoryname.DataSource = dv.ToTable();
            //  cmbCategoryname.SelectedValue = 25;
            cmbCategoryname.DisplayMember = "Categoryname";
            cmbCategoryname.ValueMember = "Categoryid";


        }


        private void BindBrandDropdown()
        {
            Brands brnd = new Brands();
            DataTable dt = new DataTable();
            int Uniqueshopid = 0;
            dt = brnd.CategoryWiseBrand(CategoryName, Uniqueshopid);
            cmbBrandName.DataSource = dt;
            cmbBrandName.DisplayMember = "BrandName";
            cmbBrandName.ValueMember = "BrandID";

        }
        #region Properties
        public string CategoryName
        {
            get
            {
                if (cmbCategoryname.Text != string.Empty)
                {
                    return cmbCategoryname.Text;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
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

        public string PName
        {
            get
            {
                if (cmbProductname.Text != string.Empty)
                {
                    return cmbProductname.Text;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public int Catid
        {
            get
            {
                if (cmbCategoryname.SelectedValue.ToString() != "0")
                {
                    return Convert.ToInt32(cmbCategoryname.SelectedValue);
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                cmbCategoryname.SelectedValue = value.ToString();
            }
        }

        public int BrandID
        {
            get
            {
                if (cmbBrandName.SelectedValue != "0")
                {
                    return Convert.ToInt32(cmbBrandName.SelectedValue);
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                cmbBrandName.SelectedValue = value.ToString();
            }
        }

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

        public int ProductID
        {
            get
            {
                if (cmbProductname.SelectedValue != "0")
                {
                    return Convert.ToInt32(cmbProductname.SelectedValue);
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                cmbProductname.SelectedValue = value.ToString();
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
        public decimal ProductDiscount
        {
            get
            {
                if (txtDiscount.Text != string.Empty)
                {
                    return Convert.ToDecimal(txtDiscount.Text);
                }
                else
                {
                    return decimal.Zero;
                }
            }
            set
            {
                txtDiscount.Text = value.ToString();
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
        public decimal ProductNetTotalAmount
        {
            get
            {
                if (TxtNetAmount.Text != string.Empty)
                {
                    return Convert.ToDecimal(TxtNetAmount.Text);
                }
                else
                {
                    return decimal.Zero;
                }
            }
            set
            {
                TxtNetAmount.Text = value.ToString();
            }
        }
        public decimal ProductSumTaxAmt
        {
            get
            {
                if (txtsumtax.Text != string.Empty)
                {
                    return Convert.ToDecimal(txtsumtax.Text);
                }
                else
                {
                    return decimal.Zero;
                }
            }
            set
            {
                txtsumtax.Text = value.ToString();
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
            CustomerDetails cd = new CustomerDetails(this, UniqueShopID);
            cd.ShowDialog();
        }

        private void btnAddPurchaseItem_Click(object sender, EventArgs e)
        {
            if (cmbProductname.Text == string.Empty)
            {
                MessageBox.Show(this, "Please Select any Product", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            if (cmbUnit.Text == string.Empty)
            {
                MessageBox.Show(this, "Please select Unit", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            if (ProductQuantity == 0)
            {
                MessageBox.Show(this, "Please enter Quantity", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtQty.Focus();
                return;
            }
            if (ProductPrice == 0)
            {
                MessageBox.Show(this, "Please enter Price", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtPrice.Focus();
                return;
            }
            if (CheckExistingProduct(ProductID) && IsEdit == false)
            {
                MessageBox.Show(this, "Product allready added.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            if (cmbProductname.Text == "AMC")
            {
                btnAddAmcSchedule.Visible = true;
            }
            else
            {
                btnAddAmcSchedule.Visible = false;
            }

            if (IsEdit == false)
            {
                dtProduct.Rows.Add(dtProduct.Rows.Count + 1, 0, 0, 0, ProductID, UnitIDS, PName, ProductQuantity, UnitName, HSNCodeVal, ProductPrice, ProductDiscount, ProductNetAmount);
                dataGridViewItemDetails.DataSource = dtProduct;             
                ResetControl();
                txtBarCode.Focus();
            }
            else
            {
                foreach (DataRow dr in dtProduct.Select("Sno = '" + EditRowIndex + "'"))
                {
                    dr["Qty"] = ProductQuantity;
                    dr["Price"] = ProductPrice;
                    dr["Discount"] = ProductDiscount;
                    dr["NetAmount"] = ProductNetAmount;
                    dr["UnitID"] = UnitIDS;
                    dr["UnitName"] = UnitName;

                }
                dtProduct.AcceptChanges();
                dataGridViewItemDetails.DataSource = dtProduct;
                btnAddPurchaseItem.Text = "ADD";
                EditRowIndex = 0;
                IsEdit = false;
                cmbCategoryname.Enabled = true;
                cmbBrandName.Enabled = true;
                cmbProductname.Enabled = true;
               
                ResetControl();
                txtBarCode.Focus();


            }
            ShowItemSummary();

            if (dtTax.Rows.Count > 0)
                CalculateTaxAmount(dtTax, ProductNetTotalAmount);            
            ResetControl();
            txtBarCode.Focus();
        }
        public string HSNCodeVal { get { return TxtHSNCode.Text; } set { TxtHSNCode.Text = value; } }

        public string Barcode { get { return txtBarCode.Text; } set { txtBarCode.Text = value; } }



        private void ResetControl()
        {
            BrandWiseProduct(UniqueShopID);
            Catid = 0;
            BrandID = 0;
            ProductID = 0;
            txtBarCode.Text = string.Empty;
            txtQty.Text = string.Empty;
            cmbProductname.SelectedValue = "0";
            ProductQuantity = decimal.Zero;
            ProductPrice = decimal.Zero;
            ProductDiscount = decimal.Zero;
            ProductNetAmount = decimal.Zero;
            HSNCodeVal = string.Empty;            
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

        private void BrandWiseProduct(int BrandID)
        {
            ProductClass cls = new ProductClass();
            List<ProductClassBe> pm = new List<ProductClassBe>();
            pm = cls.BrandWiseProduct(BrandID);
            DataTable DTP = new DataTable();
            DTP.Columns.Add("ProductID", typeof(System.Int32));
            DTP.Columns.Add("ProductName", typeof(System.String));
            DTP.Rows.Add(0, "Select");
            foreach (ProductClassBe item in pm)
            {
                DTP.Rows.Add(item.ProductID, item.ProductName);
            }
            cmbProductname.DataSource = DTP;
            cmbProductname.DisplayMember = "ProductName";
            cmbProductname.ValueMember = "ProductID";
            //cmbProductname.Items.Insert(0, "---Select----");
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
            cmbProductname.DataSource = DTP;
            cmbProductname.DisplayMember = "ProductName";
            cmbProductname.ValueMember = "ProductID";
            //cmbProductname.Items.Insert(0, "---Select----");
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

            lblHSNCode.Text = "HSNCode";
            cmbProductname.DataSource = DTP;
            cmbProductname.DisplayMember = "ProductName";
            cmbProductname.ValueMember = "ProductID";
        }
        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void CalculatedValue()
        {
            decimal Result = decimal.Zero;
            Result = ((ProductQuantity * ProductPrice) - ProductDiscount);
            txtAmount.Text = Result.ToString();
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
            TxtTotalAmount.Text = (amountt + disct).ToString();
            TxtNetAmount.Text = amountt.ToString();
            textsumdisc.Text = disct.ToString();
            txtsumnet.Text = (amountt + ProductSumTaxAmt).ToString();
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            CalculatedValue();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            CalculatedValue();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculatedValue();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (EditRowIndex > 0)
            {
                DataRow[] dr1 = dtProduct.Select("Sno='" + EditRowIndex + "'");
                dtProduct.Rows.Remove(dr1[0]);
                int i = 1;
                foreach (DataRow dr in dtProduct.Rows)
                {
                    dr["Sno"] = 1;
                    i = i + 1;
                }
                dtProduct.AcceptChanges();
                dataGridViewItemDetails.DataSource = dtProduct;
                MessageBox.Show(this, "Item Removed Succesfully.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                ShowItemSummary();
                if (dtTax.Rows.Count > 0)
                    CalculateTaxAmount(dtTax, ProductNetTotalAmount);

                ResetControl();
                btnAddPurchaseItem.Text = "ADD";
                EditRowIndex = 0;
                IsEdit = false;
                cmbCategoryname.Enabled = true;
                cmbBrandName.Enabled = true;
                cmbProductname.Enabled = true;
            }
            else
            {
                MessageBox.Show(this, "Please Select a row in below list to delete.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnAddTax_Click(object sender, EventArgs e)
        {
            FrmTax tx = new FrmTax(ProductNetTotalAmount, 0, dtTax, this,UniqueShopID);
            tx.ShowDialog();
        }



        private void dataGridViewItemDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Save Record?", "Purchase Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (TxtBookNO.Text == string.Empty)
                {
                    MessageBox.Show(this, "Please enter Book No.", "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtBookNO.Focus();
                }
                else if (txtPurdate.Text == string.Empty)
                {
                    MessageBox.Show(this, "Please Enter Purchase Date.", "Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPurdate.Focus();
                    return;
                }
                else if (cmbSupplierName.SelectedValue.ToString() == string.Empty)
                {
                    MessageBox.Show(this, "Please Select Supplier.", "Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSupplierName.Focus();
                    return;
                }
             
                else
                {
                    PurchaseBe pb = new PurchaseBe();
                    List<PurchaseBe> lstpurchasebe = new List<PurchaseBe>();
                    List<PurchaseBe> lp = new List<PurchaseBe>();
                  
                    
                    lp = (from a in dtProduct.AsEnumerable()
                          select new PurchaseBe
                          {
                              PONO = txtPono.Text,
                              PODate = Convert.ToDateTime(txtPurdate.Text),
                              BookNO = TxtBookNO.Text,
                              SupID = Convert.ToInt32(cmbSupplierName.SelectedValue),
                              Sno = Convert.ToInt32(a["Sno"].ToString()),
                              //  Barcode= Convert.ToString(a[""].ToString()),
                              dbid = Convert.ToInt32(a["dbid"].ToString()),
                              Categoryid = Convert.ToInt32(a["Categoryid"].ToString()),
                              Productid = Convert.ToInt32(a["Productid"].ToString()),
                              Brandid = Convert.ToInt32(a["Brandid"].ToString()),
                              UnitID = Convert.ToInt32(a["UnitID"].ToString()),
                              HSNCode = a["HSNCodeVal"].ToString(),
                              amount = Convert.ToDecimal(a["NetAmount"].ToString()),
                              price = Convert.ToDecimal(a["Price"].ToString()),
                              disc = Convert.ToDecimal(a["Discount"].ToString()),
                              qty = Convert.ToInt32(a["Qty"].ToString()),
                              Mode = Convert.ToInt32(CmbPaidBy.SelectedValue),
                              Remark = TxtRemark.Text,
                              Bankname = txtBankname.Text,
                              Accountno = txtAccountno.Text,
                              IfscCode = txtIfscCode.Text,
                              Vechicleno=txtVehicleno.Text,
                              Shopid = UniqueShopID
                          }).ToList();

                    List<TaxBe> lt = new List<TaxBe>();
                    lt = (from a in dtTax.AsEnumerable()
                          select new TaxBe
                          {
                              TaxID = Convert.ToInt32(a["TaxID"].ToString()),
                              TaxRate = Convert.ToInt32(a["TaxRate"].ToString()),
                              TaxAmount = Convert.ToDecimal(a["TaxAmount"].ToString()),
                              TaxOption = a["TaxOption"].ToString()

                          }).ToList();
                    List<ScheduleBE> AMCSch = new List<ScheduleBE>();
                    
                    AMCSch = (from a in dtAMCSchedule.AsEnumerable()
                          select new ScheduleBE
                          {
                              AMCID = Convert.ToInt32(a["AMCID"].ToString()),
                              AMCDate = Convert.ToDateTime(a["ScheduleDate"].ToString()),
                              Status = Convert.ToBoolean(a["Status"].ToString()),
                              IgnoreStatus = Convert.ToBoolean(a["IgnoreStatus"].ToString())

                          }).ToList();
                    Sales PUR = new Sales();
                    int phid = 0;
                    if (IsEditMode)
                    {
                        MSEntities db = new MSEntities();
                        string pono = txtPono.Text;
                        phid = db.SalesHeader.Where(x => x.PoNo == pono && x.Shopid==UniqueShopID).Select(x => x.SAID).FirstOrDefault();
                    }
                    PUR.SaveSalesOrder(lp, lt,AMCSch, IsEditMode, phid);
                    MessageBox.Show(this, "Record Saved Successfully. Please wait for Tax Invoice.", "Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //BindCategoryDropdown();
                    Report.FrmTaxInvoice tx = new Report.FrmTaxInvoice(txtPono.Text,UniqueShopID);
                    tx.ShowDialog();
                    ResetAllcontrol();
                }
            }
        }

        private void ResetAllcontrol()
        {
            TxtBookNO.Text = string.Empty;
            dtProduct.Rows.Clear();
            dtTax.Rows.Clear();
            dtUPAMCSchedule.Rows.Clear();
            dtAMCSchedule.Rows.Clear();
            dataGridViewItemDetails.DataSource = dtProduct;
            TxtTotalAmount.Text = string.Empty;
            textsumdisc.Text = string.Empty;
            TxtNetAmount.Text = string.Empty;
            txtsumtax.Text = string.Empty;
            txtsumnet.Text = string.Empty;
            CmbPaidBy.SelectedIndex = -1;
            TxtRemark.Text = string.Empty;
            txtBankname.Text = string.Empty;
            txtAccountno.Text = string.Empty;
            txtIfscCode.Text = string.Empty;
            txtVehicleno.Text = string.Empty;
            cmbSupplierName.SelectedValue = "0";
            GeneratePoNo();
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
                txtadd.Text = p.GetSupplierAddress(Convert.ToInt32(cmbSupplierName.SelectedValue), out GSTIN);
                txtGstin.Text = GSTIN;
            }

        }

        private void txtPono_Leave(object sender, EventArgs e)
        {
            if (IsEditMode)
            {
                Sales pe = new Sales();
                DataSet ds = new DataSet();
                ds = pe.BindPODetails(txtPono.Text,UniqueShopID);
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
                        TxtBookNO.Text = dthead.Rows[0]["BookNo"].ToString();
                        txtPurdate.Text = Convert.ToDateTime(dthead.Rows[0]["PoDate"].ToString()).ToString();
                        cmbSupplierName.SelectedValue = dthead.Rows[0]["CustomerID"].ToString();
                        CmbPaidBy.SelectedValue = dthead.Rows[0]["PaidByid"];
                        TxtRemark.Text = dthead.Rows[0]["Remark"].ToString(); 
                        txtBankname.Text = dthead.Rows[0]["Bankname"].ToString();
                        txtAccountno.Text = dthead.Rows[0]["Accountnumber"].ToString();
                        txtIfscCode.Text = dthead.Rows[0]["ifsccode"].ToString();
                        txtVehicleno.Text = dthead.Rows[0]["vehicleno"].ToString();
                    }
                    if (dtItem.Select("Productname='AMC'").Count() > 0)
                    {
                        btnAddAmcSchedule.Visible = true;
                    }
                    else
                    {
                        btnAddAmcSchedule.Visible = false;
                    }

                    dtProduct = dtItem;
                    dataGridViewItemDetails.DataSource = dtProduct;
                    dtTax = dttaxd;
                    CalculateTaxAmount(dtTax);

                }

            }
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
            Purchase p = new Purchase();
            int i = Convert.ToInt32(cmbProductname.SelectedIndex);
            int unitid = 0;
            int price = 0;
            if (i != 0)
            {
                TxtHSNCode.Text = p.GetItemHSNCode(Convert.ToInt32(cmbProductname.SelectedValue), out unitid, out price);
                cmbUnit.SelectedValue = unitid.ToString();
                txtPrice.Text = price.ToString();
            }
            txtQty.Focus();
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
            int i = Convert.ToInt32(dataGridViewItemDetails.Rows[e.RowIndex].Cells[0].Value.ToString());
            EditRowIndex = i;

            List<PurchaseBe> lp = new List<PurchaseBe>();
            lp = (from a in dtProduct.AsEnumerable()
                  select new PurchaseBe
                  {
                      Sno = Convert.ToInt32(a["Sno"].ToString()),
                      dbid = Convert.ToInt32(a["dbid"].ToString()),
                      Categoryid = Convert.ToInt32(a["Categoryid"].ToString()),
                      Productid = Convert.ToInt32(a["Productid"].ToString()),
                      Brandid = Convert.ToInt32(a["Brandid"].ToString()),
                      UnitID = Convert.ToInt32(a["UnitID"].ToString()),
                      amount = Convert.ToDecimal(a["NetAmount"].ToString()),
                      price = Convert.ToDecimal(a["Price"].ToString()),
                      disc = Convert.ToDecimal(a["Discount"].ToString()),
                      qty = Convert.ToInt32(a["Qty"].ToString()),
                  }).ToList();
            List<PurchaseBe> LBE = new List<PurchaseBe>();
            LBE = lp.Where(X => X.Sno == i).ToList();
            foreach (PurchaseBe item in LBE)
            {
                Catid = item.Categoryid;
                BrandID = item.Brandid;
                BrandWiseProduct(BrandID);
                ProductID = item.Productid;
                UnitIDS = item.UnitID;
                txtQty.Text = item.qty.ToString();
                txtPrice.Text = item.price.ToString();
                txtDiscount.Text = item.disc.ToString();
                txtAmount.Text = item.amount.ToString();
            }
            btnAddPurchaseItem.Text = "Update";
            IsEdit = true;
            cmbCategoryname.Enabled = false;
            cmbBrandName.Enabled = false;
            cmbProductname.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintInvoice_Click(object sender, EventArgs e)
        {
            Report.FrmTaxInvoice tx = new Report.FrmTaxInvoice(txtPono.Text,UniqueShopID);
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
            // ProductClass pc = new ProductClass();
            Purchase p = new Purchase();
            string barcode = Convert.ToString(txtBarCode.Text);
            int productid = 0;
            string HSNCode = string.Empty;
            int unitid = 0;
            int price = 0;
            if (barcode != string.Empty)
            {
                p.GetProductsDetails(Convert.ToString(txtBarCode.Text), out productid, out unitid, out price);
                TxtHSNCode.Text = HSNCode.ToString();
                cmbProductname.SelectedValue = productid.ToString();
                cmbUnit.SelectedValue = unitid.ToString();
                txtPrice.Text = price.ToString();
            }
        }

        private void btnAddAmcSchedule_Click(object sender, EventArgs e)
        {
            if (IsEditMode == true)
            {
                AmcScheduleFrm amc = new AmcScheduleFrm(dtUPAMCSchedule,dtAMCSchedule);
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
    }
}
