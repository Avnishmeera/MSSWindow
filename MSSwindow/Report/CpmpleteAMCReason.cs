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
    public partial class CpmpleteAMCReason : Form
    {
        TodayDueAMC admc = null;
        int Act = 0;
        int AMCID = 0;
        public CpmpleteAMCReason(TodayDueAMC DA,int ID,int Action)
        {
            InitializeComponent();
            admc = DA;
            Act = Action;// 1 for Done 2 for Ignore
            AMCID = ID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1 for done
            if (Act == 1)
            {
                if (MessageBox.Show("Do You Want To Complete the AMC ?", "Scheduler", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int RowID = AMCID;
                    Sales SLD = new Sales();
                    SLD.CompleteAMC(RowID, rtxtreason.Text);
                    MessageBox.Show(this, "AMC Completed Successfully", "Scheduler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    admc.BindAMCPending();
                    this.Close();
                }
            
            }

            if (Act == 2)
            {
                if (MessageBox.Show("Do You Want To Ignore the AMC ?", "Scheduler", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int RowID = AMCID;
                    Sales SLD = new Sales();
                    SLD.IgnoreAMC(RowID,rtxtreason.Text);
                    MessageBox.Show(this, "AMC Ignored Successfully", "Scheduler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    admc.BindAMCPending();
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rtxtreason.Text = string.Empty;
        }
    }
}
