using MSSwindow.CommonClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSwindow
{
    public partial class Storelocation : Form
    {

        public readonly int UniqueShopid = 0;

        public Storelocation()
        {
            InitializeComponent();
        }


        public Storelocation(int shopid)
        {
            InitializeComponent();
            UniqueShopid = shopid;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCategoryname.Text == string.Empty)
            {
                MessageBox.Show(this, "Please Fill Location name", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtCategoryname.Focus();
                return;
            }

            if (cmbtype.SelectedValue == "0")
            {
                MessageBox.Show(this, "Please Select Type", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);               
                return;
            }

            if (txtinitial.Text == string.Empty)
            {
                MessageBox.Show(this, "Please Fill Initial", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtinitial.Focus();
                return;
            }
            else
            {
                Stock st = new Stock();
                if (chkstatus.Checked==true)
                {
                    chkstatus.Checked = true;
                }
                else
                {
                    chkstatus.Checked = false;
                }
                
                if (MessageBox.Show("Do You Want To Save Record?", "Location Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    st.InsertUpdateStockLocation(UniqueShopid, Locationid, txtCategoryname.Text, Convert.ToInt32(cmbtype.SelectedValue), txtinitial.Text, Convert.ToInt32(chkstatus.Checked));
                    lblId.Text = Locationid.ToString();
                    if (lblId.Text == "0")
                    {
                        MessageBox.Show(this, "Record Saved Successfully.", "Location Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCategoryname.Text = string.Empty;
                        cmbtype.SelectedValue = 3;
                        txtinitial.Text = string.Empty;
                        chkstatus.Checked = false;
            
                    }
                    else
                    {
                        MessageBox.Show(this, "Record Updated Successfully.", "Location Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCategoryname.Text = string.Empty;
                        cmbtype.SelectedValue = 3;
                        txtinitial.Text = string.Empty;
                        chkstatus.Checked = false;
            
                    }
                }
                BindLocation();
            }
        }

        private void Storelocation_Load(object sender, EventArgs e)
        {
            BindType();
            BindLocation();
            cmbtype.SelectedValue = 3;
        }

        
        private void BindType()
        {
            Stock st = new Stock();
            cmbtype.DataSource = st.BindTypes().Tables[0];
            cmbtype.DisplayMember = "typename";
            cmbtype.ValueMember = "typeid";           
        }


        private void BindLocation()
        {
            Stock st = new Stock();
            dataGridViewlocation.DataSource = st.BindGridLocation(UniqueShopid).Tables[0];  
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtCategoryname.Text = string.Empty;
            cmbtype.SelectedValue = 3;
            txtinitial.Text = string.Empty;
            chkstatus.Checked = false;
            
        }

        public int Locationid = 0;
        private void dataGridViewlocation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                Locationid = Convert.ToInt32(dataGridViewlocation.Rows[e.RowIndex].Cells["locid"].Value.ToString());
                txtCategoryname.Text = dataGridViewlocation.Rows[e.RowIndex].Cells["Locationname"].Value.ToString();
                cmbtype.SelectedValue = dataGridViewlocation.Rows[e.RowIndex].Cells["typeid"].Value.ToString();
                chkstatus.Checked = Convert.ToBoolean(dataGridViewlocation.Rows[e.RowIndex].Cells["isactive"].Value.ToString());
                txtinitial.Text = dataGridViewlocation.Rows[e.RowIndex].Cells["Initial"].Value.ToString();
            }
            if (e.ColumnIndex == 7)
            {
                if (MessageBox.Show("Do You Want To Delete Location?", "Location Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int Locationid = Convert.ToInt32(dataGridViewlocation.Rows[e.RowIndex].Cells["Locationid"].Value.ToString());
                    CustomerClass cls = new CustomerClass();
                    int i = cls.DeleteLocation(Locationid, UniqueShopid);
                    if (i > 0)
                    {
                        MessageBox.Show(this, "Location Deleted Successfully.", "Location Details", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                    BindLocation();
                }
            }
        }

        private void txtCategoryname_Leave(object sender, EventArgs e)
        {
            txtinitial.Text = txtCategoryname.Text.ToUpper().Substring(0, 3);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text==string.Empty)
            {
                BindLocation();
            }
            else
            {
                Stock st = new Stock();
                DataView dv = new DataView();
                DataSet ds = new DataSet();
                ds = st.BindLocation(UniqueShopid);
                dv.Table = ds.Tables[0];
                dv.RowFilter = "Locationname like '%" + txtSearch.Text + "%'";
                dataGridViewlocation.DataSource = dv;
            }
        }
    }
}
