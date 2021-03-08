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

using CrystalDecisions.CrystalReports.Engine;


namespace MSSwindow.Report
{
    public partial class AMCPendingReport : Form
    {
        public AMCPendingReport(int shopid,DateTime DTD)
        {
            InitializeComponent();
            Sales sl = new Sales();
            DataSet ds = new DataSet();
            ds = sl.GetPendingAMCReport(DTD, shopid);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    PendingAMCDetail dsl = new PendingAMCDetail();
                    dsl.SetDataSource(ds.Tables[0]);
                    dsl.SetParameterValue("Date", Convert.ToDateTime(DTD));
                    dsl.SetParameterValue("Title", "AMC Pending For Dated :");
                    CRV1.ReportSource = dsl;

                }
            }
        }
    }
}
