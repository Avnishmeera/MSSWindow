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
    public partial class frmUnpaidSalesdetails : Form
    {

        int UniqueShopID = 0;
        string SelectedCustomerID = string.Empty;
        public frmUnpaidSalesdetails()
        {
            InitializeComponent();
        }

        public frmUnpaidSalesdetails(int Shopid)
        {
            InitializeComponent();
            UniqueShopID = Shopid;
        }

        private void frmUnpaidSalesdetails_Load(object sender, EventArgs e)
        {
            BindUnpaidSalesDetails();
        }


        private void BindUnpaidSalesDetails()
        {
            CustomerClass p = new CustomerClass();
            DataTable dt = p.ShowUnpaidSalesDetail(UniqueShopID, SelectedCustomerID).Tables[0];
            dataGridView1.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells["BalanceAmount"].Value);
                }
                txtUnpaidBalance.Text = sum.ToString();
            }
        }
    }
}
