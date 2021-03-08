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
    public partial class FrmCustomerSummary : Form
    {
        CustomerClass cst = new CustomerClass();
        string SelectedCustomerID = "0";
        int ? CustomerID = 0;
        bool IsNewCustomer = false;
        DataSet dsCustDetail = new DataSet();
        public FrmCustomerSummary(int UniqueShopID,int? CustID = null)
        {
            InitializeComponent();
            CustomerClass CSL = new CustomerClass();
            dsCustDetail = CSL.SearchCustomers(UniqueShopID, TxtSearch.Text);
            SelectedCustomerID = Convert.ToString(CustID);
        }

        private void FrmCustomerSummary_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = cst.GetCustomersummary(Convert.ToInt32(SelectedCustomerID==string.Empty?"0": SelectedCustomerID));
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    lblContact.Text = ds.Tables[0].Rows[0]["Contact"].ToString();
                    lbldob.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
                    lblaniversarydate.Text = ds.Tables[0].Rows[0]["AniversaryDate"].ToString();
                    lbllocation.Text = ds.Tables[0].Rows[0]["Location"].ToString();
                    lbltype.Text = ds.Tables[0].Rows[0]["Typename"].ToString();
                    lbladdress.Text = ds.Tables[0].Rows[0]["Address"].ToString();

                    lbltotalsale.Text = ds.Tables[1].Rows[0]["TotalSale"].ToString();

                    lblreceivedsale.Text = ds.Tables[1].Rows[0]["TotalPaid"].ToString();

                    lblbalsale.Text = ds.Tables[1].Rows[0]["TotalBalance"].ToString();

                    dgvHeader.DataSource = ds.Tables[2];

                    DgvItem.DataSource = ds.Tables[3];

                    DgvPayment.DataSource = ds.Tables[4];

                    lblTotalSaleAmt.Text = ds.Tables[4].Rows[0]["TotalSale"].ToString();
                    lblsalepaid.Text = ds.Tables[4].Rows[0]["TotalPaid"].ToString();
                    lblSaleBalance.Text = ds.Tables[4].Rows[0]["TotalBalance"].ToString();
                }
                
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsNewCustomer)
                    return;
                if (dsCustDetail.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(dsCustDetail.Tables[0]);
                    dv.RowFilter = "Name like '%" + TxtSearch.Text + "%'";
                    LstCustom.Visible = true;
                    LstCustom.DataSource = dv.ToTable();
                    LstCustom.DisplayMember = "Name";
                    LstCustom.ValueMember = "Customerid";
                }
            }
            catch (Exception)
            {


            }
        }

        private void LstCustom_Click(object sender, EventArgs e)
        {
            SelectedCustomerID = LstCustom.GetItemText(LstCustom.SelectedValue);
            if (!string.IsNullOrEmpty(SelectedCustomerID))
            {
                TxtSearch.Text = LstCustom.GetItemText(LstCustom.SelectedItem);
                CustomerClass p = new CustomerClass();
                string CustomerContact = string.Empty;
                int i = Convert.ToInt32(SelectedCustomerID);
                if (i != 0)
                {
                    LstCustom.Visible = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ClearControlValue();
            DataSet ds = new DataSet();
            ds = cst.GetCustomersummary(Convert.ToInt32(SelectedCustomerID));
            if (ds.Tables.Count > 0)
            {
                lblName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                lblContact.Text = ds.Tables[0].Rows[0]["Contact"].ToString();
                lbldob.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
                lblaniversarydate.Text = ds.Tables[0].Rows[0]["AniversaryDate"].ToString();
                lbllocation.Text = ds.Tables[0].Rows[0]["Location"].ToString();
                lbltype.Text = ds.Tables[0].Rows[0]["Typename"].ToString();
                lbladdress.Text = ds.Tables[0].Rows[0]["Address"].ToString();


                if (ds.Tables[3].Rows.Count == 0)
                {
                    return;
                }
                if (ds.Tables[3].Rows[0]["Productname"].ToString().Contains("AMC") == false)
                {
                    lbltotalsale.Text = ds.Tables[1].Rows[0]["TotalSale"].ToString();

                    lblreceivedsale.Text = ds.Tables[1].Rows[0]["TotalPaid"].ToString();

                    lblbalsale.Text = ds.Tables[1].Rows[0]["TotalBalance"].ToString();

                    dgvHeader.DataSource = ds.Tables[2];

                    DgvItem.DataSource = ds.Tables[3];

                    DgvPayment.DataSource = ds.Tables[4];
                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        lblTotalSaleAmt.Text = ds.Tables[4].Rows[0]["TotalSale"].ToString();
                        lblsalepaid.Text = ds.Tables[4].Rows[0]["TotalPaid"].ToString();
                        lblSaleBalance.Text = ds.Tables[4].Rows[0]["TotalBalance"].ToString();
                    }
                }
                else
                {
                    dgvAMCHeader.DataSource = ds.Tables[2];

                    dgvAMCDetail.DataSource = ds.Tables[3];

                    dgvPaymentDetails.DataSource = ds.Tables[4];
                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        lblamctotal.Text = ds.Tables[4].Rows[0]["TotalSale"].ToString();
                        lblAMCPaid.Text = ds.Tables[4].Rows[0]["TotalPaid"].ToString();
                        lblAMCBalance.Text = ds.Tables[4].Rows[0]["TotalBalance"].ToString();
                    }
                }

                if (ds.Tables[5].Rows.Count > 0)
                {
                    dgvComplaintHeader.DataSource = ds.Tables[5];
                    dgvserviceitem.DataSource = ds.Tables[6];
                    dgvServicePayment.DataSource = ds.Tables[7];

                }
                if (ds.Tables[7].Rows.Count > 0)
                {
                    lblCharge.Text = ds.Tables[5].Rows[0]["CurrentChargePaid"].ToString();
                    lblpaid.Text = ds.Tables[5].Rows[0]["PaidAmt"].ToString();
                    lblbal.Text = ds.Tables[5].Rows[0]["BalAmt"].ToString();

                }
            }
        }

        private void ClearControlValue()
        {
            lblName.Text = string.Empty;
            lblContact.Text = string.Empty;
            lbldob.Text = string.Empty;
            lblaniversarydate.Text = string.Empty;
            lbllocation.Text = string.Empty;
            lbltype.Text = string.Empty;
            lbladdress.Text = string.Empty;

            lbltotalsale.Text = string.Empty;

            lblreceivedsale.Text = string.Empty;

            lblbalsale.Text = string.Empty;

            dgvHeader.DataSource = null;

            DgvItem.DataSource = null;

            DgvPayment.DataSource = null;

            lblTotalSaleAmt.Text = string.Empty;
            lblsalepaid.Text = string.Empty;
            lblSaleBalance.Text = string.Empty;

            dgvAMCHeader.DataSource = null;

            dgvAMCDetail.DataSource = null;

            dgvPaymentDetails.DataSource = null;

            lblamctotal.Text = string.Empty;
            lblAMCPaid.Text = string.Empty;
            lblAMCBalance.Text = string.Empty;


            dgvComplaintHeader.DataSource = null;
            dgvserviceitem.DataSource = null;
            dgvServicePayment.DataSource = null;

            lblCharge.Text = string.Empty;
            lblpaid.Text = string.Empty;
            lblbal.Text = string.Empty;

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvServicePayment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvComplaintHeader_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvComplaintHeader.CurrentRow.Index >= 0)
            {
                int Compid = Convert.ToInt32(dgvComplaintHeader.CurrentRow.Cells[0].Value);
                DataTable dt = new DataTable();
                dt = cst.GetCustomerComplaintDetails(Convert.ToInt32(Compid)).Tables[0];
                dgvserviceitem.DataSource = dt;
                dgvServicePayment.DataSource = cst.GetCustomerComplaintDetails(Convert.ToInt32(Compid)).Tables[1];

            }
            
        }

        private void dgvHeader_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHeader.CurrentRow.Index >= 0)
            {
                DgvItem.DataSource = null;
                DgvPayment.DataSource = null;
                lblTotalSaleAmt.Text = "0";
                lblsalepaid.Text = "0";
                lblSaleBalance.Text = "0";
                int SAID = Convert.ToInt32(dgvHeader.CurrentRow.Cells[0].Value);
                DataTable dt = new DataTable();
                dt = cst.GetSaleDetails(Convert.ToInt32(SAID)).Tables[0];
                DgvItem.DataSource = dt;
                if (cst.GetSaleDetails(Convert.ToInt32(SAID)).Tables[1].Rows.Count > 0)
                {
                    DgvPayment.DataSource = cst.GetSaleDetails(Convert.ToInt32(SAID)).Tables[1];
                    lblTotalSaleAmt.Text = cst.GetSaleDetails(Convert.ToInt32(SAID)).Tables[1].Rows[0]["TotalSale"].ToString();
                    lblsalepaid.Text = cst.GetSaleDetails(Convert.ToInt32(SAID)).Tables[1].Rows[0]["TotalPaid"].ToString(); 
                    lblSaleBalance.Text = cst.GetSaleDetails(Convert.ToInt32(SAID)).Tables[1].Rows[0]["TotalBalance"].ToString();
                }
            }
        }

        private void dgvAMCHeader_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAMCHeader.CurrentRow.Index >= 0)
            {
                dgvAMCDetail.DataSource = null;
                dgvPaymentDetails.DataSource = null;
                dgvamcservice.DataSource = null;
                lblamctotal.Text = "0";
                lblAMCPaid.Text = "0";
                lblAMCBalance.Text = "0";
                int SAID = Convert.ToInt32(dgvAMCHeader.CurrentRow.Cells[0].Value);
                DataTable dt = new DataTable();
                dt = cst.GetSaleDetails(Convert.ToInt32(SAID)).Tables[0];
                dgvAMCDetail.DataSource = dt;
                
                if (cst.GetSaleDetails(Convert.ToInt32(SAID)).Tables[1].Rows.Count > 0)
                {
                    dgvPaymentDetails.DataSource = cst.GetSaleDetails(Convert.ToInt32(SAID)).Tables[1];
                    lblamctotal.Text = cst.GetSaleDetails(Convert.ToInt32(SAID)).Tables[1].Rows[0]["TotalSale"].ToString();
                    lblAMCPaid.Text = cst.GetSaleDetails(Convert.ToInt32(SAID)).Tables[1].Rows[0]["TotalPaid"].ToString();
                    lblAMCBalance.Text = cst.GetSaleDetails(Convert.ToInt32(SAID)).Tables[1].Rows[0]["TotalBalance"].ToString();
                }
                dgvamcservice.DataSource= cst.GetSaleDetails(Convert.ToInt32(SAID)).Tables[2];
            }
        }
    }
}
