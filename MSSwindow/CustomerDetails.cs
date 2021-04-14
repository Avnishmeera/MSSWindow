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
using MSSwindow.Connection;
using MSSEntityFrame;
using System.Web.RegularExpressions;
using System.Text.RegularExpressions;

namespace MSSwindow
{
    public partial class CustomerDetails : Form
    {
        RetailSaleDetails sd = null;
        public readonly int UniqueShopID = 0;
        public DataTable DTCUST = new DataTable();
        public CustomerDetails(int ShopID)
        {
            InitializeComponent();
            UniqueShopID = ShopID;

        }

        public CustomerDetails(RetailSaleDetails frm, int ShopID)
        {
            InitializeComponent();
            sd = frm;
            UniqueShopID = ShopID;
        }

        CustomerClass cc = new CustomerClass();

        private void CustomerDetails_Load(object sender, EventArgs e)
        {

            if (UniqueShopID == 13)
            {
                txtCity.Text = "NOIDA";
                txtCountry.Text = "INDIA";
                txtPinCode.Text = "201309";
                txtState.Text = "UP";
                txtstatecode.Text = "09";
            }

            Formload();
            BindDataGridview();
            lblId.Visible = false;
            BindGender();
            BindMaritalStatus();
            BindZone();
            BindCustomerType();
            //CountCustomer();
        }


        private void CountCustomer()
        {
            DTCUST = cc.CountRecords(UniqueShopID).Tables[0];
            lblCountCust.Text = DTCUST.Rows[0]["TotalCustomer"].ToString();
        }

        private void Formload()
        {
            txtCustomername.Enabled = false;
            cmbGender.Enabled = false;
            txtCity.Enabled = false;
            txtState.Enabled = false;
            txtCountry.Enabled = false;
            txtContact.Enabled = false;
            txtEmail.Enabled = false;
            txtPinCode.Enabled = false;
            cmbMaritalStatus.Enabled = false;
            TxtAnniversary.Enabled = false;
            TxtDOB.Enabled = false;
            txtAltContact.Enabled = false;
            txtAddress.Enabled = false;
            txtDescription.Enabled = false;
            chkIsActive.Enabled = false;

            btnAddnew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;
        }
        private void AddNewButtonClick()
        {

            txtCountry.Text = "India";
            txtCustomername.Enabled = true;
            cmbGender.Enabled = true;
            txtCity.Enabled = true;
            txtState.Enabled = true;
            txtCountry.Enabled = true;
            txtContact.Enabled = true;
            txtEmail.Enabled = true;
            txtPinCode.Enabled = true;
            cmbMaritalStatus.Enabled = true;
            TxtAnniversary.Enabled = true;
            TxtDOB.Enabled = true;
            txtAltContact.Enabled = true;
            txtAddress.Enabled = true;
            txtDescription.Enabled = true;
            chkIsActive.Enabled = true;


            txtCustomername.Text = string.Empty;
            cmbGender.SelectedIndex = 0;
            txtCity.Text = string.Empty; ;
            txtState.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPinCode.Text = string.Empty;
            cmbMaritalStatus.SelectedIndex = 0;
            TxtAnniversary.Text = string.Empty;
            TxtDOB.Text = string.Empty;
            txtAltContact.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsActive.Checked = true;

            txtstatecode.Enabled = true;
            txtShippingAdd.Enabled = true;
            txtShippingCity.Enabled = true;
            txtShippingcountry.Enabled = true;
            txtShippingpincode.Enabled = true;
            txtShippingState.Enabled = true;
            txtShippingStatecode.Enabled = true;

            btnAddnew.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;
        }

