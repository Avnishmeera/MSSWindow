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
    public partial class CustomerMessageReport : Form
    {
        int UniqueShopID = 0;
        string SelectedCustomerID = string.Empty;
        DataSet dsCustDetail = new DataSet();
        public CustomerMessageReport(int ShopID)
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
                if (TxtSearch.Text == string.Empty)
                {
                    SelectedCustomerID = string.Empty;
                }
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

        private void LstSearch_Click(object sender, EventArgs e)
        {
            SelectedCustomerID = LstSearch.GetItemText(LstSearch.SelectedValue);
            TxtSearch.Text = LstSearch.GetItemText(LstSearch.SelectedItem);
            LstSearch.Visible = false;
           

        }
        public DateTime? FdtVal
        {
            get
            {
                if (Fdt.Text == "  /  /")
                    return null;
                else
                    return Convert.ToDateTime(Fdt.Text);

            }
        }

        public DateTime? TdtVal
        {
            get
            {
                if (Tdt.Text == "  /  /")
                    return null;
                else
                    return Convert.ToDateTime(Tdt.Text);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CustomerClass p = new CustomerClass();
            CustomerMessageDetail pur = new CustomerMessageDetail();
            DataTable dt = p.ShowMessageDetail(UniqueShopID, SelectedCustomerID, FdtVal, TdtVal).Tables[0];
            pur.SetDataSource(dt);
            pur.SetParameterValue("ShopName", Helper.ShopName);
            pur.SetParameterValue("ShopAddress", Helper.ShopAddress);
            CRV1.ReportSource = pur;
        }

        private void LstSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CustomerMessageReport_Load(object sender, EventArgs e)
        {

        }
    }
}
