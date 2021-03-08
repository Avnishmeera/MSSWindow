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

namespace MSSwindow
{
    public partial class SupplierDetails : Form
    {
        public readonly int UniqueShopID = 0;
        RetailPurchaseDetails PDL = null;
        FrmAddStock PDLStock = null;
        public SupplierDetails(int ShopID)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
        }


        public SupplierDetails(RetailPurchaseDetails PUR, int ShopID)
        {
            InitializeComponent();
            PDL = PUR;
            UniqueShopID = ShopID;

        }

        public SupplierDetails(FrmAddStock PUR, int ShopID)
        {
            InitializeComponent();
            PDLStock = PUR;
            UniqueShopID = ShopID;

        }

        private void Formload()
        {
            EnableDisable(false);
            btnAddnew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;

            if (UniqueShopID == 13)
            {
                txtCity.Text = "NOIDA";
                txtCountry.Text = "INDIA";
                txtPinCode.Text = "201309";
                txtState.Text = "UP";
               
            }

        }
        private void EnableDisable(bool Flag)
        {
            txtSuppliername.Enabled = Flag;
            txtCity.Enabled = Flag;
            txtState.Enabled = Flag;
            txtCountry.Enabled = Flag;
            txtPinCode.Enabled = Flag;
            txtEmail.Enabled = Flag;
            txtContact.Enabled = Flag;
            txtAltContact.Enabled = Flag;
            txtAddress.Enabled = Flag;
            txtDescription.Enabled = Flag;
            chkIsActive.Enabled = Flag;
        }

        private void cleardata()
        {
            txtSuppliername.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtState.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtPinCode.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtAltContact.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsActive.Checked = true;

        }

        private void AddNewButtonClick()
        {

            EnableDisable(true);


        }