        private void SaveButtonClick()
        {

            txtCustomername.Text = string.Empty;
            cmbGender.SelectedIndex = 0;
            txtCity.Text = string.Empty; ;
            txtState.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPinCode.Text = string.Empty;
            cmbMaritalStatus.SelectedIndex = 0;
            TxtAnniversary.Text = string.Empty;
            TxtDOB.Text = string.Empty;
            txtAltContact.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsActive.Checked = true;
            chkIsActive.Checked = false;

            txtCustomername.Enabled = false;
            cmbGender.Enabled = false;
            txtCity.Enabled = false;
            txtState.Enabled = false;
            txtCountry.Enabled = false;
            txtContact.Enabled = false;
            txtEmail.Enabled = false;
            txtPinCode.Enabled = false;
            cmbMaritalStatus.Enabled = false;
            TxtAnniversary.Enabled = false;
            TxtDOB.Enabled = false;
            txtAltContact.Enabled = false;
            txtAddress.Enabled = false;
            txtDescription.Enabled = false;
            chkIsActive.Enabled = false;

            txtstatecode.Enabled = false;
            txtShippingAdd.Enabled = false;
            txtShippingCity.Enabled = false;
            txtShippingcountry.Enabled = false;
            txtShippingpincode.Enabled = false;
            txtShippingState.Enabled = false;
            txtShippingStatecode.Enabled = false;


            btnAddnew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;
        }

        private void DeleteButtonClick()
        {
            txtCustomername.Text = string.Empty;
            cmbGender.SelectedIndex = 0;
            txtCity.Text = string.Empty; ;
            txtState.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPinCode.Text = string.Empty;
            cmbMaritalStatus.SelectedIndex = 0;
            TxtAnniversary.Text = string.Empty;
            TxtDOB.Text = string.Empty;
            txtAltContact.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsActive.Checked = false;

            chkIsActive.Checked = false;

            txtCustomername.Enabled = false;
            cmbGender.Enabled = false;
            txtCity.Enabled = false;
            txtState.Enabled = false;
            txtCountry.Enabled = false;
            txtContact.Enabled = false;
            txtEmail.Enabled = false;
            txtPinCode.Enabled = false;
            cmbMaritalStatus.Enabled = false;
            TxtAnniversary.Enabled = false;
            TxtDOB.Enabled = false;
            txtAltContact.Enabled = false;
            txtAddress.Enabled = false;
            txtDescription.Enabled = false;
            chkIsActive.Enabled = false;

            txtstatecode.Enabled = false;
            txtShippingAdd.Enabled = false;
            txtShippingCity.Enabled = false;
            txtShippingcountry.Enabled = false;
            txtShippingpincode.Enabled = false;
            txtShippingState.Enabled = false;
            txtShippingStatecode.Enabled = false;


            btnAddnew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;

        }

        private void ResetButtonClick()
        {
            txtCustomername.Text = string.Empty;
            cmbGender.SelectedIndex = 0;
            txtCity.Text = string.Empty; ;
            txtState.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPinCode.Text = string.Empty;
            cmbMaritalStatus.SelectedIndex = 0;
            TxtAnniversary.Text = string.Empty;
            TxtDOB.Text = string.Empty;
            txtAltContact.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsActive.Checked = false;

            txtgstin.Text = string.Empty;

            cmbMaritalStatus.SelectedIndex = 0;
            txtCustomername.Enabled = false;
            cmbGender.Enabled = false;
            txtCity.Enabled = false;
            txtState.Enabled = false;
            txtCountry.Enabled = false;
            txtContact.Enabled = false;
            txtEmail.Enabled = false;
            txtPinCode.Enabled = false;
            cmbMaritalStatus.Enabled = false;
            TxtAnniversary.Enabled = false;
            TxtDOB.Enabled = false;
            txtAltContact.Enabled = false;
            txtAddress.Enabled = false;
            txtDescription.Enabled = false;
            chkIsActive.Enabled = false;
            txtstatecode.Enabled = false;
            txtShippingAdd.Enabled = false;
            txtShippingCity.Enabled = false;
            txtShippingcountry.Enabled = false;
            txtShippingpincode.Enabled = false;
            txtShippingState.Enabled = false;
            txtShippingStatecode.Enabled = false;

            txtstatecode.Text = string.Empty;
            txtShippingAdd.Text = string.Empty;
            txtShippingCity.Text = string.Empty;
            txtShippingcountry.Text = string.Empty;
            txtShippingpincode.Text = string.Empty;
            txtShippingState.Text = string.Empty;
            txtShippingStatecode.Text = string.Empty;
            CmbZone.SelectedValue = "0";
            cmbCustType.SelectedValue = "0";
            checkBox1.Checked = false;

            btnAddnew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;
        }

