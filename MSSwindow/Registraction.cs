using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using MSSwindow.CommonClass;


using System.Text.RegularExpressions;


namespace MSSwindow
{
    public partial class Registraction : Form
    {
       
        public readonly int UniqueShopID = 0;
        public int Memberid = 0;
       
        public Registraction(MainForm  Admn)
        {
            InitializeComponent();
            UniqueShopID = Admn.Shopid;
        }

        public Registraction(int memberid, int SHOPID)
        {
            InitializeComponent();
            Memberid = memberid;
            UniqueShopID = SHOPID;
           
        }
        private void Generateid()
        {
            int memberid = 0;
            RegistractionClass rc = new RegistractionClass();
            DataTable dt = new DataTable();
            dt = rc.GenerateMemberShipid(UniqueShopID).Tables[0];
            txtMembershipid.Text = dt.Rows[0]["Memberid"].ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BindDataGridviewEmployee()
        {
            RegistractionClass rc = new RegistractionClass();
            
            dataGridViewEmployee.DataSource =rc.BindMemberDetails(UniqueShopID,string.Empty).Tables[0];
        }
        private void BindviewEmployee(int ? MemberID = 0)
        {
            RegistractionClass rc = new RegistractionClass();
            DataTable DTEMP = new DataTable();
            DTEMP = rc.ShowMemberDetails(UniqueShopID, string.Empty, MemberID).Tables[0];
            Memberid = (int)MemberID;
            txtMembershipid.Text = DTEMP.Rows[0]["EmployeeID"].ToString();
            txtFirstname.Text = DTEMP.Rows[0]["Firstname"].ToString();
            txtLastname.Text = DTEMP.Rows[0]["Lastname"].ToString();
            dateTimeAdmissionDate.Value = Convert.ToDateTime(DTEMP.Rows[0]["Admissiondate"].ToString());
            dateTimePickerDateOfBirht.Value = Convert.ToDateTime(DTEMP.Rows[0]["DateofBirth"].ToString());
            txtContact.Text = DTEMP.Rows[0]["Contact"].ToString();
            txtEmail.Text = DTEMP.Rows[0]["Email"].ToString();
            txtContact.Text = DTEMP.Rows[0]["Contact"].ToString();
            cmbGender.SelectedValue = DTEMP.Rows[0]["Gender"].ToString();
            cmbProofgiven.SelectedValue = DTEMP.Rows[0]["ProofGiven"].ToString();
            txtProofdetails.Text = DTEMP.Rows[0]["ProofDetails"].ToString();
            txtSalary.Text = DTEMP.Rows[0]["Salary"].ToString();
            txtAddress.Text = DTEMP.Rows[0]["Address"].ToString();
            CmbRole.Text = DTEMP.Rows[0]["Role"].ToString();
            TxtUserID.Text= DTEMP.Rows[0]["UserID"].ToString();
            TxtPwd.Text = DTEMP.Rows[0]["Password"].ToString();
            TxtConfPwd.Text = DTEMP.Rows[0]["Password"].ToString();

        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtFirstname.Text == string.Empty)
            {
                MessageBox.Show(this, "Please enter first name.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstname.Focus();
            }
            else if (txtContact.Text == string.Empty)
            {
                MessageBox.Show(this, "Please enter contact number.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContact.Focus();
            }
            else if (CandGender == 0)
            {
                MessageBox.Show(this, "Please select gender.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGender.Focus();
            }
            else if (CandProof == 0)
            {
                MessageBox.Show(this, "Please select ID Proof.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProofgiven.Focus();
            }
            else if (CmbRole.Text == string.Empty)
            {
                MessageBox.Show(this, "Please select Role.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProofgiven.Focus();
            }
            else
            {
                RegistarctionClassBe be = new RegistarctionClassBe();
                be.Shopid = Convert.ToInt32(UniqueShopID);
                be.membershipid = Memberid;
                be.memberid = txtMembershipid.Text;
                be.AdmissionDate = Convert.ToDateTime(dateTimeAdmissionDate.Value.ToString());
                be.Firstname = txtFirstname.Text;
                be.Lastname = txtLastname.Text;
                be.Contact = txtContact.Text;
                be.Email = txtEmail.Text;
                be.Gender = CandGender;
                be.DateofBirth = Convert.ToDateTime(dateTimePickerDateOfBirht.Value.ToString());
                be.ProofGiven = Convert.ToInt32(cmbProofgiven.SelectedValue);
                be.ProofDetails = txtProofdetails.Text;
                be.Salary = CandSalaryAmount;
                be.Address = txtAddress.Text;
                be.Role = CmbRole.Text;
                be.Userid = TxtUserID.Text;
                be.NewPassword = TxtPwd.Text;
                RegistractionClass rc = new RegistractionClass();
                if (MessageBox.Show("Do You Want To Save Record?", "MSS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int i = rc.InsertUpdateMemberRegistraction(be);
                    if (i > 0)
                    {
                        MessageBox.Show(this, "Record Saved Successfully.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetControl();
                        Generateid();
                        BindDataGridviewEmployee();
                    }
                }

            }     
        }

        // public int Membershipid { get { return Membershipid; } }
        private void Registraction_Load(object sender, EventArgs e)
        {
            if (Memberid == 0)
            {
               BindGender();               
               BindProofDetails();
               Generateid();
               BindDataGridviewEmployee();
            }
            else
            {
                BindviewEmployee(Memberid);
              //  BindGender();
               // BindPlan();
               // BindProofDetails();
               // BindTextBoxValue();
            }
            // lblShopid.Text = "1";
            // txtMembershipid.Text = "0";


        }





        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
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

        private void BindProofDetails()
        {
            PlanDetailsClass ec = new PlanDetailsClass();
            DataTable dt = new DataTable();
            dt = ec.BindProofDetails().Tables[0];
            dt.Rows.Add("0", "Select");
            DataView dv = new DataView(dt);
            dv.Sort = "Proofid asc";
            cmbProofgiven.DataSource = dv.ToTable();
            cmbProofgiven.ValueMember = "Proofid";
            cmbProofgiven.DisplayMember = "Proofname";
        }

       


        private void btnUpload_Click_1(object sender, EventArgs e)
        {

        }

        private void ResetControl()
        {
            txtMembershipid.Text = string.Empty;
            txtFirstname.Text = string.Empty;
            txtLastname.Text = string.Empty;
            txtAddress.Text = string.Empty;
     
           
            txtContact.Text = string.Empty;
          
            txtEmail.Text = string.Empty;
           
            txtProofdetails.Text = string.Empty;
           
            cmbGender.SelectedIndex = 0;
          
            cmbProofgiven.SelectedIndex = 0;
            TxtUserID.Text = string.Empty;
            TxtPwd.Text = string.Empty;
            TxtConfPwd.Text = string.Empty;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        #region ControlProperty
      


      
       

        public int CandGender
        {
            get
            {
                if (cmbGender.SelectedValue == string.Empty)
                    return 0;
                else
                    return Convert.ToInt32(cmbGender.SelectedValue);
            }
            set
            {
                cmbGender.SelectedValue = value.ToString();
            }
        }


        public int CandProof
        {
            get
            {
                if (cmbProofgiven.SelectedValue == string.Empty)
                    return 0;
                else
                    return Convert.ToInt32(cmbProofgiven.SelectedValue);
            }
            set
            {
                cmbProofgiven.SelectedValue = value.ToString();
            }
        }
        
        public int CandSalaryAmount
        {
            get
            {
                if (txtSalary.Text == string.Empty)
                    return 0;
                else
                    return Convert.ToInt32(txtSalary.Text);
            }
            set
            {
                txtSalary.Text = value.ToString();
            }
        }
        #endregion
        private void btnsave_Click_1(object sender, EventArgs e)
        {
            // if (MessageBox.Show("Do You Want To Save Record?", "MSS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            // {
            if (txtMembershipid.Text == string.Empty)
            {
                MessageBox.Show(this, "Please enter Member id.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMembershipid.Focus();
            }
            else if (txtFirstname.Text == string.Empty)
            {
                MessageBox.Show(this, "Please enter first name.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstname.Focus();
            }
            else if (txtContact.Text == string.Empty)
            {
                MessageBox.Show(this, "Please enter contact number.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContact.Focus();
            }
            else if (CandGender == 0)
            {
                MessageBox.Show(this, "Please select gender.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGender.Focus();
            }           
            else if (CandProof == 0)
            {
                MessageBox.Show(this, "Please select ID Proof.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProofgiven.Focus();
            }
            else
            {
                RegistarctionClassBe be = new RegistarctionClassBe();
                be.Shopid = Convert.ToInt32(UniqueShopID);
                be.membershipid = Convert.ToInt32(txtMembershipid.Text);
                be.AdmissionDate = Convert.ToDateTime(dateTimeAdmissionDate.Value.ToString()); 
                be.Firstname = txtFirstname.Text;
                be.Lastname = txtLastname.Text;
                be.Contact = txtContact.Text;
                be.Email = txtEmail.Text;
                be.Gender = CandGender;              
                be.DateofBirth = Convert.ToDateTime(dateTimePickerDateOfBirht.Value.ToString());               
                be.ProofGiven = Convert.ToInt32(cmbProofgiven.SelectedValue);
                be.ProofDetails = txtProofdetails.Text;               
                be.Salary = CandSalaryAmount;
                be.Address = txtAddress.Text;
                RegistractionClass rc = new RegistractionClass();
                if (MessageBox.Show("Do You Want To Save Record?", "MSS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int i = rc.InsertUpdateMemberRegistraction(be);
                    if (i > 0)
                    {
                        MessageBox.Show(this, "Record Saved Successfully.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetControl();                       
                    }
                }

            }          
        }

        private void BindTextBoxValue()
        {
            RegistarctionClassBe be = new RegistarctionClassBe();
            RegistractionClass rc = new RegistractionClass();
            DataTable dt = new DataTable();
            be.membershipid = Memberid;
            be.Shopid = UniqueShopID;
            dt = rc.BindTextboxValues(be);
            txtMembershipid.Text = dt.Rows[0]["Memberid"].ToString();           
            txtFirstname.Text = dt.Rows[0]["Firstname"].ToString();
            txtLastname.Text = dt.Rows[0]["Lastname"].ToString();
            txtContact.Text = dt.Rows[0]["Contact"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            cmbGender.SelectedValue = dt.Rows[0]["Gender"].ToString();
            dateTimePickerDateOfBirht.Value = Convert.ToDateTime(dt.Rows[0]["DateofBirth"]);           
            cmbProofgiven.SelectedValue = dt.Rows[0]["ProofGiven"].ToString();
            txtProofdetails.Text = dt.Rows[0]["ProofDetails"].ToString();         
            txtAddress.Text = dt.Rows[0]["Address"].ToString();          

        }

        private void cmbplan_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegistractionClass reg = new RegistractionClass();
            RegistarctionClassBe be = new RegistarctionClassBe();

            DataTable ds = new DataTable();           
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            if (txtEmail.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                if (!mRegxExpression.IsMatch(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("E-mail address format is not correct.", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                }
            }
        }

        private void txtMembershipid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            } 
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {                
                e.Handled = true;
            } 
        }

        private void txtPlanprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            } 
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtFirstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtLastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtPaidAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtContact_Leave(object sender, EventArgs e)
        {
                      
        }

        private void txtMembershipid_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // int Shopid = Convert.ToInt32(dataGridViewEmployee.Rows[e.RowIndex].Cells["Shopid"].Value.ToString());
                if (e.RowIndex < 0)
                    return;
               Memberid= Convert.ToInt32 (dataGridViewEmployee.Rows[e.RowIndex].Cells["memid"].Value.ToString());
               BindviewEmployee(Memberid);
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtContact_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


    }
}
