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
    public partial class CustomerComplaintHistory : Form
    {
        string Complaintid = string.Empty;
        public CustomerComplaintHistory(string Customerid)
        {
            InitializeComponent();
            Complaintid = Customerid;
        }

        private void CustomerComplaintHistory_Load(object sender, EventArgs e)
        {
            Sales sl = new Sales();
            DataSet ds = new DataSet();
            ds = sl.GetCustomerHistory(Complaintid);
            if (ds.Tables.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];


            }
        }
    }
}
