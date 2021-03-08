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

namespace MSSwindow.Report
{
    public partial class FrmCustomerAMC : Form
    {
        int UniqueShopID = 0;
        string SelectedCustomerID = string.Empty;
        DataSet dsCustDetail = new DataSet();
        public FrmCustomerAMC(int ShopID)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
            CustomerClass CSL = new CustomerClass();
            dsCustDetail = CSL.SearchCustomers(UniqueShopID, TxtSearch.Text);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dsCustDetail.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(dsCustDetail.Tables[0]);
                    dv.RowFilter = "Name like '%" + TxtSearch.Text + "%'";
                    LstSearch.Visible = true;
                    LstSearch.DataSource = dv.ToTable();
                    LstSearch.DisplayMember = "Name";
                    LstSearch.ValueMember = "Customerid";
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void LstSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LstSearch_Click(object sender, EventArgs e)
        {
            SelectedCustomerID = LstSearch.GetItemText(LstSearch.SelectedValue);
            TxtSearch.Text = LstSearch.GetItemText(LstSearch.SelectedItem);
            LstSearch.Visible = false;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TxtSearch.Text == string.Empty)
            {
                MessageBox.Show(this, "Please Select Customer to Search Record.", "AMC Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!string.IsNullOrEmpty(SelectedCustomerID))
            {
                //LstSearch.Visible = false;
                CustomerClass p = new CustomerClass();
                AMCDetails pur = new AMCDetails();
                DataTable dt = p.SearchCustomerAMC(UniqueShopID, Convert.ToInt32(SelectedCustomerID)).Tables[0];
                pur.SetDataSource(dt);
                pur.SetParameterValue("CustomerName", Helper.ShopName);
                pur.SetParameterValue("CustomerAdd", Helper.ShopAddress);
                CRV1.ReportSource = pur;
            }
        }

        private void FrmCustomerAMC_Load(object sender, EventArgs e)
        {
            LstSearch.Visible = false;
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //LstSearch.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TxtSearch.Text == string.Empty)
            {
                MessageBox.Show(this, "Please Select Customer to Search Record.", "AMC Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Sales sl = new Sales();
            DataSet ds = new DataSet();
            ds = sl.GetPendingAMC(DateTime.Now.Date, UniqueShopID, DateTime.Now.Date, Convert.ToInt32(SelectedCustomerID));
            TodayDueAMC amc = new TodayDueAMC(ds.Tables[0], true,TxtSearch.Text);
            amc.ShowDialog();
        }
    }
}
