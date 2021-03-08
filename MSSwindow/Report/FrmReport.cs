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

using CrystalDecisions.CrystalReports.Engine;


namespace MSSwindow.Report
{
    public partial class FrmReport : Form
    {
        string Reportname;
        public string SelectedProductID = null; 
        public readonly int UniqueShopID = 0;
        public readonly int lcompid = 0;
        public readonly List<string> CompList = null;
        DataSet dsProdDetail = new DataSet();
        public FrmReport(string reportname, int ShopID)
        {
            InitializeComponent();
            Reportname = reportname;
            UniqueShopID = ShopID;
        }
        private void SetFormName(string RepName)
        {
            switch (RepName)
            {
                case "ProductDetailsReport":
                    this.Text = "Inventory Report";
                    break;
                case "DailySalesReport":
                    this.Text = "Product Sale Report";
                    break;
                case "BarCode":
                    this.Text = "Bar Code";
                    break;
                case "DailyPurchaseReport":
                    this.Text = "Purchase Report";
                    break;
                case "ItemAndSerialWisePurchaseReport":
                    this.Text = "Item And Serial Wise Purchase Report";
                    break;
                case "DailyAMCSalesReport":
                    this.Text = "AMC Sale Report";
                    break;
                case "TotalSalesReport":
                    this.Text = "Total Sale Report";
                    break;
                case "Product Wise Summary":
                    this.Text = "Product Wise Summary";
                    break;
                default:
                    break;
            }

        }
        public FrmReport(string reportname, List<string> CompID, int Shopid)
        {
            InitializeComponent();
            Reportname = reportname;
            UniqueShopID = Shopid;
            CompList = new List<string>();
            CompList = CompID;

        }

        public FrmReport(string reportname, int CompID, int Shopid)
        {
            InitializeComponent();
            Reportname = reportname;
            UniqueShopID = Shopid;
            lcompid = CompID;
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            SetFormName(Reportname);
            BindCategoryDropDown();
            if (Reportname == "ProductDetailsReport")
            {
                Dtp1.Enabled = false;
                Dtp1.Enabled = false;
                button1.Enabled = false;
                ProductClass p = new ProductClass();
                RptProductDetail pdl = new RptProductDetail();
                DataTable dt = p.ProductDetailsReport(UniqueShopID).Tables[0];
                pdl.SetDataSource(dt);
                pdl.SetParameterValue("CompanyName", Helper.ShopName);
                pdl.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                CRV1.ReportSource = pdl;

            }
            else if (Reportname == "ItemAndSerialWisePurchaseReport")
            {
                Dtp1.Enabled = true;
                Dtp1.Enabled = true;
                button1.Enabled = true;
                ProductClass p = new ProductClass();
                ItemAndSerialWisePurchaseReport pur = new ItemAndSerialWisePurchaseReport();
                DataTable dt = p.DailyPurchaseItemSrNoReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text)).Tables[0];
                pur.SetDataSource(dt);
                pur.SetParameterValue("FrmDate", Convert.ToDateTime(Dtp1.Text));
                pur.SetParameterValue("ToDate", Convert.ToDateTime(dtp2.Text));
                pur.SetParameterValue("CompanyName", Helper.ShopName);
                pur.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                CRV1.ReportSource = pur;
            }

