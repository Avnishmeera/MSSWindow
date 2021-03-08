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
    public partial class ItemServicesCharge : Form
    {
        readonly int CompID = 0;
        ComplaintForm cmpl = null;
        DataTable dtitm = new DataTable();
        DataTable dtchargedetail = new DataTable();
        int uniqueShopid = 0;
        int SelectedCharge = 0;
        int empid = 0;
        public ItemServicesCharge(int Compid, string ComplainID, ComplaintForm frm,int Shopid)
        {
            InitializeComponent();
            CompID = Compid;
            lblComplainID.Text = CompID.ToString();
            TxtComplaintNo.Text = ComplainID;
            cmpl = frm;
            dtitm = null;
            uniqueShopid = Shopid;
        }


        

        private void BindItemMasterDetails()
        {
            CustomerClass cls = new CustomerClass();
            DataTable dt = new DataTable();
            ddlItemName.DataSource = cls.GetAllItemMaster(uniqueShopid,CompID).Tables[0];
            ddlItemName.DisplayMember = "itemname";
            ddlItemName.ValueMember = "itemid";
            ddlItemName.SelectedIndex = -1;
            dtchargedetail = cls.GetAllItemMaster(uniqueShopid,CompID).Tables[0];
        }

        public decimal ITEMCHARGE;

        private string GetServiceCharge(int itmid)
        {
            string str = string.Empty;
            CustomerClass cls = new CustomerClass();
            
            str = cls.GetItemChargeValue(itmid,uniqueShopid,CompID).Tables[0].Rows[0]["Charge"].ToString();
            if (!string.IsNullOrEmpty(str))
            {
                ITEMCHARGE = Convert.ToDecimal(str);
                txtitemprice.Text =Convert.ToString(ITEMCHARGE);
                txtavlqty.Text = cls.GetItemChargeValue(itmid, uniqueShopid, CompID).Tables[0].Rows[0]["AvlQty"].ToString();
            }            
            return str;

        }

        private void BindItemServiceDetails()
        {
            
            CustomerClass cls = new CustomerClass();
            dtitm = cls.GetItemServicesChargeDetails(Convert.ToInt32(lblComplainID.Text), TxtComplaintNo.Text).Tables[0];
            dataGridViewItemServices.DataSource = cls.GetItemServicesChargeDetails(Convert.ToInt32(lblComplainID.Text), TxtComplaintNo.Text).Tables[0];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Save Record?", "Product Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtCharge.Text == string.Empty)
                {
                    MessageBox.Show(this, "Please Enter Charge Amount", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (TxtQty.Text == string.Empty)
                {
                    MessageBox.Show(this, "Please Enter Item Quantity", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }

                //if (Convert.ToInt32(TxtQty.Text) > Convert.ToInt32(txtavlqty.Text))
                //{
                //    MessageBox.Show(this, "Item quantity can not exceed available quantity.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //    TxtQty.Focus();
                //    return;
                //}

                if (CheckitemExist(Convert.ToInt32(SelectedCharge)))
                {
                    MessageBox.Show(this, "Charge Already Added", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                
                CustomerClass cms = new CustomerClass();
                int i = cms.InsertUpdateServiceCharge(Convert.ToInt32(lblComplainID.Text), TxtComplaintNo.Text, Convert.ToInt32(SelectedCharge), Convert.ToDecimal(txtCharge.Text), Convert.ToInt32(TxtQty.Text), Convert.ToDecimal(TxtTotalCharge.Text),ITEMCHARGE);
                if (i > 0)
                {
                    MessageBox.Show(this, "Charge added Successfully.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindItemServiceDetails();
                    txtCharge.Text = string.Empty;
                    TxtItem.Text = string.Empty;
                    TxtQty.Text = string.Empty;
                    TxtTotalCharge.Text = string.Empty;
                    cmpl.SetTotalCharge();
                }
            }
        }


        private bool CheckitemExist(int Itemid)
        {
            bool isexist = false;
            DataView dv = new DataView(dtitm);
            dv.RowFilter = "masterid = '" + Itemid + "'";
            if (dv.ToTable().Rows.Count > 0)
            {
                isexist = true;
            }

            return isexist;

        }
        private void ItemServicesCharge_Load(object sender, EventArgs e)
        {
            BindItemMasterDetails();
            BindItemServiceDetails();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            cmpl.SetTotalCharge();
            this.Close();
        }

        private void txtCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ddlItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlItemName.SelectedIndex >= 0)
                {
                    txtCharge.Text = GetServiceCharge(Convert.ToInt32(ddlItemName.SelectedValue));
                    TxtQty.Text = "1";
                    TxtTotalCharge.Text = (Convert.ToInt32(txtCharge.Text) * Convert.ToInt32(TxtQty.Text)).ToString();
                }
            }
            catch (Exception)
            {


            }

        }

        private void dataGridViewItemServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (MessageBox.Show("Do You Want To Delete Charge?", "Product Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int Rowid = Convert.ToInt32(dataGridViewItemServices.Rows[e.RowIndex].Cells["itemid"].Value.ToString());
                    CustomerClass cls = new CustomerClass();
                    int i = cls.DeleteServiceCharge(Rowid);
                    if (i > 0)
                    {
                        MessageBox.Show(this, "Charge Deleted Successfully.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindItemServiceDetails();
                        cmpl.SetTotalCharge();
                    }
                }
            }
        }

        private void TxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtQty_Leave(object sender, EventArgs e)
        {
            if (txtCharge.Text != string.Empty)
            {
                TxtTotalCharge.Text = (Convert.ToDecimal(txtCharge.Text) * Convert.ToInt32(TxtQty.Text)).ToString();
            }
        }

        private void ItemServicesCharge_FormClosing(object sender, FormClosingEventArgs e)
        {
            cmpl.SetTotalCharge();
        }

       private void TxtItem_TextChanged(object sender, EventArgs e)
       {
            try
            {
                if (txtCharge.Text == string.Empty)
                {
                    LstCharge.Visible = false;                   
                }
               
               if (dtchargedetail.Rows.Count > 0)
                 {
                        DataView dv = new DataView(dtchargedetail);
                        dv.RowFilter = "itemname like '%" + TxtItem.Text + "%'";
                        LstCharge.Visible = true;
                        LstCharge.DataSource = dv.ToTable();
                        LstCharge.DisplayMember = "itemname";
                        LstCharge.ValueMember = "itemid";
                    }
               
                
            }
            catch (Exception)
            {


            }
        }

        private void LstCharge_Click(object sender, EventArgs e)
        {
            SelectedCharge = Convert.ToInt32(LstCharge.GetItemText(LstCharge.SelectedValue));
            if (SelectedCharge==0)
            {
                MessageBox.Show(this, "Please Selected  Item ", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                TxtItem.Focus();
                return;
                
               
            }
            else
            {
                if (SelectedCharge > 0)
                {
                    TxtItem.Text = LstCharge.GetItemText(LstCharge.SelectedItem);
                    if (SelectedCharge > 0)
                    {
                        txtCharge.Text = GetServiceCharge(Convert.ToInt32(SelectedCharge));
                        TxtQty.Text = "1";
                        TxtTotalCharge.Text = (Convert.ToDecimal(txtCharge.Text) * Convert.ToInt32(TxtQty.Text)).ToString();
                    }
                    LstCharge.Visible = false;
                }
            }
            
        }

        private void LstCharge_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
