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
    public partial class EmployeeServiceRecord : Form
    {
        int UniqueShopID = 0;
        string SelectedCustomerID = string.Empty;
        DataSet dsCustDetail = new DataSet();
        string RepType = string.Empty;
        public EmployeeServiceRecord(int ShopID,string ReportType="Service Record")
        {
            InitializeComponent();
            UniqueShopID = ShopID;
            RegistractionClass rc = new RegistractionClass();
            dsCustDetail = rc.BindMemberDetails(UniqueShopID, string.Empty);
            RepType = ReportType;
            this.Text = "Employee Service Record";
            if (RepType != "Service Record")
            {
                this.Text = "Employee Service Summary";
                label2.Text = "Date";
                dtpFrm.Visible = true;
                label3.Visible = false;
                dtp2.Visible = true;
            }
           
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtSearch.Text == string.Empty)
                {
                    SelectedCustomerID = string.Empty;
                }
                if (dsCustDetail.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(dsCustDetail.Tables[0]);
                    dv.RowFilter = "FullName like '%" + TxtSearch.Text + "%'";
                    LstSearch.Visible = true;
                    LstSearch.DataSource = dv.ToTable();
                    LstSearch.DisplayMember = "FullName";
                    LstSearch.ValueMember = "memid";
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
            if (RepType == "Service Record")
            {
                CustomerClass p = new CustomerClass();
                ServiceRecord pur = new ServiceRecord();
                DataTable dt = p.ShowEmployeeServiceRecord(UniqueShopID, SelectedCustomerID,dtpFrm.Value, dtp2.Value).Tables[0];
                pur.SetDataSource(dt);
                pur.SetParameterValue("ShopName", Helper.ShopName);
                pur.SetParameterValue("ShopAddress", Helper.ShopAddress);
                CRV1.ReportSource = pur;
            }
            else
            {
                CustomerClass p = new CustomerClass();
                EmployeeServiceSummary pur = new EmployeeServiceSummary();
                DataTable dt = p.ShowEmployeeServiceSummary(UniqueShopID, SelectedCustomerID,dtpFrm.Value).Tables[0];
                pur.SetDataSource(dt);
                pur.SetParameterValue("ShopName", Helper.ShopName);
                pur.SetParameterValue("ShopAddress", Helper.ShopAddress);
                pur.SetParameterValue("Date", dtpFrm.Value);
                CRV1.ReportSource = pur;
            }
        }

        private void LstSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
