using MSSwindow.CommonClass;
using MSSwindow.Report;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSwindow
{
    public partial class MainForm : Form
    {
        List<SMSCredential> lstCred = new List<SMSCredential>();
        public readonly int Shopid = 2;
        public readonly string Role = "ADMIN";
        public readonly int ShopUserID = 0;
        Loginform log_local = null;

        DataTable dtpendingAMC = new DataTable();
        public MainForm()
        {
            InitializeComponent();
            Shopid = ShpID;

        }

        public MainForm(int SHOPID, int UserID, string Rol, Loginform log)
        {
            InitializeComponent();
            Shopid = SHOPID;
            Role = Rol;
            log_local = log;
            ShopUserID = UserID;


        }


        public int ShpID { get { return Shopid; } }
        private void categoryMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryDetails cd = new CategoryDetails(this);
            cd.ShowDialog();
        }

        private void brandMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrandDetails bd = new BrandDetails(this);
            bd.ShowDialog();
        }

        private void productMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductDetails pd = new ProductDetails(this);
            pd.ShowDialog();
        }

        private void branchMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void supplierMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierDetails sd = new SupplierDetails(Shopid);
            sd.ShowDialog();
        }

        private void employeeMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerDetails cd = new CustomerDetails(Shopid);
            cd.ShowDialog();
        }

        private void purchaseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void taxDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaxDetails td = new TaxDetails(this);
            td.Show();
        }

        private void addPurchaseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RetailPurchaseDetails pd = new RetailPurchaseDetails(false, Shopid);
            pd.ShowDialog();
        }

        private void modifyPurchaseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RetailPurchaseDetails pd = new RetailPurchaseDetails(true, Shopid);
            pd.ShowDialog();
        }

        private void addSalesDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RetailSaleDetails sd = new RetailSaleDetails(false, Shopid);
            sd.ShowDialog();
        }

        private void modifySalesDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //RetailSaleDetails sd = new RetailSaleDetails(true, Shopid);
            //sd.ShowDialog();

            FrmInvoiceSearch ser = new FrmInvoiceSearch(Shopid);
            ser.ShowDialog();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    Report.FrmReport sd = new Report.FrmReport();
            //    sd.ShowDialog();
        }

        private void productDetailReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report.FrmReport sd = new Report.FrmReport("ProductDetailsReport", Shopid);
            sd.ShowDialog();
        }

        private void inventoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Report.FrmReport sd = new Report.FrmReport("DailyPurchaseReport",Shopid);
            //sd.ShowDialog();
        }

        private void dailySaleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report.FrmReport sd = new Report.FrmReport("DailySalesReport", Shopid);
            sd.ShowDialog();
        }

        private void taxInvoiceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report.FrmReport sd = new Report.FrmReport("Report1", Shopid);
            sd.ShowDialog();
        }

        private void unitMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnitMaster um = new UnitMaster(this);
            um.ShowDialog();
        }

        private void ledgerEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LedgerForm lgf = new LedgerForm(Shopid);
            lgf.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            log_local.Hide();
            if (Helper.SmsEnabled == true)
            {
                FindSMSCred();
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
            }

            ShowDashboardItems();

            if (Role != "ADMIN")
                ShowUserAccessMenu();

            this.Text = Helper.ShopName;
            double Ysize = this.Size.Height;
            TableLayoutRowStyleCollection styles = tableLayoutPanel1.RowStyles;
            int j = Convert.ToInt32((60.0 / Ysize) * 100);
            foreach (RowStyle style in styles)
            {
                // Set the row height to 20 pixels.
                style.SizeType = SizeType.Percent;
                style.Height = j;
                break;
            }
            //lblcopyright.Text = "Develop By Meera Infotech ! Any Query Please Contact Us : 7838633460";

            System.Drawing.Rectangle rect = Screen.GetWorkingArea(this);
            this.MaximizedBounds = Screen.GetWorkingArea(this);
            this.WindowState = FormWindowState.Maximized;

        }

        private void generateBarCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report.FrmReport sd = new Report.FrmReport("BarCode", Shopid);
            sd.ShowDialog();
        }

        private void employeeDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registraction r = new Registraction(this);
            r.ShowDialog();
        }

        private void sMSAlertsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerSMS sms = new CustomerSMS(this);
            sms.ShowDialog();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {

        }
        private void FindSMSCred()
        {
            string strReport = "SMSCred.txt";
            var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            path = path.Substring(6);
            path = path + "\\" + strReport;
            string fileName = path;

            // Read a text file using StreamReader
            using (System.IO.StreamReader sr = new System.IO.StreamReader(fileName))
            {

                String line;

                while ((line = sr.ReadLine()) != null)
                {
                    var tagIds = new List<string>(line.Split(',').Select(s => s));
                    SMSCredential cred = new SMSCredential();
                    cred.Key = tagIds[0];
                    cred.Value = tagIds[1];
                    lstCred.Add(cred);

                }

            }
        }
        private void FinallySendSMS(DataTable DT)
        {
            if (DT.Rows.Count == 0)
            {
                return;
            }
            int NotID;
            string SMSUserID;
            String SMSPassword;
            String SMSSenderID;
            string SMSPriority;
            string SMSType;
            string SMSText;
            string SMSContact;
            string PUristring;
            string ShopName;
            string Customername;
            string TempID;
            foreach (DataRow item in DT.Rows)
            {
                NotID = Convert.ToInt32(item["NotID"].ToString());
                SMSText = item["MessageText"].ToString();
                SMSContact = item["ContactNo"].ToString();
                TempID = item["TempID"].ToString();
                //PUristring = lstCred.Where(x => x.Key == "PUristring").Select(x => x.Value).FirstOrDefault();
                PUristring = Helper.ApiUrl;
                //ShopName = item["ShopName"].ToString();
                //Customername = item["Customername"].ToString();
                if (Shopid == 3)
                {
                    SendSingleSmsPentacare(NotID, SMSText, SMSContact, PUristring, TempID);
                }
                else
                    SendSingleSms(NotID, SMSText, SMSContact, PUristring);
            }
        }
        public void SendSMS()
        {
            try
            {
                DataTable DT = new DataTable();
                DT = SMSTrans.InsertSmsNotification(Shopid);
                if (DT.Rows.Count > 0)
                    FinallySendSMS(DT);
            }
            catch (Exception)
            {

            }

        }
        private void SendSingleSms(int NotID, string SMSText, string SMSContact, string PUristring)
        {
            string URISTRING = string.Format(PUristring, SMSContact, SMSText);
            System.Net.WebRequest WEBreq;
            System.Net.WebResponse WEBRES;
            WEBreq = System.Net.HttpWebRequest.Create(URISTRING);
            WEBreq.Timeout = 25000;
            string ResponseString = string.Empty;
            try
            {
                WEBRES = WEBreq.GetResponse();
                StreamReader strd = new StreamReader(WEBRES.GetResponseStream());
                ResponseString = strd.ReadToEnd();
                WEBRES.Close();
                SMSTrans.UpdateSMSSend(NotID, true, false, ResponseString);
            }
            catch (Exception ex)
            {
                SMSTrans.UpdateSMSSend(NotID, false, true, Convert.ToString(ex.InnerException));
            }

        }

        private void SendSingleSmsPentacare(int NotID, string SMSText, string SMSContact, string PUristring, string TempID)
        {
            string URISTRING = string.Format("http://sms.digimiles.in/bulksms/bulksms?username=di78-pentacare&password=digimile&type=0&dlr=1&destination={0}&source=PNTACR&message={1}&entityid=1101625060000019104&tempid={2}", SMSContact, SMSText, TempID);
            System.Net.WebRequest WEBreq;
            System.Net.WebResponse WEBRES;
            WEBreq = System.Net.HttpWebRequest.Create(URISTRING);
            WEBreq.Timeout = 25000;
            string ResponseString = string.Empty;
            try
            {
                WEBRES = WEBreq.GetResponse();
                StreamReader strd = new StreamReader(WEBRES.GetResponseStream());
                ResponseString = strd.ReadToEnd();
                WEBRES.Close();
                SMSTrans.UpdateSMSSend(NotID, true, false, ResponseString);
            }
            catch (Exception ex)
            {
                SMSTrans.UpdateSMSSend(NotID, false, true, Convert.ToString(ex.InnerException));
            }

        }
        private void ShowDashboardItems()
        {
            Sales sl = new Sales();
            DataSet ds = new DataSet();
            ds = sl.GetPendingAMC(DateTime.Now.Date, Shopid, DateTime.Now.Date);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    linkLabel2.Text = ds.Tables[0].Rows.Count.ToString();
                    dtpendingAMC = ds.Tables[0];
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    LnkOpenComplaint.Text = ds.Tables[1].Rows[0][0].ToString();
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    LnkDueComplaint.Text = ds.Tables[2].Rows[0][0].ToString();
                }

                if (ds.Tables[3].Rows.Count > 0)
                {
                    LnkBalanceToPaid.Text = ds.Tables[3].Rows[0][0].ToString();
                }

                if (ds.Tables[4].Rows.Count > 0)
                {
                    LnkCollection.Text = ds.Tables[4].Rows[0][0].ToString();
                }

                if (ds.Tables[5].Rows.Count > 0)
                {
                    fillChart(ds.Tables[5]);
                }

                if (ds.Tables[6].Rows.Count > 0)
                {
                    fillChart1(ds.Tables[6]);
                }

                if (ds.Tables[7].Rows.Count > 0)
                {
                    dgv10Cust.DataSource = ds.Tables[7];

                }
                if (ds.Tables[8].Rows.Count > 0)
                {
                    LnkSalePayment.Text = ds.Tables[8].Rows[0][0].ToString();

                }
                if (ds.Tables[9].Rows.Count > 0)
                {
                    LnkSaleBalance.Text = ds.Tables[9].Rows[0][0].ToString();

                }

                if (ds.Tables[11].Rows.Count > 0)
                {
                    dgvDelivery.DataSource = ds.Tables[11];

                }
                if (ds.Tables[12].Rows.Count > 0)
                {
                    DgvEMI.DataSource = ds.Tables[12];

                }

                if (ds.Tables[13].Rows.Count > 0)
                {
                    LinkLabelOnline.Text = ds.Tables[13].Rows[0][0].ToString();

                }

                if (ds.Tables[14].Rows.Count > 0)
                {
                    Lnk_Customer.Text = ds.Tables[14].Rows[0][0].ToString();

                }

                if (ds.Tables[15].Rows.Count > 0)
                {
                    Lnk_Unplanned.Text = ds.Tables[15].Rows[0][0].ToString();

                }

                if (ds.Tables[16].Rows.Count > 0)
                {
                    LnkPendingInvoice.Text = ds.Tables[16].Rows[0][0].ToString();

                }
                if (ds.Tables[17].Rows.Count > 0)
                {
                    LnkDueRent.Text = ds.Tables[17].Rows[0][0].ToString();

                }


            }

        }

        private void ShowUserAccessMenu()
        {

            LoginClass fp = new LoginClass();
            DataTable dt = new DataTable();
            dt = fp.UserAccess(Convert.ToInt32(ShopUserID));
            foreach (ToolStripMenuItem itm in menuStrip1.Items)
            {
                foreach (ToolStripDropDownItem itm1 in itm.DropDownItems)
                {
                    if (itm1.DropDownItems.Count > 0)
                    {
                        foreach (ToolStripDropDownItem itm2 in itm1.DropDownItems)
                        {
                            foreach (DataRow item in dt.Select("menuitemid='" + itm2.Name + "'"))
                            {

                                itm2.Visible = Convert.ToBoolean(item["IsActive"]);

                            }
                        }

                    }
                    else
                    {
                        foreach (DataRow item in dt.Select("menuitemid='" + itm1.Name + "'"))
                        {

                            itm1.Visible = Convert.ToBoolean(item["IsActive"]);
                        }
                    }
                }
            }
        }


        public string checkBalance()
        {
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("http://smpp.webtechsolution.co/http-credit.php?username=vikash565&password=Vikash@1235&route_id=1", new NameValueCollection()
                {
                    //{"apikey" , "yourapiKey"}
                });

                string result = System.Text.Encoding.UTF8.GetString(response);
                return result;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                checkBalance();
                ShowDashboardItems();
                CustomerClass cls = new CustomerClass();
                DataSet dsfp = new DataSet();
                dsfp = cls.SearchCustomerEnquiry(string.Empty, Shopid);
                DataView dv = new DataView(dsfp.Tables[0]);
                dv.RowFilter = "VisitDate = '" + DateTime.Now.Date + "'";
                //linkLabelfp.Text = dv.ToTable().Rows.Count.ToString();
                SendSMS();
            }
            catch (Exception)
            {

            }
        }

        private void aMCPendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TodayDueAMC tds = new TodayDueAMC(Shopid);
            tds.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TodayExpWar tds = new TodayExpWar(Shopid);
            tds.ShowDialog();
        }

        private void LnkSummary_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmunpaidservice frmunpaid = new frmunpaidservice(Shopid);
            frmunpaid.ShowDialog();
        }

        private void aMCDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCustomerAMC SearchAMC = new FrmCustomerAMC(Shopid);
            SearchAMC.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ForgotPassword fp = new ForgotPassword(Helper.ShopUserID);
            fp.ShowDialog();
        }

        private void myProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShopDetail fp = new ShopDetail(Shopid);
            fp.ShowDialog();
        }

        private void complaintFormToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //ComplaintForm cmp = new ComplaintForm(Shopid);
            //cmp.ShowDialog();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void generateBarCodeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CustomerMessageReport rep = new CustomerMessageReport(Shopid);
            rep.ShowDialog();
        }

        private void employeeServiceRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeServiceRecord rep = new EmployeeServiceRecord(Shopid);
            rep.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void followupFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Followupform follow = new Followupform(Shopid);
            follow.Show();
        }

        private void linkLabelfp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TodayDueFollowUP tfp = new TodayDueFollowUP(Shopid);
            tfp.Show();
        }

        private void customerEnquiryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerEnquiryDetail rep = new CustomerEnquiryDetail(Shopid);
            rep.ShowDialog();
        }

        private void complaintReasonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReasonCodeMaster res = new ReasonCodeMaster(this);
            res.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //QuickSale sd = new QuickSale(false, Shopid);
            //sd.ShowDialog();  
        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            FrmInvoiceSearch ser = new FrmInvoiceSearch(Shopid);
            ser.ShowDialog();
        }

        private void ToolStrioItemmaster_Click(object sender, EventArgs e)
        {

        }

        private void employeeServiceSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeServiceRecord ser = new EmployeeServiceRecord(Shopid, "Service Summary");
            ser.ShowDialog();
        }

        private void itemWisePurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report.FrmReport sd = new Report.FrmReport("DailyPurchaseReport", Shopid);
            sd.ShowDialog();
        }

        private void itemAndSerialNumberWisePurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report.FrmReport sd = new Report.FrmReport("ItemAndSerialWisePurchaseReport", Shopid);
            sd.ShowDialog();
        }

        private void pendingServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TodayDueServices ds = new TodayDueServices(Shopid);
            ds.ShowDialog();
        }

        private void ItemMaster_Click(object sender, EventArgs e)
        {
            ItemMaster im = new ItemMaster(Shopid);
            im.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MannualSMS sms = new MannualSMS(this);
            sms.ShowDialog();
        }

        private void unapaidCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerUnpaidReport rep = new CustomerUnpaidReport(Shopid);
            rep.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void LnkOpenComplaint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSearchComplaint cmpl = new FrmSearchComplaint(Shopid, "Open");
            cmpl.ShowDialog();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void complaintPaymentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerUnpaidReport rep = new CustomerUnpaidReport(Shopid, "Payment Detail");
            rep.ShowDialog();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void accessRightManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAccessRight rep = new FrmAccessRight(Shopid);
            rep.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Report.FrmReport sd = new Report.FrmReport("DailyAMCSalesReport", Shopid);
            sd.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Report.FrmReport sd = new Report.FrmReport("TotalSalesReport", Shopid);
            sd.ShowDialog();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fillChart(DataTable dt)
        {

            //chart1.Titles.Add("Week Wise Complaint");
        }

        private void fillChart1(DataTable dt)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void LnkDueComplaint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSearchComplaint cmpl = new FrmSearchComplaint(Shopid, DateTime.Now.Date);
            cmpl.ShowDialog();
        }

        private void searchComplaintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSearchComplaint cmp = new FrmSearchComplaint(Shopid);
            cmp.ShowDialog();
        }

        private void newComplaintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComplaintForm cmp = new ComplaintForm(Shopid);
            cmp.ShowDialog();
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TodayDueAMC tds = new TodayDueAMC(Shopid);
            tds.ShowDialog();
        }

        private void employeeLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeledgerReport elr = new EmployeeledgerReport(Shopid);
            elr.Show();
        }

        private void productWiseSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report.FrmReport sd = new Report.FrmReport("Product Wise Summary", Shopid);
            sd.ShowDialog();
        }

        private void receiveServiceItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddStock cstm = new FrmAddStock(false, Shopid);
            cstm.ShowDialog();
        }

        private void customerSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCustomerSummary cstm = new FrmCustomerSummary(Shopid);
            cstm.ShowDialog();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            UnitMaster um = new UnitMaster(this);
            um.ShowDialog();
        }

        private void stockHeaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmstockdetails frmstk = new frmstockdetails(Shopid);
            frmstk.ShowDialog();
        }

        private void LnkSaleBalance_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmUnpaidSalesdetails frmunpaid = new frmUnpaidSalesdetails(Shopid);
            frmunpaid.ShowDialog();
        }

        private void zoneDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmzone frmuzn = new frmzone(Shopid);
            frmuzn.ShowDialog();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            frmMessageconfiguration frmconfig = new frmMessageconfiguration(Shopid);
            frmconfig.ShowDialog();
        }

        private void searchCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrentedproducts custreports = new frmrentedproducts(Shopid);
            custreports.ShowDialog();
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvDelivery_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgvEMI_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDelivery_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string pono = string.Empty;
            int GenID = 0;
            pono = dgvDelivery.CurrentRow.Cells[1].Value.ToString();
            GenID = Convert.ToInt32(dgvDelivery.CurrentRow.Cells["InvoiceID"].Value.ToString());
            RetailSaleDetails sd = new RetailSaleDetails(true, Shopid, pono, GenID);
            sd.ShowDialog();
        }

        private void DgvEMI_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                string InvoiceNo = string.Empty;
                int Emidetid = 0;
                int Invid = 0;
                int Amount = 0;
                Emidetid = Convert.ToInt32(DgvEMI.CurrentRow.Cells[0].Value.ToString());
                Invid = Convert.ToInt32(DgvEMI.CurrentRow.Cells[1].Value.ToString());
                InvoiceNo = DgvEMI.CurrentRow.Cells[2].Value.ToString();
                Amount = Convert.ToInt32(DgvEMI.CurrentRow.Cells[6].Value.ToString());

                ReceivedEmiPayment rsp = new ReceivedEmiPayment(Emidetid, Invid, Amount, InvoiceNo, null);
                rsp.ShowDialog();
                // ReceivedEmiPayment rsp = new ReceivedEmiPayment(detailid,GenID,Amount,pono);
                // rsp.ShowDialog();
                // RetailSaleDetails sd = new RetailSaleDetails(true, Shopid, pono, GenID);
                //  sd.ShowDialog();
            }

        }

        private void stockDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StorestockDetails frmconfig = new StorestockDetails(Shopid);
            frmconfig.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void srockDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StorestockDetails frmconfig = new StorestockDetails(Shopid);
            frmconfig.ShowDialog();
        }

        private void issueMatrialToEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueMatrialtoemp frmconfig = new IssueMatrialtoemp(Shopid);
            frmconfig.ShowDialog();
        }

        private void rentSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RentDetails frmconfig = new RentDetails(Shopid);
            frmconfig.ShowDialog();
        }

        private void linkLabel3_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void dgvDelivery_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void stockInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InventoryReport frmconfig = new InventoryReport(Shopid);
            frmconfig.ShowDialog();
        }
    }
}
