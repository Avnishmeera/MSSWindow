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
    public partial class ReceivePayment : Form
    {
        readonly int? CompID = 0;
        readonly int? OrdID = 0;
        ComplaintForm cmpl = null;
        RetailSaleDetails Sld = null;
        DataTable dtitm = new DataTable();
        DataTable dtchargedetail = new DataTable();
        int uniqueShopid = 0;
        int SelectedCharge = 0;
        public ReceivePayment(int OrderID, string InvoiceNo, RetailSaleDetails frm, int Shopid, Decimal AmtToReceive)
        {
            InitializeComponent();
            OrdID = OrderID;
            CompID = null;
            lblComplainID.Text = InvoiceNo.ToString();
            TxtComplaintNo.Text = InvoiceNo;
            Sld = frm;
            dtitm = null;
            uniqueShopid = Shopid;
            TxtRecAmt.Text = AmtToReceive.ToString();

        }
        public ReceivePayment(int Compid, string ComplainID, ComplaintForm frm, int Shopid, int AmtToReceive)
        {
            InitializeComponent();
            CompID = Compid;
            OrdID = null;
            lblComplainID.Text = CompID.ToString();
            TxtComplaintNo.Text = ComplainID;
            cmpl = frm;
            dtitm = null;
            uniqueShopid = Shopid;
            TxtRecAmt.Text = AmtToReceive.ToString();
        }


        private void BindItemMasterDetails()
        {
            List<PaymentModeBe> paym = new List<PaymentModeBe>();
            Purchase p = new Purchase();
            paym = p.GetPaymentMode();
            ddlItemName.DataSource = paym;
            ddlItemName.DisplayMember = "Mode";
            ddlItemName.ValueMember = "ID";
        }

        private string GetServiceCharge(int itmid)
        {
            string str = string.Empty;
            CustomerClass cls = new CustomerClass();
           // str = cls.GetItemChargeValue(itmid).Tables[0].Rows[0]["Charge"].ToString();
            str = cls.GetItemChargeValue(itmid).Tables[0].Rows[0]["Charge"].ToString();
            return str;

        }

        public void BindItemServiceDetails()
        {
            TxtBalance.Text = "0";
            CustomerClass cls = new CustomerClass();
            dtitm = cls.GetReceivedAmount(CompID, OrdID).Tables[0];
            dataGridViewItemServices.DataSource = dtitm;
            int i = 0;
            foreach (DataRow item in dtitm.Rows)
            {
               // i = i + Convert.ToInt32(item["Amount"]);
            }
            TxtPaidAmt.Text = i.ToString();
            TxtBalance.Text = (Convert.ToDecimal(TxtRecAmt.Text) - Convert.ToInt32(TxtPaidAmt.Text)).ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Save Record?", "Product Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (TxtRef.Text == string.Empty)
                {
                    MessageBox.Show(this, "Please Enter Reference Detail", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (TxtAmt.Text == string.Empty)
                {
                    MessageBox.Show(this, "Please Enter Received Amount.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (Convert.ToInt32(TxtAmt.Text) > Convert.ToDecimal(TxtBalance.Text))
                {
                    MessageBox.Show(this, "Received Amount Can not be greater than Balance Amount.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }

                CustomerClass cms = new CustomerClass();
                int i = 0;

                if (CompID != null)
                    i = cms.InsertUpdateReceivePayment(OrdID, CompID, Convert.ToInt32(ddlItemName.SelectedValue), Convert.ToInt32(TxtAmt.Text), dtp1.Value, 0, TxtRef.Text);
                else
                    i = cms.InsertUpdateReceivePayment(OrdID, CompID, Convert.ToInt32(ddlItemName.SelectedValue), Convert.ToInt32(TxtAmt.Text), dtp1.Value, 1, TxtRef.Text);

                if (i > 0)
                {
                    MessageBox.Show(this, "Charge added Successfully.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtRef.Text = string.Empty;
                    TxtAmt.Text = string.Empty;
                    dtp1.Value = DateTime.Now;
                    ddlItemName.SelectedValue = "0";
                    BindItemServiceDetails();
                    if (cmpl != null)
                        cmpl.BindPaymentDetails();
                    if (Sld != null)
                        Sld.BindPaymentDetails();

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
            if (CompID != null)
                cmpl.SetTotalCharge();
            this.Close();
        }

        private void txtCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void ddlItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlItemName.SelectedIndex >= 0)
                {
                    //TxtRef.Text = GetServiceCharge(Convert.ToInt32(ddlItemName.SelectedValue));
                    //TxtQty.Text = "1";
                    //TxtTotalCharge.Text = (Convert.ToInt32(TxtRef.Text) * Convert.ToInt32(TxtQty.Text)).ToString();
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
                if (MessageBox.Show("Do You Want To Delete Payment?", "Payment Receive", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int Rowid = Convert.ToInt32(dataGridViewItemServices.Rows[e.RowIndex].Cells["PayID"].Value.ToString());
                    CustomerClass cls = new CustomerClass();
                    int i = cls.DeleteReceivePay(Rowid);
                    if (i > 0)
                    {
                        MessageBox.Show(this, "Charge Deleted Successfully.", "Payment Receive", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindItemServiceDetails();

                        if (cmpl != null)
                            cmpl.BindPaymentDetails();
                        if (Sld != null)
                            Sld.BindPaymentDetails();

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
            if (TxtRef.Text != string.Empty)
            {
                //TxtTotalCharge.Text = (Convert.ToInt32(TxtRef.Text) * Convert.ToInt32(TxtQty.Text)).ToString();
            }
        }

        private void ItemServicesCharge_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CompID != null)
                cmpl.SetTotalCharge();
        }

        private void TxtItem_TextChanged(object sender, EventArgs e)
        {

        }

        private void LstCharge_Click(object sender, EventArgs e)
        {

        }

        private void TxtAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
