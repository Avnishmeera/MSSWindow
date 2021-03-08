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
    public partial class Customerrpt : Form
    {
        public Customerrpt()
        {
            InitializeComponent();
        }

        DataTable custdt = new DataTable();

        DataTable dt = null;
        public Customerrpt(DataView dv)
        {
            InitializeComponent();
            dt = dv.ToTable();       
        }

        private void Customerrpt_Load(object sender, EventArgs e)
        {             
                CustomerDetailsReports pur = new CustomerDetailsReports();
                pur.SetDataSource(dt);
                pur.SetParameterValue("ShopName", Helper.ShopName);
                pur.SetParameterValue("ShopAddress", Helper.ShopAddress);
                crystalReportViewer1.ReportSource = pur;
        }
    }
}
