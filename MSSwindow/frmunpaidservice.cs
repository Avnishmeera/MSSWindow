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
    public partial class frmunpaidservice : Form
    {

        int UniqueShopID = 0;
        string SelectedCustomerID = string.Empty;
        public frmunpaidservice()
        {
            InitializeComponent();
        }


        public frmunpaidservice(int Shopid)
        {
            InitializeComponent();
            UniqueShopID = Shopid;
        }

        private void frmunpaidservice_Load(object sender, EventArgs e)
        {
            BindUnpaidService();
        }


        private void BindUnpaidService()
        {
            CustomerClass p = new CustomerClass();           
            DataTable dt = p.ShowUnpaidDetail(UniqueShopID, SelectedCustomerID).Tables[0];
            dt.Columns.Remove("Previous Balance");
            dt.Columns.Remove("Complaint Charge");
            dt.AcceptChanges();
            dataGridView1.DataSource = dt;
            if (dt.Rows.Count>0)
            {
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells["ActualBalance"].Value);
                }
                txtUnpaidBalance.Text = sum.ToString();
            }            
        }
    }
}
