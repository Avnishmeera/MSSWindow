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
    public partial class FrmInvoiceSearch : Form
    {
        CustomerClass cc = new CustomerClass();
        readonly int UniqueShopid;
        DataTable dtcust = new DataTable();
        public FrmInvoiceSearch(int Shopid)
        {
            InitializeComponent();
            UniqueShopid = Shopid;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FrmInvoiceSearch_Load(object sender, EventArgs e)
        {
            ProductClass p = new ProductClass();
            DataTable dt = p.InvoiceSearch(UniqueShopid, TxtSearch.Text).Tables[0];
            dtcust = dt;
            SaleDGV.DataSource = dt;
        }

        private void TxtCustomerSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string txtsearch = TxtSearch.Text;
            if (!string.IsNullOrEmpty(txtsearch))
            {
                DataView dv = new DataView(dtcust);
                dv.RowFilter = "InvoiceNo LIKE '%" + txtsearch + "%' or Customername LIKE '%" + txtsearch + "%' or Address like '%" + txtsearch + "%' or ContactNo like '%" + txtsearch + "%' or InvoiceDate like '%" + txtsearch + "%' or Productname like '%" + txtsearch + "%' or ModelNO like '%" + txtsearch + "%' or RefBy like '%" + txtsearch + "%' or BookNo like '%" + txtsearch + "%' or DeliveryMode like '%" + txtsearch + "%' or DeliveryBy like '%" + txtsearch + "%' or BasePrice Like '%" + txtsearch + "%'";
                SaleDGV.DataSource = dv.ToTable();
            }
            else
            {
                SaleDGV.DataSource = dtcust;
            }

        }

        private void SaleDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string pono = string.Empty;
            int GenID = 0;
            pono = SaleDGV.CurrentRow.Cells[0].Value.ToString();
            GenID = Convert.ToInt32(SaleDGV.CurrentRow.Cells["SAID"].Value.ToString());
            RetailSaleDetails sd = new RetailSaleDetails(true, UniqueShopid, pono, GenID);
            sd.ShowDialog();
        }
    }
}
