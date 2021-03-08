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



namespace MSSwindow
{
    public partial class ProductDetails : Form
    {
        public readonly int UniqueShopID = 0;
        public ProductDetails(MainForm admn)
        {
            InitializeComponent();
            UniqueShopID = admn.ShpID;
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
            txthsncode.Enabled = false;
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
        }
        private void AddNewButtonClick()
        {
            cmbCategoryname.Enabled = true;
            cmbBrandName.Enabled = true;
            txtProductCode.Enabled = true;
            txthsncode.Enabled = true;           
            txtProductName.Enabled = true;
            TxtPrice.Enabled = true;
            cmbUnit.Enabled = true;
            txtBarCode.Enabled = true;
            txtDescription.Enabled = true;
            chkIsActive.Enabled = true;

            cmbCategoryname.SelectedIndex = 0;
            cmbBrandName.SelectedIndex = 0;
            txtProductCode.Text = string.Empty;
            txthsncode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            TxtPrice.Text = string.Empty;
            cmbUnit.SelectedIndex = 0;
            txtBarCode.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsActive.Checked = true;

            btnAddnew.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;
        }

        private void SaveButtonClick()
        {

            cmbCategoryname.SelectedIndex = 0;
            cmbBrandName.SelectedIndex = 0;
            txtProductCode.Text = string.Empty;
            txthsncode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            TxtPrice.Text = string.Empty;
            cmbUnit.SelectedIndex = 0;
            txtBarCode.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsActive.Checked = false;

            cmbCategoryname.Enabled = false;
            cmbBrandName.Enabled = false;
            txtProductCode.Enabled = false;
            txthsncode.Enabled = false;
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
        }

        private void DeleteButtonClick()
        {
            cmbCategoryname.SelectedIndex = 0;
            cmbBrandName.SelectedIndex = 0;
            txtProductCode.Text = string.Empty;
            txthsncode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            TxtPrice.Text = string.Empty;
            cmbUnit.SelectedIndex = 0;
            txtBarCode.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsActive.Checked = false;

            cmbCategoryname.Enabled = false;
            cmbBrandName.Enabled = false;
            txtProductCode.Enabled = false;
            txthsncode.Enabled = false;
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

        }

        private void ResetButtonClick()
        {
            cmbCategoryname.SelectedIndex = 0;
            cmbBrandName.SelectedIndex = 0;
            txtProductCode.Text = string.Empty;
            txthsncode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            TxtPrice.Text = string.Empty;
            cmbUnit.SelectedIndex = 0;
            txtBarCode.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsActive.Checked = false;

            cmbCategoryname.Enabled = false;
            cmbBrandName.Enabled = false;
            txtProductCode.Enabled = false;
            txthsncode.Enabled = false;
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
        }

        private void DataGridviewCellClick()
        {
            cmbCategoryname.Enabled = true;
            cmbBrandName.Enabled = true;
            txtProductCode.Enabled = true;
            txthsncode.Enabled = true;
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
                    be.Price = Convert.ToInt32(TxtPrice.Text);
                    be.Unit = Convert.ToInt32(cmbUnit.SelectedValue);
                    be.Barcode = txtBarCode.Text;
                    be.HSNCode = txthsncode.Text;
                    be.IsActive = Convert.ToInt32(chkIsActive.Checked);
                    ProductClass pd = new ProductClass();
                    pd.InsertUpdateProducts(be);

                    if (lblId.Text == "0")
                    {
                        MessageBox.Show(this, "Record Saved Successfully.", "Products Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SaveButtonClick();                      
                    }
                    else
                    {
                        MessageBox.Show(this, "Record Updated Successfully.", "Products Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SaveButtonClick();
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
                lblId.Text = dataGridViewProducts.Rows[e.RowIndex].Cells["Productid"].Value.ToString();         
                cmbCategoryname.SelectedValue = dataGridViewProducts.Rows[e.RowIndex].Cells["CatID"].Value.ToString();  
                cmbBrandName.SelectedValue = dataGridViewProducts.Rows[e.RowIndex].Cells["BrandID"].Value.ToString();
                txtProductCode.Text = dataGridViewProducts.Rows[e.RowIndex].Cells["ProductCode"].Value.ToString(); 
                txtProductName.Text = dataGridViewProducts.Rows[e.RowIndex].Cells["Productname"].Value.ToString();             
                TxtPrice.Text = dataGridViewProducts.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                cmbUnit.SelectedValue = dataGridViewProducts.Rows[e.RowIndex].Cells["UnitID"].Value.ToString();
                txthsncode.Text = dataGridViewProducts.Rows[e.RowIndex].Cells["HSNCode"].Value.ToString();
                txtDescription.Text = dataGridViewProducts.Rows[e.RowIndex].Cells["Description"].Value.ToString();
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
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
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
    }
}
