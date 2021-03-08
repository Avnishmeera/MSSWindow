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
    public partial class CustomerUnpaidReport : Form
    {
        int UniqueShopID = 0;
        string SelectedCustomerID = string.Empty;
        DataSet dsCustDetail = new DataSet();
        string ReportType = string.Empty;
        String DefaultSearch = string.Empty;
        String DefaultID = string.Empty;

        public CustomerUnpaidReport(int ShopID)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
            LstSearch.Visible = false;
            CustomerClass CSL = new CustomerClass();
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            panel3.Visible = false;
            this.Name = "Customer Unpaid Report";
            dsCustDetail = CSL.SearchCustomers(UniqueShopID, TxtSearch.Text);
        }

        public CustomerUnpaidReport(int ShopID, string PayReport,string  DefaultCust=null,string LDefaultID=null)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
            LstSearch.Visible = false;
            CustomerClass CSL = new CustomerClass();
            ReportType = PayReport;
            this.Name = "Customer Payment Detail";
            DefaultSearch = DefaultCust;
            DefaultID = LDefaultID;
            dsCustDetail = CSL.SearchCustomers(UniqueShopID, TxtSearch.Text);
        }

        

        private void TxtSearch_TextChanged(object sender, EventArgs e)
       {
            try
            {
                if (TxtSearch.Text == string.Empty)
                {
                    SelectedCustomerID = string.Empty;
                    LstSearch.Visible = false;
                    LstSearch.DataSource = null;
                }
                if (dsCustDetail.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(dsCustDetail.Tables[0]);
                    if(RadCust.Checked)
                    {
                        dv.RowFilter = "Name like '%" + TxtSearch.Text + "%'";
                        LstSearch.Visible = true;
                        LstSearch.DataSource = dv.ToTable();
                        LstSearch.DisplayMember = "Name";
                        LstSearch.ValueMember = "Customerid";
                    }
                    else if (RadEmp.Checked)
                    {
                        dv.RowFilter = "Fullname like '%" + TxtSearch.Text + "%'";
                        LstSearch.Visible = true;
                        LstSearch.DataSource = dv.ToTable();
                        LstSearch.DisplayMember = "Fullname";
                        LstSearch.ValueMember = "memid";
                    }
                    else if (RadSubBy.Checked)
                    {
                        dv.RowFilter = "Fullname like '%" + TxtSearch.Text + "%'";
                        LstSearch.Visible = true;
                        LstSearch.DataSource = dv.ToTable();
                        LstSearch.DisplayMember = "Fullname";
                        LstSearch.ValueMember = "memid";
                    }
                    else
                    {
                        dv.RowFilter = "Name like '%" + TxtSearch.Text + "%'";
                        LstSearch.Visible = true;
                        LstSearch.DataSource = dv.ToTable();
                        LstSearch.DisplayMember = "Name";
                        LstSearch.ValueMember = "Customerid";
                    }

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
            if (ReportType == "Payment Detail")
            {
                
                CustomerClass p = new CustomerClass();
                RPT_Paid_Rpt pur = new RPT_Paid_Rpt();
                DataTable dt = null;
                if (RadCust.Checked == true)
                    dt = p.ShowpaidDetail(UniqueShopID, SelectedCustomerID, null,null, dateTimePicker1.Value, dateTimePicker2.Value).Tables[0];
                else if (RadEmp.Checked == true)
                    dt = p.ShowpaidDetail(UniqueShopID, null, SelectedCustomerID,null, dateTimePicker1.Value, dateTimePicker2.Value).Tables[0];
                else if (RadSubBy.Checked == true)
                    dt = p.ShowpaidDetail(UniqueShopID, null, null, SelectedCustomerID, dateTimePicker1.Value, dateTimePicker2.Value).Tables[0];
                else
                    dt = p.ShowpaidDetail(UniqueShopID, SelectedCustomerID, null,null, dateTimePicker1.Value, dateTimePicker2.Value).Tables[0];

                pur.SetDataSource(dt);
                pur.Subreports[0].SetDataSource(dt);
                pur.SetParameterValue("CompanyName", Helper.ShopName);
                pur.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                CRV1.ReportSource = pur;
            }
            else
            {
                CustomerClass p = new CustomerClass();
                RPT_Unpaid pur = new RPT_Unpaid();
                DataTable dt = p.ShowUnpaidDetail(UniqueShopID, SelectedCustomerID).Tables[0];
                pur.SetDataSource(dt);
                pur.SetParameterValue("CompanyName", Helper.ShopName);
                pur.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                CRV1.ReportSource = pur;
            }
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
                SelectedCustomerID = string.Empty;
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
                SelectedCustomerID = string.Empty;
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
                SelectedCustomerID = string.Empty;
            }
        }

        private void CustomerUnpaidReport_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DefaultSearch))
            {
                RadCust.Checked = true;
                TxtSearch.Text = DefaultSearch;
                SelectedCustomerID = DefaultID;
                LstSearch.Visible = false;
                dateTimePicker1.Value = dateTimePicker1.Value.AddMonths(-60);
                DataTable dt = null;
                CustomerClass p = new CustomerClass();
                RPT_Paid_Rpt pur = new RPT_Paid_Rpt();
                dt = p.ShowpaidDetail(UniqueShopID, SelectedCustomerID, null, null, dateTimePicker1.Value, dateTimePicker2.Value).Tables[0];
                pur.SetDataSource(dt);
                pur.Subreports[0].SetDataSource(dt);
                pur.SetParameterValue("CompanyName", Helper.ShopName);
                pur.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                CRV1.ReportSource = pur;
                DefaultSearch = string.Empty;
                SelectedCustomerID = DefaultID;
                DefaultID = string.Empty;
            }
        }
    }
}
