using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSSwindow.CommonClass;
using MSSEntityFrame;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;

namespace MSSwindow.Report
{
    public partial class FrmTaxInvoice : Form
    {
        string InvoiceNo = string.Empty;
        public readonly int UniqueShopID = 0;
        public FrmTaxInvoice(string Invoice, int ShopID)
        {
            InitializeComponent();
            InvoiceNo = Invoice;
            UniqueShopID = ShopID;
            
        }
        private void BindReport(string Typestr)
        {
            MSEntities db = new MSEntities();
            string strReport = db.StoreRegistration.Where(x => x.ShopID == UniqueShopID).Select(x => x.ReportName).FirstOrDefault().ToString();
            var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            path = path.Substring(6);
            path = path + "\\" + strReport + ".rpt";
            if (File.Exists(path))
            {
                //UserDefined def = new UserDefined();
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                ProductClass cls = new ProductClass();
                ds = cls.TaxInvoice(InvoiceNo,UniqueShopID);
                if (ds != null)
                {
                    dt = ds.Tables[0];
                }
                ReportDocument rptdoc = new ReportDocument();
                rptdoc.Load(path);
                rptdoc.SetDataSource(dt);
                rptdoc.SetParameterValue("Copy", Typestr);
                CRTaxInvoice.ReportSource = rptdoc;
                
            }
            else
            {
                MessageBox.Show(this, "Report Source Not Found Kindly Contact MSS Team For the appropriate action", "Invoice Printing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void FrmTaxInvoice_Load(object sender, EventArgs e)
        {
            BindReport("Original Copy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindReport(comboBox1.Text);
        }
    }
}