        private void SaveButtonClick()
        {

            txtSuppliername.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtState.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtPinCode.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtAltContact.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsActive.Checked = false;
            txtSuppliername.Enabled = false;
            txtCity.Enabled = false;
            txtState.Enabled = false;
            txtCountry.Enabled = false;
            txtPinCode.Enabled = false;
            txtEmail.Enabled = false;
            txtContact.Enabled = false;
            txtAltContact.Enabled = false;
            txtAddress.Enabled = false;
            txtDescription.Enabled = false;
            chkIsActive.Enabled = false;

            Helper.AddNew(btnAddnew, btnSave, btnDelete, btnReset, btnClose);
        }
        private void DeleteButtonClick()
        {
            txtSuppliername.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtState.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtPinCode.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtAltContact.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsActive.Checked = false;

            txtSuppliername.Enabled = false;
            txtCity.Enabled = false;
            txtState.Enabled = false;
            txtCountry.Enabled = false;
            txtPinCode.Enabled = false;
            txtEmail.Enabled = false;
            txtContact.Enabled = false;
            txtAltContact.Enabled = false;
            txtAddress.Enabled = false;
            txtDescription.Enabled = false;
            chkIsActive.Enabled = false;



        }
        private void ResetButtonClick()
        {
            txtSuppliername.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtState.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtPinCode.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtAltContact.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsActive.Checked = false;

            txtSuppliername.Enabled = false;
            txtCity.Enabled = false;
            txtState.Enabled = false;
            txtCountry.Enabled = false;
            txtPinCode.Enabled = false;
            txtEmail.Enabled = false;
            txtContact.Enabled = false;
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

        private void DataGridviewCellClick()
        {
            txtSuppliername.Enabled = true;
            txtCity.Enabled = true;
            txtState.Enabled = true;
            txtCountry.Enabled = true;
            txtPinCode.Enabled = true;
            txtEmail.Enabled = true;
            txtContact.Enabled = true;
            txtAltContact.Enabled = true;
            txtAddress.Enabled = true;
            txtDescription.Enabled = true;
            chkIsActive.Enabled = true;

            btnAddnew.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            btnReset.Enabled = true;
            btnClose.Enabled = true;
        }


        SupplierClass sup = new SupplierClass();
        private void Disabled()
        {
            txtSuppliername.Enabled = true;
            txtCity.Enabled = true;
            txtState.Enabled = true;
            txtCountry.Enabled = true;
            txtPinCode.Enabled = true;
            txtEmail.Enabled = true;
            txtContact.Enabled = true;
            txtAltContact.Enabled = true;
            txtAddress.Enabled = true;
            txtDescription.Enabled = true;
            chkIsActive.Checked = true;
        }

        private void Enableded()
        {
            txtSuppliername.Focus();
            txtSuppliername.Enabled = false;
            txtCity.Enabled = false;
            txtState.Enabled = false;
            txtCountry.Enabled = false;
            txtPinCode.Enabled = false;
            txtEmail.Enabled = false;
            txtContact.Enabled = false;
            txtAltContact.Enabled = false;
            txtAddress.Enabled = false;
            txtDescription.Enabled = false;
            chkIsActive.Checked = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnAddnew.Enabled = true;
            btnClose.Enabled = true;
        }

        private void BtnAddNewClick()
        {
            txtSuppliername.Focus();
            txtSuppliername.Enabled = true;
            txtCity.Enabled = true;
            txtState.Enabled = true;
            txtCountry.Enabled = true;
            txtPinCode.Enabled = true;
            txtEmail.Enabled = true;
            txtContact.Enabled = true;
            txtAltContact.Enabled = true;
            txtAddress.Enabled = true;
            txtDescription.Enabled = true;
            chkIsActive.Checked = true;

            btnAddnew.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnReset.Enabled = true;
            btnClose.Enabled = true;
        }

        private void BtnDatagridcellClick()
        {
            txtSuppliername.Enabled = true;
            txtCity.Enabled = true;
            txtState.Enabled = true;
            txtCountry.Enabled = true;
            txtPinCode.Enabled = true;
            txtEmail.Enabled = true;
            txtContact.Enabled = true;
            txtAltContact.Enabled = true;
            txtAddress.Enabled = true;
            txtDescription.Enabled = true;
            chkIsActive.Checked = true;

            btnAddnew.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            btnReset.Enabled = true;
            btnClose.Enabled = true;
        }
        private void ResetControl()
        {
            txtSuppliername.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtState.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtPinCode.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtAltContact.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtDescription.Text = string.Empty;

            txtSuppliername.Focus();
            txtSuppliername.Enabled = false;
            txtCity.Enabled = false;
            txtState.Enabled = false;
            txtCountry.Enabled = false;
            txtPinCode.Enabled = false;
            txtEmail.Enabled = false;
            txtContact.Enabled = false;
            txtAltContact.Enabled = false;
            txtAddress.Enabled = false;
            txtDescription.Enabled = false;
            chkIsActive.Checked = false;

            btnAddnew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;

        }

        private void BindGridSupplierMaster()
        {
            dataGridViewSupplier.DataSource = sup.BindSuppliers(UniqueShopID).Tables[0];
        }
        private void SupplierDetails_Load(object sender, EventArgs e)
        {
            Enableded();
            BindGridSupplierMaster();
            lblId.Visible = false;
        }

        private void btnAddnew_Click(object sender, EventArgs e)
        {
            BtnAddNewClick();
            //btnAddnew.Enabled = false;
            //btnSave.Enabled = true;
            //btnDelete.Enabled = false;
            //btnReset.Enabled = true;
            //btnClose.Enabled = true;

            // ResetControl();
            //  Disabled();
            int ID = 0;
            lblId.Text = "" + ID;


            if (UniqueShopID == 13)
            {
                txtCity.Text = "NOIDA";
                txtCountry.Text = "INDIA";
                txtPinCode.Text = "201309";
                txtState.Text = "UP";

            }

        }

        private void BtnEnabled()
        {
            btnAddnew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;
        }

        private void BtnDisabled()
        {
            btnAddnew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Save Record?", "Supplier Master", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtSuppliername.Text == string.Empty)
                {
                    MessageBox.Show(this, "Please Fill Supplier Name", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    txtSuppliername.Focus();
                    return;
                }
                else
                {
                    SupplierClassBe be = new SupplierClassBe();
                    be.SupplierId = Convert.ToInt32(lblId.Text);
                    be.SupplierName = txtSuppliername.Text;
                    be.City = txtCity.Text;
                    be.State = txtState.Text;
                    be.Country = txtCountry.Text;
                    be.Pincode = txtPinCode.Text;
                    be.Emailid = txtEmail.Text;
                    be.Contact = txtContact.Text;
                    be.AltContact = txtAltContact.Text;
                    be.Address = txtAddress.Text;
                    be.Descriptions = txtDescription.Text;
                    be.IsActive = Convert.ToInt32(chkIsActive.Checked);
                    be.Shopid = UniqueShopID;
                    sup.InsertUpdateSuppliers(be);
                    if (lblId.Text == "0")
                    {
                        MessageBox.Show(this, "Record Added Sucessfully.", "Supplier Master", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show(this, "Record Updated Sucessfully.", "Supplier Master", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    BindGridSupplierMaster();
                    if (PDL != null)
                        PDL.BindSupplierDropDown();
                    Enableded();
                    ResetControl();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblId.Text))
            {
                SupplierClass sup = new SupplierClass();
                SupplierClassBe be = new SupplierClassBe();
                be.SupplierId = Convert.ToInt32(lblId.Text);
                sup.DeleteSuppliers(be);
                BindGridSupplierMaster();
                ResetControl();
                Helper.Delete(btnAddnew, btnSave, btnDelete, btnReset, btnClose);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (PDL != null)
            {
                PDL.InitializeControl();
            }
            this.Close();
        }

        private void dataGridViewSupplier_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BtnDatagridcellClick();
            if (e.RowIndex < 0)
                return;
            lblId.Text = dataGridViewSupplier.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtSuppliername.Text = dataGridViewSupplier.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCity.Text = dataGridViewSupplier.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtState.Text = dataGridViewSupplier.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtCountry.Text = dataGridViewSupplier.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPinCode.Text = dataGridViewSupplier.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtEmail.Text = dataGridViewSupplier.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtContact.Text = dataGridViewSupplier.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtAltContact.Text = dataGridViewSupplier.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtAddress.Text = dataGridViewSupplier.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtDescription.Text = dataGridViewSupplier.Rows[e.RowIndex].Cells[10].Value.ToString();
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
