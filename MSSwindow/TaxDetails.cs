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
    public partial class TaxDetails : Form
    {
        public readonly int UniqueShopid = 0;

        public TaxDetails(MainForm admn)
        {
            InitializeComponent();
            UniqueShopid = admn.Shopid;
        }

        TaxesClass tc = new TaxesClass();
        private void btnAddnew_Click(object sender, EventArgs e)
        {
            txtTaxname.Enabled = true;
            txtTaxRate.Enabled = true;
            txtDescription.Enabled = true;
            int id = 0;
            lblId.Text = "" + id;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTaxname.Text == string.Empty)
            {
                 MessageBox.Show(this, "Please Fill Category Name", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                 return;           
               
            }
            else
            {
                TaxesClassBe be = new TaxesClassBe();
                be.Shopid = UniqueShopid;
                be.Taxid = Convert.ToInt32(lblId.Text);                
                be.Taxname = txtTaxname.Text;
                be.Rate = txtTaxRate.Text;
                be.Description = txtDescription.Text;
                be.IsActive = Convert.ToInt32(chkIsActive.Checked);
                TaxesClass tc = new TaxesClass();
              
                if (lblId.Text == "0")
                {
                    if (MessageBox.Show("Do You Want To Save Record?", "MSS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        tc.InsertUpdateTaxes(be);
                        MessageBox.Show(this, "Record Saved Successfully", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        txtTaxname.Enabled = false;
                        txtTaxRate.Enabled = false;
                        txtDescription.Enabled = false;
                        txtTaxname.Text = string.Empty;
                        txtTaxRate.Text = string.Empty;
                        txtDescription.Text = string.Empty;
                        chkIsActive.Checked = false;
                        BindTaxesGridview();
                        btnAddnew.Enabled = true;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        btnClose.Enabled = true;
                    }
                    
                }
                else
                {
                    if (MessageBox.Show("Do You Want To Save Record?", "MSS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        tc.InsertUpdateTaxes(be);
                        MessageBox.Show(this, "Record Updated Successfully", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        txtTaxname.Enabled = false;
                        txtTaxRate.Enabled = false;
                        txtDescription.Enabled = false;
                        txtTaxname.Text = string.Empty;
                        txtTaxRate.Text = string.Empty;
                        txtDescription.Text = string.Empty;
                        chkIsActive.Checked = false;
                        BindTaxesGridview();
                        btnAddnew.Enabled = true;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        btnClose.Enabled = true;
                    }
           
                }

                         
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TaxDetails_Load(object sender, EventArgs e)
        {
            txtTaxname.Enabled = false;
            txtTaxRate.Enabled = false;
            txtDescription.Enabled = false;
            lblId.Visible = false;
            int id = 0;
            lblId.Text = "" + id;
            BindTaxesGridview();
        }

        private void BindTaxesGridview()
        {
            dataGridViewTaxes.DataSource = tc.BindTaxes(UniqueShopid).Tables[0];
        }

        private void dataGridViewTaxes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          //////  UniqueShopid =Convert.ToInt32(dataGridViewTaxes.CurrentRow.Cells[0].ToString());
          //  lblId.Text = dataGridViewTaxes.Rows[e.RowIndex].Cells["Taxid"].Value.ToString();
          //  txtTaxname.Text = dataGridViewTaxes.Rows[e.RowIndex].Cells["Taxname"].Value.ToString();
          //  txtTaxRate.Text = dataGridViewTaxes.Rows[e.RowIndex].Cells["Rate"].Value.ToString();
          //  txtDescription.Text = dataGridViewTaxes.Rows[e.RowIndex].Cells["Description"].Value.ToString();
        }

        private void dataGridViewTaxes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblId.Text = dataGridViewTaxes.Rows[e.RowIndex].Cells["Taxid"].Value.ToString();
            txtTaxname.Text = dataGridViewTaxes.Rows[e.RowIndex].Cells["Taxname"].Value.ToString();
            txtTaxRate.Text = dataGridViewTaxes.Rows[e.RowIndex].Cells["Rate"].Value.ToString();
            txtDescription.Text = dataGridViewTaxes.Rows[e.RowIndex].Cells["Description"].Value.ToString();
            chkIsActive.Checked = Convert.ToBoolean(dataGridViewTaxes.Rows[e.RowIndex].Cells["IsActive"].Value);
            EnabledDisabled(true);
            btnAddnew.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            btnClose.Enabled = true;
        }
        private void EnabledDisabled(bool val)
        {
            txtTaxname.Enabled = val;
            txtTaxRate.Enabled = val;
            txtDescription.Enabled = val;
            chkIsActive.Enabled = val;
           
        }
       
    }
}