            else if (Reportname == "DailyPurchaseReport")
            {
                Dtp1.Enabled = true;
                Dtp1.Enabled = true;
                button1.Enabled = true;
                ProductClass p = new ProductClass();
                DailyPurchaseReport pur = new DailyPurchaseReport();
                DataTable dt = p.DailyPurchaseReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text)).Tables[0];
                pur.SetDataSource(dt);
                pur.SetParameterValue("FrmDate", Convert.ToDateTime(Dtp1.Text));
                pur.SetParameterValue("ToDate", Convert.ToDateTime(Dtp1.Text));
                pur.SetParameterValue("CompanyName", Helper.ShopName);
                pur.SetParameterValue("CompanyAdd", Helper.ShopAddress);

                CRV1.ReportSource = pur;

            }

            else if (Reportname == "BarCode")
            {
                string strReport = "barcode";
                var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                path = path.Substring(6);
                path = path + "\\" + strReport + ".rpt";
                Dtp1.Enabled = true;
                Dtp1.Enabled = true;
                button1.Enabled = true;
                ProductClass p = new ProductClass();
                ReportDocument rptdoc = new ReportDocument();
                rptdoc.Load(path);
                DataTable dt = p.ShowBarcode(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text)).Tables[0];
                rptdoc.SetDataSource(dt);
                CRV1.ReportSource = rptdoc;



            }
            else if (Reportname == "Product Wise Summary")
            {
                Dtp1.Enabled = true;
                Dtp1.Enabled = true;
                button1.Enabled = true;
                ProductClass pd = new ProductClass();
                dsProdDetail = pd.BindProducts(UniqueShopID);

                ProductClass p = new ProductClass();
                DataTable dt = p.DailySalesReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text), Convert.ToInt32(SelectedProductID), Convert.ToInt32(CmbBrand.SelectedValue), Convert.ToInt32(CmbCategory.SelectedValue)).Tables[0];
                DataView DV = new DataView(dt);
                string Type = "AMC";
                DV.RowFilter = "ProductName not like '%" + Type + "%'";

                if (UniqueShopID == 7)
                {
                    ProductSummary_Sonar dsl = new ProductSummary_Sonar();
                    // DataTable dt = p.DailySalesReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text)).Tables[0];
                    dsl.SetDataSource(DV.ToTable());
                    dsl.SetParameterValue("FrmDate", Convert.ToDateTime(Dtp1.Text));
                    dsl.SetParameterValue("ToDate", Convert.ToDateTime(dtp2.Text));
                    dsl.SetParameterValue("CompanyName", Helper.ShopName);
                    dsl.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                    dsl.SetParameterValue("ReportHeader", "Product Wise Summary");
                    CRV1.ReportSource = dsl;
                }
                else
                {

                    ProductSummary_Sonar dsl = new ProductSummary_Sonar();
                    // DataTable dt = p.DailySalesReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text)).Tables[0];
                    dsl.SetDataSource(DV.ToTable());
                    dsl.SetParameterValue("FrmDate", Convert.ToDateTime(Dtp1.Text));
                    dsl.SetParameterValue("ToDate", Convert.ToDateTime(dtp2.Text));
                    dsl.SetParameterValue("CompanyName", Helper.ShopName);
                    dsl.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                    dsl.SetParameterValue("ReportHeader", "Product Wise Summary");
                    CRV1.ReportSource = dsl;
                }
            }
            else if (Reportname == "DailySalesReport")
            {
                Dtp1.Enabled = true;
                Dtp1.Enabled = true;
                button1.Enabled = true;
                ProductClass pd = new ProductClass();
                dsProdDetail = pd.BindProducts(UniqueShopID);

                ProductClass p = new ProductClass();
                DataTable dt = p.DailySalesReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text), Convert.ToInt32(SelectedProductID), Convert.ToInt32(CmbBrand.SelectedValue), Convert.ToInt32(CmbCategory.SelectedValue)).Tables[0];
                DataView DV = new DataView(dt);
                string Type = "AMC";
                DV.RowFilter = "ProductName not like '%" + Type + "%'";

                if (UniqueShopID == 7)
                {
                    DailySalesReport_Sonar dsl = new DailySalesReport_Sonar();
                    // DataTable dt = p.DailySalesReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text)).Tables[0];
                    dsl.SetDataSource(DV.ToTable());
                    dsl.Subreports[0].SetDataSource(DV.ToTable());
                    dsl.Subreports[1].SetDataSource(DV.ToTable());
                    dsl.SetParameterValue("FrmDate", Convert.ToDateTime(Dtp1.Text));
                    dsl.SetParameterValue("ToDate", Convert.ToDateTime(dtp2.Text));
                    dsl.SetParameterValue("CompanyName", Helper.ShopName);
                    dsl.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                    dsl.SetParameterValue("ReportHeader", "Sales Report (Product)");
                    CRV1.ReportSource = dsl;
                }
                else
                {

                    DailySalesReport dsl = new DailySalesReport();
                    //DataTable dt = p.DailySalesReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text)).Tables[0];
                    dsl.SetDataSource(DV.ToTable());
                    dsl.SetParameterValue("FrmDate", Convert.ToDateTime(Dtp1.Text));
                    dsl.SetParameterValue("ToDate", Convert.ToDateTime(dtp2.Text));
                    dsl.SetParameterValue("CompanyName", Helper.ShopName);
                    dsl.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                    dsl.SetParameterValue("ReportHeader", "Sales Report (Product)");
                    CRV1.ReportSource = dsl;
                }



            }

            else if (Reportname == "ComplaintSlip")
            {
                Dtp1.Enabled = false;
                Dtp1.Enabled = false;
                button1.Enabled = false;
                ProductClass p = new ProductClass();

                if (UniqueShopID == 3)
                {
                    Report.Pentacare_Report dsl = new Report.Pentacare_Report();
                    DataTable dt = p.CustomerSlip(lcompid).Tables[0];
                    dsl.SetDataSource(dt);
                    dsl.SetParameterValue("ShopName", Helper.ShopName);
                    dsl.SetParameterValue("ShopAddress", Helper.ShopAddress);
                    CRV1.ReportSource = dsl;
                }
                else
                {
                    Report.CustomerSlip dsl = new Report.CustomerSlip();
                    DataTable dt = p.CustomerSlip(lcompid).Tables[0];
                    dsl.SetDataSource(dt);
                    dsl.SetParameterValue("ShopName", Helper.ShopName);
                    dsl.SetParameterValue("ShopAddress", Helper.ShopAddress);
                    CRV1.ReportSource = dsl;
                }

            }
            else if (Reportname == "MultipleComplaintSlip")
            {

                DataTable dt = new DataTable();
                ProductClass p = new ProductClass();
                dt = p.CustomerSlip(Convert.ToInt32(0)).Tables[0].Clone();

                foreach (string item in CompList)
                {

                    foreach (DataRow dr in p.CustomerSlip(Convert.ToInt32(item)).Tables[0].Rows)
                    {
                        dt.ImportRow(dr);
                    }

                }
                string strReport = "ComplaintSlip_All";//
               // string strReport = "CustomerSlip_proven";
                var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                path = path.Substring(6);
                path = path + "\\" + strReport + ".rpt";
                ReportDocument rptdoc = new ReportDocument();
                rptdoc.Load(path);
                rptdoc.SetDataSource(dt);
                rptdoc.SetParameterValue("ShopName", Helper.ShopName);
                rptdoc.SetParameterValue("ShopAddress", Helper.ShopAddress);
                CRV1.ReportSource = rptdoc;
            }
            else if (Reportname == "DailyAMCSalesReport")
            {

                ProductClass p = new ProductClass();
                dsProdDetail = p.BindProducts(UniqueShopID);
                DataTable dt = p.DailySalesReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text), Convert.ToInt32(SelectedProductID), Convert.ToInt32(CmbBrand.SelectedValue), Convert.ToInt32(CmbCategory.SelectedValue)).Tables[0];
                DataView DV = new DataView(dt);
                string Type = "AMC";
                DV.RowFilter = "ProductName like '%" + Type + "%'";


                if (UniqueShopID == 7)
                {
                    DailySalesReport_Sonar dsl = new DailySalesReport_Sonar();

                    dsl.SetDataSource(DV.ToTable());
                    dsl.Subreports[0].SetDataSource(DV.ToTable());
                    dsl.Subreports[1].SetDataSource(DV.ToTable());
                    dsl.SetParameterValue("FrmDate", Convert.ToDateTime(Dtp1.Text));
                    dsl.SetParameterValue("ToDate", Convert.ToDateTime(dtp2.Text));
                    dsl.SetParameterValue("CompanyName", Helper.ShopName);
                    dsl.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                    dsl.SetParameterValue("ReportHeader", "Sales Report (AMC)");
                    CRV1.ReportSource = dsl;
                }
                else
                {

                    DailySalesReport dsl = new DailySalesReport();
                    //DataTable dt = p.DailySalesReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text)).Tables[0];
                    dsl.SetDataSource(DV.ToTable());
                    dsl.SetParameterValue("FrmDate", Convert.ToDateTime(Dtp1.Text));
                    dsl.SetParameterValue("ToDate", Convert.ToDateTime(dtp2.Text));
                    dsl.SetParameterValue("CompanyName", Helper.ShopName);
                    dsl.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                    dsl.SetParameterValue("ReportHeader", "Sales Report (AMC)");
                    CRV1.ReportSource = dsl;
                }
            }
            else if (Reportname == "TotalSalesReport")
            {
                ProductClass p = new ProductClass();
                dsProdDetail = p.BindProducts(UniqueShopID);
                DataTable dt = p.DailySalesReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text), Convert.ToInt32(SelectedProductID), Convert.ToInt32(CmbBrand.SelectedValue), Convert.ToInt32(CmbCategory.SelectedValue)).Tables[0];
                DataView DV = new DataView(dt);
                //string Type = "AMC";
                //DV.RowFilter = "ProductName like '%" + Type + "%'";


                if (UniqueShopID == 7)
                {
                    DailySalesReport_Sonar dsl = new DailySalesReport_Sonar();

                    dsl.SetDataSource(DV.ToTable());
                    dsl.Subreports[0].SetDataSource(DV.ToTable());
                    dsl.Subreports[1].SetDataSource(DV.ToTable());
                    dsl.SetParameterValue("FrmDate", Convert.ToDateTime(Dtp1.Text));
                    dsl.SetParameterValue("ToDate", Convert.ToDateTime(dtp2.Text));
                    dsl.SetParameterValue("CompanyName", Helper.ShopName);
                    dsl.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                    dsl.SetParameterValue("ReportHeader", "Sales Report (Product + AMC)");
                    CRV1.ReportSource = dsl;
                }
                else
                {

                    DailySalesReport dsl = new DailySalesReport();
                    //DataTable dt = p.DailySalesReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text)).Tables[0];
                    dsl.SetDataSource(DV.ToTable());
                    dsl.SetParameterValue("FrmDate", Convert.ToDateTime(Dtp1.Text));
                    dsl.SetParameterValue("ToDate", Convert.ToDateTime(dtp2.Text));
                    dsl.SetParameterValue("CompanyName", Helper.ShopName);
                    dsl.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                    dsl.SetParameterValue("ReportHeader", "Sales Report (Product + AMC)");
                    CRV1.ReportSource = dsl;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (Reportname == "ProductDetailsReport")
            {
                Dtp1.Enabled = false;
                Dtp1.Enabled = false;
                button1.Enabled = false;
                ProductClass p = new ProductClass();
                RptProductDetail pdl = new RptProductDetail();
                DataTable dt = p.ProductDetailsReport(UniqueShopID).Tables[0];
                pdl.SetDataSource(dt);
                pdl.SetParameterValue("CompanyName", Helper.ShopName);
                pdl.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                CRV1.ReportSource = pdl;

            }
            else if (Reportname == "Product Wise Summary")
            {
                Dtp1.Enabled = true;
                Dtp1.Enabled = true;
                button1.Enabled = true;
                ProductClass pd = new ProductClass();
                dsProdDetail = pd.BindProducts(UniqueShopID);

                ProductClass p = new ProductClass();
                DataTable dt = p.DailySalesReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text), Convert.ToInt32(SelectedProductID), Convert.ToInt32(CmbBrand.SelectedValue), Convert.ToInt32(CmbCategory.SelectedValue)).Tables[0];
                DataView DV = new DataView(dt);
                string Type = "AMC";
                DV.RowFilter = "ProductName not like '%" + Type + "%'";

                if (UniqueShopID == 7)
                {
                    ProductSummary_Sonar dsl = new ProductSummary_Sonar();
                    // DataTable dt = p.DailySalesReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text)).Tables[0];
                    dsl.SetDataSource(DV.ToTable());
                    dsl.SetParameterValue("FrmDate", Convert.ToDateTime(Dtp1.Text));
                    dsl.SetParameterValue("ToDate", Convert.ToDateTime(dtp2.Text));
                    dsl.SetParameterValue("CompanyName", Helper.ShopName);
                    dsl.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                    dsl.SetParameterValue("ReportHeader", "Product Wise Summary");
                    CRV1.ReportSource = dsl;
                }
                else
                {

                    ProductSummary_Sonar dsl = new ProductSummary_Sonar();
                    // DataTable dt = p.DailySalesReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text)).Tables[0];
                    dsl.SetDataSource(DV.ToTable());
                    dsl.SetParameterValue("FrmDate", Convert.ToDateTime(Dtp1.Text));
                    dsl.SetParameterValue("ToDate", Convert.ToDateTime(dtp2.Text));
                    dsl.SetParameterValue("CompanyName", Helper.ShopName);
                    dsl.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                    dsl.SetParameterValue("ReportHeader", "Product Wise Summary");
                    CRV1.ReportSource = dsl;
                }
            }
            else if (Reportname == "DailyPurchaseReport")
            {
                Dtp1.Enabled = true;
                Dtp1.Enabled = true;
                button1.Enabled = true;
                ProductClass p = new ProductClass();
                DailyPurchaseReport pur = new DailyPurchaseReport();
                DataTable dt = p.DailyPurchaseReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text)).Tables[0];
                pur.SetDataSource(dt);
                pur.SetParameterValue("FrmDate", Convert.ToDateTime(Dtp1.Text));
                pur.SetParameterValue("ToDate", Convert.ToDateTime(dtp2.Text));
                pur.SetParameterValue("CompanyName", Helper.ShopName);
                pur.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                CRV1.ReportSource = pur;

            }


            else if (Reportname == "DailySalesReport")
            {
                Dtp1.Enabled = true;
                Dtp1.Enabled = true;
                button1.Enabled = true;
                ProductClass p = new ProductClass();
                DataTable dt = p.DailySalesReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text), Convert.ToInt32(SelectedProductID), Convert.ToInt32(CmbBrand.SelectedValue), Convert.ToInt32(CmbCategory.SelectedValue)).Tables[0];
                DataView DV = new DataView(dt);
                string Type = "AMC";
                DV.RowFilter = "ProductName not like '%" + Type + "%'";
                if (UniqueShopID == 7)
                {
                    DailySalesReport_Sonar dsl = new DailySalesReport_Sonar();
                    //DataTable dt = p.DailySalesReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text)).Tables[0];
                    dsl.SetDataSource(DV.ToTable());
                    dsl.Subreports[0].SetDataSource(DV.ToTable());
                    dsl.Subreports[1].SetDataSource(DV.ToTable());
                    dsl.SetParameterValue("FrmDate", Convert.ToDateTime(Dtp1.Text));
                    dsl.SetParameterValue("ToDate", Convert.ToDateTime(dtp2.Text));
                    dsl.SetParameterValue("CompanyName", Helper.ShopName);
                    dsl.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                    dsl.SetParameterValue("ReportHeader", "Sales Report (Product)");
                    CRV1.ReportSource = dsl;
                }
                else
                {

                    DailySalesReport dsl = new DailySalesReport();
                    //DataTable dt = p.DailySalesReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text)).Tables[0];
                    dsl.SetDataSource(DV.ToTable());
                    //dsl.Subreports[0].SetDataSource(DV.ToTable());
                    dsl.SetParameterValue("FrmDate", Convert.ToDateTime(Dtp1.Text));
                    dsl.SetParameterValue("ToDate", Convert.ToDateTime(dtp2.Text));
                    dsl.SetParameterValue("CompanyName", Helper.ShopName);
                    dsl.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                    dsl.SetParameterValue("ReportHeader", "Sales Report (Product)");
                    CRV1.ReportSource = dsl;
                }



            }
            else if (Reportname == "BarCode")
            {
                string strReport = "barcode";
                var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                path = path.Substring(6);
                path = path + "\\" + strReport + ".rpt";
                Dtp1.Enabled = true;
                Dtp1.Enabled = true;
                button1.Enabled = true;
                ProductClass p = new ProductClass();
                ReportDocument rptdoc = new ReportDocument();
                rptdoc.Load(path);
                DataTable dt = p.ShowBarcode(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text)).Tables[0];
                rptdoc.SetDataSource(dt);
                //dsl.SetParameterValue("FrmDate", Convert.ToDateTime(Dtp1.Text));
                //dsl.SetParameterValue("ToDate", Convert.ToDateTime(Dtp1.Text));
                CRV1.ReportSource = rptdoc;
            }
            else if (Reportname == "ItemAndSerialWisePurchaseReport")
            {
                Dtp1.Enabled = true;
                Dtp1.Enabled = true;
                button1.Enabled = true;
                ProductClass p = new ProductClass();
                ItemAndSerialWisePurchaseReport pur = new ItemAndSerialWisePurchaseReport();
                DataTable dt = p.DailyPurchaseItemSrNoReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text)).Tables[0];
                pur.SetDataSource(dt);
                pur.SetParameterValue("FrmDate", Convert.ToDateTime(Dtp1.Text));
                pur.SetParameterValue("ToDate", Convert.ToDateTime(dtp2.Text));
                pur.SetParameterValue("CompanyName", Helper.ShopName);
                pur.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                CRV1.ReportSource = pur;
            }
            else if (Reportname == "ComplaintSlip")
            {
                Dtp1.Enabled = false;
                Dtp1.Enabled = false;
                button1.Enabled = false;
                ProductClass p = new ProductClass();
                Report.CustomerSlip dsl = new Report.CustomerSlip();
                DataTable dt = p.CustomerSlip(UniqueShopID).Tables[0];
                dsl.SetDataSource(dt);
                dsl.SetParameterValue("ShopName", Helper.ShopName);
                dsl.SetParameterValue("ShopAddress", Helper.ShopAddress);
                CRV1.ReportSource = dsl;



            }
            else if (Reportname == "MultipleComplaintSlip")
            {

                DataTable dt = new DataTable();
                ProductClass p = new ProductClass();
                dt = p.CustomerSlip(Convert.ToInt32(0)).Tables[0].Clone();

                foreach (string item in CompList)
                {

                    foreach (DataRow dr in p.CustomerSlip(Convert.ToInt32(item)).Tables[0].Rows)
                    {
                        dt.ImportRow(dr);
                    }

                }
                string strReport = "ComplaintSlip_All";
                var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                path = path.Substring(6);
                path = path + "\\" + strReport + ".rpt";
                ReportDocument rptdoc = new ReportDocument();
                rptdoc.Load(path);
                rptdoc.SetDataSource(dt);
                rptdoc.SetParameterValue("ShopName", Helper.ShopName);
                rptdoc.SetParameterValue("ShopAddress", Helper.ShopAddress);
                CRV1.ReportSource = rptdoc;
            }
            else if (Reportname == "DailyAMCSalesReport")
            {
                ProductClass p = new ProductClass();
                DataTable dt = p.DailySalesReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text), Convert.ToInt32(SelectedProductID), Convert.ToInt32(CmbBrand.SelectedValue), Convert.ToInt32(CmbCategory.SelectedValue)).Tables[0];
                DataView DV = new DataView(dt);
                string Type = "AMC";
                DV.RowFilter = "ProductName like '%" + Type + "%'";


                if (UniqueShopID == 7)
                {
                    DailySalesReport_Sonar dsl = new DailySalesReport_Sonar();

                    dsl.SetDataSource(DV.ToTable());
                    dsl.Subreports[0].SetDataSource(DV.ToTable());
                    dsl.Subreports[1].SetDataSource(DV.ToTable());
                    dsl.SetParameterValue("FrmDate", Convert.ToDateTime(Dtp1.Text));
                    dsl.SetParameterValue("ToDate", Convert.ToDateTime(dtp2.Text));
                    dsl.SetParameterValue("CompanyName", Helper.ShopName);
                    dsl.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                    dsl.SetParameterValue("ReportHeader", "Sales Report (AMC)");
                    CRV1.ReportSource = dsl;
                }
                else
                {

                    DailySalesReport dsl = new DailySalesReport();
                    //DataTable dt = p.DailySalesReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text)).Tables[0];
                    dsl.SetDataSource(DV.ToTable());
                    dsl.SetParameterValue("FrmDate", Convert.ToDateTime(Dtp1.Text));
                    dsl.SetParameterValue("ToDate", Convert.ToDateTime(dtp2.Text));
                    dsl.SetParameterValue("CompanyName", Helper.ShopName);
                    dsl.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                    dsl.SetParameterValue("ReportHeader", "Sales Report (AMC)");
                    CRV1.ReportSource = dsl;
                }
            }
            else if (Reportname == "TotalSalesReport")
            {
                ProductClass p = new ProductClass();
                DataTable dt = p.DailySalesReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text), Convert.ToInt32(SelectedProductID), Convert.ToInt32(CmbBrand.SelectedValue), Convert.ToInt32(CmbCategory.SelectedValue)).Tables[0];
                DataView DV = new DataView(dt);
                //string Type = "AMC";
                //DV.RowFilter = "ProductName like '%" + Type + "%'";


                if (UniqueShopID == 7)
                {
                    DailySalesReport_Sonar dsl = new DailySalesReport_Sonar();

                    dsl.SetDataSource(DV.ToTable());
                    dsl.Subreports[0].SetDataSource(DV.ToTable());
                    dsl.Subreports[1].SetDataSource(DV.ToTable());
                    dsl.SetParameterValue("FrmDate", Convert.ToDateTime(Dtp1.Text));
                    dsl.SetParameterValue("ToDate", Convert.ToDateTime(dtp2.Text));
                    dsl.SetParameterValue("CompanyName", Helper.ShopName);
                    dsl.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                    dsl.SetParameterValue("ReportHeader", "Sales Report (Product + AMC)");
                    CRV1.ReportSource = dsl;
                }
                else
                {

                    DailySalesReport dsl = new DailySalesReport();
                    //DataTable dt = p.DailySalesReport(UniqueShopID, Convert.ToDateTime(Dtp1.Text), Convert.ToDateTime(dtp2.Text)).Tables[0];
                    dsl.SetDataSource(DV.ToTable());
                    dsl.SetParameterValue("FrmDate", Convert.ToDateTime(Dtp1.Text));
                    dsl.SetParameterValue("ToDate", Convert.ToDateTime(dtp2.Text));
                    dsl.SetParameterValue("CompanyName", Helper.ShopName);
                    dsl.SetParameterValue("CompanyAdd", Helper.ShopAddress);
                    dsl.SetParameterValue("ReportHeader", "Sales Report (Product + AMC)");
                    CRV1.ReportSource = dsl;
                }
            }

        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtSearch.Text == string.Empty)
                {
                    SelectedProductID = null;
                    LstSearch.Visible = false;
                    LstSearch.DataSource = null;
                }
                if (dsProdDetail.Tables[0].Rows.Count > 0)
                {

                    DataView dv = new DataView(dsProdDetail.Tables[0]);
                    if (CmbBrand.SelectedValue.ToString() == "0" && CmbCategory.SelectedValue.ToString() == "0")
                    {
                        dv.RowFilter = "Product like '%" + TxtSearch.Text + "%'";
                    }
                    else if (Convert.ToInt32(CmbBrand.SelectedValue.ToString()) >= 0 && Convert.ToInt32(CmbCategory.SelectedValue.ToString()) >= 0)
                    {
                        dv.RowFilter = "Product like '%" + TxtSearch.Text + "%' and CatID ='" + CmbCategory.SelectedValue.ToString() + "' and BrandID='" + CmbBrand.SelectedValue.ToString() + "'";
                    }
                    else if (string.IsNullOrEmpty(CmbCategory.SelectedValue.ToString()) && Convert.ToInt32(CmbBrand.SelectedValue.ToString()) >= 0)
                    {
                        dv.RowFilter = "Product like '%" + TxtSearch.Text + "%' and BrandID='" + CmbBrand.SelectedValue.ToString() + "'";
                    }
                    else if (string.IsNullOrEmpty(CmbBrand.SelectedValue.ToString()) && Convert.ToInt32(CmbCategory.SelectedValue.ToString()) >= 0)
                    {
                        dv.RowFilter = "Product like '%" + TxtSearch.Text + "%' and CatID ='" + CmbCategory.SelectedValue.ToString() + "' ";
                    }

                    LstSearch.Visible = true;
                    LstSearch.DataSource = dv.ToTable();
                    LstSearch.DisplayMember = "Product";
                    LstSearch.ValueMember = "Productid";

                }
            }
            catch (Exception)
            {


            }
         }

        private void LstSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void LstSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                SelectedProductID = LstSearch.GetItemText(LstSearch.SelectedValue);
                if (!string.IsNullOrEmpty(SelectedProductID))
                {
                    TxtSearch.Text = LstSearch.GetItemText(LstSearch.SelectedItem);
                    
                    LstSearch.Visible = false;
                }
            
        }

        private void BindCategoryDropDown()
        {
            CategoryclassBe be = new CategoryclassBe();
            be.Shopid = UniqueShopID;
            DataTable dt = new DataTable();
            CategoryClass cc = new CategoryClass();
            dt = cc.BindDropDownCategory1(be);
            dt.Rows.Add("0", "Select");
            DataView dv = new DataView(dt);
            dv.Sort = "Categoryid asc";
            CmbCategory.DataSource = dv.ToTable();
            CmbCategory.DisplayMember = "Categoryname";
            CmbCategory.ValueMember = "Categoryid";
        }

        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Brands brnd = new Brands();
                DataTable dt = new DataTable();
                BrandsBe be = new BrandsBe();
                be.Shopid = UniqueShopID;
                dt = brnd.CategoryWiseBrand(Convert.ToInt32(CmbCategory.SelectedValue));
                dt.Rows.Add("0", "Select");
                DataView dv = new DataView(dt);
                dv.Sort = "BrandID asc";
                CmbBrand.DataSource = dv.ToTable();
                CmbBrand.DisplayMember = "BrandName";
                CmbBrand.ValueMember = "BrandID";
                TxtSearch.Text = string.Empty;
                SelectedProductID = "0";

            }
            catch (Exception)
            {

               
            }
            
        }

        private void CmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtSearch.Text = string.Empty;
            SelectedProductID = "0";
        }
    }
}
