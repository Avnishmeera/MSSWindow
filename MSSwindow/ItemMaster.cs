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
    public partial class ItemMaster : Form
    {
        public readonly int UniqueShopID = 0;
        public ItemMaster(int ShopID)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
        }

        public ItemMaster(MainForm ADMN)
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
            txtItemname.Focus();
        }

        private void Formload()
        {            
            txtItemname.Enabled = false;
            txtCharge.Enabled = false;
            chkIsActive.Enabled = false;

            btnAddnew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;
        }

        private void AddNewButtonClick()
        {
            txtItemname.Enabled = true;          
            txtCharge.Enabled = true;
            chkIsActive.Enabled = true;

            txtItemname.Text = string.Empty;
            txtCharge.Text = string.Empty;
            chkIsActive.Checked = true;

            btnAddnew.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;
        }

        private void SaveButtonClick()
        {           
            txtItemname.Text = string.Empty;
            txtCharge.Text = string.Empty;
            chkIsActive.Checked = false;

            txtItemname.Enabled = false;           
            txtCharge.Enabled = false;
            chkIsActive.Enabled = false;

            btnAddnew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;
        }

        private void DeleteButtonClick()
        {
            
            txtItemname.Text = string.Empty;
            txtCharge.Text = string.Empty;
            chkIsActive.Checked = false;

            txtItemname.Enabled = false;           
            txtCharge.Enabled = false;
            chkIsActive.Enabled = false;

            btnAddnew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;

        }
        private void ResetButtonClick()
        {            
            txtItemname.Text = string.Empty;
            txtCharge.Text = string.Empty;
            chkIsActive.Checked = true;           

            btnAddnew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;
        }

        private void DataGridviewCellClick()
        {            
            txtItemname.Enabled = true;
            txtCharge.Enabled = true;
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
            txtItemname.Focus();
        }       

       private void btnSave_Click(object sender, EventArgs e)
        {
           if (txtItemname.Text == string.Empty)
            {
                MessageBox.Show(this, "Please Fill Item Name", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtItemname.Focus();
                return;               
            }
           else if (txtCharge.Text == string.Empty)
           {
               MessageBox.Show(this, "Please Fill Charge", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
               txtCharge.Focus();
               return;
           }
            else
            {
                CategoryclassBe be = new CategoryclassBe();
                be.Shopid = UniqueShopID;
                be.Itemid =Convert.ToInt32(lblId.Text);
                be.Itemname = txtItemname.Text;
                be.Charge = txtCharge.Text;
                be.IsActive = Convert.ToInt32(chkIsActive.Checked);
                CategoryClass catclass = new CategoryClass();
                catclass.InsertUpdateItemDetails(be);
                if (MessageBox.Show("Do You Want To Save Record?", "Item Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (lblId.Text == "0")
                    {
                        MessageBox.Show(this, "Record Saved Successfully.", "Item Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            dataGridViewCategory.DataSource = cc.BindItemMaster(be);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Record?", "Confirm deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(lblId.Text))
                {
                    CategoryclassBe be = new CategoryclassBe();
                    be.Categoryid = Convert.ToInt32(lblId.Text);
                    cc.DeleteItemDetails(be);
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
            txtItemname.Text = dataGridViewCategory.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtCharge.Text = dataGridViewCategory.Rows[e.RowIndex].Cells[3].Value.ToString();
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
            ds = cc.BindItemDetails(UniqueShopID);
            dv.Table = ds.Tables[0];
            dv.RowFilter = "Itemname like '%" + txtSearch.Text + "%'";
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

