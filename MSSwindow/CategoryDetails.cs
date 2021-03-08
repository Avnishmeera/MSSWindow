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
using System.Data.SqlClient;



namespace MSSwindow
{
    public partial class CategoryDetails : Form
    {
        public readonly int UniqueShopID = 0;
        public CategoryDetails(int ShopID)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
        }        
        
        public CategoryDetails(MainForm ADMN)
        {
            InitializeComponent();
            UniqueShopID = ADMN.ShpID;
        }        
        
        CategoryClass cc = new CategoryClass();
        private void btnAddnew_Click(object sender, EventArgs e)
        {
            AddNewButtonClick();
            int id = 0;
            lblId.Text = "" + id;                        
            txtCategoryname.Focus();
        }

        private void Formload()
        {            
            txtCategoryname.Enabled = false;
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
            txtCategoryname.Enabled = true;          
            txtDescription.Enabled = true;
            chkIsActive.Enabled = true;

            txtCategoryname.Text = string.Empty;
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
            txtCategoryname.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsActive.Checked = false;

            txtCategoryname.Enabled = false;           
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
            
            txtCategoryname.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsActive.Checked = false;

            txtCategoryname.Enabled = false;           
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
            txtCategoryname.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsActive.Checked = true;           

            btnAddnew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;
        }

        private void DataGridviewCellClick()
        {            
            txtCategoryname.Enabled = true;
            txtDescription.Enabled = true;
            chkIsActive.Enabled = true;

            btnAddnew.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            btnReset.Enabled = true;
            btnClose.Enabled = true;
        }        
     
        private void CategoryDetails_Load(object sender, EventArgs e)
        {
            Formload();                
            BindDataGridview();
            lblId.Visible = false;           
            txtCategoryname.Focus();
        }       

       private void btnSave_Click(object sender, EventArgs e)
        {
            //if (CheckExistingProduct(Categoryid) && IsEdit == false)
            //{
            //    MessageBox.Show(this, "Category allready added.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            //    return;
            //}
           // else
            if (txtCategoryname.Text == string.Empty)
            {
                MessageBox.Show(this, "Please Fill Category Name", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtCategoryname.Focus();
                return;               
            }
           
            else
            {
                CategoryclassBe be = new CategoryclassBe();
                be.Shopid = UniqueShopID;
                be.Categoryid =Convert.ToInt32(lblId.Text);
                be.Categoryname = txtCategoryname.Text;
                be.Description = txtDescription.Text;
                be.IsActive = Convert.ToInt32(chkIsActive.Checked);
                CategoryClass catclass = new CategoryClass();
                catclass.InsertUpdateCategory(be);
                if (MessageBox.Show("Do You Want To Save Record?", "Category Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (lblId.Text == "0")
                    {
                        MessageBox.Show(this, "Record Saved Successfully.", "Category Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SaveButtonClick();
                    }
                    else
                    {
                        MessageBox.Show(this, "Record Updated Successfully.", "Category Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SaveButtonClick();
                    }
                }                
                BindDataGridview();               
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
        private void BindDataGridview()
        {
            CategoryclassBe be = new CategoryclassBe();
            be.Shopid = UniqueShopID;
            dataGridViewCategory.DataSource = cc.BindCategory1(be);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Record?", "Confirm deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(lblId.Text))
                {
                    CategoryclassBe be = new CategoryclassBe();
                    be.Categoryid = Convert.ToInt32(lblId.Text);
                    cc.DeleteCategory(be);
                    MessageBox.Show("Successfully deleted the Record. ", "Sucessful deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindDataGridview();
                    DeleteButtonClick();
                }
            }           
        }

        private void dataGridViewCategory_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridviewCellClick();
            if (e.RowIndex < 0)
                return;
            int UniqueShopID = Convert.ToInt32(dataGridViewCategory.Rows[e.RowIndex].Cells[0].Value.ToString());
            lblId.Text = dataGridViewCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCategoryname.Text = dataGridViewCategory.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDescription.Text = dataGridViewCategory.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            CategoryclassBe be = new CategoryclassBe();
          
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            CategoryClass cc = new CategoryClass();
            DataView dv = new DataView();
            DataSet ds = new DataSet();
            ds = cc.BindCategory(UniqueShopID);
            dv.Table = ds.Tables[0];
            dv.RowFilter = "Categoryname like '%" + txtSearch.Text + "%'";
            dataGridViewCategory.DataSource = dv;
           
        }
        DataTable dtProduct = new DataTable();
        private bool CheckExistingProduct(int id)
        {
            bool exist = false;
            List<CategoryclassBe> lp = new List<CategoryclassBe>();
            lp = (from a in dtProduct.AsEnumerable()
                  select new CategoryclassBe
                  {
                      Categoryid = Convert.ToInt32(a["Categoryid"].ToString())
                  }).ToList();
            var p = lp.Where(x => x.Categoryid == id).FirstOrDefault();
            if (p != null)
            {
                exist = true;
            }
            return exist;
        }
       
        private void dataGridViewCategory_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            
        }

        
    }
}

