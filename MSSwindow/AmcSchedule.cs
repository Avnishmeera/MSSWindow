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
    public partial class AmcScheduleFrm : Form
    {
        Sales sl = new Sales();
        RetailSaleDetails sl1 = null;
        DataTable DtAmc = new DataTable();
        // test Comment
        public AmcScheduleFrm(DateTime StartDate, DateTime EndDate, int duration, DataTable DTAMC, RetailSaleDetails sld)
        {
            InitializeComponent();
            NMDuration.Value = 2;
            dtfrm.Value = StartDate;
            DtTo.Value = EndDate;
            DtAmc = DTAMC;
            sl1 = sld;
            ShowAMCDetail(DTAMC, DTAMC);



        }
        public AmcScheduleFrm(DateTime StartDate, DataTable DTAMC, DataTable DtSchedule, RetailSaleDetails sld)
        {
            InitializeComponent();
            NMDuration.Value = 2;
            dtfrm.Value = StartDate;
            DtTo.Value = StartDate.AddMonths(12);
            sl1 = sld;
            ShowAMCDetail(DTAMC, DtSchedule);


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
        private void ShowAMCDetail(DateTime StartDate, DateTime EndDate, int duration, DataTable DTAMC)
        {
            DTAMC.Rows.Clear();
            DataSet ds = new DataSet();
            ds = sl.BindAMCSchedule(StartDate, EndDate, duration);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                dtfrm.Value = StartDate;
                DtTo.Value = EndDate;
                NMDuration.Value = duration;
                foreach (DataRow item in dt.Rows)
                {
                    bool CurrentStatus = item["Status"].ToString() == "Pending" ? true : false;
                    bool IgnoreStatus = item["IgnoreStatus"].ToString() == "No" ? false : true;
                    DTAMC.Rows.Add(item["RN"].ToString(), Convert.ToDateTime(item["AMCDate"]), CurrentStatus, IgnoreStatus, item["Remark"].ToString());
                }
                DtAmc = DTAMC;
                sl1.SetNewSchedule(DtAmc);

            }
        }
        private void ShowAMCDetail(DataTable DTAMC, DataTable DTSchedule)
        {
            if (DTSchedule.Rows.Count > 0)
            {
                dataGridView1.DataSource = DTSchedule;
                DTAMC = DTSchedule;
            }
            else
                DTSchedule.Rows.Clear();
           
        }
        private void NMDuration_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NMDuration_Leave(object sender, EventArgs e)
        {
            DtAmc.Rows.Clear();
            DateTime saledate = dtfrm.Value;
            DateTime SaleExpDate = saledate.AddMonths(12);
            int duration = Convert.ToInt32(NMDuration.Value);
            ShowAMCDetail(saledate, SaleExpDate, duration, DtAmc);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowAMCDetail(dtfrm.Value, DtTo.Value, Convert.ToInt32(NMDuration.Value), DtAmc);
        }
    }
}
