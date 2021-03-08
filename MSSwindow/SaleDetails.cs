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
using System.Globalization;

namespace MSSwindow
{
    public partial class RetailSaleDetails : Form
    {

        public DataSet dsCustDetail = new DataSet();
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
        string Editpono = string.Empty;
        int OrdID = 0;
        int InvoiceID = 0;



        public RetailSaleDetails(bool IsEditm, int ShopID)
        {
            InitializeComponent();
            IsEditMode = IsEditm;
            UniqueShopID = ShopID;
            CustomerClass CSL = new CustomerClass();
            dsCustDetail = CSL.SearchCustomers(UniqueShopID, TxtEmp.Text);
            ProductClass prod = new ProductClass();
            dsProduct = prod.BindProducts(UniqueShopID);

        }

        public void RefreshCustomerOnSales(int Customerid)
        {
            BindCustomerDropDown();
            CustomerClass CSL = new CustomerClass();
            dsCustDetail = CSL.SearchCustomers(UniqueShopID, TxtEmp.Text);

            CustomerClass p = new CustomerClass();
            DataView dv = new DataView(p.BindCustomers(UniqueShopID).Tables[0]);
            SelectedCustomerID = Customerid.ToString();
            dv.RowFilter = "Customerid = '" + SelectedCustomerID + "'";
            TxtEmp.Text = dv.ToTable().Rows[0]["CustomerName"].ToString();
            txtadd.Text = dv.ToTable().Rows[0]["Address"].ToString();
            TxtContact.Text = dv.ToTable().Rows[0]["Contact"].ToString();
            txtGstin.Text = dv.ToTable().Rows[0]["GSTIN"].ToString();
            LstEmp.Visible = false;
            cmbSupplierName.SelectedValue = SelectedCustomerID;
        }
        public RetailSaleDetails(bool IsEditm, int ShopID, string pono,int GenID)
        {
            InitializeComponent();
            IsEditMode = IsEditm;
            UniqueShopID = ShopID;
            CustomerClass CSL = new CustomerClass();
            dsCustDetail = CSL.SearchCustomers(UniqueShopID, TxtEmp.Text);
            ProductClass prod = new ProductClass();
            dsProduct = prod.BindProducts(UniqueShopID);
            Editpono = pono;
            InvoiceID = GenID;
            //EditPo(pono);

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
        public void RefreshProductOnSales(int ProductID)
        {
            BindProductsDropDown();
            SelectedProductID = ProductID.ToString();
            ProductClass prod = new ProductClass();
            dsProduct = prod.BindProducts(UniqueShopID);
            cmbProductname.SelectedValue = ProductID.ToString();
            DataView dv = new DataView(dsProduct.Tables[0]);
            dv.RowFilter = "Productid = '" + SelectedProductID + "'";
            TxtProduct.Text = dv.ToTable().Rows[0]["ProductName"].ToString();
            LstProduct.Visible = false;

        }

        public void BindProductsDropDown()
        {
            ProductClass PC = new ProductClass();
            //cmbProductname.Items.Insert(0, "---Select----");
            cmbProductname.DataSource = PC.BindDropDownProducts().Tables[0];
            cmbProductname.DisplayMember = "Productname";
            cmbProductname.ValueMember = "Productid";

        }


        public void BindPaymentDetails()
        {

            CustomerClass cls = new CustomerClass();
            DataTable dtitm = new DataTable();
            dtitm = cls.GetReceivedAmount(null, OrdID).Tables[0];
            dataGridViewItemServices.DataSource = dtitm;
            int i = 0;
            foreach (DataRow item in dtitm.Rows)
            {
                i = i + Convert.ToInt32(item["Amount"]);
            }
            txtpaidamt.Text = i.ToString();
           // txtbalanceamt.Text = (Convert.ToInt32(txtsumnet.Text) - Convert.ToInt32(txtpaidamt.Text)).ToString();
        }

        private void PurchaseDetails_Load(object sender, EventArgs e)
        {
            if (IsEditMode)
            {
                txtPono.Enabled = false;
                txtPono.ReadOnly = false;
                btnConvertEmi.Visible = Helper.IsConvertEMIEnabled ? true : false;
                btnConvertEmi.Visible = true;
            }
            CmbStatus.SelectedValue = "2";
            BindCustomerDropDown();
            BindTaxesDropDown();
            BindUnitDropdown();
            AddTableColumn();
            AddTaxDataTableColumn();
            AddAMCSchedule();
            GeneratePoNo();
            BindPaymentMode();
            BindTax();
            BrandWiseProduct(UniqueShopID);
            //TxtBookNO.Focus();
            TxtBookNO.Focus();
            btnAddAmcSchedule.Visible = false;
            BtnAddExtra.Visible = false;
            BindDelMode();
            BindPaymentStatus();
            if (IsEditMode)
                 EditPo(Editpono, InvoiceID);
        }
        public void BindPaymentStatus()
        {
            CustomerClass cls = new CustomerClass();
            CmbStatus.DataSource = cls.GetPaymentStatus().Tables[0];
            CmbStatus.DisplayMember = "Status";
            CmbStatus.ValueMember = "StatusID";

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
            CmbPaidBy.DataSource = paym;
            CmbPaidBy.DisplayMember = "Mode";
            CmbPaidBy.ValueMember = "ID";

        }

        private void GeneratePoNo()
        {
            string pono = string.Empty;

            // CustomerClass cls = new CustomerClass();
            // txtPono.Text = cls.GenerateComplaint(UniqueShopID).Tables[0].Rows[0][0].ToString();
            // txtPono.Text = pono;

            Sales P = new Sales();
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
            ProductSumTaxAmt = Convert.ToDecimal(lp.Sum(x => x.TaxAmount).ToString());
            ShowItemSummary();
            //txtsumnet.Text = Math.Round((Convert.ToDecimal(TxtNetAmount.Text) + Convert.ToDecimal(ProductSumTaxAmt)), 0).ToString();
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
            dtProduct.Columns.Add("ModelVal", typeof(System.String));
            dtProduct.Columns.Add("SrNoVal", typeof(System.String));
            dtProduct.Columns.Add("BasePrice", typeof(System.Double));
            dtProduct.Columns.Add("Price", typeof(System.Double));
            dtProduct.Columns.Add("Discount", typeof(System.Int32));
            dtProduct.Columns.Add("NetAmount", typeof(System.Double));
            dtProduct.Columns.Add("TaxIncluded", typeof(System.Boolean));
            dtProduct.Columns.Add("SCGST", typeof(System.Boolean));
            dtProduct.Columns.Add("IGST", typeof(System.Boolean));
            dtProduct.Columns.Add("CGSTPer", typeof(System.Double));
            dtProduct.Columns.Add("SGSTPer", typeof(System.Double));
            dtProduct.Columns.Add("IGSTPer", typeof(System.Double));
            dtProduct.Columns.Add("CGSTVal", typeof(System.Double));
            dtProduct.Columns.Add("SGSTVal", typeof(System.Double));
            dtProduct.Columns.Add("IGSTVal", typeof(System.Double));
            dtProduct.Columns.Add("NetTax", typeof(System.Double));
            dtProduct.Columns.Add("NetAmt", typeof(System.Double));

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
                if (value.ToString() != "0")
                    TxtProduct.Text = cmbProductname.Text;
                else
                    TxtProduct.Text = string.Empty;

                LstProduct.Visible = false;
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
        public decimal ProductBasePrice
        {
            get
            {
                if (txtbaseprice.Text != string.Empty)
                {
                    return Convert.ToDecimal(txtbaseprice.Text);
                }
                else
                {
                    return decimal.Zero;
                }
            }
            set
            {
                txtbaseprice.Text = value.ToString();
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
            //if (ProductBasePrice == 0)
            //{
            //    MessageBox.Show(this, "Please enter Price", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            //    txtPrice.Focus();
            //    return;
            //}
            if (CheckExistingProduct(ProductID) && IsEdit == false)
            {
                MessageBox.Show(this, "Product allready added.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            if (cmbProductname.Text.Contains("AMC"))
            {
                btnAddAmcSchedule.Visible = true;
                BtnAddExtra.Visible = true;
                label6.Text = "Model No.";
            }
            else
            {
                btnAddAmcSchedule.Visible = false;
                BtnAddExtra.Visible = false;
                label6.Text = "Model No.";
            }

            if (IsEdit == false)
            {


                dtProduct.Rows.Add(dtProduct.Rows.Count + 1, 0, 0, 0, ProductID, UnitIDS, PName, ProductQuantity, UnitName, HSNCodeVal, ModelVal, SerialNO, txtbaseprice.Text, ProductPrice, ProductDiscount, ProductNetAmount, ChkTaxIncluded.Checked,
                    Chkscgst.Checked, ChkIgst.Checked, Convert.ToDouble(TxtItemCGST.Text),
                    Convert.ToDouble(TxtItemSGST.Text),
                    Convert.ToDouble(TxtItemIGST.Text),
                    Convert.ToDouble(TxtItemCGSTVal.Text),
                    Convert.ToDouble(TxtItemSGSTVal.Text),
                    Convert.ToDouble(TxtItemIGSTVal.Text),
                    Convert.ToDouble(ItemNetTax.Text),
                    Convert.ToDouble(TxtTotalAmt.Text));
                dataGridViewItemDetails.DataSource = dtProduct;
                ResetControl();
                txtBarCode.Focus();
            }
            else
            {
                foreach (DataRow dr in dtProduct.Select("Sno = '" + EditRowIndex + "'"))
                {
                    dr["Productid"] = ProductID;
                    dr["ProductName"] = PName;
                    dr["HSNCodeVal"] = HSNCodeVal;
                    dr["ModelVal"] = ModelVal;
                    dr["SrNoVal"] = SerialNO;
                    dr["Qty"] = ProductQuantity;
                    dr["Price"] = ProductPrice;
                    dr["BasePrice"] = txtbaseprice.Text;
                    dr["Discount"] = ProductDiscount;
                    dr["NetAmount"] = ProductNetAmount;
                    dr["UnitID"] = UnitIDS;
                    dr["UnitName"] = UnitName;
                    dr["TaxIncluded"] = ChkTaxIncluded.Checked;
                    dr["SCGST"] = Chkscgst.Checked;
                    dr["IGST"] = ChkIgst.Checked;
                    dr["CGSTPer"] = Convert.ToDouble(TxtItemCGST.Text).ToString();
                    dr["SGSTPer"] = Convert.ToDouble(TxtItemSGST.Text).ToString();
                    dr["IGSTPer"] = Convert.ToDouble(TxtItemIGST.Text).ToString();
                    dr["CGSTVal"] = Convert.ToDouble(TxtItemCGSTVal.Text).ToString();
                    dr["SGSTVal"] = Convert.ToDouble(TxtItemSGSTVal.Text).ToString();
                    dr["IGSTVal"] = Convert.ToDouble(TxtItemIGSTVal.Text).ToString();
                    dr["NetTax"] = Convert.ToDouble(ItemNetTax.Text).ToString();
                    dr["NetAmt"] = Convert.ToDouble(TxtTotalAmt.Text).ToString();
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
            decimal Rate = decimal.Zero;
            string TypeTx = "";
            if (TxtSCTax.Text != string.Empty || TXTIGST.Text != string.Empty)
            {
                Rate = TxtSCTax.Text == string.Empty ? Convert.ToDecimal(TXTIGST.Text) : Convert.ToDecimal(TxtSCTax.Text);
                TypeTx = TxtSCTax.Text == string.Empty ? "IG" : "SC";
            }

            if (Rate >= 0)
                CalculateTaxByNewLogic(dtProduct, Rate, TypeTx);
            ResetControl();
            txtBarCode.Focus();
        }

        private void AddOrder()
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
            if (ProductBasePrice == 0)
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
                BtnAddExtra.Visible = true;
                label6.Text = "Model No.";
            }
            else
            {
                btnAddAmcSchedule.Visible = false;
                BtnAddExtra.Visible = false;
                label6.Text = "Model No.";
            }

            if (IsEdit == false)
            {


                dtProduct.Rows.Add(dtProduct.Rows.Count + 1, 0, 0, 0, ProductID, UnitIDS, PName, ProductQuantity, UnitName, HSNCodeVal, ModelVal, SerialNO, txtbaseprice.Text, ProductPrice, ProductDiscount, ProductNetAmount, ChkTaxIncluded.Checked,
                    Chkscgst.Checked, ChkIgst.Checked, Convert.ToDouble(TxtItemCGST.Text),
                    Convert.ToDouble(TxtItemSGST.Text),
                    Convert.ToDouble(TxtItemIGST.Text),
                    Convert.ToDouble(TxtItemCGSTVal.Text),
                    Convert.ToDouble(TxtItemSGSTVal.Text),
                    Convert.ToDouble(TxtItemIGSTVal.Text),
                    Convert.ToDouble(ItemNetTax.Text),
                    Convert.ToDouble(TxtTotalAmt.Text));
                dataGridViewItemDetails.DataSource = dtProduct;
                ResetControl();
                txtBarCode.Focus();
            }
            else
            {
                foreach (DataRow dr in dtProduct.Select("Sno = '" + EditRowIndex + "'"))
                {
                    dr["HSNCodeVal"] = HSNCodeVal;
                    dr["ModelVal"] = ModelVal;
                    dr["SrNoVal"] = SerialNO;
                    dr["Qty"] = ProductQuantity;
                    dr["Price"] = ProductPrice;
                    dr["BasePrice"] = txtbaseprice.Text;
                    dr["Discount"] = ProductDiscount;
                    dr["NetAmount"] = ProductNetAmount;
                    dr["UnitID"] = UnitIDS;
                    dr["UnitName"] = UnitName;
                    dr["TaxIncluded"] = ChkTaxIncluded.Checked;
                    dr["SCGST"] = Chkscgst.Checked;
                    dr["IGST"] = ChkIgst.Checked;
                    dr["CGSTPer"] = Convert.ToDouble(TxtItemCGST.Text).ToString();
                    dr["SGSTPer"] = Convert.ToDouble(TxtItemSGST.Text).ToString();
                    dr["IGSTPer"] = Convert.ToDouble(TxtItemIGST.Text).ToString();
                    dr["CGSTVal"] = Convert.ToDouble(TxtItemCGSTVal.Text).ToString();
                    dr["SGSTVal"] = Convert.ToDouble(TxtItemSGSTVal.Text).ToString();
                    dr["IGSTVal"] = Convert.ToDouble(TxtItemIGSTVal.Text).ToString();
                    dr["NetTax"] = Convert.ToDouble(ItemNetTax.Text).ToString();
                    dr["NetAmt"] = Convert.ToDouble(TxtTotalAmt.Text).ToString();
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
            decimal Rate = decimal.Zero;
            string TypeTx = "";
            if (TxtSCTax.Text != string.Empty || TXTIGST.Text != string.Empty)
            {
                Rate = TxtSCTax.Text == string.Empty ? Convert.ToDecimal(TXTIGST.Text) : Convert.ToDecimal(TxtSCTax.Text);
                TypeTx = TxtSCTax.Text == string.Empty ? "IG" : "SC";
            }

            if (Rate > 0)
                CalculateTaxByNewLogic(dtProduct, Rate, TypeTx);
            ResetControl();
            txtBarCode.Focus();
        }
        public string HSNCodeVal { get { return TxtHSNCode.Text; } set { TxtHSNCode.Text = value; } }
        public string ModelVal { get { return TxtModel.Text; } set { TxtModel.Text = value; } }
        public string SerialNO { get { return TxtSrno.Text; } set { TxtSrno.Text = value; } }
        public string Barcode { get { return txtBarCode.Text; } set { txtBarCode.Text = value; } }
        private void ResetControl()
        {
            TxtProduct.Text = string.Empty;
            BrandWiseProduct(UniqueShopID);
            Catid = 0;
            BrandID = 0;
            ProductID = 0;
            ModelVal = string.Empty;
            SerialNO = string.Empty;
            txtBarCode.Text = string.Empty;
            txtQty.Text = string.Empty;
            cmbProductname.SelectedValue = "0";
            ProductQuantity = decimal.Zero;
            ProductPrice = decimal.Zero;
            ProductDiscount = decimal.Zero;
            ProductNetAmount = decimal.Zero;
            HSNCodeVal = string.Empty;
            cmbUnit.SelectedValue = "0";
            txtbaseprice.Text = string.Empty;
            ChkTaxIncluded.Checked = false;

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
            ShowItemSummary();

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
            decimal Result = decimal.Zero;
            ProductPrice = ProductBasePrice;
            Result = ((ProductQuantity * ProductPrice) - ((ProductQuantity * ProductPrice) * ProductDiscount / 100));
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
                      BasePrice = Convert.ToDecimal(a["Price"].ToString()),
                      amount = Convert.ToDecimal(a["NetAmt"].ToString()),
                      price = Convert.ToDecimal(a["Price"].ToString()),
                      disc = Convert.ToDecimal(a["Discount"].ToString()),
                      qty = Convert.ToInt32(a["Qty"].ToString()),
                      CGSTVal = Convert.ToDecimal(a["CGSTVal"].ToString()),
                      SGSTVal = Convert.ToDecimal(a["SGSTVal"].ToString()),
                      IGSTVal = Convert.ToDecimal(a["IGSTVal"].ToString()),
                      NetTax = Convert.ToDecimal(a["NetTax"].ToString())
                  }).ToList();
            var disct = lp.Sum(x => x.disc);
            var amountt = lp.Sum(x => x.BasePrice);
            var cgstval = lp.Sum(x => x.CGSTVal);
            var sgstval = lp.Sum(x => x.SGSTVal);
            var IGSTval = lp.Sum(x => x.IGSTVal);
            var NetTax = lp.Sum(x => x.NetTax);
            var NetAmt = lp.Sum(x => x.amount);
            TxtTotalAmount.Text = (amountt + disct).ToString();
            txtsumnet.Text = NetAmt.ToString();
            textsumdisc.Text = disct.ToString();
            TxtCGSTVal.Text = cgstval.ToString();
            TxtSgstVal.Text = sgstval.ToString();
            TxtIGSTVal.Text = IGSTval.ToString();
            txtsumtax.Text = NetTax.ToString();
            //txtsumnet.Text = (amountt + ProductSumTaxAmt).ToString();
            txtbalanceamt.Text=(Convert.ToDecimal(txtsumnet.Text)-Convert.ToDecimal(txtpaidamt.Text==string.Empty?"0.00":txtpaidamt.Text)).ToString();
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
            TxtTotalAmount.Text = (amountt).ToString();

            textsumdisc.Text = (amountt * disct / 100).ToString();
            disct = (amountt * disct / 100);
            TxtNetAmount.Text = (amountt - disct).ToString();
            ProductSumTaxAmt = Math.Round((amountt - disct) * Rate / 100, 2);
            if (!IsEditMode)
                txtbalanceamt.Text = ((amountt - disct) + Math.Round((amountt - disct) * Rate / 100, 2)).ToString();
            else
                txtbalanceamt.Text = ((amountt - disct) + Math.Round((amountt - disct) * Rate / 100, 2)- Convert.ToInt32(txtpaidamt.Text==string.Empty?0 : Convert.ToInt32(txtpaidamt.Text))).ToString();

            if (Typetx == "SC")
            {
                TxtSgstVal.Text = Math.Round((amountt - disct) * Convert.ToDecimal(Rate / 2) / 100, 2).ToString();
                TxtCGSTVal.Text = Math.Round((amountt - disct) * Convert.ToDecimal(Rate / 2) / 100, 2).ToString();
                TxtIGSTVal.Text = string.Empty;
                //      dtTax.Columns.Add("TaxID", typeof(System.Int32));
                //dtTax.Columns.Add("TaxName", typeof(System.String));
                //dtTax.Columns.Add("TaxRate", typeof(System.String));
                //dtTax.Columns.Add("TaxOption", typeof(System.String));
                //dtTax.Columns.Add("TaxAmount", typeof(System.Decimal));
                dtTax.Rows.Add(1, "SGST", Rate / 2, "%", Convert.ToDecimal(TxtSgstVal.Text));
                dtTax.Rows.Add(2, "CGST", Rate / 2, "%", Convert.ToDecimal(TxtCGSTVal.Text));
                dtTax.Rows.Add(3, "IGST", 0, "%", 0);
            }
            else
            {
                TxtIGSTVal.Text = Math.Round((amountt - disct) * Convert.ToDecimal(Rate) / 100, 2).ToString();
                TxtSgstVal.Text = string.Empty;
                TxtCGSTVal.Text = string.Empty;
                dtTax.Rows.Add(1, "SGST", 0, "%", 0);
                dtTax.Rows.Add(2, "CGST", 0, "%", 0);
                dtTax.Rows.Add(3, "IGST", Rate, "%", Convert.ToDecimal(TxtIGSTVal.Text));
            }
            txtsumnet.Text = Math.Round((amountt + ProductSumTaxAmt - disct), 0).ToString();
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            CalculatedValue();

            ShowTaxValues();

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
            CGST = Convert.ToDouble(TxtItemCGST.Text == string.Empty ? "0.00" : TxtItemCGST.Text);
            SGST = Convert.ToDouble(TxtItemSGST.Text == string.Empty ? "0.00" : TxtItemSGST.Text);
            IGST = Convert.ToDouble(TxtItemIGST.Text == string.Empty ? "0.00" : TxtItemIGST.Text);

            if (txtAmount.Text != string.Empty)
            {
                ShowItemWiseTax(Convert.ToDouble(txtAmount.Text), SGST, CGST, IGST, Convert.ToBoolean(ChkTaxIncluded.Checked), Convert.ToBoolean(Chkscgst.Checked), Convert.ToBoolean(ChkIgst.Checked), out CGSTVal, out SGSTVal
                       , out IGSTVal, out BasePrice);
                TxtItemSGSTVal.Text = SGSTVal.ToString();
                TxtItemCGSTVal.Text = CGSTVal.ToString();
                TxtItemIGSTVal.Text = IGSTVal.ToString();
                ItemNetTax.Text = (SGSTVal + IGSTVal + CGSTVal).ToString();
                if (ChkTaxIncluded.Checked)
                {
                    txtAmount.Text = (Convert.ToDouble(txtAmount.Text) - (SGSTVal + IGSTVal + CGSTVal)).ToString();
                }
                else
                {
                    txtAmount.Text = Convert.ToDouble(txtAmount.Text).ToString();
                }

                if (Convert.ToDecimal(ItemNetTax.Text) != decimal.Zero)
                    txtPrice.Text = BasePrice.ToString();
                TxtTotalAmt.Text = Math.Round((Convert.ToDouble(ItemNetTax.Text) + Convert.ToDouble(txtAmount.Text)), 0).ToString();
            }

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            // CalculatedValue();

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
            FrmTax tx = new FrmTax(ProductNetTotalAmount, 0, dtTax, this, UniqueShopID);
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
            string MessageString = string.Empty;
            if (IsEditMode)
            {
                MessageString = "Do You Want To Update Record?";
            }
            else
            {
                MessageString = "Do You Want To Save Record?";
            }
            if (MessageBox.Show(MessageString, "Sales Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Regenerate PONO While saving data;
                if (!IsEditMode)
                {
                    GeneratePoNo();
                }
                if (TxtBookNO.Text == string.Empty)
                {
                    MessageBox.Show(this, "Please enter Book No.", "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtBookNO.Focus();
                }
                else if (txtPurdate.Text == string.Empty)
                {
                    MessageBox.Show(this, "Please Enter Sale Date.", "Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPurdate.Focus();
                    return;
                }
                else if (cmbSupplierName.SelectedValue.ToString() == string.Empty)
                {
                    MessageBox.Show(this, "Please Select Customer.", "Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSupplierName.Focus();
                    return;
                }
                else
                {
                    PurchaseBe pb = new PurchaseBe();
                    List<PurchaseBe> lstpurchasebe = new List<PurchaseBe>();
                    List<PurchaseBe> lp = new List<PurchaseBe>();
                    DateTime? dtPur = null;
                    string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    if (!string.IsNullOrEmpty(txtPurdate.Text))
                        dtPur = DateTime.ParseExact(txtPurdate.Text, sysFormat, CultureInfo.InvariantCulture);
                    //dtPur = DateTime.ParseExact(txtPurdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    lp = (from a in dtProduct.AsEnumerable()
                          select new PurchaseBe
                          {
                              PONO = txtPono.Text,
                              PODate = Convert.ToDateTime(dtPur),
                              BookNO = TxtBookNO.Text,
                              SupID = Convert.ToInt32(cmbSupplierName.SelectedValue),
                              Sno = Convert.ToInt32(a["Sno"].ToString()),
                              RefBy = TxtReffBy.Text,
                              DelMode = Convert.ToInt32(CmbDelMode.SelectedValue),
                              DeliverBy = TxtDelBy.Text,
                              IsDelivered = ChkDel.Checked,
                              ExpDelDate = Convert.ToDateTime(ChkDel.Checked == false?DtpExp.Value:(DateTime?)null),
                              //  Barcode= Convert.ToString(a[""].ToString()),
                              dbid = Convert.ToInt32(a["dbid"].ToString()),
                              Categoryid = Convert.ToInt32(a["Categoryid"].ToString()),
                              Productid = Convert.ToInt32(a["Productid"].ToString()),
                              Brandid = Convert.ToInt32(a["Brandid"].ToString()),
                              UnitID = Convert.ToInt32(a["UnitID"].ToString()),
                              HSNCode = a["HSNCodeVal"].ToString(),
                              ModelNo = a["ModelVal"].ToString(),
                              ItemSrNo = a["SrNoVal"].ToString(),
                              amount = Convert.ToDecimal(a["NetAmount"].ToString()),
                              price = Convert.ToDecimal(a["Price"].ToString()),
                              disc = Convert.ToDecimal(a["Discount"].ToString()),
                              qty = Convert.ToInt32(a["Qty"].ToString()),
                              Mode = Convert.ToInt32(CmbPaidBy.SelectedValue),
                              BasePrice = Convert.ToDecimal(a["BasePrice"].ToString()),
                              IsTaxIncluded = Convert.ToBoolean(a["TaxIncluded"].ToString()),
                              SCGST = Convert.ToBoolean(a["SCGST"].ToString()),
                              IGST = Convert.ToBoolean(a["IGST"].ToString()),
                              CGSTPer = Convert.ToDecimal(a["CGSTPer"].ToString()),
                              SGSTPer = Convert.ToDecimal(a["SGSTPer"].ToString()),
                              IGSTPer = Convert.ToDecimal(a["IGSTPer"].ToString()),
                              CGSTVal = Convert.ToDecimal(a["CGSTVal"].ToString()),
                              SGSTVal = Convert.ToDecimal(a["SGSTVal"].ToString()),
                              IGSTVal = Convert.ToDecimal(a["IGSTVal"].ToString()),
                              NetTax = Convert.ToDecimal(a["NetTax"].ToString()),
                              NetAmt = Convert.ToDecimal(a["NetAmt"].ToString()),
                              

                              Remark = TxtRemark.Text,
                              Bankname = txtBankname.Text,
                              Accountno = txtAccountno.Text,
                              IfscCode = txtIfscCode.Text,
                              Vechicleno = txtVehicleno.Text,
                              Shopid = UniqueShopID,
                              IsWaranty = ChkWar.Checked,
                              WarDuration = (int)NMWarDuration.Value,
                              ExpDate = dtexp.Value,
                              PaidAmt = Convert.ToDecimal(txtpaidamt.Text == string.Empty ? "0" : txtpaidamt.Text),
                              BalAmt = Convert.ToDecimal(txtbalanceamt.Text == string.Empty ? "0" : txtbalanceamt.Text),
                              PayStatus = Convert.ToBoolean(CmbStatus.SelectedValue.ToString() == "1" ? true : false)


                          }).ToList();

                    List<TaxBe> lt = new List<TaxBe>();
                    lt = (from a in dtTax.AsEnumerable()
                          select new TaxBe
                          {
                              TaxID = Convert.ToInt32(a["TaxID"].ToString()),
                              TaxName = a["TaxName"].ToString(),
                              TaxRate = Convert.ToDecimal(a["TaxRate"].ToString()),
                              TaxAmount = Convert.ToDecimal(a["TaxAmount"].ToString()),
                              TaxOption = a["TaxOption"].ToString()

                          }).ToList();
                    List<ScheduleBE> AMCSch = new List<ScheduleBE>();
                    if (dtUPAMCSchedule.Rows.Count > 0)
                    {
                        AMCSch = (from a in dtUPAMCSchedule.AsEnumerable()
                                  select new ScheduleBE
                                  {
                                      AMCID = Convert.ToInt32(a["RN"].ToString()),
                                      AMCDate = Convert.ToDateTime(a["AMCDate"].ToString()),
                                      Status = Convert.ToBoolean(a["Status"].ToString()),
                                      IgnoreStatus = Convert.ToBoolean(a["IgnoreStatus"].ToString()),
                                      Remark = a["Remark"].ToString()

                                  }).ToList();


                    }
                    else
                    {
                        AMCSch = (from a in dtAMCSchedule.AsEnumerable()
                                  select new ScheduleBE
                                  {
                                      AMCID = Convert.ToInt32(a["AMCID"].ToString()),
                                      AMCDate = Convert.ToDateTime(a["ScheduleDate"].ToString()),
                                      Status = Convert.ToBoolean(a["Status"].ToString()),
                                      IgnoreStatus = Convert.ToBoolean(a["IgnoreStatus"].ToString()),
                                      Remark = a["Remark"].ToString()

                                  }).ToList();
                    }
                    Sales PUR = new Sales();
                    int phid = 0;
                    int GenID = 0;
                    if (IsEditMode)
                    {
                        MSEntities db = new MSEntities();
                        string pono = txtPono.Text;
                        phid = db.SalesHeader.Where(x => x.PoNo == pono && x.ShopID == UniqueShopID).Select(x => x.SAID).FirstOrDefault();
                        PUR.UpdateSalesOrder(lp, lt, AMCSch,out GenID, IsEditMode, phid, Helper.ShopUserID);
                        MessageBox.Show(this, "Record Updated Successfully.", "Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        PUR.SaveSalesOrder(lp, lt, AMCSch,out GenID, IsEditMode, phid, Helper.ShopUserID);
                        MessageBox.Show(this, "Record Saved Successfully.", "Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //BindCategoryDropdown();
                    //Report.FrmTaxInvoice tx = new Report.FrmTaxInvoice(txtPono.Text, UniqueShopID);
                    //tx.ShowDialog();
                    IsEditMode = true;
                    if (IsEditMode)
                    {
                        //txtPono.Enabled = true;
                        //txtPono.ReadOnly = false;
                        Editpono = txtPono.Text;


                    }
                    if (IsEditMode && Editpono != string.Empty)
                    {

                        Editpono = txtPono.Text;
                        OrdID = GenID;
                        InvoiceID = GenID;
                        EditPo(Editpono,GenID);
                    }
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
            ChkWar.Checked = false;
            NMWarDuration.Value = 1;
            dtexp.Value = DateTime.Now.Date;
            GeneratePoNo();
            TxtCGSTVal.Text = string.Empty;
            TxtIGSTVal.Text = string.Empty;
            TxtSgstVal.Text = string.Empty;
            TxtSCTax.Text = string.Empty;
            TXTIGST.Text = string.Empty;

            TxtItemCGST.Text = string.Empty;
            TxtItemSGST.Text = string.Empty;
            TxtItemIGST.Text = string.Empty;

            TxtItemCGSTVal.Text = string.Empty;
            TxtItemIGSTVal.Text = string.Empty;
            TxtItemSGSTVal.Text = string.Empty;

            TxtModel.Text = string.Empty;
            TxtHSNCode.Text = string.Empty;
            txtbaseprice.Text = string.Empty;
            ItemNetTax.Text = string.Empty;

            TxtTotalAmount.Text = string.Empty;
            txtAmount.Text = string.Empty;
            TxtProduct.Text = string.Empty;

            TxtTotalAmt.Text = string.Empty;
            cmbUnit.SelectedIndex = 0;
            txtQty.Text = string.Empty;
            CmbDelMode.SelectedValue = "0";
            TxtReffBy.Text = string.Empty;
            TxtDelBy.Text = string.Empty;
            txtpaidamt.Text = string.Empty;
            txtbalanceamt.Text = string.Empty;
            CmbStatus.SelectedValue = "2";
            dataGridViewItemServices.DataSource = null;


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
                int GenID = InvoiceID;
                ds = pe.BindPODetails(txtPono.Text, UniqueShopID, GenID);
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
                        OrdID = Convert.ToInt32(dthead.Rows[0]["SAID"].ToString());
                        button4.Enabled = true;
                        btnConvertEmi.Visible = Helper.IsConvertEMIEnabled ? true : false;
                        CmbStatus.Enabled = true;
                        TxtBookNO.Text = dthead.Rows[0]["BookNo"].ToString();
                        txtPurdate.Text = Convert.ToDateTime(dthead.Rows[0]["PoDate"].ToString()).ToString();
                        cmbSupplierName.SelectedValue = dthead.Rows[0]["CustomerID"].ToString();
                        TxtEmp.Text = cmbSupplierName.Text;
                        LstEmp.Visible = false;
                        CmbPaidBy.SelectedValue = dthead.Rows[0]["PaidByid"];
                        TxtRemark.Text = dthead.Rows[0]["Remark"].ToString();
                        txtBankname.Text = dthead.Rows[0]["Bankname"].ToString();
                        txtAccountno.Text = dthead.Rows[0]["Accountnumber"].ToString();
                        txtIfscCode.Text = dthead.Rows[0]["ifsccode"].ToString();
                        txtVehicleno.Text = dthead.Rows[0]["vehicleno"].ToString();
                        ChkWar.Checked = Convert.ToBoolean(dthead.Rows[0]["Is_War_Dur"]);
                        NMWarDuration.Value = Convert.ToInt32(dthead.Rows[0]["War_Dur"]);
                        dtexp.Value = Convert.ToDateTime(dthead.Rows[0]["War_ExpDate"]);
                        CmbDelMode.SelectedValue = Convert.ToInt32(dthead.Rows[0]["deliverymode"]);
                        TxtReffBy.Text = dthead.Rows[0]["RefBy"].ToString();
                        TxtDelBy.Text = dthead.Rows[0]["deliverby"].ToString();
                        txtpaidamt.Text = dthead.Rows[0]["PaidAmount"].ToString();
                        txtbalanceamt.Text = dthead.Rows[0]["BalanceAmount"].ToString();
                        if (!String.IsNullOrEmpty(dthead.Rows[0]["PayStatus"].ToString()))
                            CmbStatus.SelectedValue = dthead.Rows[0]["PayStatus"].ToString() == "True" ? 1 : 2;
                    }
                    if (dtItem.Select("Productname='AMC'").Count() > 0)
                    {
                        btnAddAmcSchedule.Visible = true;
                        BtnAddExtra.Visible = true;
                        label6.Text = "Model No.";
                    }
                    else
                    {
                        btnAddAmcSchedule.Visible = false;
                        BtnAddExtra.Visible = false;
                        label6.Text = "Model No.";
                    }

                    dtProduct = dtItem;
                    dataGridViewItemDetails.DataSource = dtProduct;
                    dtTax = dttaxd;
                    ShowTaxOnEdit(dtTax);
                    CalculateTaxAmount(dtTax);
                    BindPaymentDetails();
                    decimal GST = decimal.Zero;
                    string TypeTx = String.Empty;
                    ShowItemSummary(GST, TypeTx);

                }

            }
        }
        private void EditPo(string pono,int GenID)
        {
            if (IsEditMode)
            {
                Sales pe = new Sales();
                DataSet ds = new DataSet();
                ds = pe.BindPODetails(pono, UniqueShopID, GenID);
                if (ds.Tables.Count > 0)
                {
                    btnConvertEmi.Visible = Helper.IsConvertEMIEnabled ? true : false;
                    btnConvertEmi.Visible = true;
                    DataTable dthead = new DataTable();
                    DataTable dtItem = new DataTable();
                    DataTable dttaxd = new DataTable();
                    DataTable dtEMISummary = new DataTable();
                    //DataTable dtAMC = new DataTable();
                    dthead = ds.Tables[0];
                    dtItem = ds.Tables[1];
                    dttaxd = ds.Tables[2];
                    dtUPAMCSchedule = ds.Tables[3];
                    dtEMISummary = ds.Tables[4];
                    if (dtEMISummary.Rows.Count > 0)                    
                    {                       
                        LblEmiStatus.Text = "Active";
                        LblEmiStatus.ForeColor = Color.Green;
                        LBlEmiDate.Text = dtEMISummary.Rows[0]["emidate"].ToString();
                        LblEMIAmt.Text = dtEMISummary.Rows[0]["emiamount"].ToString();
                    }
                    else
                    {
                        LblEmiStatus.Text = "Closed";
                        LblEmiStatus.ForeColor = Color.Red;
                        LBlEmiDate.Text = "NA";
                        LblEMIAmt.Text = "0.00";
                    }
                    if (dtUPAMCSchedule.Rows.Count > 0)
                    {
                        btnAddAmcSchedule.Visible = true;
                        BtnAddExtra.Visible = true;
                        label6.Text = "Model No.";
                    }
                    else
                    {
                        btnAddAmcSchedule.Visible = false;
                        BtnAddExtra.Visible = false;
                        //label6.Text = "Model No.";
                    }

                    if (dthead.Rows.Count > 0)
                    {

                        OrdID = InvoiceID;
                        button4.Enabled = true;
                        btnConvertEmi.Visible = Helper.IsConvertEMIEnabled ? true : false;
                        btnConvertEmi.Visible = true;
                        CmbStatus.Enabled = true;
                        txtPono.Text = pono;
                        if (dthead.Rows[0]["IsDelivered"] != DBNull.Value)
                        {
                            ChkDel.Checked = Convert.ToBoolean(dthead.Rows[0]["IsDelivered"]);
                        }                       
                        if (dthead.Rows[0]["ExpDelDate"] != DBNull.Value)
                        {
                            DtpExp.Value = Convert.ToDateTime(dthead.Rows[0]["ExpDelDate"]);
                        }                       
                        TxtBookNO.Text = dthead.Rows[0]["BookNo"].ToString();
                        txtPurdate.Text = Convert.ToDateTime(dthead.Rows[0]["PoDate"].ToString()).ToString();
                        cmbSupplierName.SelectedValue = dthead.Rows[0]["CustomerID"].ToString();
                        TxtEmp.Text = cmbSupplierName.Text;
                        LstEmp.Visible = false;
                        CmbPaidBy.SelectedValue = dthead.Rows[0]["PaidByid"];
                        TxtRemark.Text = dthead.Rows[0]["Remark"].ToString();
                        txtBankname.Text = dthead.Rows[0]["Bankname"].ToString();
                        txtAccountno.Text = dthead.Rows[0]["Accountnumber"].ToString();
                        txtIfscCode.Text = dthead.Rows[0]["ifsccode"].ToString();
                        txtVehicleno.Text = dthead.Rows[0]["vehicleno"].ToString();
                        ChkWar.Checked = Convert.ToBoolean(dthead.Rows[0]["Is_War_Dur"]);
                        NMWarDuration.Value = Convert.ToInt32(dthead.Rows[0]["War_Dur"]);
                        dtexp.Value = Convert.ToDateTime(dthead.Rows[0]["War_ExpDate"]);
                        CmbDelMode.SelectedValue = Convert.ToInt32(dthead.Rows[0]["deliverymode"]);
                        TxtReffBy.Text = dthead.Rows[0]["RefBy"].ToString();
                        TxtDelBy.Text = dthead.Rows[0]["deliverby"].ToString();
                        txtpaidamt.Text = dthead.Rows[0]["PaidAmount"].ToString();
                        txtbalanceamt.Text = dthead.Rows[0]["BalanceAmount"].ToString();
                        if (!String.IsNullOrEmpty(dthead.Rows[0]["PayStatus"].ToString()))
                            CmbStatus.SelectedValue = dthead.Rows[0]["PayStatus"].ToString() == "True" ? 1 : 2;
                    }
                    if (dtItem.Select("Productname LIKE '%AMC%'").Count() > 0)
                    {
                        btnAddAmcSchedule.Visible = true;
                        BtnAddExtra.Visible = true;
                        label6.Text = "Model No.";
                    }
                    else
                    {
                        btnAddAmcSchedule.Visible = false;
                        BtnAddExtra.Visible = false;
                        label6.Text = "Model No.";
                    }

                    dtProduct = dtItem;
                    dataGridViewItemDetails.DataSource = dtProduct;
                    dtTax = dttaxd;
                    //ShowTaxOnEdit(dtTax);
                    //CalculateTaxAmount(dtTax);
                    BindPaymentDetails();
                    decimal GST = decimal.Zero;
                    string TypeTX = string.Empty;
                    ShowItemSummary();

                }

            }
        }
        private void ShowTaxOnEdit(DataTable dtTax)
        {
            decimal Rate = decimal.Zero;
            TxtCGSTVal.Text = string.Empty;
            TxtIGSTVal.Text = string.Empty;
            TxtSgstVal.Text = string.Empty;
            TxtSCTax.Text = string.Empty;
            TXTIGST.Text = string.Empty;
            foreach (DataRow item in dtTax.Select("TaxName = 'CGST'"))
            {
                TxtCGSTVal.Text = item["TaxAmount"].ToString();
                Rate = Convert.ToDecimal(item["TaxRate"].ToString());

            }
            foreach (DataRow item in dtTax.Select("TaxName = 'SGST'"))
            {
                TxtSgstVal.Text = item["TaxAmount"].ToString();
                Rate = Rate + Convert.ToDecimal(item["TaxRate"].ToString());
                TxtSCTax.Text = Rate.ToString();
            }
            foreach (DataRow item in dtTax.Select("TaxName = 'IGST'"))
            {
                TxtIGSTVal.Text = item["TaxAmount"].ToString();
                Rate = Convert.ToDecimal(item["TaxRate"].ToString());
                TXTIGST.Text = Rate.ToString();
            }
        }
        public void BindCustomerDropDownOnSales()
        {
            CustomerClass cup = new CustomerClass();
            DataTable dt = new DataTable();
            dt.Columns.Add("Customerid", typeof(System.Int32));
            dt.Columns.Add("Name", typeof(System.String));
            dsCustDetail = cup.BindDropDownCustomers(UniqueShopID);
            dt = cup.BindDropDownCustomers(UniqueShopID).Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataView dv = new DataView(dt);
                //dv.Sort = "Customerid desc";
                cmbSupplierName.DataSource = dv.ToTable();
                cmbSupplierName.DisplayMember = "Name";
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

        public void BindDelMode()
        {
            CustomerClass cup = new CustomerClass();
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(System.Int32));
            dt.Columns.Add("Delmode", typeof(System.String));
            dt = cup.BindDelMode().Tables[0];
            dt.Rows.Add(0, "Select Mode");
            DataView dv = new DataView(dt);
            dv.Sort = "id";
            CmbDelMode.DataSource = dv.ToTable();
            CmbDelMode.DisplayMember = "Delmode";
            CmbDelMode.ValueMember = "id";
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
            double CGST = 0.00;
            double SGST = 0.00;
            double IGST = 0.00;



            string Modelno = string.Empty;
            if (i != 0)
            {
                TxtHSNCode.Text = p.GetItemHSNCode(UniqueShopID, Convert.ToInt32(cmbProductname.SelectedValue), out unitid, out price, out Modelno, out CGST, out SGST, out IGST);
                cmbUnit.SelectedValue = unitid.ToString();
                TxtItemCGST.Text = CGST.ToString();
                TxtItemSGST.Text = SGST.ToString();
                TxtItemIGST.Text = IGST.ToString();
                txtPrice.Text = price.ToString();
                txtbaseprice.Text = price.ToString();
                TxtModel.Text = Modelno;


            }
            Chkscgst.Checked = true;
            ChkTaxIncluded.Checked = true;
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
            if (e.RowIndex < 0)
                return;
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
                      BasePrice = Convert.ToDecimal(a["BasePrice"].ToString()),
                      ItemSrNo = a["SrNoVal"].ToString(),
                      price = Convert.ToDecimal(a["Price"].ToString()),
                      disc = Convert.ToDecimal(a["Discount"].ToString()),
                      qty = Convert.ToInt32(a["Qty"].ToString()),
                      IsTaxIncluded = Convert.ToBoolean(a["TaxIncluded"].ToString()),
                      SCGST = Convert.ToBoolean(a["SCGST"].ToString()),
                      IGST = Convert.ToBoolean(a["IGST"].ToString()),
                      CGSTPer = Convert.ToDecimal(a["CGSTPer"].ToString()),
                      SGSTPer = Convert.ToDecimal(a["SGSTPer"].ToString()),
                      IGSTPer = Convert.ToDecimal(a["IGSTPer"].ToString()),
                      CGSTVal = Convert.ToDecimal(a["CGSTVal"].ToString()),
                      SGSTVal = Convert.ToDecimal(a["SGSTVal"].ToString()),
                      IGSTVal = Convert.ToDecimal(a["IGSTVal"].ToString()),
                      NetTax = Convert.ToDecimal(a["NetTax"].ToString()),
                      NetAmt = Convert.ToDecimal(a["NetAmt"].ToString())
                  }).ToList();
            List<PurchaseBe> LBE = new List<PurchaseBe>();
            LBE = lp.Where(X => X.Sno == i).ToList();
            foreach (PurchaseBe item in LBE)
            {
                Catid = item.Categoryid;
                BrandID = item.Brandid;
                BrandWiseProduct(BrandID);
                ProductID = item.Productid;
                SerialNO = item.ItemSrNo;
                UnitIDS = item.UnitID;
                txtQty.Text = item.qty.ToString();
                txtPrice.Text = item.price.ToString();
                txtbaseprice.Text = item.BasePrice.ToString();
                txtDiscount.Text = item.disc.ToString();
                txtAmount.Text = item.amount.ToString();
                ChkTaxIncluded.Checked = item.IsTaxIncluded;

                Chkscgst.Checked = item.SCGST;
                ChkIgst.Checked = item.IGST;
                TxtItemCGST.Text = item.CGSTPer.ToString();
                TxtItemSGST.Text = item.SGSTPer.ToString();
                TxtItemIGST.Text = item.IGSTPer.ToString();
                TxtCGSTVal.Text = item.CGSTVal.ToString();
                TxtSgstVal.Text = item.SGSTVal.ToString();
                TxtIGSTVal.Text = item.IGSTVal.ToString();
                ItemNetTax.Text = item.NetTax.ToString();
                TxtTotalAmt.Text = item.NetAmt.ToString();
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
            Report.FrmTaxInvoice tx = new Report.FrmTaxInvoice(txtPono.Text, UniqueShopID);
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
            Report.AddViewCustomerAMC amcadd = new Report.AddViewCustomerAMC(dtUPAMCSchedule, this);
            amcadd.ShowDialog();
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
            dtexp.Value = txtPurdate.Value.AddYears((int)NMWarDuration.Value);
        }

        private void ChkWar_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkWar.Checked)
            {
                dtexp.Value = txtPurdate.Value.AddYears((int)NMWarDuration.Value);
            }
        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtSCTax.Text))
            {
                TXTIGST.Text = string.Empty;
                TxtIGSTVal.Text = string.Empty;
                CalculateTaxByNewLogic(dtProduct, Convert.ToInt32(TxtSCTax.Text), "SC");

            }
        }

        private void ShowItemWiseTax(Double NetAmount, double SGSTRate, double CGSTRate, double IGSTRate, bool IsTaxIncluded, bool ApplyCSGST, bool ApplyIGST, out double CGSTVAL, out double SGSTVal, out double IGSTVal, out double BasePrice)
        {
            CGSTVAL = 0.00;
            SGSTVal = 0.00;
            IGSTVal = 0.00;
            BasePrice = 0.00;
            double BP = 0.00;
            if (NetAmount > 0)
            {
                if (IsTaxIncluded)
                {
                    if (ApplyCSGST)
                    {
                        BasePrice = Math.Round(((NetAmount / (double)ProductQuantity) / (100 + CGSTRate + SGSTRate)) * 100, 2);
                        BP = Math.Round((NetAmount / (100 + CGSTRate + SGSTRate)) * 100, 2);
                        CGSTVAL = Math.Round((NetAmount - BP) / 2, 2);
                        SGSTVal = Math.Round((NetAmount - BP) / 2, 2);
                        IGSTVal = 0.00;
                    }
                    else if (ApplyIGST)
                    {
                        BasePrice = Math.Round(((NetAmount / (double)ProductQuantity) / (100 + IGSTRate)) * 100, 2);
                        BP = Math.Round((NetAmount / (100 + IGSTRate)) * 100, 2);
                        CGSTVAL = 0.00;
                        SGSTVal = 0.00;
                        IGSTVal = Math.Round((NetAmount - BP), 2);
                    }
                }
                else
                {
                    if (ApplyCSGST)
                    {
                        BasePrice = NetAmount;
                        CGSTVAL = (NetAmount * CGSTRate) / 100;
                        SGSTVal = (NetAmount * SGSTRate) / 100;
                        IGSTVal = 0.00;
                    }
                    else if (ApplyIGST)
                    {
                        BasePrice = NetAmount;
                        CGSTVAL = 0.00;
                        SGSTVal = 0.00;
                        IGSTVal = (NetAmount * IGSTRate) / 100;
                    }
                }
            }

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbaseprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtbaseprice_TextChanged(object sender, EventArgs e)
        {
            CalculatedValue();
            ShowTaxValues();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TXTIGST_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void TXTIGST_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TXTIGST.Text))
            {
                TxtCGSTVal.Text = string.Empty;
                TxtSgstVal.Text = string.Empty;
                TxtSCTax.Text = string.Empty;
                CalculateTaxByNewLogic(dtProduct, Convert.ToInt32(TXTIGST.Text), "IG");
            }
        }

        private void TxtSCTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TXTIGST_KeyPress(object sender, KeyPressEventArgs e)
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
                CustomerClass p = new CustomerClass();
                string CustomerContact = string.Empty;
                int i = Convert.ToInt32(SelectedCustomerID);
                if (i != 0)
                {
                    DataView dv = new DataView(p.BindCustomers(UniqueShopID).Tables[0]);
                    dv.RowFilter = "Customerid = '" + SelectedCustomerID + "'";
                    txtadd.Text = dv.ToTable().Rows[0]["Address"].ToString();
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
                    CustomerClass p = new CustomerClass();
                    string CustomerContact = string.Empty;
                    int i = Convert.ToInt32(SelectedCustomerID);
                    if (i != 0)
                    {
                        DataView dv = new DataView(p.BindCustomers(UniqueShopID).Tables[0]);
                        dv.RowFilter = "Customerid = '" + SelectedCustomerID + "'";

                        txtadd.Text = dv.ToTable().Rows[0]["Address"].ToString();
                        TxtContact.Text = dv.ToTable().Rows[0]["Contact"].ToString();
                        txtGstin.Text = dv.ToTable().Rows[0]["GSTIN"].ToString();
                        LstEmp.Visible = false;
                        cmbSupplierName.SelectedValue = SelectedCustomerID;

                    }
                }
            }
        }

        private void TxtEmp_KeyDown(object sender, KeyEventArgs e)
        {
            //LstEmp.Focus();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtProduct_TextChanged(object sender, EventArgs e)
        {
            if (TxtProduct.Text == string.Empty)
            {
                LstProduct.Visible = false;
                return;
            }
            if (dsProduct.Tables[0].Rows.Count > 0)
            {
                DataView dv = new DataView(dsProduct.Tables[0]);
                dv.RowFilter = "Productname like '%" + TxtProduct.Text + "%'";
                LstProduct.Visible = true;
                LstProduct.DataSource = dv.ToTable();
                LstProduct.DisplayMember = "Productname";
                LstProduct.ValueMember = "Productid";
            }
        }

        private void LstProduct_Click(object sender, EventArgs e)
        {
            SelectedProductID = LstProduct.GetItemText(LstProduct.SelectedValue);
            if (!string.IsNullOrEmpty(SelectedProductID))
            {
                TxtProduct.Text = LstProduct.GetItemText(LstProduct.SelectedItem);
                cmbProductname.SelectedValue = SelectedProductID;
                ProductClass p1 = new ProductClass();
                DataView dv = new DataView(p1.AvailableInventory(UniqueShopID, SelectedProductID, TxtSrno.Text).Tables[0]);
                TxtAvailQty.Text = dv.ToTable().Rows[0]["AvailableQty"].ToString();
                LstProduct.Visible = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LstProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SelectedProductID = LstProduct.GetItemText(LstProduct.SelectedValue);
                if (!string.IsNullOrEmpty(SelectedProductID))
                {
                    TxtProduct.Text = LstProduct.GetItemText(LstProduct.SelectedItem);
                    cmbProductname.SelectedValue = SelectedProductID;
                    LstProduct.Visible = false;
                }
            }
        }

        private void Chkscgst_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkscgst.Checked == true)
            {
                ChkIgst.Checked = false;
                CalculatedValue();
                ShowTaxValues();
            }

        }

        private void ChkIgst_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkIgst.Checked == true)
            {
                Chkscgst.Checked = false;
                CalculatedValue();
                ShowTaxValues();
            }
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtBarCode_KeyUp(object sender, KeyEventArgs e)
        {
            // ProductClass pc = new ProductClass();
            if (e.KeyValue == (char)Keys.Return)
            {
                if (txtBarCode.Text == string.Empty)
                {
                    return;
                }
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
                    TxtProduct.Text = cmbProductname.Text;
                    cmbUnit.SelectedValue = unitid.ToString();
                    txtPrice.Text = price.ToString();
                    txtQty.Text = "1";
                }
                AddOrder();
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
            ResetAllcontrol();
        }