        private void SameAsAbove(bool IsTrue)
        {
            if (IsTrue)
            {
                txtShippingAdd.Text = txtAddress.Text;
                txtShippingCity.Text = txtCity.Text;
                txtShippingcountry.Text = txtCountry.Text;
                txtShippingpincode.Text = txtPinCode.Text;
                txtShippingState.Text = txtState.Text;
                txtShippingStatecode.Text = txtstatecode.Text;

                txtShippingAdd.Enabled = true;
                txtShippingCity.Enabled = true;
                txtShippingcountry.Enabled = true;
                txtShippingpincode.Enabled = true;
                txtShippingState.Enabled = true;
                txtShippingStatecode.Enabled = true;
            }
            else
            {
                txtShippingAdd.Text = string.Empty;
                txtShippingCity.Text = string.Empty;
                txtShippingcountry.Text = string.Empty;
                txtShippingpincode.Text = string.Empty;
                txtShippingState.Text = string.Empty;
                txtShippingStatecode.Text = string.Empty;

                txtShippingAdd.Enabled = true;
                txtShippingCity.Enabled = true;
                txtShippingcountry.Enabled = true;
                txtShippingpincode.Enabled = true;
                txtShippingState.Enabled = true;
                txtShippingStatecode.Enabled = true;
            }

        }

        private void DataGridviewCellClick()
        {
            CmbZone.SelectedValue = "0";
            txtCustomername.Enabled = true;
            cmbGender.Enabled = true;
            txtCity.Enabled = true;
            txtState.Enabled = true;
            txtCountry.Enabled = true;
            txtContact.Enabled = true;
            txtEmail.Enabled = true;
            txtPinCode.Enabled = true;
            cmbMaritalStatus.Enabled = true;
            TxtAnniversary.Enabled = true;
            TxtDOB.Enabled = true;
            txtAltContact.Enabled = true;
            txtAddress.Enabled = true;
            txtDescription.Enabled = true;
            chkIsActive.Enabled = true;
            txtstatecode.Enabled = true;
            txtShippingAdd.Enabled = true;
            txtShippingCity.Enabled = true;
            txtShippingcountry.Enabled = true;
            txtShippingpincode.Enabled = true;
            txtShippingState.Enabled = true;
            txtShippingStatecode.Enabled = true;
            checkBox1.Checked = false;


            btnAddnew.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            btnReset.Enabled = true;
            btnClose.Enabled = true;
            CmbZone.Enabled = true;
        }

