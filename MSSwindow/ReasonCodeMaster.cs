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
    public partial class ReasonCodeMaster : Form
    {
        public readonly int UniqueShopID = 0;
        public ReasonCodeMaster(MainForm ADMN)
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
            CMBCategory.DataSource = dv.ToTable();
            CMBCategory.DisplayMember = "Categoryname";
            CMBCategory.ValueMember = "Categoryid";
        }
        private void Formload()
        {
            txtCategoryname.Enabled = false;
            // // txtDescription.Enabled = false;
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
            // txtDescription.Enabled = true;
            chkIsActive.Enabled = true;
            CMBCategory.SelectedValue = "0";
            txtCategoryname.Text = string.Empty;
            // txtDescription.Text = string.Empty;
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
            // txtDescription.Text = string.Empty;
            chkIsActive.Checked = false;
            txtTimeInMinute.Text = string.Empty;
            txtCategoryname.Enabled = false;
            // txtDescription.Enabled = false;
            chkIsActive.Enabled = false;
            txtfds1.Text = string.Empty;
            txtfds2.Text = string.Empty;
            txtfds3.Text = string.Empty;
            txtfds4.Text = string.Empty;
            txtfds5.Text = string.Empty;

            btnAddnew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;
            CMBCategory.SelectedValue = "0";
        }

        private void DeleteButtonClick()
        {

            txtCategoryname.Text = string.Empty;
            // txtDescription.Text = string.Empty;
            chkIsActive.Checked = false;

            txtCategoryname.Enabled = false;
            // txtDescription.Enabled = false;
            chkIsActive.Enabled = false;
            txtTimeInMinute.Enabled = false;
            btnAddnew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;
            CMBCategory.SelectedValue = "0";

        }
        private void ResetButtonClick()
        {
            txtCategoryname.Text = string.Empty;
            // txtDescription.Text = string.Empty;
            chkIsActive.Checked = true;
            txtTimeInMinute.Enabled = true;
            btnAddnew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;
        }

        private void DataGridviewCellClick()
        {
            txtCategoryname.Enabled = true;
            // txtDescription.Enabled = true;
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
            BindCategoryDropDown();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCategoryname.Text == string.Empty)
            {
                MessageBox.Show(this, "Please Fill Reason Name", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtCategoryname.Focus();
                return;
            }
            else if (txtTimeInMinute.Text == string.Empty)
            {
                MessageBox.Show(this, "Please Fill Time Duration", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtCategoryname.Focus();
                return;
            }
            else if (CMBCategory.SelectedValue.ToString() == "0")
            {
                MessageBox.Show(this, "Please Select Category.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                CMBCategory.Focus();
                return;
            }

            else
            {
                CategoryclassBe be = new CategoryclassBe();
                be.Shopid = UniqueShopID;
                be.Categoryid = Convert.ToInt32(CMBCategory.SelectedValue);
                be.StatusID = Convert.ToInt32(lblId.Text);
                be.StatusDescription = txtCategoryname.Text;
                be.TimeDuration = Convert.ToInt32(txtTimeInMinute.Text == string.Empty ? "0" : txtTimeInMinute.Text);
                be.FDS1 = txtfds1.Text;
                be.FDS2 = txtfds2.Text;
                be.FDS3 = txtfds3.Text;
                be.FDS4 = txtfds4.Text;
                be.FDS5 = txtfds5.Text;
                be.IsActive = Convert.ToInt32(chkIsActive.Checked);
                CategoryClass catclass = new CategoryClass();
                catclass.InsertUpdateReasonCode(be);
                if (MessageBox.Show("Do You Want To Save Record?", "Reason Code Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (lblId.Text == "0")
                    {
                        MessageBox.Show(this, "Record Saved Successfully.", "Reason Code Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SaveButtonClick();
                    }
                    else
                    {
                        MessageBox.Show(this, "Record Updated Successfully.", "Reason Code  Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            dataGridViewCategory.DataSource = cc.BindComplaintstatus(be);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Record?", "Confirm deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(lblId.Text))
                {
                    CategoryclassBe be = new CategoryclassBe();
                    be.Categoryid = Convert.ToInt32(lblId.Text);
                    cc.DeleteCompalintStatus(be);
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
            lblId.Text = dataGridViewCategory.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (!string.IsNullOrEmpty(dataGridViewCategory.Rows[e.RowIndex].Cells["CategoryID"].Value.ToString()))
                CMBCategory.SelectedValue = dataGridViewCategory.Rows[e.RowIndex].Cells["CategoryID"].Value.ToString();
            txtCategoryname.Text = dataGridViewCategory.Rows[e.RowIndex].Cells["StatusDescription"].Value.ToString();
            chkIsActive.Checked = Convert.ToBoolean(dataGridViewCategory.Rows[e.RowIndex].Cells[4].Value.ToString());
            txtTimeInMinute.Text = Convert.ToString(dataGridViewCategory.Rows[e.RowIndex].Cells[5].Value.ToString());
            txtfds1.Text = Convert.ToString(dataGridViewCategory.Rows[e.RowIndex].Cells["Star1"].Value.ToString());
            txtfds2.Text = Convert.ToString(dataGridViewCategory.Rows[e.RowIndex].Cells["Star2"].Value.ToString());
            txtfds3.Text = Convert.ToString(dataGridViewCategory.Rows[e.RowIndex].Cells["Star3"].Value.ToString());
            txtfds4.Text = Convert.ToString(dataGridViewCategory.Rows[e.RowIndex].Cells["Star4"].Value.ToString());
            txtfds5.Text = Convert.ToString(dataGridViewCategory.Rows[e.RowIndex].Cells["Star5"].Value.ToString());

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
            ds = cc.BindComplaintStatusM(UniqueShopID);
            dv.Table = ds.Tables[0];
            dv.RowFilter = "StatusDescription like '%" + txtSearch.Text + "%'";
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

        private void txtTimeInMinute_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }


    }
}

