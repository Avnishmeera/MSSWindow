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
    public partial class Searchcustomerreport : Form
    {
        public readonly int UniqueShopID = 0;
        public DataTable DTCUST = new DataTable();
        public Searchcustomerreport()
        {
            InitializeComponent();
        }
        public Searchcustomerreport(int Shopid)
        {
            InitializeComponent();
            UniqueShopID = Shopid;
        }
        CustomerClass cc = new CustomerClass();
        private void BindDataGridview()
        {
            DTCUST = cc.BindCustomers(UniqueShopID).Tables[0];
            dataGridViewCustomer.DataSource = DTCUST;

        }

        private void Searchcustomerreport_Load(object sender, EventArgs e)
        {
            BindDataGridview();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                CustomerClass cc = new CustomerClass();
                DataView dv = new DataView(DTCUST);
                dv.RowFilter = "Customername like '%" + txtSearch.Text + "%' or contact like '%" + txtSearch.Text + "%' or Address like '%" + txtSearch.Text + "%' ";
                dataGridViewCustomer.DataSource = dv;
            }
            else
            {
                BindDataGridview();
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {

        }
    }
}
