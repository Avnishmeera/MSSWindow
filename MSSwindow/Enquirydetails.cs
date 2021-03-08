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
    public partial class Enquirydetails : Form
    {
        public Enquirydetails()
        {
            InitializeComponent();
        }

        public readonly int UniqueShopid;
        bool IsNewCustomer = false;
        DataSet dsCustDetail = new DataSet();
        public Enquirydetails(int Shopid)
        {
            InitializeComponent();
            UniqueShopid = Shopid;
            CustomerClass CSL = new CustomerClass();
            dsCustDetail = CSL.SearchCustomers(UniqueShopid, txtcustomer.Text);
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void GenerateInvoiceNO()
        {
            CustomerClass cls = new CustomerClass();
            txtenquiruinvoice.Text = cls.GenerateEnquiry(UniqueShopid).Tables[0].Rows[0][0].ToString();
        }


        EnquiryClass cls = new EnquiryClass();

        private void btnsave_Click(object sender, EventArgs e)
        {
            Enquriryclsbe be = new Enquriryclsbe();
            be.Shopid = UniqueShopid;
            be.Enquiryid = 0;
            be.Enquiryno = txtenquiruinvoice.Text;
            be.Enqurirydate =Convert.ToDateTime(dtEnqdate);
            be.Types =Convert.ToInt32(cmbTypes.SelectedValue);
            be.Category = Convert.ToInt32(cmbcat.SelectedValue);
            be.Product = Convert.ToInt32(cmbcat.SelectedValue);
            be.Vistitdate =Convert.ToDateTime(dtvisiteddate.Value);
            be.Visittime = Convert.ToDateTime(dtvisitedTime.Value);;
            be.Source = Convert.ToInt32(cmbSource.SelectedValue);
            be.CallBy = Convert.ToInt32(cmbcallby.SelectedValue);
            be.CallNumber = txtcallingnumber.Text;
            be.SubmitedBy =Convert.ToInt32(cmbsubmitedby.SelectedValue);
            be.Referenceno = txtrefno.Text;
            be.EnqStatus =Convert.ToInt32(cmbStatus.SelectedValue);
            be.NextFollowupdate =Convert.ToDateTime(dtnextfollowupdate.Value);
            be.Followuplastremarks = txtlastfollowupremarks.Text;
            be.Followupremarks = txtnextfollowupremarks.Text;
            EnquiryClass cms = new EnquiryClass();
            cms.InsertUpdateEnquiry(be);
            int i=5;
            if (i > 0)
            {
                MessageBox.Show(this, "Enquiry Saved Successfully.", "Enquiry Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void BindFollowupDetails()
        {

        }

        private void Enquirydetails_Load(object sender, EventArgs e)
        {
            lstcustomer.Visible = false;
            GenerateInvoiceNO();
            BindFollowupDetails();
            BindCategoryDropDown();
            BindSourceCMB();
            BindDataGridviewAdminEmployee();
            BindTypesCMB();
            BindStatus();
        }

        private void BindStatus()
        {
            CustomerClass cls = new CustomerClass();
            cmbStatus.DataSource = cls.GetAllComplaintResolutionStatus().Tables[0];
            cmbStatus.DisplayMember = "StatusDescription";
            cmbStatus.ValueMember = "StatusID";
        }



        private void BindDataGridviewAdminEmployee()
        {
            RegistractionClass rc = new RegistractionClass();
            DataTable dtemp = new DataTable();
            dtemp.Columns.Add("memid", typeof(System.Int32));
            dtemp.Columns.Add("FullName", typeof(System.String));
            dtemp.Rows.Add(0, "Select");
            DataTable dt = rc.BindMemberDetails(UniqueShopid, string.Empty).Tables[0];
            DataView dv = new DataView(dt);
            string RoleType = "ADMIN";
            dv.RowFilter = "Role='" + RoleType + "'";
            foreach (DataRow item in dv.ToTable().Rows)
            {
                dtemp.Rows.Add(item["memid"], item["FullName"]);
            }
            cmbsubmitedby.DataSource = dtemp;
            if (dtemp.Rows.Count < 1)
            {
                cmbsubmitedby.DisplayMember = "FullName";
                cmbsubmitedby.ValueMember = "memid";
            }
            else
            {
                cmbsubmitedby.DisplayMember = "FullName";
                cmbsubmitedby.ValueMember = "memid";
            }

            if (cmbsubmitedby.Items.Count == 2)
            {
                cmbsubmitedby.SelectedIndex = 1;              
            }

        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {

        }

        private void btnreset_Click(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void BindCategoryDropDown()
        {
            CategoryclassBe be = new CategoryclassBe();
            be.Shopid = UniqueShopid;
            CategoryClass catc = new CategoryClass();
            DataTable dt = new DataTable();
            dt.Columns.Add("Categoryid", typeof(System.Int32));
            dt.Columns.Add("Categoryname", typeof(System.String));
            dt = catc.BindDropDownCategory1(be);
            dt.Rows.Add(0, "----- Select -----");
            DataView dv = new DataView(dt);
            dv.Sort = "Categoryid";
            cmbcat.DataSource = dv.ToTable();
            cmbcat.DisplayMember = "Categoryname";
            cmbcat.ValueMember = "Categoryid";
        }


        private void BindSourceCMB()
        {
            CategoryclassBe be = new CategoryclassBe();
            be.Shopid = UniqueShopid;
            CategoryClass catc = new CategoryClass();
            DataTable dt = new DataTable();
            dt.Columns.Add("Sourceid", typeof(System.Int32));
            dt.Columns.Add("Sourcename", typeof(System.String));
            dt = catc.BindSource();
            dt.Rows.Add(0, "----- Select -----");
            DataView dv = new DataView(dt);
            dv.Sort = "Sourceid";
            cmbSource.DataSource = dv.ToTable();
            cmbSource.DisplayMember = "Sourcename";
            cmbSource.ValueMember = "Sourceid";
        }


        private void BindTypesCMB()
        {
            CategoryclassBe be = new CategoryclassBe();
            be.Shopid = UniqueShopid;
            CategoryClass catc = new CategoryClass();
            DataTable dt = new DataTable();
            dt.Columns.Add("Typeid", typeof(System.Int32));
            dt.Columns.Add("Typename", typeof(System.String));
            dt = catc.BindTypes();
            dt.Rows.Add(0, "----- Select -----");
            DataView dv = new DataView(dt);
            dv.Sort = "Typeid";
            cmbTypes.DataSource = dv.ToTable();
            cmbTypes.DisplayMember = "Typename";
            cmbTypes.ValueMember = "Typeid";
        }

        string SelectedCustomerID = "0";
        private void lstcustomer_Click(object sender, EventArgs e)
        {
            SelectedCustomerID = lstcustomer.GetItemText(lstcustomer.SelectedValue);
            if (!string.IsNullOrEmpty(SelectedCustomerID))
            {
                txtcustomer.Text = lstcustomer.GetItemText(lstcustomer.SelectedItem);
                Sales p = new Sales();
                string CustomerContact = string.Empty;
                int i = Convert.ToInt32(SelectedCustomerID);
                if (i != 0)
                {

                    txtaddress.Text = p.GetSupplierAddressWithContact(Convert.ToInt32(SelectedCustomerID), out CustomerContact);
                    txtcontact.Text = CustomerContact;
                    lstcustomer.Visible = false;
                }
            }
        }

        private void txtcustomer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsNewCustomer)
                    return;
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
    }
}
