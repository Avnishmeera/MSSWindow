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
    public partial class SMSScheduling : Form
    {
        Sales sl = new Sales();
        List<CustomerClassBe> LstBE = null;
        string TextSMS = string.Empty;
        int UniqueShopID = 0;
        public SMSScheduling(List<CustomerClassBe> Lstbe,string SMSTEXT,int ShopID)
        {
            InitializeComponent();
            DtTo.Value = dtfrm.Value.AddYears(1);
            NMDuration.Value = 4;
            LstBE = Lstbe;
            TextSMS = SMSTEXT;
            UniqueShopID = ShopID;
        }
        
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void AmcSchedule_Load(object sender, EventArgs e)
        {

        }
        private void ShowAMCDetail(DateTime StartDate, DateTime EndDate, int duration)
        {
            
            DataSet ds = new DataSet();
            ds = sl.BindSMSSchedule(StartDate, EndDate, duration,TextSMS);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
            }
        }
      
        private void NMDuration_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void NMDuration_Leave(object sender, EventArgs e)
        {
            
            DateTime saledate = dtfrm.Value;
            DateTime SaleExpDate = saledate.AddMonths(12);
            int duration = Convert.ToInt32(NMDuration.Value);
            ShowAMCDetail(saledate, SaleExpDate, duration);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowAMCDetail(dtfrm.Value, DtTo.Value, Convert.ToInt32(NMDuration.Value));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Save Record?", "SMS Scheduler", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CustomerClass CSMS = new CustomerClass();
                string Messagetext = TextSMS;
                List<CustomerClassBe> be = new List<CustomerClassBe>();
                foreach (CustomerClassBe item in LstBE)
                {
                    foreach (DataGridViewRow item1 in dataGridView1.Rows)
                    {
                        be.Add(new CustomerClassBe { CustomerName = item.CustomerName,Contact=item.Contact,ScheduleDate= Convert.ToDateTime(item1.Cells["ScheduleDt"].Value.ToString()) });

                    }


                }
                SMSQue schd = new SMSQue(be, Messagetext, UniqueShopID);
                schd.ShowDialog();
                MessageBox.Show(this, "Record Saved Successfully.", "SMS Scheduler", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
