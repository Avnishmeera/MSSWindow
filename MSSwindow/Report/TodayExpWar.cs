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
    public partial class TodayExpWar : Form
    {
       int UniqueShopID = 0;
        public TodayExpWar(DataTable DT,int ShopID)
        {
            InitializeComponent();
            dataGridView1.DataSource = DT;
            UniqueShopID = ShopID;

        }
        public TodayExpWar(int ShopID)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
           

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sales sl = new Sales();
            DataSet ds = new DataSet();
            ds = sl.GetExpiredWaranty(dtfrm.Value, UniqueShopID,DtTo.Value);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables[0];

                }
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToInt32(row.Cells["Day"].Value) > 0)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.IndianRed;
                }
            }
        }

        private void BindAMCPending()
        {
            Sales sl = new Sales();
            DataSet ds = new DataSet();
            ds = sl.GetExpiredWaranty(dtfrm.Value, UniqueShopID,DtTo.Value);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables[0];

                }
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToInt32(row.Cells["Day"].Value) > 0)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.IndianRed;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmRepoExpWaranty RPT = new FrmRepoExpWaranty(UniqueShopID, dtfrm.Value,DtTo.Value);
            RPT.ShowDialog();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
           
        }
    }
}
