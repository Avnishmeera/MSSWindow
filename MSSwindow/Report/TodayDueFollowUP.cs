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
    public partial class TodayDueFollowUP : Form
    {
        int UniqueShopID = 0;
       
        public TodayDueFollowUP(int ShopID)
        {
            InitializeComponent();
            dtfrm.Value = DateTime.Now.Date;
            CustomerClass cls = new CustomerClass();
            DataSet dsfp = new DataSet();
            dsfp = cls.DailyFollowup(dtfrm.Value, ShopID);
            dataGridView1.DataSource = dsfp.Tables[0];
            UniqueShopID = ShopID;

           

        }

        public TodayDueFollowUP(DataTable DT, bool ViewCustomer, string CustomerName)
        {
            InitializeComponent();
            dataGridView1.DataSource = DT;
            if (ViewCustomer)
            {
                label4.Text = "Pending Follow-Up For " + CustomerName;
                label1.Visible = false;
                dtfrm.Visible = false;
                button1.Visible = false;
                button2.Visible = false;

            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            CustomerClass cls = new CustomerClass();
            DataSet dsfp = new DataSet();
            dsfp = cls.DailyFollowup(dtfrm.Value, UniqueShopID);
            dataGridView1.DataSource = dsfp.Tables[0];

        }

        public void BindAMCPending()
        {
            
            Sales sl = new Sales();
            DataSet ds = new DataSet();
            ds = sl.GetPendingAMC(dtfrm.Value, UniqueShopID, dtfrm.Value);
            if (ds.Tables.Count > 0)
            {
               dataGridView1.DataSource = ds.Tables[0];

                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AMCPendingReport RPT = new AMCPendingReport(UniqueShopID, dtfrm.Value);
            RPT.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
