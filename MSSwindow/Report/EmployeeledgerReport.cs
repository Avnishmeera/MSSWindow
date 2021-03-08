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

namespace MSSwindow.Report
{
    public partial class EmployeeledgerReport : Form
    {
        int UniqueShopID = 0;
        string SelectedCustomerID = null;
        DataSet dsCustDetail = new DataSet();
        string ReportType = string.Empty;

        public EmployeeledgerReport(int ShopID)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
            LstSearch.Visible = false;
            CustomerClass CSL = new CustomerClass();
            //dateTimePicker1.Visible = false;
            //dateTimePicker2.Visible = false;
            //label2.Visible = false;
            //label3.Visible = false;
            //panel3.Visible = false;
            RadEmp.Checked = true;
            this.Name = "Employee Ledger Report";
            RegistractionClass rc = new RegistractionClass();
            dsCustDetail = rc.BindMemberDetails(UniqueShopID, string.Empty);

        }

        public EmployeeledgerReport(int ShopID, string PayReport)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
            LstSearch.Visible = false;
            CustomerClass CSL = new CustomerClass();
            ReportType = PayReport;
            this.Name = "Employee Ledger Report";
            RegistractionClass rc = new RegistractionClass();
            dsCustDetail = rc.BindMemberDetails(UniqueShopID, string.Empty);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtSearch.Text == string.Empty)
                {
                    SelectedCustomerID = null;
                    LstSearch.Visible = false;
                    LstSearch.DataSource = null;
                }
                if (dsCustDetail.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(dsCustDetail.Tables[0]);
                    RadEmp.Checked = true;
                    dv.RowFilter = "Fullname like '%" + TxtSearch.Text + "%'";
                    LstSearch.Visible = true;
                    LstSearch.DataSource = dv.ToTable();
                    LstSearch.DisplayMember = "Fullname";
                    LstSearch.ValueMember = "memid";

                    //    dv.RowFilter = "Fullname like '%" + TxtSearch.Text + "%'";


                    //if (RadCust.Checked)
                    //{
                    //    dv.RowFilter = "Name like '%" + TxtSearch.Text + "%'";
                    //    LstSearch.Visible = true;
                    //    LstSearch.DataSource = dv.ToTable();
                    //    LstSearch.DisplayMember = "Name";
                    //    LstSearch.ValueMember = "Customerid";
                    //}
                    //else if (RadEmp.Checked)
                    //{
                    //    dv.RowFilter = "Fullname like '%" + TxtSearch.Text + "%'";
                    //    LstSearch.Visible = true;
                    //    LstSearch.DataSource = dv.ToTable();
                    //    LstSearch.DisplayMember = "Fullname";
                    //    LstSearch.ValueMember = "memid";
                    //}
                    //else if (RadSubBy.Checked)
                    //{
                    //    dv.RowFilter = "Fullname like '%" + TxtSearch.Text + "%'";
                    //    LstSearch.Visible = true;
                    //    LstSearch.DataSource = dv.ToTable();
                    //    LstSearch.DisplayMember = "Fullname";
                    //    LstSearch.ValueMember = "memid";
                    //}
                    //else
                    //{
                    //    dv.RowFilter = "Name like '%" + TxtSearch.Text + "%'";
                    //    LstSearch.Visible = true;
                    //    LstSearch.DataSource = dv.ToTable();
                    //    LstSearch.DisplayMember = "Name";
                    //    LstSearch.ValueMember = "Customerid";
                    //}

                }
            }
            catch (Exception)
            {


            }




        }

        private void LstSearch_Click(object sender, EventArgs e)
        {
            SelectedCustomerID = LstSearch.GetItemText(LstSearch.SelectedValue);
            TxtSearch.Text = LstSearch.GetItemText(LstSearch.SelectedItem);
            LstSearch.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Ledger l = new Ledger();
            RPT_Empledger_Rpt pur = new RPT_Empledger_Rpt();
            DataTable dt = l.BindLedgerBalance(UniqueShopID, dateTimePicker1.Value, dateTimePicker2.Value,Convert.ToInt32(SelectedCustomerID)).Tables[0];
            pur.SetDataSource(dt);
            pur.SetParameterValue("CompanyName", Helper.ShopName);
            pur.SetParameterValue("CompanyAdd", Helper.ShopAddress);
            pur.SetParameterValue("FrmDate", dateTimePicker1.Value);
            pur.SetParameterValue("ToDate", dateTimePicker2.Value);
            CRV1.ReportSource = pur;

        }

        private void LstSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadCust_CheckedChanged(object sender, EventArgs e)
        {
            if (RadCust.Checked == true)
            {
                TxtSearch.Text = string.Empty;
                CustomerClass CSL = new CustomerClass();
                dsCustDetail = CSL.SearchCustomers(UniqueShopID, TxtSearch.Text);
            }
            else if (RadEmp.Checked == true)
            {
                TxtSearch.Text = string.Empty;
                RegistractionClass rc = new RegistractionClass();
                dsCustDetail = rc.BindMemberDetails(UniqueShopID, string.Empty);
            }
            else if (RadSubBy.Checked == true)
            {
                TxtSearch.Text = string.Empty;
                RegistractionClass rc = new RegistractionClass();
                dsCustDetail = rc.BindAdminMemberDetails(UniqueShopID, string.Empty);
            }
            else
            {
                TxtSearch.Text = string.Empty;
                SelectedCustomerID = null;
            }
        }

        private void RadEmp_CheckedChanged(object sender, EventArgs e)
        {
            if (RadCust.Checked == true)
            {
                TxtSearch.Text = string.Empty;
                CustomerClass CSL = new CustomerClass();
                dsCustDetail = CSL.SearchCustomers(UniqueShopID, TxtSearch.Text);
            }
            else if (RadEmp.Checked == true)
            {
                TxtSearch.Text = string.Empty;
                RegistractionClass rc = new RegistractionClass();
                dsCustDetail = rc.BindMemberDetails(UniqueShopID, string.Empty);
            }
            else if (RadSubBy.Checked == true)
            {
                TxtSearch.Text = string.Empty;
                RegistractionClass rc = new RegistractionClass();
                dsCustDetail = rc.BindAdminMemberDetails(UniqueShopID, string.Empty);
            }
            else
            {
                TxtSearch.Text = string.Empty;
                SelectedCustomerID = null;
            }
        }

        private void RadSubBy_CheckedChanged(object sender, EventArgs e)
        {
            if (RadCust.Checked == true)
            {
                TxtSearch.Text = string.Empty;
                CustomerClass CSL = new CustomerClass();
                dsCustDetail = CSL.SearchCustomers(UniqueShopID, TxtSearch.Text);
            }
            else if (RadEmp.Checked == true)
            {
                TxtSearch.Text = string.Empty;
                RegistractionClass rc = new RegistractionClass();
                dsCustDetail = rc.BindMemberDetails(UniqueShopID, string.Empty);
            }
            else if (RadSubBy.Checked == true)
            {
                TxtSearch.Text = string.Empty;
                RegistractionClass rc = new RegistractionClass();
                dsCustDetail = rc.BindAdminMemberDetails(UniqueShopID, string.Empty);
            }
            else
            {
                TxtSearch.Text = string.Empty;
                SelectedCustomerID = null;
            }
        }

        private void EmployeeledgerReport_Load(object sender, EventArgs e)
        {
            RadEmp.Checked = true;
        }
    }
}
