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
    public partial class FrmRepoExpWaranty : Form
    {
        public FrmRepoExpWaranty(int shopid, DateTime DTD,DateTime DtTo)
        {
            InitializeComponent();
            Sales sl = new Sales();
            DataSet ds = new DataSet();
            ds = sl.GetExpiredWarantyReport(DTD, shopid, DtTo);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    PendingAMCDetail dsl = new PendingAMCDetail();
                    dsl.SetDataSource(ds.Tables[0]);
                    dsl.SetParameterValue("Date", Convert.ToDateTime(DTD));
                    dsl.SetParameterValue("Title", "Waranty Expired Between :");
                    dsl.SetParameterValue("ToDate", Convert.ToDateTime(DtTo));
                    crv1.ReportSource = dsl;

                }
            }
        }
    }
}
