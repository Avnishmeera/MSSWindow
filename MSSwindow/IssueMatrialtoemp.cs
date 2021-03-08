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
    public partial class IssueMatrialtoemp : Form
    {
        public IssueMatrialtoemp()
        {
            InitializeComponent();
        }

        public readonly int UniqueShopID;


        public IssueMatrialtoemp(int shopid)
        {
            InitializeComponent();
            UniqueShopID = shopid;
        }

        private void IssueMatrialtoemp_Load(object sender, EventArgs e)
        {
            BindFromLocation();
            ProductClass prod = new ProductClass();
            dsProduct = prod.BindProducts(UniqueShopID);
        }
        private void BindFromLocation()
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
                cmbfrom.DataSource = dv.ToTable();
                cmbfrom.DisplayMember = "Locationname";
                cmbfrom.ValueMember = "Locationid";
            }
            catch (Exception)
            {

            }
        }

        private void btntransfer_Click(object sender, EventArgs e)
        {

        }


        DataTable dt = new DataTable();
        private void BindGridview(int locationid , int Productid)
        {
            Stockbe be = new Stockbe();
            be.Shopid = UniqueShopID;
            be.Locationid = locationid;
            be.Productid = Productid;
            Stock p1 = new Stock();
            //DataView dv = new DataView(p1.BindStockDetails(be));
          
            dt = p1.BindStockDetails(be);
            if (dt.Rows.Count > 0)
            {
                dt.Columns.Remove("TransQty");
                dt.Columns.Remove("RemQty");
                dt.Columns.Remove("Unitid");
                datagridIssueMatrial.DataSource = dt;
                int totalqty = 0;
                int totalprice = 0;
                for (int i = 0; i < datagridIssueMatrial.Rows.Count; ++i)
                {
                    totalprice += Convert.ToInt32(datagridIssueMatrial.Rows[i].Cells[5].Value);
                    totalqty += Convert.ToInt32(datagridIssueMatrial.Rows[i].Cells[6].Value);
                }
                lblavlstack.Text = "Total Available Qty is: " + totalqty.ToString();
                lbltotalprice.Text = "Total Price is: " + totalprice.ToString();
            }
            else
            {
                dt = null;
                datagridIssueMatrial.DataSource = dt;
                lblavlstack.Text = "0";
                lbltotalprice.Text = "0";
            }
        }
       
        private void cmbfrom_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            try
            {
                if (cmbfrom.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    if (cmbfrom.SelectedValue.ToString() != "0")
                    {
                        BindGridview(Convert.ToInt32(cmbfrom.SelectedValue),Convert.ToInt32(SelectedProductID));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        string SelectedProductID = "0";

        private void LstProduct_Click(object sender, EventArgs e)
        {
            SelectedProductID = LstProduct.GetItemText(LstProduct.SelectedValue);
            if (!string.IsNullOrEmpty(SelectedProductID))
            {
                txtproduct.Text = LstProduct.GetItemText(LstProduct.SelectedItem);
                BindGridview(Convert.ToInt32(cmbfrom.SelectedValue), Convert.ToInt32(SelectedProductID));
                LstProduct.Visible = false;
            }
        }



        DataSet dsProduct = new DataSet();
        private void txtproduct_TextChanged(object sender, EventArgs e)
       {
            if (txtproduct.Text == string.Empty)
            {
                LstProduct.Visible = false;
                SelectedProductID = "0";
                BindGridview(Convert.ToInt32(cmbfrom.SelectedValue), Convert.ToInt32(SelectedProductID));
                return;
            }
            if (dsProduct.Tables[0].Rows.Count > 0)
            {
                DataView dv = new DataView(dsProduct.Tables[0]);
                dv.RowFilter = "Productname like '%" + txtproduct.Text + "%'";
                LstProduct.Visible = true;
                LstProduct.DataSource = dv.ToTable();
                LstProduct.DisplayMember = "Productname";
                LstProduct.ValueMember = "Productid";
            }
        }

    }
}
