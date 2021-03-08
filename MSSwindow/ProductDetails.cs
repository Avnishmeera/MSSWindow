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
using System.IO;



namespace MSSwindow
{
    public partial class ProductDetails : Form
    {
        public readonly int UniqueShopID = 0;
        RetailSaleDetails SaleDetail = null;

        public ProductDetails(MainForm admn)
        {
            InitializeComponent();
            UniqueShopID = admn.ShpID;
        }
        public ProductDetails(RetailSaleDetails rsd,int ShopID)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
            SaleDetail = rsd;
        }

        public ProductDetails()
        {
            InitializeComponent();         

        }
        private void Formload()
        {
            cmbCategoryname.Enabled = false;
            cmbBrandName.Enabled = false;
            txtProductCode.Enabled = false;
            txtModelNo.Enabled = false;
            txtProductName.Enabled = false;
            TxtPrice.Enabled = false;
            cmbUnit.Enabled = false;
            txtBarCode.Enabled = false;
            txtDescription.Enabled = false;
            chkIsActive.Enabled = false;

            txtCgst.Enabled = false;
            txtSgst.Enabled = false;
            txtIGST.Enabled = false; 

            btnAddnew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;
        }
        private void AddNewButtonClick()
        {
            cmbCategoryname.Enabled = true;
            cmbBrandName.Enabled = true;
            txtProductCode.Enabled = true;
            txtModelNo.Enabled = true;           
            txtProductName.Enabled = true;
            TxtPrice.Enabled = true;
            cmbUnit.Enabled = true;
            txtBarCode.Enabled = true;
            txtDescription.Enabled = true;
            chkIsActive.Enabled = true;
            txtCgst.Text = "0";
            txtSgst.Text = "0";
            txtIGST.Text = "0";
            cmbCategoryname.SelectedIndex = 0;
            cmbBrandName.SelectedIndex = 0;
            txtProductCode.Text = string.Empty;
            txtModelNo.Text = string.Empty;
            txtProductName.Text = string.Empty;
            TxtPrice.Text = string.Empty;
            cmbUnit.SelectedIndex = 0;
            txtBarCode.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsActive.Checked = true;

            txtCgst.Enabled = true;
            txtSgst.Enabled = true;
            txtIGST.Enabled = true;



            btnAddnew.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;
            pictureBox1.Image = null;
        }

        private void SaveButtonClick()
        {

            cmbCategoryname.SelectedIndex = 0;
            cmbBrandName.SelectedIndex = 0;
            txtProductCode.Text = string.Empty;
            txtModelNo.Text = string.Empty;
            txtProductName.Text = string.Empty;
            TxtPrice.Text = string.Empty;
            cmbUnit.SelectedIndex = 0;
            txtBarCode.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsActive.Checked = false;
            txtCgst.Text = "0";
            txtSgst.Text = "0";
            txtIGST.Text = "0";
            cmbCategoryname.Enabled = false;
            cmbBrandName.Enabled = false;
            txtProductCode.Enabled = false;
            txtModelNo.Enabled = false;
            txtProductName.Enabled = false;
            TxtPrice.Enabled = false;
            cmbUnit.Enabled = false;
            txtBarCode.Enabled = false;
            txtDescription.Enabled = false;
            chkIsActive.Enabled = false;            

            btnAddnew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;
            pictureBox1.Image = null;
            txtHsnCode.Text = string.Empty;
        }

        private void DeleteButtonClick()
        {
            cmbCategoryname.SelectedIndex = 0;
            cmbBrandName.SelectedIndex = 0;
            txtProductCode.Text = string.Empty;
            txtModelNo.Text = string.Empty;
            txtProductName.Text = string.Empty;
            TxtPrice.Text = string.Empty;
            cmbUnit.SelectedIndex = 0;
            txtBarCode.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsActive.Checked = false;

            cmbCategoryname.Enabled = false;
            cmbBrandName.Enabled = false;
            txtProductCode.Enabled = false;
            txtModelNo.Enabled = false;
            txtProductName.Enabled = false;
            TxtPrice.Enabled = false;
            cmbUnit.Enabled = false;
            txtBarCode.Enabled = false;
            txtDescription.Enabled = false;
            chkIsActive.Enabled = false; 

            btnAddnew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;
            pictureBox1.Image = null;

        }

