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
    public partial class Followupform : Form
    {
        DataSet dsCustDetail = new DataSet();
        int UniqueShopID = 0;
        string SelectedCustomerID = "0";
        int CompID = 0;
        bool IsNewCustomer = false;
        public Followupform(int ShopID)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
            CustomerClass CSL = new CustomerClass();
            dsCustDetail = CSL.SearchCustomers(UniqueShopID, TxtEmp.Text);
        }

        private void TxtEmp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsNewCustomer)
                    return;
                if (dsCustDetail.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(dsCustDetail.Tables[0]);
                    dv.RowFilter = "Name like '%" + TxtEmp.Text + "%'";
                    LstEmp.Visible = true;
                    LstEmp.DataSource = dv.ToTable();
                    LstEmp.DisplayMember = "Name";
                    LstEmp.ValueMember = "Customerid";
                }
            }
            catch (Exception)
            {


            }
        }
        private void BindDataGridviewEmployee()
        {
            RegistractionClass rc = new RegistractionClass();
            DataTable dtemp = new DataTable();
            dtemp.Columns.Add("memid", typeof(System.Int32));
            dtemp.Columns.Add("FullName", typeof(System.String));
            dtemp.Rows.Add(0, "Select");
            DataTable dt = rc.BindMemberDetails(UniqueShopID, string.Empty).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                dtemp.Rows.Add(item["memid"], item["FullName"]);
            }

            CmbEmp.DataSource = dtemp;
            CmbEmp.DisplayMember = "FullName";
            CmbEmp.ValueMember = "memid";


        }
        private void LstEmp_Click(object sender, EventArgs e)
        {
            SelectedCustomerID = LstEmp.GetItemText(LstEmp.SelectedValue);
            if (!string.IsNullOrEmpty(SelectedCustomerID))
            {
                TxtEmp.Text = LstEmp.GetItemText(LstEmp.SelectedItem);
                Sales p = new Sales();
                string CustomerContact = string.Empty;
                int i = Convert.ToInt32(SelectedCustomerID);
                if (i != 0)
                {
                    
                    txtadd.Text = p.GetSupplierAddressWithContact(Convert.ToInt32(SelectedCustomerID), out CustomerContact);
                    TxtContact.Text = CustomerContact;
                    LstEmp.Visible = false;

                }
            }
        }

        private void ComplaintForm_Load(object sender, EventArgs e)
        {
            LstEmp.Visible = false;
            BindDataGridviewEmployee();
            bindComplaintGrid(string.Empty);
            BindComplaintStatus();
            GenerateComplaintNO();
            BindComplaintResolutionStatus();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void BindComplaintStatus()
        {
            CustomerClass cls = new CustomerClass();
            CmbCompStatus.DataSource = cls.GetAllComplaintResolutionStatus().Tables[0];
            CmbCompStatus.DisplayMember = "StatusDescription";
            CmbCompStatus.ValueMember = "StatusID";

        }

      
        private void BindComplaintResolutionStatus()
        {
            ProductClass cls = new ProductClass();
            List<ProductClassBe> pm = new List<ProductClassBe>();
            pm = cls.BrandWiseProduct(UniqueShopID);
            DataTable DTP = new DataTable();
            DTP.Columns.Add("ProductID", typeof(System.Int32));
            DTP.Columns.Add("ProductName", typeof(System.String));
            DTP.Rows.Add(0, "Select");
            foreach (ProductClassBe item in pm)
            {
                DTP.Rows.Add(item.ProductID, item.ProductName);
            }
            CmbStatus.DataSource = DTP;
            CmbStatus.DisplayMember = "ProductName";
            CmbStatus.ValueMember = "ProductID";
            //cmbProductname.Items.Insert(0, "---Select----");
        }

        private void bindComplaintGrid(string strSearch)
        {
            CustomerClass cls = new CustomerClass();
            dataGridView1.DataSource = cls.SearchCustomerEnquiry(strSearch, UniqueShopID).Tables[0];
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Register the complaint?", "Customer Complaint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (TxtEmp.Text == string.Empty)
                {
                    MessageBox.Show(this, "Please select  customer to register the complaint", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (TxtContact.Text == string.Empty)
                {
                    MessageBox.Show(this, "Please Enter Customer Contact No.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }

                CustomerComplaint cmpl = new CustomerComplaint();
                cmpl.CompID = CompID;
                cmpl.CustomerID = Convert.ToInt32(SelectedCustomerID);
                cmpl.ComplaintID = TxtEnquiryNo.Text;
                cmpl.ComplaintDate = dtCompDate.Value;
                cmpl.EmpID = Convert.ToInt32(CmbEmp.SelectedValue);
                cmpl.CloseDate = dtresolve.Value;
                cmpl.VisitDate = dtvisit.Value;
                cmpl.StatusID = Convert.ToInt32(CmbStatus.SelectedValue);
                cmpl.ShopID = UniqueShopID;
                cmpl.Remark = TxtRemark.Text;
                cmpl.CustomerName = TxtEmp.Text;
                cmpl.CustomerAddress = txtadd.Text;
                cmpl.CustomerContact = TxtContact.Text;
                cmpl.IsNewCustomer = IsNewCustomer;
                cmpl.ResolutionStatusID = Convert.ToInt32(CmbCompStatus.SelectedValue);
                CustomerClass cms = new CustomerClass();
                int i = cms.InsertUpdateCustomerEnquiry(cmpl);
                if (i > 0)
                {
                    MessageBox.Show(this, "Complaint Registered Successfully.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bindComplaintGrid(string.Empty);
                    clearControl();
                }
            }
        }
        private void clearControl()
        {
            SelectedCustomerID = "0";
            GenerateComplaintNO();
            CmbEmp.SelectedIndex = 0;
            CmbStatus.SelectedIndex = 0;
            TxtEmp.Text = string.Empty;
            txtadd.Text = string.Empty;
            CmbEmp.SelectedIndex = 0;
            TxtRemark.Text = string.Empty;
            CompID = 0;
            LstEmp.Visible = false;
            TxtContact.Enabled = false;
            txtadd.Enabled = false;
            IsNewCustomer = false;
            CmbCompStatus.SelectedIndex = 0;
            TxtContact.Text = string.Empty;

        }

        private void GenerateComplaintNO()
        {
            CustomerClass cls = new CustomerClass();
            TxtEnquiryNo.Text = cls.GenerateEnquiry(UniqueShopID).Tables[0].Rows[0][0].ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                CompID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["GenID"].Value.ToString());
                dtCompDate.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["Date"].Value.ToString());
                TxtEnquiryNo.Text = dataGridView1.CurrentRow.Cells["EnquiryID"].Value.ToString();
                CmbEmp.SelectedValue = dataGridView1.CurrentRow.Cells["EmpID"].Value.ToString();
                TxtRemark.Text = dataGridView1.CurrentRow.Cells["Remark"].Value.ToString();
                TxtEmp.Text = dataGridView1.CurrentRow.Cells["Customername"].Value.ToString();
                SelectedCustomerID = dataGridView1.CurrentRow.Cells["Customerid"].Value.ToString();
                CmbCompStatus.SelectedValue = dataGridView1.CurrentRow.Cells["StatusID"].Value.ToString();
                dtvisit.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["VisitDate"].Value.ToString());
                dtresolve.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["ResolveDate"].Value.ToString());
                CmbStatus.SelectedValue = dataGridView1.CurrentRow.Cells["ReasonID"].Value.ToString();
                LstEmp.Visible = false;
                string CustomerContact = string.Empty;
                Sales p = new Sales();
                txtadd.Text = p.GetSupplierAddressWithContact(Convert.ToInt32(SelectedCustomerID), out CustomerContact);
                TxtContact.Text = CustomerContact;

               

            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
           
            if (TxtSearch.Text != string.Empty)
                bindComplaintGrid(TxtSearch.Text);
            else
                bindComplaintGrid(string.Empty);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearControl();
        }

        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TxtContact.Enabled = true;
            txtadd.Enabled = true;
            IsNewCustomer = true;
        }


    }
}
