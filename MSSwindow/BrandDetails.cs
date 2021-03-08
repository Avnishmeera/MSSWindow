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
    public partial class BrandDetails : Form
    {
        public readonly int UniqueShopID = 0;
        public BrandDetails(MainForm ADMN)
        {
            InitializeComponent();
            UniqueShopID = ADMN.ShpID;
        }
        CategoryClass cc = new CategoryClass();
        Brands brnd = new Brands();
        Brands bd = new Brands();

        private void BrandDetails_Load(object sender, EventArgs e)
        {
            Formload();      
            BindDataGridview();
            lblid.Visible = false;
            int id = 0;
            lblid.Text = "" + id;
            BindCategoryDropDown();            
        }       

        private void BindCategoryDropDown()
        {
            CategoryclassBe be = new CategoryclassBe();
            be.Shopid = UniqueShopID;
            CategoryClass catc = new CategoryClass();
            DataTable dt = new DataTable();
            dt.Columns.Add("Categoryid", typeof(System.Int32));
            dt.Columns.Add("Categoryname", typeof(System.String));
            dt = catc.BindDropDownCategory1(be);
            dt.Rows.Add(0, "----- Select -----");
            DataView dv = new DataView(dt);
            dv.Sort = "Categoryid";
            cmbCategoryname.DataSource = dv.ToTable();
            cmbCategoryname.DisplayMember = "Categoryname";
            cmbCategoryname.ValueMember = "Categoryid";           
        }

        private void Formload()
        {
            cmbCategoryname.Enabled = false;
            txtBrandName.Enabled = false;
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
            cmbCategoryname.Enabled=true;
            txtBrandName.Enabled=true;
            txtDescription.Enabled=true;
            chkIsActive.Enabled=true;

            cmbCategoryname.SelectedIndex=0;
            txtBrandName.Text = string.Empty;
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
            txtBrandName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsActive.Checked = false;

            cmbCategoryname.Enabled = false;
            txtBrandName.Enabled = false;
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
            txtBrandName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsActive.Checked = false;

            cmbCategoryname.Enabled = false;
            txtBrandName.Enabled = false;
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
            txtBrandName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsActive.Checked = true;

            cmbCategoryname.Enabled = false;
            txtBrandName.Enabled = false;
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
            txtBrandName.Enabled = true;
            txtDescription.Enabled = true;
            chkIsActive.Enabled = true;

            btnAddnew.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            btnReset.Enabled = true;
            btnClose.Enabled = true;
        }         
        private void BindDataGridview()
        {
            BrandsBe be = new BrandsBe();
            be.Shopid = UniqueShopID;
            dataGridViewBrands.DataSource = bd.BindBrands1(be);
        }
        private void btnAddnew_Click(object sender, EventArgs e)
        {
            AddNewButtonClick();           
            int id = 0;
            lblid.Text = "" + id;          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Save Record?","Purchase Order",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                 if (txtBrandName.Text == string.Empty)
            {
                MessageBox.Show(this, "Please Fill Brand Name", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtBrandName.Focus();               
            }
            else
            {
                BrandsBe be = new BrandsBe();
                be.Shopid = UniqueShopID;
                be.BrandID = Convert.ToInt32(lblid.Text);
                be.CategoryBrandID = Convert.ToInt32(cmbCategoryname.SelectedValue);
                be.BrandName = txtBrandName.Text;
                be.Description = txtDescription.Text;
                be.IsActive = Convert.ToInt32(chkIsActive.Checked);
                Brands bd = new Brands();
                bd.InsertUpdateBrands(be);
                if (lblid.Text=="0")
                {
                    MessageBox.Show(this, "Record Saved Successfully.", "Brand Details", MessageBoxButtons.OK, MessageBoxIcon.Information);                   
                    SaveButtonClick();
                }
                else
                {
                    MessageBox.Show(this, "Record Updated Successfully.", "Brand Details", MessageBoxButtons.OK, MessageBoxIcon.Information);                   
                    SaveButtonClick();                  
                }
                BindDataGridview();              
                SaveButtonClick();
            }
         }         
          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete this Record?", "Confirm deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(lblid.Text))
                {
                    BrandsBe be = new BrandsBe();
                    be.BrandID = Convert.ToInt32(lblid.Text);
                    brnd.DeleteBrands(be);
                    MessageBox.Show("Successfully deleted the Record. ", "Sucessful deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindDataGridview();                 
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

        private void dataGridViewBrands_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {       
            DataGridviewCellClick();
            if (e.RowIndex < 0)
                return;
            lblid.Text = dataGridViewBrands.Rows[e.RowIndex].Cells["Brandid"].Value.ToString();
            cmbCategoryname.SelectedValue = dataGridViewBrands.Rows[e.RowIndex].Cells["CatID"].Value.ToString();
            txtBrandName.Text = dataGridViewBrands.Rows[e.RowIndex].Cells["Brandname"].Value.ToString();
            txtDescription.Text = dataGridViewBrands.Rows[e.RowIndex].Cells["Description"].Value.ToString();           
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Brands br = new Brands();
            DataView dv = new DataView();
            DataSet ds = new DataSet();
            ds = br.BindBrands(UniqueShopID);
            dv.Table = ds.Tables[0];
            dv.RowFilter = "Brandname like '%" + txtSearch.Text + "%'";
            dataGridViewBrands.DataSource = dv;
        }
    }
}
