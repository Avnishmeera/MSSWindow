using MSSwindow.CommonClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSwindow
{
    public partial class SMSQue : Form
    {
        DataTable dtLocal = new DataTable();
        List<CustomerClassBe> lstBE = new List<CustomerClassBe>();
        public delegate void ReportProgressDelegate(int percentage);
        string Mobile = string.Empty;
        string CustomerName = string.Empty;
        string MessageText = string.Empty;
        int UniqueShopID = 0;
        DateTime dtime = DateTime.Now;
        DateTime? ScheduleDate=null;
        public SMSQue(DataTable dt,string Message,int shopid,DateTime date)
        {
            InitializeComponent();
            dtLocal = dt;
            MessageText = Message;
            UniqueShopID = shopid;
            dtime = date;
        }

        public SMSQue(List<CustomerClassBe> dt, string Message, int shopid)
        {
            InitializeComponent();
            lstBE = dt;
            MessageText = Message;
            UniqueShopID = shopid;
           
        }

        private void BW1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundProcessLogicMethod(BW1.ReportProgress);
        }
        private void BackgroundProcessLogicMethod(ReportProgressDelegate bw)
        {
            int i = 1;
            if (dtLocal.Rows.Count > 0)
            {
                foreach (DataRow item in dtLocal.Rows)
                {
                    Mobile = item["Mobile"].ToString();
                    CustomerName = item["CustomerName"].ToString();
                    ScheduleDate = DateTime.Now;
                    CustomerClass CSMS = new CustomerClass();
                    CSMS.InsertNotification(Mobile, MessageText, UniqueShopID, (DateTime)ScheduleDate);
                    bw(i);
                    Thread.Sleep(200);
                    i = i + 1;
                }
            }
            else
            {
                foreach (CustomerClassBe item in lstBE)
                {
                    Mobile = item.Contact.ToString();
                    CustomerName = item.CustomerName.ToString();
                    ScheduleDate = item.ScheduleDate;
                    CustomerClass CSMS = new CustomerClass();
                    CSMS.InsertNotification(item.Contact, MessageText, UniqueShopID, (DateTime)ScheduleDate);
                    bw(i);
                    Thread.Sleep(200);
                    i = i + 1;
                }
            }
            
        }
        private void BW1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblprogress.Text= e.ProgressPercentage.ToString()+" % ";
            lblCustomerContact.Text = Mobile;
            lblCustomerName.Text = CustomerName;
            label4.Text = ScheduleDate.ToString();
        }

        private void BW1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblprogress.Text = "Completed";
        }

        private void SMSQue_Load(object sender, EventArgs e)
        {
            if (dtLocal.Rows.Count > 0)
            {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = dtLocal.Rows.Count;
                BW1.RunWorkerAsync(2000);
            }
            if (lstBE.Count > 0)
            {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = lstBE.Count;
                BW1.RunWorkerAsync(2000);
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
