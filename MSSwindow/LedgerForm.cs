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
    public partial class LedgerForm : Form
    {
        //public readonly int RetailerID = 3;

        public int lblid = 0;
        public readonly int UniqueShopID = 0;
        public LedgerForm(int ShopID)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Save Record?", "Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (cmbtype.SelectedValue == "0")
                {
                    MessageBox.Show(this, "Please Select Payment Type.", "Ledger", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbtype.Focus();
                }
                else if (PaidDT.Text == string.Empty)
                {
                    MessageBox.Show(this, "Please Enter Payment  Date.", "Ledger", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    PaidDT.Focus();
                    return;
                }
                else if (SUPCUST.SelectedValue == null)
                {
                    MessageBox.Show(this, "Please select Party.", "Ledger", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SUPCUST.Focus();
                    return;
                }
                else if (TxtAmount.Text == string.Empty)
                {
                    MessageBox.Show(this, "Please enter amount.", "Ledger", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtAmount.Focus();
                    return;
                }
                LedgerBE LBE = new LedgerBE();

                LBE.TranID = lblid;
                LBE.LedgerNO = LedgNo.Text;
                LBE.Shopid = UniqueShopID;
                LBE.CustID = PaymentType == 1 || PaymentType == 3 ? 0 : Convert.ToInt32(SUPCUST.SelectedValue);
                LBE.SupID = PaymentType == 2 || PaymentType == 3 ? 0 : Convert.ToInt32(SUPCUST.SelectedValue);
                LBE.EMPID = PaymentType == 1 || PaymentType == 2 ? 0 : Convert.ToInt32(SUPCUST.SelectedValue);
                LBE.PayDt = Convert.ToDateTime(PaidDT.Text);
                LBE.PayType = Convert.ToInt32(cmbtype.SelectedValue);
                LBE.Amt = Convert.ToInt32(TxtAmount.Text);
                LBE.remark = txtremark.Text;
                LedgerTransaction TS = new LedgerTransaction();
                int RESULT = TS.InsertUpdateLedger(LBE);
                if (RESULT > 0)
                {
                    MessageBox.Show(this, "Record Saved Successfully.", "ledger", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetAllcontrol();
                    BindDataGridviewLeger();
                    LedgerNo();
                }
            }
        }

        private void ResetAllcontrol()
        {
            SUPCUST.SelectedValue = "0";
            cmbtype.SelectedValue = "0";
            TxtAmount.Text = string.Empty;
            PaidDT.Text = Convert.ToDateTime(DateTime.Now.Date).ToString();
            PARTYGSTIN.Text = string.Empty;
            TxtPartyAdd.Text = string.Empty;
            SUPCUST.DataSource = null;
            lblid = 0;
            txtremark.Text = string.Empty;
            cmbtype.SelectedValue = 3;
            PaidDT.Focus();
            LedgerNo();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            ResetAllcontrol();
        }
        public int PaymentType { get { return Convert.ToInt32(cmbtype.SelectedValue); } }
        private string LedgerNo()
        {
            LedgerTransaction tr = new LedgerTransaction();
            string LedgerNO = string.Empty;
            DataTable dt = new DataTable();
            LedgerBE be = new LedgerBE();
            be.Shopid = UniqueShopID;
            dt = tr.LedgerSeries(be);
            if (dt.Rows.Count > 0)
            {
                LedgNo.Text = dt.Rows[0]["Ledger"].ToString();
            }
            return LedgerNO;
        }

        private void BindPayType()
        {
            DataTable dtpay = new DataTable();
            dtpay.Columns.Add("ID", typeof(System.Int32));
            dtpay.Columns.Add("VALUE", typeof(System.String));
            dtpay.Rows.Add(0, "Select");
            dtpay.Rows.Add(1, "DEBIT");
            dtpay.Rows.Add(2, "CREDIT");
            dtpay.Rows.Add(3, "Employee");
            cmbtype.DataSource = dtpay;
            cmbtype.DisplayMember = "VALUE";
            cmbtype.ValueMember = "ID";
        }

        private void LedgerForm_Load(object sender, EventArgs e)
        {
            LedgerNo();
            BindPayType();
            BindDataGridviewLeger();
            cmbtype.SelectedValue = 3;
            PaidDT.Focus();
        }

        private void BindEmployeeDropDown()
        {
            SupplierClass sup = new SupplierClass();
            DataTable dt = new DataTable();
            dt.Columns.Add("Supplierid", typeof(System.Int32));
            dt.Columns.Add("Suppliername", typeof(System.String));
            dt = sup.BindDebitor(UniqueShopID).Tables[0];
            dt.Rows.Add(0, "Select Employee");
            DataView dv = new DataView(dt);
            dv.Sort = "Supplierid";
            SUPCUST.DataSource = dv.ToTable();
            SUPCUST.DisplayMember = "Suppliername";
            SUPCUST.ValueMember = "Supplierid";
        }
        private void BindSupplier()
        {
            SupplierClass sup = new SupplierClass();
            DataTable dt = new DataTable();
            dt.Columns.Add("Supplierid", typeof(System.Int32));
            dt.Columns.Add("Suppliername", typeof(System.String));
            dt = sup.BindDropDownSuppliers(UniqueShopID).Tables[0];
            dt.Rows.Add(0, "Select Debitor");
            DataView dv = new DataView(dt);
            dv.Sort = "Supplierid";
            SUPCUST.DataSource = dv.ToTable();
            SUPCUST.DisplayMember = "Suppliername";
            SUPCUST.ValueMember = "Supplierid";
        }

        public void BindCustomerDropDown()
        {
            CustomerClass cup = new CustomerClass();
            DataTable dt = new DataTable();
            dt.Columns.Add("Customerid", typeof(System.Int32));
            dt.Columns.Add("Customername", typeof(System.String));
            dt = cup.BindDropDownCustomers(UniqueShopID).Tables[0];
            dt.Rows.Add(0, "Select Creditor");
            DataView dv = new DataView(dt);
            dv.Sort = "Customerid";
            SUPCUST.DataSource = dv.ToTable();
            SUPCUST.DisplayMember = "Customername";
            SUPCUST.ValueMember = "Customerid";

        }

        private void cmbtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbtype.SelectedValue.ToString() == "1")
            {
                BindSupplier();
            }
            else if (cmbtype.SelectedValue.ToString() == "2")
            {
                BindCustomerDropDown();
            }
            else if (cmbtype.SelectedValue.ToString() == "3")
            {
                BindEmployeeDropDown();
            }

        }

        private void BindDataGridviewLeger()
        {
            Ledger l = new Ledger();
            dataGridViewLeger.DataSource = l.BindLedgerBalance(UniqueShopID).Tables[0];

        }



        private void SUPCUST_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbtype.SelectedValue.ToString() == "1")
            {
                Purchase p = new Purchase();
                int i = Convert.ToInt32(SUPCUST.SelectedIndex);
                string GSTIN = string.Empty;
                if (i != 0)
                {
                    TxtPartyAdd.Text = p.GetSupplierAddress(Convert.ToInt32(SUPCUST.SelectedValue), out GSTIN);
                    PARTYGSTIN.Text = GSTIN;
                }
            }
            else if (cmbtype.SelectedValue.ToString() == "2")
            {
                Sales p = new Sales();
                string GSTIN = string.Empty;
                int i = Convert.ToInt32(SUPCUST.SelectedIndex);
                if (i != 0)
                {
                    TxtPartyAdd.Text = p.GetSupplierAddress(Convert.ToInt32(SUPCUST.SelectedValue), out GSTIN);
                    PARTYGSTIN.Text = GSTIN;
                }
            }

            TxtAmount.Focus();
        }

        private void dataGridViewLeger_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ResetAllcontrol();
            if (e.RowIndex >= 0)
            {
                lblid = Convert.ToInt32(dataGridViewLeger.Rows[e.RowIndex].Cells["TranID"].Value.ToString());
                Ledger LED = new Ledger();
                DataTable DT = new DataTable();
                DT = LED.BindLedgerByID(UniqueShopID, lblid).Tables[0];
                LedgNo.Text = DT.Rows[0]["LedNO"].ToString();
                cmbtype.SelectedValue = DT.Rows[0]["PayType"].ToString();
                if (cmbtype.SelectedValue.ToString() == "1")
                {
                    BindSupplier();
                }
                else if (cmbtype.SelectedValue.ToString() == "2")
                {
                    BindCustomerDropDown();
                }
                else if (cmbtype.SelectedValue.ToString() == "3")
                {
                    BindEmployeeDropDown();
                }
                SUPCUST.SelectedValue = DT.Rows[0]["PartyID"].ToString();
                TxtAmount.Text = dataGridViewLeger.Rows[e.RowIndex].Cells["Amount"].Value.ToString();
                PaidDT.Text = Convert.ToDateTime(DT.Rows[0]["PayDt"].ToString()).ToString();
                txtremark.Text = DT.Rows[0]["Remark"].ToString();
            }
        }

        private void TxtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridViewLeger_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridViewLeger_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (MessageBox.Show("Do You Want To Delete Record?", "Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LedgerBE LBE = new LedgerBE();

                    LBE.TranID = Convert.ToInt32(dataGridViewLeger.Rows[e.RowIndex].Cells[1].Value.ToString());
                    LBE.Shopid = UniqueShopID;
                    LedgerTransaction TS = new LedgerTransaction();
                    int RESULT = TS.DeleteLedger(LBE);
                    if (RESULT > 0)
                    {
                        MessageBox.Show(this, "Record Deleted Successfully.", "ledger", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindDataGridviewLeger();
                    }
                }
            }
        }
    }
}