        private void TxtSrno_Leave(object sender, EventArgs e)
        {
            ProductClass p1 = new ProductClass();
            DataView dv = new DataView(p1.AvailableInventory(UniqueShopID, SelectedProductID, TxtSrno.Text).Tables[0]);
            TxtAvailQty.Text = dv.ToTable().Rows[0]["AvailableQty"].ToString();
        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ProductClass prod = new ProductClass();
            dsProduct = prod.BindProducts(UniqueShopID);
        }

        private void ChkTaxIncluded_CheckedChanged(object sender, EventArgs e)
        {
            CalculatedValue();
            ShowTaxValues();
        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductDetails cd = new ProductDetails(this, UniqueShopID);
            cd.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReceivePayment rec = new ReceivePayment(OrdID, txtPono.Text, this, UniqueShopID, Convert.ToDecimal(txtsumnet.Text));
            rec.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Delete Record?", "Sales Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sales PUR = new Sales();
                int phid = 0;
                if (IsEditMode)
                {
                    MSEntities db = new MSEntities();
                    string pono = txtPono.Text;
                    phid = InvoiceID;
                }
                PUR.DeleteSalesOrder(IsEditMode, phid);
                MessageBox.Show(this, "Record Deleted Successfully.", "Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnConvertEmi_Click(object sender, EventArgs e)
        {           
            frmconvertemi frmcnvt = new frmconvertemi(OrdID, txtPono.Text, UniqueShopID, Convert.ToDouble(txtbalanceamt.Text),this);
            frmcnvt.ShowDialog();
        }

        private void txtsumnet_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChkDel_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDel.Checked)
            {
                ChkDel.Text = "Delivered";
                
            }
            else
            {
                ChkDel.Text = "Not Delivered";
                
            }
        }
    }
}