        private void ResetButtonClick()
        {
            cmbCategoryname.SelectedIndex = 0;
            cmbBrandName.SelectedIndex = 0;
            txtProductCode.Text = string.Empty;
            txtModelNo.Text = string.Empty;
            txtProductName.Text = string.Empty;
            TxtPrice.Text = string.Empty;
            cmbUnit.SelectedIndex = 0;
            txtBarCode.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsActive.Checked = false;
            txtModelNo.Text = string.Empty;

            cmbCategoryname.Enabled = false;
            cmbBrandName.Enabled = false;
            txtProductCode.Enabled = false;
            txtModelNo.Enabled = false;
            txtProductName.Enabled = false;
            TxtPrice.Enabled = false;
            cmbUnit.Enabled = false;
            txtBarCode.Enabled = false;
            txtDescription.Enabled = false;
            chkIsActive.Enabled = false;

            btnAddnew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;
            pictureBox1.Image = null;
        }

        private void DataGridviewCellClick()
        {
            cmbCategoryname.Enabled = true;
            cmbBrandName.Enabled = true;
            txtProductCode.Enabled = true;
            txtModelNo.Enabled = true;
            txtProductName.Enabled = true;
            TxtPrice.Enabled = true;
            cmbUnit.Enabled = true;
            txtBarCode.Enabled = true;
            txtDescription.Enabled = true;
            chkIsActive.Enabled = true;

            btnAddnew.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            btnReset.Enabled = true;
            btnClose.Enabled = true;
        }         

        CategoryClass cc = new CategoryClass();
        ProductClass pd = new ProductClass();
        private void txtBrandName_TextChanged(object sender, EventArgs e)
        {

        }
        private void BindCategoryDropDown()
        {
            CategoryclassBe be = new CategoryclassBe();
            be.Shopid = UniqueShopID;
            DataTable dt = new DataTable();
            dt = cc.BindDropDownCategory1(be);
            dt.Rows.Add("0", "Select");
            DataView dv = new DataView(dt);
            dv.Sort = "Categoryid asc";
            cmbCategoryname.DataSource = dv.ToTable();
            cmbCategoryname.DisplayMember = "Categoryname";
            cmbCategoryname.ValueMember = "Categoryid";           
        }

        private void ProductDetails_Load(object sender, EventArgs e)
        {
            Formload();
            lblId.Visible = false;
            BindCategoryDropDown();
            BindGridProducts();
            BindUnitDropdown();         
        }
             
        private void BindGridProducts()
        {
            dataGridViewProducts.DataSource = pd.BindProducts(UniqueShopID).Tables[0];
        }
        public int CategoryID
        {
            get
            {
                if (cmbCategoryname.SelectedValue != string.Empty)
                {
                    return Convert.ToInt32(cmbCategoryname.SelectedValue);
                }
                else
                {
                    return 0;
                }
            }
        }

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

