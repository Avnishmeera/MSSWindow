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
    public partial class InventoryReport : Form
    {
        int UniqueShopID = 0;
        public InventoryReport(int ShopID)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
        }

        private void InventoryReport_Load(object sender, EventArgs e)
        {
            BindEmployee();
            bindFrmLocation(null);
            bindToLocation(null);
            CMBReportType.SelectedValue = 0;
        }

        private void BindEmployee()
        {
            RegistractionClass rc = new RegistractionClass();
            DataTable dtemp = new DataTable();
            dtemp.Columns.Add("memid", typeof(System.Int32));
            dtemp.Columns.Add("FullName", typeof(System.String));
            dtemp.Rows.Add(0, "Select");
            // DataTable dt = rc.BindMemberDetailsComplaint(UniqueShopID, string.Empty).Tables[0];
            DataTable dt = rc.BindMemberDetails(UniqueShopID, string.Empty).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                dtemp.Rows.Add(item["memid"], item["FullName"]);
            }
            CMBTech.DataSource = dtemp;
            CMBTech.DisplayMember = "FullName";
            CMBTech.ValueMember = "memid";
        }

        private void bindFrmLocation(int? locationid)
        {
            try
            {
                Stockbe be = new Stockbe();
                be.Shopid = UniqueShopID;

                Stock UC = new Stock();
                DataTable dt = new DataTable();
                dt = UC.BindFromLocation(be).Tables[0];
                dt.Rows.Add("0", "Select");
                DataView dv = new DataView(dt);
                dv.Sort = "Locationid asc";
                CmbFrm.DataSource = dv.ToTable();
                CmbFrm.DisplayMember = "Locationname";
                CmbFrm.ValueMember = "Locationid";
            }
            catch (Exception)
            {

            }
        }
        private void bindToLocation(int? locationid)
        {
            try
            {
                Stockbe be = new Stockbe();
                be.Shopid = UniqueShopID;

                Stock UC = new Stock();
                DataTable dt = new DataTable();
                dt = UC.BindFromLocation(be).Tables[0];
                dt.Rows.Add("0", "Select");
                DataView dv = new DataView(dt);
                dv.Sort = "Locationid asc";
                CmbTo.DataSource = dv.ToTable();
                CmbTo.DisplayMember = "Locationname";
                CmbTo.ValueMember = "Locationid";
            }
            catch (Exception)
            {

            }
        }

        private void BindReport(string Param)
        {

        }

        private void CMBReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (CMBReportType.SelectedItem.ToString() == "Profit/ Loss Report")
            {
                CmbFrm.Enabled = false;
                CmbTo.Enabled = false;
            }
            else if (CMBReportType.SelectedItem.ToString() == "Inventory Transfer Report")
            {
                CmbFrm.Enabled = true;
                CmbTo.Enabled = false;
            }

            else if (CMBReportType.SelectedItem.ToString() == "Inventory Transfer Detail Report")
            {
                CmbFrm.Enabled = true;
                CmbTo.Enabled = true;
            }
        }
    }
}
