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
    public partial class AddViewCustomerAMC : Form
    {
        DataTable dtamcSchedule = new DataTable();
        RetailSaleDetails sldet = null;
        public AddViewCustomerAMC(DataTable dtamc,RetailSaleDetails sld)
        {
            InitializeComponent();
            dtamcSchedule = dtamc;
            sldet = sld;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Add new  AMC ?", "Scheduler", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                dtamcSchedule.Rows.Add(0, dtp1.Value.Date, "true", "false", TxtRemark.Text);
                dtamcSchedule.AcceptChanges();
                MessageBox.Show(this, "New AMC Added Successfully", "Scheduler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sldet.SetNewSchedule(dtamcSchedule);
                this.Close();
            }
           
        }
    }
}