        public int UnitID
        {
            get
            {
                if (cmbUnit.SelectedValue != string.Empty)
                {
                    return Convert.ToInt32(cmbUnit.SelectedValue);
                }
                else
                {
                    return 0;
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
        private void cmbCategoryname_SelectedIndexChanged(object sender, EventArgs e)
        {
            Brands brnd = new Brands();
            DataTable dt = new DataTable();
            BrandsBe be = new BrandsBe();
            be.Shopid = UniqueShopID;
            dt = brnd.CategoryWiseBrand(CategoryName,UniqueShopID);            
            cmbBrandName.DataSource = dt;
            cmbBrandName.DisplayMember = "BrandName";
            cmbBrandName.ValueMember = "BrandID";
        }         

        private void btnAddnew_Click(object sender, EventArgs e)
        {
            AddNewButtonClick();                    
            int id = 0;
            lblId.Text = "" + id;            
        }

        private void ShowImageInPictureBox(string FileName)
        {
            String ExePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            ExePath = ExePath.Substring(6);
            ExePath = ExePath + "\\Images\\" + FileName;
            textBox1.Text = ExePath;
            pictureBox1.ImageLocation = ExePath;

        }
        private void BindDataGridviewProducts()
        {
            dataGridViewProducts.DataSource = pd.BindProducts(UniqueShopID).Tables[0];
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Save Record?", "Products Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                if (txtProductName.Text == string.Empty)
                {
                    MessageBox.Show("Please Fill Product Name");
                    txtProductName.Focus();
                }
                else if (TxtPrice.Text == string.Empty)
                {
                    MessageBox.Show("Please Fill Price");
                    TxtPrice.Focus();
                }

                else if (cmbUnit.SelectedValue.ToString() == "0")
                {
                    MessageBox.Show("Please select Unit");
                    cmbUnit.Focus();
                }      
                
	          else
                {
                    ProductClassBe be = new ProductClassBe();
                    be.Shopid = UniqueShopID;
                    be.ProductID = Convert.ToInt32(lblId.Text);
                    be.CategoryPID = Convert.ToInt32(cmbCategoryname.SelectedValue);
                    be.BrandPID = Convert.ToInt32(cmbBrandName.SelectedValue);
                    be.ProductCode = txtProductCode.Text;
                    be.ProductName = txtProductName.Text;
                    be.Description = txtDescription.Text;
                    be.Price = Convert.ToDouble(TxtPrice.Text);
                    be.Unit = Convert.ToInt32(cmbUnit.SelectedValue);
                    be.CGST =Convert.ToDouble(txtCgst.Text);
                    be.SGST = Convert.ToDouble(txtSgst.Text);
                    be.IGST = Convert.ToDouble(txtIGST.Text);
                    be.Barcode = txtBarCode.Text;
                    be.HSNCode = txtHsnCode.Text;
                    be.ModelNo = txtModelNo.Text;
                    be.IsActive = Convert.ToInt32(chkIsActive.Checked);
                    //be.ImageName=
                    ProductClass pd = new ProductClass();
                    pd.InsertUpdateProducts(be);

                    if (lblId.Text == "0")
                    {
                        MessageBox.Show(this, "Record Saved Successfully.", "Products Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SaveButtonClick();
                        if (SaleDetail != null)
                        {
                            SaleDetail.RefreshProductOnSales(be.ProductID);
                            this.Close();
                        }
                                             
                    }
                    else
                    {
                        MessageBox.Show(this, "Record Updated Successfully.", "Products Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SaveButtonClick();
                        if (SaleDetail != null)
                        {
                            SaleDetail.RefreshProductOnSales(be.ProductID);
                            this.Close();
                        }
                    }                    
                    BindGridProducts();
                    SaveButtonClick();
                   
                }
            }
          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Record?", "Confirm deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(lblId.Text))
                {
                    ProductClass pc = new ProductClass();
                    ProductClassBe be = new ProductClassBe();
                    be.ProductID = Convert.ToInt32(lblId.Text);
                    pc.DeleteProduct(be);
                    MessageBox.Show("Successfully deleted the Record. ", "Sucessful deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGridProducts();
                    DeleteButtonClick();
                }
            }
          
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetButtonClick();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewProducts_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridviewCellClick();
            try
            {
                if (e.RowIndex < 0)
                    return;

                lblId.Text = dataGridViewProducts.Rows[e.RowIndex].Cells["Productid"].Value.ToString();         
                cmbCategoryname.SelectedValue = dataGridViewProducts.Rows[e.RowIndex].Cells["CatID"].Value.ToString();  
                cmbBrandName.SelectedValue = dataGridViewProducts.Rows[e.RowIndex].Cells["BrandID"].Value.ToString();
                txtProductCode.Text = dataGridViewProducts.Rows[e.RowIndex].Cells["ProductCode"].Value.ToString(); 
                txtProductName.Text = dataGridViewProducts.Rows[e.RowIndex].Cells["Productname"].Value.ToString();             
                TxtPrice.Text = dataGridViewProducts.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                txtCgst.Text = dataGridViewProducts.Rows[e.RowIndex].Cells["CGST"].Value.ToString();
                txtSgst.Text = dataGridViewProducts.Rows[e.RowIndex].Cells["SGST"].Value.ToString();
                txtIGST.Text = dataGridViewProducts.Rows[e.RowIndex].Cells["IGST"].Value.ToString();
                cmbUnit.SelectedValue = dataGridViewProducts.Rows[e.RowIndex].Cells["UnitID"].Value.ToString();
                txtHsnCode.Text = dataGridViewProducts.Rows[e.RowIndex].Cells["HSNCode"].Value.ToString();
                txtModelNo.Text = dataGridViewProducts.Rows[e.RowIndex].Cells["Model"].Value.ToString();
                txtDescription.Text = dataGridViewProducts.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                txtCgst.Enabled = true;
                txtIGST.Enabled = true;
                txtSgst.Enabled = true;
            }
            catch (Exception ex)
            {                
                throw;
            }          
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }         
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            } 
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ProductClass pc = new ProductClass();
            DataSet ds = new DataSet();
            DataView dv = new DataView();
            ds = pc.BindProducts(UniqueShopID);
            dv.Table = ds.Tables[0];
            dv.RowFilter = "Productname like '%" + txtSearch.Text + "%'";
            dataGridViewProducts.DataSource = dv;
        }

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

        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TxtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
            pictureBox1.ImageLocation = textBox1.Text;
        }

        private void txtCgst_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            } 
        }




        private void txtSgst_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            } 
        }

        private void txtIGST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            } 
        }

        private void dataGridViewProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
