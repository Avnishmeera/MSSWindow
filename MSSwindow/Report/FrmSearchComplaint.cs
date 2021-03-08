using MSSwindow.CommonClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSwindow.Report
{
    public partial class FrmSearchComplaint : Form
    {
        int CustomerStatus = 0;
        int UniqueShopID = 0;
        DataTable dtcomplaint = null;
        DateTime? VDate = null;
        public FrmSearchComplaint(int ShopID)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
        }
        public FrmSearchComplaint(int ShopID, string SearchText)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
            TxtSearch.Text = SearchText;
        }

        public FrmSearchComplaint(int ShopID, DateTime VisitDate)
        {
            InitializeComponent();
            UniqueShopID = ShopID;
            TxtSearch.Text = "Open";
            VDate = VisitDate;
        }

        private void FrmSearchComplaint_Load(object sender, EventArgs e)
        {

            if (TxtSearch.Text != string.Empty && VDate == null)
                bindComplaintGrid(TxtSearch.Text);
            else if (TxtSearch.Text != string.Empty && VDate != null)
            {
                CustomerClass cls = new CustomerClass();
                DataView dv = new DataView(dtcomplaint);
                dv.RowFilter = "VisitDate='" + VDate.Value.Date + "'";
                DgvComplaint.DataSource = dv.ToTable();
            }
            else
                bindComplaintGrid(string.Empty);

            BindComplaintResolutionStatus();
            checkedstatus.SetItemChecked(0, true);
            checkedstatus.SetItemChecked(3, true);
            ShowItemBasedOnStatus();
           
            BindEmployee();
        }



        private void BindComplaintResolutionStatus()
        {
            CustomerClass cls = new CustomerClass();
            checkedstatus.DataSource = cls.GetAllComplaintResolutionStatus_Summary(UniqueShopID).Tables[0];
            checkedstatus.DisplayMember = "StatusDescription";
            checkedstatus.ValueMember = "StatusID";
        }

        public void LoadAlldata()
        {
            CustomerClass cls = new CustomerClass();
            dtcomplaint = cls.SearchCustomerComplaint(string.Empty, UniqueShopID).Tables[0];
            DgvComplaint.DataSource = dtcomplaint;
        }
        public void bindComplaintGrid(string strSearch)
        {
            if (CustomerStatus == 0)
            {

                if (dtcomplaint == null)
                {
                    CustomerClass cls = new CustomerClass();
                    dtcomplaint = cls.SearchCustomerComplaint(strSearch, UniqueShopID).Tables[0];
                    DgvComplaint.DataSource = dtcomplaint;
                    lbltotalcmp.Text = dtcomplaint.Rows.Count.ToString();
                }
                else
                {
                    DataView dv = new DataView(dtcomplaint);
                    dv.RowFilter = "ComplaintID LIKE '%" + strSearch + "%' OR CustomerContact LIKE '%" + strSearch + "%' or Customername LIKE '%" + strSearch + "%' OR Zone LIKE '%" + strSearch + "%' OR ADDRESS LIKE '%" + strSearch + "%' OR AssignedTo like '%" + strSearch + "%' OR Status like '%" + strSearch + "%' or SubmittedBy Like '%" + strSearch + "%' or FilterDate LIKE '%" + strSearch + "%'";
                    DgvComplaint.DataSource = dv.ToTable();
                    lbltotalcmp.Text = dv.ToTable().Rows.Count.ToString();
                }
            }
            else
            {
                CustomerClass cls = new CustomerClass();
                DataView dv = new DataView(dtcomplaint);
                dv.RowFilter = "StatusID='" + CustomerStatus + "'";
                DgvComplaint.DataSource = dv.ToTable();
                lbltotalcmp.Text = dv.ToTable().Rows.Count.ToString();

            }

        }

        public void bindComplaintGrid(string strSearch, string StatusIDs)
        {

            CustomerClass cls = new CustomerClass();
            dtcomplaint = cls.SearchCustomerComplaint(strSearch, UniqueShopID, StatusIDs).Tables[0];
            DgvComplaint.DataSource = dtcomplaint;

            //DataView dv = new DataView(dtcomplaint);
            //dv.RowFilter = "ComplaintID LIKE '%" + strSearch + "%' OR CustomerContact LIKE '%" + strSearch + "%' or Customername LIKE '%" + strSearch + "%' OR Zone LIKE '%" + strSearch + "%' OR ADDRESS LIKE '%" + strSearch + "%' OR AssignedTo like '%" + strSearch + "%' OR Status like '%" + strSearch + "%' or SubmittedBy Like '%" + strSearch + "%' or FilterDate LIKE '%" + strSearch + "%'";
            //DgvComplaint.DataSource = dv.ToTable();
            lbltotalcmp.Text = dtcomplaint.Rows.Count.ToString();


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
            ComplaintForm cmp = new ComplaintForm(UniqueShopID, this);
            cmp.ShowDialog();
        }

        private void DgvComplaint_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex > 1)
                {
                    CustomerComplaint cmpl = new CustomerComplaint();
                    cmpl.CompID = Convert.ToInt32(DgvComplaint.CurrentRow.Cells["GenID"].Value.ToString());
                    cmpl.ComplaintDate = Convert.ToDateTime(DgvComplaint.CurrentRow.Cells["Date"].Value.ToString());
                    cmpl.ComplaintID = DgvComplaint.CurrentRow.Cells["ComplaintID"].Value.ToString();
                    cmpl.EmpID = Convert.ToInt32(DgvComplaint.CurrentRow.Cells["EmpID"].Value.ToString());
                    cmpl.Remark = DgvComplaint.CurrentRow.Cells["Remark"].Value.ToString();
                    cmpl.CustomerName = DgvComplaint.CurrentRow.Cells["Customername"].Value.ToString();
                    cmpl.CustomerID = Convert.ToInt32(DgvComplaint.CurrentRow.Cells["Customerid"].Value.ToString());
                    cmpl.StatusID = Convert.ToInt32(DgvComplaint.CurrentRow.Cells["StatusID"].Value.ToString());
                    cmpl.VisitDate = Convert.ToDateTime(DgvComplaint.CurrentRow.Cells["VisitDate"].Value.ToString());
                    cmpl.CloseDate = Convert.ToDateTime(DgvComplaint.CurrentRow.Cells["ResolveDate"].Value.ToString());
                    cmpl.ResolutionStatusID = Convert.ToInt32(DgvComplaint.CurrentRow.Cells["StatusID"].Value.ToString());
                    if (DgvComplaint.CurrentRow.Cells["ReasonID"].Value.ToString() != string.Empty)
                        cmpl.StatusID = Convert.ToInt32(DgvComplaint.CurrentRow.Cells["ReasonID"].Value.ToString());
                    cmpl.ReferenceNo = DgvComplaint.CurrentRow.Cells["ReferenceNo"].Value.ToString();
                    if (DgvComplaint.CurrentRow.Cells["SubID"].Value.ToString() != string.Empty)
                        cmpl.SubmittedBY = Convert.ToInt32(DgvComplaint.CurrentRow.Cells["SubID"].Value);
                    cmpl.CategoryID = Convert.ToInt32(DgvComplaint.CurrentRow.Cells["Category"].Value);
                    cmpl.NextCategoryID = Convert.ToInt32(DgvComplaint.CurrentRow.Cells["NextCategory"].Value);
                    if (DgvComplaint.CurrentRow.Cells["StartTime"].Value.ToString() != string.Empty)
                    {
                        cmpl.StartTime = Convert.ToDateTime(DgvComplaint.CurrentRow.Cells["StartTime"].Value.ToString());
                        cmpl.EndTime = Convert.ToDateTime(DgvComplaint.CurrentRow.Cells["ResolveTime"].Value.ToString());
                    }
                    if (DgvComplaint.CurrentRow.Cells["TypeID"].Value.ToString() != string.Empty)
                    {
                        cmpl.ComplaintLogType = Convert.ToInt32(DgvComplaint.CurrentRow.Cells["TypeID"].Value.ToString());
                    }
                    else
                    {
                        cmpl.ComplaintLogType = 0;
                    }
                    if (DgvComplaint.CurrentRow.Cells["ServiceDueDate"].Value.ToString() != string.Empty)
                    {
                        cmpl.ServiceDate = Convert.ToDateTime(DgvComplaint.CurrentRow.Cells["ServiceDueDate"].Value.ToString());
                    }
                    else
                    {
                        cmpl.ServiceDate = DateTime.Now.Date;
                    }
                    if (DgvComplaint.CurrentRow.Cells["ActualServiceDate"].Value.ToString() != string.Empty)
                    {
                        cmpl.ActualServiceDate = Convert.ToDateTime(DgvComplaint.CurrentRow.Cells["ActualServiceDate"].Value.ToString());
                    }
                    else
                    {
                        cmpl.ActualServiceDate = DateTime.Now.Date;
                    }
                    cmpl.PayStatus = Convert.ToBoolean(DgvComplaint.CurrentRow.Cells["PayStatus"].Value.ToString() == "1" ? true : false);
                    cmpl.PrevDue = Convert.ToInt32(DgvComplaint.CurrentRow.Cells["PrevDue"].Value.ToString() == string.Empty ? "0" : DgvComplaint.CurrentRow.Cells["PrevDue"].Value.ToString());
                    cmpl.CurrentCharge = Convert.ToInt32(DgvComplaint.CurrentRow.Cells["CurrentDue"].Value.ToString() == string.Empty ? "0" : DgvComplaint.CurrentRow.Cells["CurrentDue"].Value.ToString());

                    cmpl.PaidAmt = Convert.ToInt32(DgvComplaint.CurrentRow.Cells["PaidAmt"].Value.ToString());
                    cmpl.BalAmt = Convert.ToInt32(DgvComplaint.CurrentRow.Cells["BalAmt"].Value.ToString());
                    cmpl.PModelNo = DgvComplaint.CurrentRow.Cells["ModelNo"].Value.ToString();
                    if (!string.IsNullOrEmpty(DgvComplaint.CurrentRow.Cells["ExpDate"].Value.ToString()))
                        cmpl.WEXPDate = Convert.ToDateTime(DgvComplaint.CurrentRow.Cells["ExpDate"].Value.ToString());
                    if (!string.IsNullOrEmpty(DgvComplaint.CurrentRow.Cells["ExpStatus"].Value.ToString()))
                        cmpl.WExpStatus = Convert.ToInt32(DgvComplaint.CurrentRow.Cells["ExpStatus"].Value.ToString());
                    ComplaintForm frm = new ComplaintForm(cmpl, UniqueShopID, this);
                    frm.ShowDialog();

                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ComplaintForm cmp = new ComplaintForm(UniqueShopID, this);
            cmp.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;

                worksheet.Name = "ExportedFromDatGrid";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column. 
                for (int i = 0; i < DgvComplaint.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < DgvComplaint.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = DgvComplaint.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = DgvComplaint.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Export Successful");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }

        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> lst = new List<string>();
            foreach (DataGridViewRow item in DgvComplaint.Rows)
            {
                if (Convert.ToBoolean(item.Cells[0].Value) == true)
                {
                    lst.Add(item.Cells["GenID"].Value.ToString());
                }
            }
            if (lst.Count > 0)
            {
                Report.FrmReport sd = new Report.FrmReport("MultipleComplaintSlip", lst, UniqueShopID);
                sd.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Please Select Complaint to Print Slip.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<CustomerComplaint> lst = new List<CustomerComplaint>();
            foreach (DataGridViewRow item in DgvComplaint.Rows)
            {
                if (Convert.ToBoolean(item.Cells[0].Value) == true)
                {
                    CustomerComplaint cmpl = new CustomerComplaint();
                    cmpl = SetComplaintObject(item.Index);
                    lst.Add(cmpl);
                }
            }
            if (lst.Count > 0)
            {
                ComplaintForm frm = new ComplaintForm(lst, UniqueShopID, this);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Please Select Complaint to Modify.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

        }

        private CustomerComplaint SetComplaintObject(int rowindx)
        {
            CustomerComplaint cmpl = new CustomerComplaint();
            cmpl.SeqNo = rowindx;
            cmpl.CompID = Convert.ToInt32(DgvComplaint.Rows[rowindx].Cells["GenID"].Value.ToString());
            cmpl.ComplaintDate = Convert.ToDateTime(DgvComplaint.Rows[rowindx].Cells["Date"].Value.ToString());
            cmpl.ComplaintID = DgvComplaint.Rows[rowindx].Cells["ComplaintID"].Value.ToString();
            cmpl.EmpID = Convert.ToInt32(DgvComplaint.Rows[rowindx].Cells["EmpID"].Value.ToString());
            cmpl.Remark = DgvComplaint.Rows[rowindx].Cells["Remark"].Value.ToString();
            cmpl.CustomerName = DgvComplaint.Rows[rowindx].Cells["Customername"].Value.ToString();
            cmpl.CustomerID = Convert.ToInt32(DgvComplaint.Rows[rowindx].Cells["Customerid"].Value.ToString());
            cmpl.StatusID = Convert.ToInt32(DgvComplaint.Rows[rowindx].Cells["StatusID"].Value.ToString());
            cmpl.VisitDate = Convert.ToDateTime(DgvComplaint.Rows[rowindx].Cells["VisitDate"].Value.ToString());
            cmpl.CloseDate = Convert.ToDateTime(DgvComplaint.Rows[rowindx].Cells["ResolveDate"].Value.ToString());
            cmpl.ResolutionStatusID = Convert.ToInt32(DgvComplaint.Rows[rowindx].Cells["StatusID"].Value.ToString());
            if (DgvComplaint.Rows[rowindx].Cells["ReasonID"].Value.ToString() != string.Empty)
                cmpl.StatusID = Convert.ToInt32(DgvComplaint.Rows[rowindx].Cells["ReasonID"].Value.ToString());
            cmpl.ReferenceNo = DgvComplaint.Rows[rowindx].Cells["ReferenceNo"].Value.ToString();
            if (DgvComplaint.Rows[rowindx].Cells["SubID"].Value.ToString() != string.Empty)
                cmpl.SubmittedBY = Convert.ToInt32(DgvComplaint.Rows[rowindx].Cells["SubID"].Value);
            cmpl.CategoryID = Convert.ToInt32(DgvComplaint.CurrentRow.Cells["Category"].Value);


            if (DgvComplaint.Rows[rowindx].Cells["StartTime"].Value.ToString() != string.Empty)
            {
                cmpl.StartTime = Convert.ToDateTime(DgvComplaint.Rows[rowindx].Cells["StartTime"].Value.ToString());
                cmpl.EndTime = Convert.ToDateTime(DgvComplaint.Rows[rowindx].Cells["ResolveTime"].Value.ToString());
            }
            if (DgvComplaint.Rows[rowindx].Cells["TypeID"].Value.ToString() != string.Empty)
            {
                cmpl.ComplaintLogType = Convert.ToInt32(DgvComplaint.Rows[rowindx].Cells["TypeID"].Value.ToString());
            }
            else
            {
                cmpl.ComplaintLogType = 0;
            }
            if (DgvComplaint.Rows[rowindx].Cells["ServiceDueDate"].Value.ToString() != string.Empty)
            {
                cmpl.ServiceDate = Convert.ToDateTime(DgvComplaint.Rows[rowindx].Cells["ServiceDueDate"].Value.ToString());
            }
            else
            {
                cmpl.ServiceDate = DateTime.Now.Date;
            }
            if (DgvComplaint.Rows[rowindx].Cells["ActualServiceDate"].Value.ToString() != string.Empty)
            {
                cmpl.ActualServiceDate = Convert.ToDateTime(DgvComplaint.Rows[rowindx].Cells["ActualServiceDate"].Value.ToString());
            }
            else
            {
                cmpl.ActualServiceDate = DateTime.Now.Date;
            }
            cmpl.PayStatus = Convert.ToBoolean(DgvComplaint.Rows[rowindx].Cells["PayStatus"].Value.ToString() == "1" ? true : false);
            cmpl.PrevDue = Convert.ToInt32(DgvComplaint.Rows[rowindx].Cells["PrevDue"].Value.ToString() == string.Empty ? "0" : DgvComplaint.Rows[rowindx].Cells["PrevDue"].Value.ToString());
            cmpl.CurrentCharge = Convert.ToInt32(DgvComplaint.Rows[rowindx].Cells["CurrentDue"].Value.ToString() == string.Empty ? "0" : DgvComplaint.Rows[rowindx].Cells["CurrentDue"].Value.ToString());

            cmpl.PaidAmt = Convert.ToInt32(DgvComplaint.Rows[rowindx].Cells["PaidAmt"].Value.ToString());
            cmpl.BalAmt = Convert.ToInt32(DgvComplaint.Rows[rowindx].Cells["BalAmt"].Value.ToString());
            cmpl.PModelNo = DgvComplaint.Rows[rowindx].Cells["ModelNo"].Value.ToString();
            if (!string.IsNullOrEmpty(DgvComplaint.Rows[rowindx].Cells["ExpDate"].Value.ToString()))
                cmpl.WEXPDate = Convert.ToDateTime(DgvComplaint.Rows[rowindx].Cells["ExpDate"].Value.ToString());
            if (!string.IsNullOrEmpty(DgvComplaint.Rows[rowindx].Cells["ExpStatus"].Value.ToString()))
                cmpl.WExpStatus = Convert.ToInt32(DgvComplaint.Rows[rowindx].Cells["ExpStatus"].Value.ToString());

            return cmpl;
        }

        private void checkedstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            ShowItemBasedOnStatus();
        }

        private void ShowItemBasedOnStatus()
        {
            TxtSearch.Text = string.Empty;
            List<int> LstStatus = new List<int>();

            if (checkedstatus.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                foreach (object itemChecked in checkedstatus.CheckedItems)
                {
                    DataRowView castedItem = itemChecked as DataRowView;
                    int comapnyName = Convert.ToInt32(castedItem["StatusID"].ToString());
                    LstStatus.Add(comapnyName);
                }

                string StatusIds = String.Join(",", LstStatus);

                if (TxtSearch.Text != string.Empty)
                    bindComplaintGrid(TxtSearch.Text, StatusIds);
                else
                    bindComplaintGrid(string.Empty, StatusIds);
            }


           
        }


        private void ShowItemBasedOnEmployee()
        {
            TxtSearch.Text = string.Empty;
            List<int> LstStatus = new List<int>();
            foreach (object itemChecked in checkedstatus.CheckedItems)
            {
                DataRowView castedItem = itemChecked as DataRowView;
                int comapnyName = Convert.ToInt32(castedItem["StatusID"].ToString());
                LstStatus.Add(comapnyName);
            }
            string StatusIds = String.Join(",", LstStatus);
            if (TxtSearch.Text != string.Empty)
                bindComplaintGrid(TxtSearch.Text, StatusIds);
            else
                bindComplaintGrid(string.Empty, StatusIds);
        }


        private void BindEmployee()
        {
            RegistractionClass rc = new RegistractionClass();
            DataTable dtemp = new DataTable();
            dtemp.Columns.Add("memid", typeof(System.Int32));
            dtemp.Columns.Add("FullName", typeof(System.String));
            dtemp.Rows.Add(0, "Select All");
            DataTable dt = rc.BindMemberDetails(UniqueShopID, string.Empty).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                dtemp.Rows.Add(item["memid"], item["FullName"]);
            }
            checkedEmp.DataSource = dtemp;
            checkedEmp.DisplayMember = "FullName";
            checkedEmp.ValueMember = "memid";
        }

        private void checkedEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<int> LstStatus = new List<int>();
            foreach (object itemChecked in checkedstatus.CheckedItems)
            {
                DataRowView castedItem = itemChecked as DataRowView;
                int comapnyName = Convert.ToInt32(castedItem["StatusID"].ToString());
                LstStatus.Add(comapnyName);

            }
        }
    }
}
