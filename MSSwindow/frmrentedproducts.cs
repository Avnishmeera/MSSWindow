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
    public partial class frmrentedproducts : MasterForm
    {


        public DataSet dsCustDetail = new DataSet();
        private readonly int UniqueShopID = 0;
        string SelectedCustomerID = "0";
        DataSet dsProduct = new DataSet();
        string SelectedProductID = "0";
        public frmrentedproducts()
        {
            InitializeComponent();
        }
        public frmrentedproducts(int shopid)
        {
            InitializeComponent();
            UniqueShopID = shopid;
        }

        private void GetRefNo()
        {
            try
            {
                Rentcls st = new Rentcls();
                DataTable dt = new DataTable();
                dt = st.BindRentRefNo(UniqueShopID);
                txtinvoiceno.Text = dt.Rows[0]["Refno"].ToString();
            }
            catch (Exception)
            {

            }
        }



        private void txtcustomer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dsCustDetail.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(dsCustDetail.Tables[0]);
                    dv.RowFilter = "Name like '%" + txtcustomer.Text + "%'";
                    lstcustomer.Visible = true;
                    lstcustomer.DataSource = dv.ToTable();
                    lstcustomer.DisplayMember = "Name";
                    lstcustomer.ValueMember = "Customerid";
                }
            }
            catch (Exception)
            {


            }
        }


        private void lstcustomer_Click(object sender, EventArgs e)
        {
            SelectedCustomerID = lstcustomer.GetItemText(lstcustomer.SelectedValue);
            if (!string.IsNullOrEmpty(SelectedCustomerID))
            {
                txtcustomer.Text = lstcustomer.GetItemText(lstcustomer.SelectedItem);
                CustomerClass p = new CustomerClass();
                string CustomerContact = string.Empty;
                int i = Convert.ToInt32(SelectedCustomerID);
                if (i != 0)
                {
                    DataView dv = new DataView(p.BindCustomers(UniqueShopID).Tables[0]);
                    dv.RowFilter = "Customerid = '" + SelectedCustomerID + "'";
                    txtaddress.Text = dv.ToTable().Rows[0]["Address"].ToString();
                    txtcontact.Text = dv.ToTable().Rows[0]["Contact"].ToString();
                    lstcustomer.Visible = false;
                }
            }
        }

        private void txtproduct_TextChanged(object sender, EventArgs e)
        {
            if (txtproduct.Text == string.Empty)
            {
                lstproduct.Visible = false;
                return;
            }
            if (dsProduct.Tables[0].Rows.Count > 0)
            {
                DataView dv = new DataView(dsProduct.Tables[0]);
                dv.RowFilter = "Productname like '%" + txtproduct.Text + "%'";
                lstproduct.Visible = true;
                lstproduct.DataSource = dv.ToTable();
                lstproduct.DisplayMember = "Productname";
                lstproduct.ValueMember = "Productid";
            }
        }

        private void lstproduct_Click(object sender, EventArgs e)
        {
            SelectedProductID = lstproduct.GetItemText(lstproduct.SelectedValue);
            if (!string.IsNullOrEmpty(SelectedProductID))
            {
                txtproduct.Text = lstproduct.GetItemText(lstproduct.SelectedItem);
                lstproduct.Visible = false;
            }
        }

        private void frmrentedproducts_Load(object sender, EventArgs e)
        {
            GetRefNo();
            ProductClass prod = new ProductClass();
            dsProduct = prod.BindProducts(UniqueShopID);
            CustomerClass CSL = new CustomerClass();
            dsCustDetail = CSL.SearchCustomers(UniqueShopID, txtcustomer.Text);
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void btnsave_Click_1(object sender, EventArgs e)
        {
            CustomerClass cl = new CustomerClass();
            Rent rnt = new Rent();
            rnt.rentid = null;
            rnt.Invoiceid = txtinvoiceno.Text;
            rnt.productid = Convert.ToInt32(SelectedProductID);
            rnt.customerid = Convert.ToInt32(SelectedCustomerID);
            rnt.rentstartdate = datetimeStartdate.Value;
            rnt.rentenddate = dateTimePicker1.Value;
            rnt.securityAmount = Convert.ToInt32(txtserurityamt.Text);
            rnt.Daliyrentamount = Convert.ToInt32(txtdailyamt.Text);
            rnt.Monthlyrentamount = Convert.ToInt32(txtmonthlyamt.Text);
            rnt.Yearlyrentamount = Convert.ToInt32(txtyearlyamt.Text);
            rnt.penaltycharge = Convert.ToInt32(txtpenaltycharge.Text);
            rnt.bouncecharge = Convert.ToInt32(txtbouncechrg.Text);
            rnt.policy = 1;
            rnt.servicestartdate = null;
            rnt.remserday = Convert.ToInt32(remserday.Text);
            rnt.noofser = Convert.ToInt32(noofser.Value);
            rnt.remrentday = Convert.ToInt32(remrentday.Value);
            rnt.rentcoldays = Convert.ToInt32(rentcoldays.Value);
            rnt.isactive = true;
            rnt.Price = Convert.ToInt32(txtprice.Text);
            rnt.Qty = Convert.ToInt32(txtqty.Text);
            rnt.ShopID = UniqueShopID;
            DataSet ds = new DataSet();
            ds = cl.CreateRent(rnt);
            if (ds.Tables.Count>0)
            {
                dataGridViewRent.DataSource = ds.Tables[0];
                dataGridViewAmc.DataSource = ds.Tables[1];
            }
        }

        private void numrentduration_ValueChanged(object sender, EventArgs e)
        {
           // dtexp.Value = txtPurdate.Value.AddYears((int)NMWarDuration.Value);
        }

        private void txtdailyamt_TextChanged(object sender, EventArgs e)
        {

        }

        //private void SetKeyPress(object sender, KeyPressEventArgs e)
        //{

        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //    }
        //}
    }
}
