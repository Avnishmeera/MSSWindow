using MSSwindow.CommonClass;
using MSSwindow.Report;
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
    public partial class ComplaintForm : Form
    {
        DataSet dsCustDetail = new DataSet();
        int UniqueShopID = 0;
        string SelectedCustomerID = "0";
        int CompID = 0;
        bool IsNewCustomer = false;
        int CustomerStatus = 0;
        DataTable dtComplaintType = new DataTable();
        List<CustomerComplaint> CMPList = null;
        CustomerComplaint cmpl1 = null;
        Report.FrmSearchComplaint scomp = null;
        int HappyCode = 0;
        int CurComplaint = 0;
        public ComplaintForm(int ShopID, int Status)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
            CustomerClass CSL = new CustomerClass();
            dsCustDetail = CSL.SearchCustomers(UniqueShopID, TxtEmp.Text);
            mskStart.Text = DateTime.Now.ToString("HH:mm");
            mskEnd.Text = DateTime.Now.ToString("HH:mm");
            CustomerStatus = Status;
            button5.Visible = false;
        }
        public ComplaintForm(int ShopID, Report.FrmSearchComplaint scomp_local)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
            CustomerClass CSL = new CustomerClass();
            dsCustDetail = CSL.SearchCustomers(UniqueShopID, TxtEmp.Text);
            mskStart.Text = DateTime.Now.ToString("HH:mm");
            mskEnd.Text = DateTime.Now.ToString("HH:mm");
            scomp = scomp_local;
            button5.Visible = false;
        }
        public ComplaintForm(int ShopID)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
            CustomerClass CSL = new CustomerClass();
            dsCustDetail = CSL.SearchCustomers(UniqueShopID, TxtEmp.Text);
            mskStart.Text = DateTime.Now.ToString("HH:mm");
            mskEnd.Text = DateTime.Now.ToString("HH:mm");
            scomp = null;
            button5.Visible = false;
           
        }

        private void BindCategoryDropDown()
        {
            CategoryclassBe be = new CategoryclassBe();
            be.Shopid = UniqueShopID;
            CategoryClass catc = new CategoryClass();
            DataTable dt = new DataTable();
            dt.Columns.Add("Categoryid", typeof(System.Int32));
            dt.Columns.Add("Categoryname", typeof(System.String));
            dt = catc.BindDropDownCategory1(be);
            dt.Rows.Add(0, "----- Select -----");
            DataView dv = new DataView(dt);
            dv.Sort = "Categoryid";
            CmbCat.DataSource = dv.ToTable();
            CmbCat.DisplayMember = "Categoryname";
            CmbCat.ValueMember = "Categoryid";

            CmbCat_Next.DataSource = dv.ToTable();
            CmbCat_Next.DisplayMember = "Categoryname";
            CmbCat_Next.ValueMember = "Categoryid";
        }

        public ComplaintForm(CustomerComplaint cmpl, int ShopID, Report.FrmSearchComplaint scomp_local)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
            cmpl1 = cmpl;
            SetComplaintData(cmpl);
            scomp = scomp_local;
            button5.Visible = false;
        }

        public ComplaintForm(List<CustomerComplaint> cmpl, int ShopID, Report.FrmSearchComplaint scomp_local)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
            CMPList = cmpl;
            cmpl1 = cmpl.OrderByDescending(x => x.SeqNo).FirstOrDefault();
            CurComplaint = cmpl.OrderByDescending(x => x.SeqNo).FirstOrDefault().SeqNo;
            SetComplaintData(cmpl.OrderByDescending(x => x.SeqNo).FirstOrDefault());
            scomp = scomp_local;
            button5.Visible = true;
        }
        private void BindZone()
        {
            EnquiryClass ec = new EnquiryClass();
            DataTable dt = new DataTable();
            dt = ec.BindZone(UniqueShopID).Tables[0];
           // dt.Rows.Add("0", "Select");
            DataView dv = new DataView(dt);
            dv.Sort = "ZoneID asc";
            CmbZone.DataSource = dv.ToTable();
            CmbZone.ValueMember = "ZoneID";
            CmbZone.DisplayMember = "Zone";
        }

        private int BindHappyCode(int CompID)
        {
            int HappyCode = 0;
            EnquiryClass ec = new EnquiryClass();
            DataTable dt = new DataTable();
            dt = ec.BindHappyCode(CompID).Tables[0];
            HappyCode = Convert.ToInt32(dt.Rows[0]["HappyCode"].ToString());
            return HappyCode;
        }

        private void BindExpStatus()
        {
            EnquiryClass ec = new EnquiryClass();
            DataTable dt = new DataTable();
            dt = ec.BindExpStatus().Tables[0];
            dt.Rows.Add("0", "Select");
            DataView dv = new DataView(dt);
            dv.Sort = "ID asc";
            CmbWarantyStatus.DataSource = dv.ToTable();
            CmbWarantyStatus.ValueMember = "ID";
            CmbWarantyStatus.DisplayMember = "Status";
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

        private void BindDataGridviewAdminEmployee()
        {
            RegistractionClass rc = new RegistractionClass();
            DataTable dtemp = new DataTable();
            dtemp.Columns.Add("memid", typeof(System.Int32));
            dtemp.Columns.Add("FullName", typeof(System.String));
            dtemp.Rows.Add(0, "Select");
            DataTable dt = rc.BindMemberDetails(UniqueShopID, string.Empty).Tables[0];
            DataView dv = new DataView(dt);
            string RoleType = "ADMIN";
            dv.RowFilter = "Role='" + RoleType + "'";
            foreach (DataRow item in dv.ToTable().Rows)
            {
                dtemp.Rows.Add(item["memid"], item["FullName"]);
            }
            cmbSubmittedBy.DataSource = dtemp;
            if (dtemp.Rows.Count<1)
            {
                cmbSubmittedBy.DisplayMember = "FullName";
                cmbSubmittedBy.ValueMember = "memid";
            }
            else
            {
                cmbSubmittedBy.DisplayMember = "FullName";
                cmbSubmittedBy.ValueMember = "memid";
            }

            if (cmbSubmittedBy.Items.Count == 2)
            {
                cmbSubmittedBy.SelectedIndex = 1;
                TxtEmp.Focus();
            }

        }
        private void LstEmp_Click(object sender, EventArgs e)
        {
            SelectedCustomerID = LstEmp.GetItemText(LstEmp.SelectedValue);
            if (!string.IsNullOrEmpty(SelectedCustomerID))
            {
                TxtEmp.Text = LstEmp.GetItemText(LstEmp.SelectedItem);
                CustomerClass p = new CustomerClass();
                string CustomerContact = string.Empty;
                int i = Convert.ToInt32(SelectedCustomerID);
                if (i != 0)
                {
                    DataView dv = new DataView(p.BindCustomers(UniqueShopID).Tables[0]);
                    dv.RowFilter = "Customerid = '" + SelectedCustomerID + "'";

                    txtadd.Text = dv.ToTable().Rows[0]["ShippingAddress"].ToString();

                    TxtContact.Text = dv.ToTable().Rows[0]["Contact"].ToString();

                    TxtAltContact.Text = dv.ToTable().Rows[0]["GSTIN"].ToString();
                    if (dv.ToTable().Rows[0]["ZoneID"].ToString() != String.Empty)
                        CmbZone.SelectedValue = dv.ToTable().Rows[0]["ZoneID"].ToString();

                    DataView dv1 = new DataView(p.SearchCustomerRefNo(i).Tables[0]);
                    if (dv1.ToTable().Rows.Count > 0)
                        txtRefno.Text = dv1.ToTable().Rows[0]["Custsalerefno"].ToString();

                    LstEmp.Visible = false;


                }
                SetTotalDueCharge();
                //-----------------Customer Warranty-------------------
                DataTable dtWar = new DataTable();
                dtWar = p.BindCustomerWarranty(UniqueShopID, Convert.ToInt32(SelectedCustomerID)).Tables[0];
                if (dtWar.Rows.Count > 0)
                {
                    CmbWarantyStatus.SelectedValue = dtWar.Rows[0]["Status"].ToString();

                    if (Convert.ToString(dtWar.Rows[0]["Status"]) == "2")
                        PexpDate.Enabled = false;

                    PexpDate.Value = Convert.ToDateTime(dtWar.Rows[0]["PoDate"].ToString());
                    TxtProductModelNo.Text = dtWar.Rows[0]["Productname"].ToString() + '-' + dtWar.Rows[0]["ModelNO"].ToString();

                }
                //----------------End Customer Warranty-------------------

            }
        }

        public void BindPaymentStatus()
        {
            CustomerClass cls = new CustomerClass();
            CmbPayStatus.DataSource = cls.GetPaymentStatus().Tables[0];
            CmbPayStatus.DisplayMember = "Status";
            CmbPayStatus.ValueMember = "StatusID";
            CmbPayStatus.SelectedValue = 2;

        }
        public void SetTotalCharge()
        {
            try
            {
                LblCharges.Text = "0";
                CustomerClass cls = new CustomerClass();

                int Custid = Convert.ToInt32(SelectedCustomerID);
                LblPrevCharge.Text = cls.GetItemTotalChargeValue(CompID, Custid).Tables[0].Rows[0]["PrevDue"].ToString();
                LblCharges.Text = cls.GetItemTotalChargeValue(CompID, Custid).Tables[0].Rows[0]["Charge"].ToString();
                LblTotalCharges.Text = cls.GetItemTotalChargeValue(CompID, Custid).Tables[0].Rows[0]["TotalCharge"].ToString();
                TxtBal.Text = (Convert.ToInt32(LblTotalCharges.Text) - Convert.ToInt32(TxtPaid.Text)).ToString();


            }
            catch (Exception)
            {


            }

        }

        public void SetTotalDueCharge()
        {
            try
            {
                LblCharges.Text = "0";
                CustomerClass cls = new CustomerClass();

                int Custid = Convert.ToInt32(SelectedCustomerID);
                LblPrevCharge.Text = cls.GetItemTotalChargeValue(0, Custid).Tables[0].Rows[0]["PrevDue"].ToString();
                LblCharges.Text = cls.GetItemTotalChargeValue(0, Custid).Tables[0].Rows[0]["Charge"].ToString();
                LblTotalCharges.Text = cls.GetItemTotalChargeValue(0, Custid).Tables[0].Rows[0]["TotalCharge"].ToString();
                TxtProductModelNo.Text = cls.GetItemTotalChargeValue(0, Custid).Tables[0].Rows[0]["ModelNo"].ToString();


            }
            catch (Exception)
            {


            }

        }
        private void ComplaintForm_Load(object sender, EventArgs e)
        {

            LstEmp.Visible = false;          
            if (cmpl1 == null)
            {
                TxtPaid.Text = string.Empty;
                LblCharges.Text = "0";
                LblPrevCharge.Text = "0";
                LblTotalCharges.Text = "0";
                BindDataGridviewEmployee();
                BindDataGridviewAdminEmployee();
                BindCategoryDropDown();
                //bindComplaintGrid(string.Empty);
                BindComplaintStatus();
                BindComplaintType();
                GenerateComplaintNO();
                BindComplaintResolutionStatus();
                SetTotalCharge();
                BindPaymentStatus();
                BindZone();
                BindExpStatus();
                BindPaymentDetails();                
            }
            TxtEmp.Focus();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void BindComplaintStatus()
        {
            int res = 0;
            if (int.TryParse(CmbCat.SelectedValue.ToString(),out res))
            {
                CustomerClass cls = new CustomerClass();
                CmbStatus.DataSource = cls.GetAllComplaintStatus(UniqueShopID, Convert.ToInt32(CmbCat.SelectedValue)).Tables[0];
                CmbStatus.DisplayMember = "StatusDescription";
                CmbStatus.ValueMember = "StatusID";
            }


        }

        private void BindComplaintType()
        {
            CustomerClass cls = new CustomerClass();
            CmbLogType.DataSource = cls.GetAllComplaintType().Tables[0];
            CmbLogType.DisplayMember = "TypeName";
            CmbLogType.ValueMember = "TypeID";


        }


        private void BindComplaintResolutionStatus()
        {
            CustomerClass cls = new CustomerClass();
            CmbCompStatus.DataSource = cls.GetAllComplaintResolutionStatus().Tables[0];
            CmbCompStatus.DisplayMember = "StatusDescription";
            CmbCompStatus.ValueMember = "StatusID";
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
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (IsNewCustomer)
            {
                if (string.IsNullOrEmpty(TxtContact.Text))
                {
                    MessageBox.Show(this, "Please Enter Contact No. of the customer", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }
                else if (CheckIsExist(TxtContact.Text, TxtEmp.Text))
                {
                    MessageBox.Show(this, "Customer already exist.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            if (MessageBox.Show("Do You Want To Save the complaint?", "Customer Complaint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (TxtEmp.Text == string.Empty)
                {
                    MessageBox.Show(this, "Please select  customer to register the complaint", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (mskStart.ValidateText() == string.Empty)
                {
                    MessageBox.Show(this, "Please Enter Start Time.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (mskEnd.ValidateText() == string.Empty)
                {
                    MessageBox.Show(this, "Please Enter End Time.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (dtCompDate.Value.Date > dtvisit.Value.Date)
                {
                    MessageBox.Show(this, "Complaint Date can not be greater than visit date.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (dtCompDate.Value.Date > dtresolve.Value.Date)
                {
                    MessageBox.Show(this, "Complaint Date can not be greater than Resolve date.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (cmbSubmittedBy.SelectedIndex == 0)
                {
                    MessageBox.Show(this, "Please select submitted by.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (CmbEmp.SelectedIndex == 0 && UniqueShopID==3)
                {
                    MessageBox.Show(this, "Please select Employee.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    CmbEmp.Focus();
                    return;
                }
                if (txtRefno.Text == string.Empty)
                {
                    MessageBox.Show(this, "Please fill Reference No.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (TxtPaid.Text == string.Empty)
                {
                    MessageBox.Show(this, "Please Enter Paid Amount.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    TxtPaid.Focus();
                    return;
                }
                if (dtCompDate.Value.Date == dtresolve.Value.Date)
                {
                    if (Convert.ToDateTime(mskStart.Text) > Convert.ToDateTime(mskEnd.Text))
                    {
                        MessageBox.Show(this, "Start Time can not be greater than Resolve Time", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        mskStart.Focus();
                        return;

                    }

                }
                if (CmbCompStatus.SelectedValue.ToString() == "2")
                {
                    if (Helper.HappyCodeEnabled)
                    {
                        if (TxtHappyCode.Text != BindHappyCode(CompID).ToString())
                        {
                            MessageBox.Show(this, "Please Enter Valid Happy Code.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            TxtHappyCode.Focus();
                            return;
                        }
                    }
                }

                CustomerComplaint cmpl = new CustomerComplaint();
                cmpl.CompID = CompID;
                cmpl.CustomerID = Convert.ToInt32(SelectedCustomerID);
                cmpl.ComplaintID = TxtComplaintNo.Text;
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
                cmpl.StartTime = Convert.ToDateTime(mskStart.Text);
                cmpl.EndTime = Convert.ToDateTime(mskEnd.Text);
                cmpl.SubmittedBY = Convert.ToInt32(cmbSubmittedBy.SelectedValue);
                cmpl.ReferenceNo = Convert.ToString(txtRefno.Text);
                cmpl.ComplaintLogType = Convert.ToInt32(CmbLogType.SelectedValue);
                cmpl.ServiceDate = Convert.ToDateTime(dtservicedate.Value);
                cmpl.ActualServiceDate = Convert.ToDateTime(dtactservicedate.Value);

                cmpl.PayStatus = Convert.ToBoolean(CmbPayStatus.SelectedValue.ToString() == "2" ? 0 : 1);
                cmpl.PrevDue = Convert.ToInt32(LblPrevCharge.Text);

                cmpl.PaidAmt = Convert.ToInt32(TxtPaid.Text);
                cmpl.BalAmt = Convert.ToInt32(TxtBal.Text);

                cmpl.CurrentCharge = Convert.ToInt32(LblCharges.Text);
                cmpl.ActualServiceDate = Convert.ToDateTime(dtactservicedate.Value);
                cmpl.ZoneID = Convert.ToInt32(CmbZone.SelectedValue);
                cmpl.PModelNo = TxtProductModelNo.Text;
                cmpl.WEXPDate = Convert.ToDateTime(PexpDate.Text);
                cmpl.WExpStatus = Convert.ToInt32(CmbWarantyStatus.SelectedValue);
                cmpl.AltContact = TxtAltContact.Text;
                cmpl.NextCategoryID = Convert.ToInt32(CmbCat_Next.SelectedValue);
                CustomerClass cms = new CustomerClass();
                int i = cms.InsertUpdateCustomerCmplaint(cmpl);
                if (i > 0)
                {
                    MessageBox.Show(this, "Complaint Saved Successfully.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //bindComplaintGrid(string.Empty);
                    if (scomp != null)
                    {
                        scomp.LoadAlldata();
                    }
                    clearControl();
                    button4.Enabled = false;
                    if (CMPList == null)
                        this.Close();
                }
            }
        }
        private void clearControl()
        {

            CmbZone.SelectedValue = "0";
            TxtPaid.Text = string.Empty;
            TxtEmp.Focus();
            TxtBal.Text = "0";
            LblPrevCharge.Text = "0";
            LblCharges.Text = "0";
            LblTotalCharges.Text = "0";
            SelectedCustomerID = "0";
            GenerateComplaintNO();
            CmbEmp.SelectedIndex = 0;
            CmbStatus.SelectedIndex = -1;
            TxtEmp.Text = string.Empty;
            txtadd.Text = string.Empty;
            CmbEmp.SelectedIndex = 0;
            TxtRemark.Text = string.Empty;
            CompID = 0;
            LstEmp.Visible = false;
            TxtContact.Enabled = false;
            txtadd.Enabled = false;
            CmbZone.Enabled = false;
            IsNewCustomer = false;
            CmbCompStatus.SelectedIndex = 0;
            TxtContact.Text = string.Empty;
            mskStart.Text = DateTime.Now.ToString("HH:mm");
            mskEnd.Text = DateTime.Now.ToString("HH:mm");
            dtvisit.Value = DateTime.Now.Date;
            dtresolve.Value = DateTime.Now.Date;
            dtCompDate.Value = DateTime.Now.Date;
            dtservicedate.Value = DateTime.Now.Date;
            dtactservicedate.Value = DateTime.Now.Date;
            cmbSubmittedBy.SelectedIndex = 0;
            txtRefno.Text = string.Empty;
            CmbPayStatus.SelectedValue = "2";

        }

        private void GenerateComplaintNO()
        {
            if (cmpl1 == null)
            {
                CustomerClass cls = new CustomerClass();
                TxtComplaintNo.Text = cls.GenerateComplaint(UniqueShopID).Tables[0].Rows[0][0].ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void SetComplaintData(CustomerComplaint cmpl)
        {
            if (cmpl != null)
            {
                if (Helper.HappyCodeEnabled)
                {
                    LnkResendHappyCode.Visible = true;
                }
                BindCategoryDropDown();
                BindDataGridviewEmployee();
                BindDataGridviewAdminEmployee();
                //bindComplaintGrid(string.Empty);
                BindComplaintStatus();
                BindComplaintType();
                GenerateComplaintNO();
                BindComplaintResolutionStatus();
                SetTotalCharge();
                BindPaymentStatus();
                BindZone();
                BindExpStatus();

                CompID = cmpl.CompID;
                CmbCat.SelectedValue = cmpl.CategoryID;
                BindPaymentDetails();
                if (Helper.HappyCodeEnabled == true)
                {
                    HappyCode = BindHappyCode(CompID);
                }
                dtCompDate.Value = cmpl.ComplaintDate;
                TxtComplaintNo.Text = cmpl.ComplaintID;
                CmbEmp.SelectedValue = cmpl.EmpID.ToString();
                TxtRemark.Text = cmpl.Remark;
                TxtEmp.Text = cmpl.CustomerName;
                SelectedCustomerID = cmpl.CustomerID.ToString();
                CmbCompStatus.SelectedValue = cmpl.ResolutionStatusID;
                dtvisit.Value = cmpl.VisitDate;
                dtresolve.Value = cmpl.CloseDate;
                if (Convert.ToString(cmpl.StatusID) != string.Empty)
                    CmbStatus.SelectedValue = cmpl.StatusID;
                txtRefno.Text = cmpl.ReferenceNo;
                if (cmpl.SubmittedBY.ToString() != string.Empty)
                    cmbSubmittedBy.SelectedValue = cmpl.SubmittedBY;

                if (cmpl.ResolutionStatusID == 1)
                {
                    button3.Enabled = true;
                }
                else if (cmpl.ResolutionStatusID == 2)
                {
                    TxtHappyCode.Text = HappyCode.ToString();
                    TxtHappyCode.ReadOnly = true;
                }
                LstEmp.Visible = false;
                string CustomerContact = string.Empty;
                //Sales p = new Sales();

                CustomerClass pc = new CustomerClass();
                DataView dv = new DataView(pc.BindCustomers(UniqueShopID).Tables[0]);
                dv.RowFilter = "Customerid = '" + cmpl.CustomerID + "'";
                if (dv.ToTable().Rows.Count > 0)
                {
                    txtadd.Text = dv.ToTable().Rows[0]["Address"].ToString();
                    TxtContact.Text = dv.ToTable().Rows[0]["Contact"].ToString();
                    if (!string.IsNullOrEmpty(dv.ToTable().Rows[0]["ZoneID"].ToString()))
                        CmbZone.SelectedValue = dv.ToTable().Rows[0]["ZoneID"].ToString();
                }

                //txtadd.Text = p.GetSupplierAddressWithContact(Convert.ToInt32(SelectedCustomerID), out CustomerContact);
                //TxtContact.Text = CustomerContact;
                if (cmpl.StartTime.ToString() != string.Empty)
                {
                    mskStart.Text = cmpl.StartTime.ToString("HH:mm");
                    mskEnd.Text = cmpl.EndTime.ToString("HH:mm");
                }
                if (cmpl.ComplaintLogType.ToString() != string.Empty)
                {
                    CmbLogType.SelectedValue = cmpl.ComplaintLogType;
                }
                else
                {
                    CmbLogType.SelectedIndex = 0;
                }
                if (cmpl.ServiceDate.ToString() != string.Empty)
                {
                    dtservicedate.Value = cmpl.ServiceDate;
                }
                else
                {
                    dtservicedate.Value = DateTime.Now.Date;
                }
                if (cmpl.ActualServiceDate.ToString() != string.Empty)
                {
                    dtactservicedate.Value = cmpl.ActualServiceDate;
                }
                else
                {
                    dtactservicedate.Value = DateTime.Now.Date;
                }
                CmbPayStatus.SelectedValue = cmpl.PayStatus == true ? "1" : "2";
                LblPrevCharge.Text = cmpl.PrevDue.ToString();
                LblCharges.Text = cmpl.CurrentCharge.ToString();

                TxtPaid.Text = cmpl.PaidAmt.ToString();
                TxtBal.Text = cmpl.BalAmt.ToString();
                if (string.IsNullOrEmpty(LblPrevCharge.Text))
                {
                    LblPrevCharge.Text = "0";
                }
                if (string.IsNullOrEmpty(LblCharges.Text))
                {
                    LblCharges.Text = "0";
                }
                LblTotalCharges.Text = (Convert.ToInt32(LblPrevCharge.Text) + Convert.ToInt32(LblCharges.Text)).ToString();
                TxtProductModelNo.Text = cmpl.PModelNo;
                CmbWarantyStatus.SelectedValue = cmpl.WExpStatus;
                if (cmpl.WEXPDate.Year != 1)
                    PexpDate.Value = cmpl.WEXPDate;
                CmbCat_Next.SelectedValue = cmpl.NextCategoryID;
                BtnAttachMent.Enabled = true;
                btnItemMaster.Enabled = true;
                button4.Enabled = true;
                btnprint.Enabled = true;
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            clearControl();
            BtnAttachMent.Enabled = false;
            button3.Enabled = false;
            btnItemMaster.Enabled = false;
            button4.Enabled = false;
        }

        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TxtEmp.Text = string.Empty;
            TxtContact.Text = string.Empty;
            txtadd.Text = string.Empty;
            TxtAltContact.Text = string.Empty;
            CmbZone.SelectedValue = "0";
            TxtContact.Enabled = true;
            txtadd.Enabled = true;
            IsNewCustomer = true;
            CmbZone.Enabled = true;
            TxtAltContact.Enabled = true;
            LblPrevCharge.Text = "0";
            LblCharges.Text = "0";
            LblTotalCharges.Text = "0";
            TxtPaid.Text = "0";
            TxtBal.Text = "0";
            LstEmp.Visible = false;
            SelectedCustomerID = "0";
        }

        private void TxtEmp_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void LstEmp_Enter(object sender, EventArgs e)
        {

        }

        private void TxtEmp_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void mskEnd_Leave(object sender, EventArgs e)
        {
            DateTime dt;
            if (!DateTime.TryParse(mskEnd.Text, out dt))
            {
                MessageBox.Show(this, "Time Format is not valid.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskEnd.Text = string.Empty;
                mskEnd.Focus();
            }

        }

        private void mskStart_Leave(object sender, EventArgs e)
        {
            DateTime dt;
            if (!DateTime.TryParse(mskStart.Text, out dt))
            {
                MessageBox.Show(this, "Time Format is not valid.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskStart.Text = string.Empty;
                mskStart.Focus();
            }
        }

        private void BtnAttachMent_Click(object sender, EventArgs e)
        {
            ImageUpload imgup = new ImageUpload(CompID);
            imgup.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomerClass CLS = new CustomerClass();
            CustomerComplaint cmpl = new CustomerComplaint();
            cmpl.CompID = CompID;
            cmpl.CustomerID = Convert.ToInt32(SelectedCustomerID);
            cmpl.ComplaintID = TxtComplaintNo.Text;
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
            cmpl.StartTime = Convert.ToDateTime(mskStart.Text);
            cmpl.EndTime = Convert.ToDateTime(mskEnd.Text);
            cmpl.StartTime = Convert.ToDateTime(mskStart.Text);
            if (MessageBox.Show("Do You Want To Send SMS?", "MSS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int Result = CLS.SendEmpSMS(cmpl);
                if (Result > 0)
                {
                    MessageBox.Show(this, "SMS Resend Sucessfully on Employee Registered Mobile Number.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


        }

        private void btnItemMaster_Click(object sender, EventArgs e)
        {
            ItemServicesCharge im = new ItemServicesCharge(CompID, TxtComplaintNo.Text, this, UniqueShopID);
            im.ShowDialog();
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void TxtPaid_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtPaid.Text))
            {

                TxtBal.Text = (Convert.ToInt32(LblTotalCharges.Text == string.Empty ? "0" : LblTotalCharges.Text) - Convert.ToInt32(TxtPaid.Text == string.Empty ? "0" : TxtPaid.Text)).ToString();
            }
            else
            {
                TxtBal.Text = string.Empty;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TxtPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CustomerClass CLS = new CustomerClass();
            if (MessageBox.Show("Do You Want To Send Charge SMS? Kindly Save the Complaint before sent.", "MSS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int Result = CLS.SendChargeSMS(CompID);
                if (Result > 0)
                {
                    MessageBox.Show(this, "Bill detail SMS Resend Sucessfully on Employee Registered Mobile Number.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void CmbLogType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CmbEmp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtresolve_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dtvisit_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void TxtRemark_TextChanged(object sender, EventArgs e)
        {

        }

        private void mskEnd_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void CmbCompStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Helper.HappyCodeEnabled == true)
            {
                if (CmbCompStatus.SelectedValue.ToString() == "2")
                {
                    TxtHappyCode.Enabled = true;
                }
                else
                {
                    TxtHappyCode.Text = string.Empty;
                    TxtHappyCode.Enabled = false;
                }
            }
        }

        private void TxtHappyCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Report.FrmReport sd = new Report.FrmReport("ComplaintSlip", cmpl1.CompID, UniqueShopID);
            sd.ShowDialog();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            clearControl();          
            SelectedCustomerID = "0";
            CompID = 0;
            cmpl1 = null;
            CMPList = null;
            BtnAttachMent.Enabled = false;
            btnItemMaster.Enabled = false;
            button4.Enabled = false;
            btnprint.Enabled = false;
            LblPrevCharge.Text = "0";
            LblCharges.Text = "0";
            LblTotalCharges.Text = "0";
            TxtPaid.Text = "0";
            TxtBal.Text = "0";
            GenerateComplaintNO();
            CustomerClass CSL = new CustomerClass();
            dsCustDetail = CSL.SearchCustomers(UniqueShopID, TxtEmp.Text);
        }

        public void BindPaymentDetails()
        {
            
            CustomerClass cls = new CustomerClass();
            DataTable dtitm = new DataTable();
            dtitm = cls.GetReceivedAmount(CompID, null).Tables[0];
            dataGridViewItemServices.DataSource = dtitm;
            int i = 0;
            foreach (DataRow item in dtitm.Rows)
            {
                i = i + Convert.ToInt32(item["Amount"]);
            }
            TxtPaid.Text = i.ToString();
            TxtBal.Text = (Convert.ToInt32(LblTotalCharges.Text) - Convert.ToInt32(TxtPaid.Text)).ToString();
        }

        private void btnExisting_Click(object sender, EventArgs e)
        {
            IsNewCustomer = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (CMPList != null)
            {
                var comp = CMPList.Where(x => x.SeqNo < CurComplaint).OrderByDescending(x => x.SeqNo).ToList();
                if (comp.Count > 0)
                {
                    cmpl1 = CMPList.Where(x => x.SeqNo < CurComplaint).OrderByDescending(x => x.SeqNo).FirstOrDefault();
                    SetComplaintData(CMPList.Where(x => x.SeqNo < CurComplaint).OrderByDescending(x => x.SeqNo).FirstOrDefault());
                    CurComplaint = CMPList.Where(x => x.SeqNo < CurComplaint).OrderByDescending(x => x.SeqNo).FirstOrDefault().SeqNo;
                }
                else
                {
                    MessageBox.Show(this, "Next Record does not exists.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ReceivePayment rec = new ReceivePayment(CompID, TxtComplaintNo.Text, this, UniqueShopID, Convert.ToInt32(LblTotalCharges.Text));
            rec.ShowDialog();
        }

        private void CmbCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindComplaintStatus();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedCustomerID)|| SelectedCustomerID == "0")
            {
                MessageBox.Show(this, "Please select an existing customer.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CustomerUnpaidReport rep = new CustomerUnpaidReport(UniqueShopID, "Payment Detail",TxtEmp.Text,SelectedCustomerID);
            rep.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CustomerClass CLS = new CustomerClass();
            if (MessageBox.Show("Do You Want To Send Happy Code Again?", "MSS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int Result = CLS.SendHappyCodeSMS(CompID);
                if (Result > 0)
                {
                    MessageBox.Show(this, "Happy Code Resend Sucessfully on Customer Registered Mobile Number.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedCustomerID) || SelectedCustomerID == "0")
            {
                MessageBox.Show(this, "Please select an existing customer.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FutureSMSHistory rep = new FutureSMSHistory(UniqueShopID,TxtContact.Text);
            rep.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CompID == 0 )
            {
                MessageBox.Show(this, "Feedback is only Applicable for an existing complaint.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CustomerFeedback rep = new CustomerFeedback(CompID);
            rep.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (CompID == 0)
            {
                MessageBox.Show(this, "Notification is only Applicable for an existing complaint.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            NotifyCustomer rep = new NotifyCustomer(CompID);
            rep.ShowDialog();
        }
    }
}
