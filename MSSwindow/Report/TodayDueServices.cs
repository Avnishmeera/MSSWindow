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
    public partial class TodayDueServices : Form
    {
       int UniqueShopID = 0;
        public TodayDueServices(DataTable DT,int ShopID)
        {
            InitializeComponent();
            dataGridView1.DataSource = DT;
            UniqueShopID = ShopID;

        }
        public TodayDueServices(int ShopID)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
           

        }

        public TodayDueServices(DataTable DT, bool ViewCustomer, string CustomerName)
        {
            InitializeComponent();
            dataGridView1.DataSource = DT;
            if (ViewCustomer)
            {
                label4.Text = "Pending AMC For " + CustomerName;
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
          
            Sales sl = new Sales();
            DataSet ds = new DataSet();
            ds = sl.GetPendingServices(dtfrm.Value, UniqueShopID, ToDate.Value);
            if (ds.Tables.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        public void BindAMCPending()
        {
            
            Sales sl = new Sales();
            DataSet ds = new DataSet();
            ds = sl.GetPendingAMC(dtfrm.Value, UniqueShopID,ToDate.Value);
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
            if (e.ColumnIndex == 0)
            {
                if (dataGridView1.CurrentRow.Cells[e.ColumnIndex].Value.ToString() == "History")
                {
                  
                        string RowID =dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        CustomerComplaintHistory amcmp = new CustomerComplaintHistory(RowID);
                        amcmp.ShowDialog();
                   
                   
                  
                }
            }

           
        }
    }
}