        private bool CheckIsExist(string Contact, string CustName, int Customerid = 0)
        {
            CustomerClass pc = new CustomerClass();
            DataView dv = new DataView(pc.BindCustomers(UniqueShopID).Tables[0]);
            if (Customerid == 0)
                dv.RowFilter = "Contact = '" + Contact + "' and Customername = '" + CustName + "'";
            else
                dv.RowFilter = "Contact = '" + Contact + "' and Customername = '" + CustName + "' and CustomerID <> '" + Customerid + "'";

            if (dv.ToTable().Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCustomername.Text == string.Empty)
            {
                MessageBox.Show(this, "Please Fill Customer Name", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            else if (txtContact.Text == string.Empty)
            {
                MessageBox.Show(this, "Please Fill Contact Number", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            else if (CheckIsExist(txtContact.Text, txtCustomername.Text, Convert.ToInt32(lblId.Text == string.Empty ? "0" : lblId.Text)))
            {
                MessageBox.Show(this, "Customer Already Exist.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                CustomerClassBe be = new CustomerClassBe();
                be.CustomerId = Convert.ToInt32(lblId.Text == string.Empty ? "0" : lblId.Text);
                be.CustomerName = txtCustomername.Text;
                be.Gender = Convert.ToInt32(cmbGender.SelectedValue);
                be.City = txtCity.Text;
                be.State = txtState.Text;
                be.StateCode = txtstatecode.Text;
                be.Country = txtCountry.Text;
                be.Pincode = txtPinCode.Text;
                be.Emailid = txtEmail.Text;
                be.Contact = txtContact.Text;
                be.AltContact = txtAltContact.Text;
                be.Address = txtAddress.Text;
                be.Descriptions = txtDescription.Text;
                be.Birthdate = TxtDOB.Text.Trim() == "/  /" ? (DateTime?)null: Convert.ToDateTime(TxtDOB.Text);
                be.Aniversarydate = TxtAnniversary.Text.Trim() == "/  /" ? (DateTime?)null : Convert.ToDateTime(TxtAnniversary.Text);
                be.IsActive = Convert.ToInt32(chkIsActive.Checked);
                be.ShopID = UniqueShopID;
                be.MaritalStatus = Convert.ToInt32(cmbMaritalStatus.SelectedValue);
                be.SameAsBilling = checkBox1.Checked;
                be.ShippingAddress = txtShippingAdd.Text;
                be.ShippingCity = txtShippingCity.Text;
                be.ShippingState = txtShippingState.Text;
                be.ShippingStateCode = txtShippingStatecode.Text;
                be.ShippingPincode = txtShippingpincode.Text;
                be.ShippingCountry = txtShippingcountry.Text;
                be.ZoneID = Convert.ToInt32(CmbZone.SelectedValue);
                be.CustomerType = Convert.ToInt32(cmbCustType.SelectedValue);
                be.GSTIN = txtgstin.Text;
                
                CustomerClass catclass = new CustomerClass();
                catclass.InsertUpdateCustomer(be);

                if (MessageBox.Show("Do You Want To Save Record?", "Customer Master", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (lblId.Text == "0")
                    {
                        MessageBox.Show(this, "Record Saved Successfully.", "Customer Master", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SaveButtonClick();
                        if (sd != null)
                        {
                            sd.RefreshCustomerOnSales(be.CustomerId);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Record Updated Successfully.", "Customer Master", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SaveButtonClick();
                        if (sd != null)
                        {
                            sd.RefreshCustomerOnSales(be.CustomerId);
                            this.Close();
                        }
                    }
                }


                BindDataGridview();
                SaveButtonClick();
                ResetButtonClick();
            }
        }



        private void BindDataGridview()
        {
            DTCUST = cc.BindCustomers(UniqueShopID).Tables[0];
            dataGridViewCustomer.DataSource = DTCUST;
            lblCountCust.Text = dataGridViewCustomer.Rows.Count.ToString();
            lblSearchRecords.Text = "0";
        }

        public decimal ProductQuantity
        {
            get
            {
                if (txtAltContact.Text != string.Empty)
                {
                    return Convert.ToDecimal(txtAltContact.Text);
                }
                else
                {
                    return decimal.Zero;
                }
            }
            set
            {
                txtAltContact.Text = value.ToString();
            }
        }

        private void btnAddnew_Click(object sender, EventArgs e)
        {

            ResetButtonClick();
            int id = 0;
            lblId.Text = "" + id;
            AddNewButtonClick();
            txtCountry.Text = "India";

            if (UniqueShopID == 13)
            {
                txtCity.Text = "NOIDA";
                txtCountry.Text = "INDIA";
                txtPinCode.Text = "201309";
                txtState.Text = "UP";
                txtstatecode.Text = "09";
            }

            txtCustomername.Focus();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Record?", "Confirm deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(lblId.Text))
                {
                    CustomerClassBe be = new CustomerClassBe();
                    be.CustomerId = Convert.ToInt32(lblId.Text);
                    cc.DeleteCustomer(be);
                    MessageBox.Show("Successfully deleted the Record. ", "Sucessful deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindDataGridview();
                    DeleteButtonClick();
                    ResetButtonClick();
                    // ClearData();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetButtonClick();
            //if (!string.IsNullOrEmpty(lblId.Text))
            //{
            //    CustomerClassBe be = new CustomerClassBe();
            //    be.CustomerId = Convert.ToInt32(lblId.Text);
            //    cc.BindTextBoxCustomer(be);
            //    BindDataGridview();
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewCustomer_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridviewCellClick();
            if (e.RowIndex < 0)
                return;
            lblId.Text = dataGridViewCustomer.Rows[e.RowIndex].Cells["Customerid"].Value.ToString();
            txtCustomername.Text = dataGridViewCustomer.Rows[e.RowIndex].Cells["Customername"].Value.ToString();
            txtCity.Text = dataGridViewCustomer.Rows[e.RowIndex].Cells["city"].Value.ToString();
            txtState.Text = dataGridViewCustomer.Rows[e.RowIndex].Cells["States"].Value.ToString();
            txtCountry.Text = dataGridViewCustomer.Rows[e.RowIndex].Cells["country"].Value.ToString();
            txtPinCode.Text = dataGridViewCustomer.Rows[e.RowIndex].Cells["pincode"].Value.ToString();
            txtContact.Text = dataGridViewCustomer.Rows[e.RowIndex].Cells["Contact"].Value.ToString();
            if (!string.IsNullOrEmpty(dataGridViewCustomer.Rows[e.RowIndex].Cells["AniversaryDate"].Value.ToString()))
                TxtAnniversary.Text = Convert.ToDateTime(dataGridViewCustomer.Rows[e.RowIndex].Cells["AniversaryDate"].Value.ToString()).ToString("dd/MM/yyyy");
            if (!string.IsNullOrEmpty(dataGridViewCustomer.Rows[e.RowIndex].Cells["BirthDate"].Value.ToString()))
                TxtDOB.Text = Convert.ToDateTime(dataGridViewCustomer.Rows[e.RowIndex].Cells["BirthDate"].Value.ToString()).ToString("dd/MM/yyyy");
            txtEmail.Text = dataGridViewCustomer.Rows[e.RowIndex].Cells["Emailid"].Value.ToString();
            txtAltContact.Text = dataGridViewCustomer.Rows[e.RowIndex].Cells["GSTIN"].Value.ToString();
            if (dataGridViewCustomer.Rows[e.RowIndex].Cells["MaritalStatus"].Value.ToString() != string.Empty)
                cmbMaritalStatus.SelectedValue = dataGridViewCustomer.Rows[e.RowIndex].Cells["MaritalStatus"].Value.ToString();
            if (dataGridViewCustomer.Rows[e.RowIndex].Cells["Gender"].Value.ToString() != string.Empty)
                cmbGender.SelectedValue = Convert.ToString(dataGridViewCustomer.Rows[e.RowIndex].Cells["Gender"].Value);
            txtAddress.Text = dataGridViewCustomer.Rows[e.RowIndex].Cells["Address"].Value.ToString();
            txtDescription.Text = dataGridViewCustomer.Rows[e.RowIndex].Cells["Descriptions"].Value.ToString();
            chkIsActive.Checked = Convert.ToBoolean(dataGridViewCustomer.Rows[e.RowIndex].Cells["IsActive"].Value);
            txtstatecode.Text = dataGridViewCustomer.Rows[e.RowIndex].Cells["StateCode"].Value.ToString();
            txtShippingAdd.Text = dataGridViewCustomer.Rows[e.RowIndex].Cells["ShippingAddress"].Value.ToString();
            txtShippingCity.Text = dataGridViewCustomer.Rows[e.RowIndex].Cells["ShippingCity"].Value.ToString();
            txtShippingState.Text = dataGridViewCustomer.Rows[e.RowIndex].Cells["ShippingState"].Value.ToString();
            txtShippingStatecode.Text = dataGridViewCustomer.Rows[e.RowIndex].Cells["ShippingStateCode"].Value.ToString();
            txtShippingpincode.Text = dataGridViewCustomer.Rows[e.RowIndex].Cells["ShippingPinCode"].Value.ToString();
            txtShippingcountry.Text = dataGridViewCustomer.Rows[e.RowIndex].Cells["ShippingCountry"].Value.ToString();
            checkBox1.Checked = Convert.ToBoolean(dataGridViewCustomer.Rows[e.RowIndex].Cells["SameAsBilling"].Value);
            if (dataGridViewCustomer.Rows[e.RowIndex].Cells["ZoneID"].Value.ToString() != string.Empty)
                CmbZone.SelectedValue = Convert.ToString(dataGridViewCustomer.Rows[e.RowIndex].Cells["ZoneID"].Value);
            if (dataGridViewCustomer.Rows[e.RowIndex].Cells["typeid"].Value.ToString() != string.Empty)
                cmbCustType.SelectedValue = Convert.ToString(dataGridViewCustomer.Rows[e.RowIndex].Cells["typeid"].Value);
            txtgstin.Text = dataGridViewCustomer.Rows[e.RowIndex].Cells["gstin1"].Value.ToString();

        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAltContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAltContact_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPinCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            if (txtEmail.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                if (!mRegxExpression.IsMatch(txtEmail.Text.Trim()))
                {

                    MessageBox.Show("E-mail address format is not correct.", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtEmail.Focus();

                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                CustomerClass cc = new CustomerClass();
                DTCUST = cc.BindCustomers(UniqueShopID).Tables[0];
                DataView dv = new DataView(DTCUST);
                dv.RowFilter = "Customername like '%" + txtSearch.Text + "%' or contact like '%" + txtSearch.Text + "%' or Address like '%" + txtSearch.Text + "%' ";
                dataGridViewCustomer.DataSource = dv;
                lblSearchRecords.Text = dataGridViewCustomer.Rows.Count.ToString();
            }
            else
            {
                BindDataGridview();
            }

           

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }


        private void BindGender()
        {
            EnquiryClass ec = new EnquiryClass();
            DataTable dt = new DataTable();
            dt = ec.BindGender().Tables[0];
            dt.Rows.Add("0", "Select");
            DataView dv = new DataView(dt);
            dv.Sort = "Genderid asc";
            cmbGender.DataSource = dv.ToTable();
            cmbGender.ValueMember = "Genderid";
            cmbGender.DisplayMember = "Gendername";
        }

        private void BindZone()
        {
            EnquiryClass ec = new EnquiryClass();
            DataTable dt = new DataTable();
            dt = ec.BindZone(UniqueShopID).Tables[0];
            //dt.Rows.Add("0", "Select");
            DataView dv = new DataView(dt);
            dv.Sort = "ZoneID asc";
            CmbZone.DataSource = dv.ToTable();
            CmbZone.ValueMember = "ZoneID";
            CmbZone.DisplayMember = "Zone";
        }


        private void BindCustomerType()
        {
            EnquiryClass ec = new EnquiryClass();
            DataTable dt = new DataTable();
            dt = ec.BindCustomerType().Tables[0];
            dt.Rows.Add("0", "Select");
            DataView dv = new DataView(dt);
            dv.Sort = "Typeid asc";
            cmbCustType.DataSource = dv.ToTable();
            cmbCustType.ValueMember = "Typeid";
            cmbCustType.DisplayMember = "Typename";
        }

        private void BindMaritalStatus()
        {
            EnquiryClass ec = new EnquiryClass();
            DataTable dt = new DataTable();
            dt = ec.BindMaritalStatus().Tables[0];
            dt.Rows.Add("0", "Select");
            DataView dv = new DataView(dt);
            dv.Sort = "MaritalStatusid asc";
            cmbMaritalStatus.DataSource = dv.ToTable();
            cmbMaritalStatus.ValueMember = "MaritalStatusid";
            cmbMaritalStatus.DisplayMember = "MaritalStatusname";
        }

        private void cmbMaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaritalStatus.SelectedIndex == 2)
            {
                TxtAnniversary.Enabled = true;
            }
            else
            {
                TxtAnniversary.Text = string.Empty;
                TxtAnniversary.Enabled = false;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerAnivarsary_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SameAsAbove(checkBox1.Checked);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblId.Text))
            {
                EnquiryClass cl = new EnquiryClass();
                int i = cl.SendUserCredential(Convert.ToInt32(lblId.Text));
                BindDataGridview();
                if (i > 0)
                {
                    MessageBox.Show("User Credential succssfully sent to customer registered mobile no. ", "Sucessful Delivered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("User Credential not sent to customer registered mobile no. ", "UNdelivered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
            else
            {
                MessageBox.Show("Double click the customer to whom you want to send User Details", "Customer Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            CustomerClass cc = new CustomerClass();
            DTCUST = cc.BindCustomers(UniqueShopID).Tables[0];
            DataView dv = new DataView(DTCUST);
            dv.RowFilter = "Customername like '%" + txtSearch.Text + "%' or contact like '%" + txtSearch.Text + "%' or Address like '%" + txtSearch.Text + "%' ";
            dataGridViewCustomer.DataSource = dv;

            Report.Customerrpt custrpt = new Report.Customerrpt(dv);
            custrpt.ShowDialog();
        }
    }
}

