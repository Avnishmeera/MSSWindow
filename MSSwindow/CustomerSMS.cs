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
using MSSEntityFrame;


using System.Text.RegularExpressions;


namespace MSSwindow
{
    public partial class CustomerSMS : Form
    {

        public readonly int UniqueShopID = 0;
        public int Memberid = 0;
        DataTable dtAllCustomer = new DataTable();
        DataTable dtSelectedCustomer = new DataTable();

        public CustomerSMS(MainForm Admn)
        {
            InitializeComponent();
            UniqueShopID = Admn.Shopid;
        }

        public CustomerSMS(int memberid, int SHOPID)
        {
            InitializeComponent();
            Memberid = memberid;
            UniqueShopID = SHOPID;

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int categoryid = 0;

        private void CustomerSMS_Load(object sender, EventArgs e)
        {

           
            dtAllCustomer.Columns.Add("select", typeof(System.Boolean));
            dtAllCustomer.Columns.Add("customername", typeof(System.String));
            dtAllCustomer.Columns.Add("mobile", typeof(System.String));

             dtSelectedCustomer.Columns.Add("Select", typeof(System.Boolean));
             dtSelectedCustomer.Columns.Add("CustomerName", typeof(System.String));
             dtSelectedCustomer.Columns.Add("Mobile", typeof(System.String));
            //MSEntities db = new MSEntities();
            //var CustData = db.CustomerMaster.Where(x => x.IsActive == true && x.ShopID == UniqueShopID).Select(x => new { x.Customername, x.Contact });

            //foreach (var item in CustData)
            //{
            //    dtAllCustomer.Rows.Add(false, item.Customername, item.Contact);
            //}
             BindCategoryDropDown();
             BindCustomer();
            
        }


        private void BindCustomer()
        {          
            CategoryClass catc = new CategoryClass();
            dtAllCustomer = catc.BindCustomerDetails(UniqueShopID,categoryid);
            DgvAllCustomer.DataSource = dtAllCustomer;
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
            cmbCategory.DataSource = dv.ToTable();
            cmbCategory.DisplayMember = "Categoryname";
            cmbCategory.ValueMember = "Categoryid";
        }


        //private void BindCategoryDropDown()
        //{
        //    try
        //    {
        //        CategoryclassBe be = new CategoryclassBe();
        //        be.Shopid = UniqueShopID;
        //        CategoryClass catc = new CategoryClass();
        //        DataTable dt = new DataTable();
        //        dt.Columns.Add("Categoryid", typeof(System.Int32));
        //        dt.Columns.Add("Categoryname", typeof(System.String));
        //        dt = catc.BindDropDownCategory1(be);
        //        dt.Rows.Add("0", "Select");
        //        cmbCategory.DataSource = dt;
        //        cmbCategory.DisplayMember = "Categoryname";
        //        cmbCategory.ValueMember = "Categoryid";
        //    }
        //    catch (Exception)
        //    {
               
        //    }
           
            
        //}

        private void button1_Click(object sender, EventArgs e)
        {

            dtSelectedCustomer.Rows.Clear();
            foreach (DataGridViewRow item in DgvAllCustomer.Rows)
            {
                if (Convert.ToBoolean(item.Cells[0].Value) == true)
                {
                    dtSelectedCustomer.Rows.Add(false, item.Cells[1].Value, item.Cells[2].Value);
                   
                }
            }
            dgvSelectCustomer.DataSource = dtSelectedCustomer;
            
            this.dgvSelectCustomer.CommitEdit(DataGridViewDataErrorContexts.Commit);
            int i = 0;
            foreach (DataGridViewRow item in dgvSelectCustomer.Rows)
            {
                if (Convert.ToBoolean(item.Cells[0].Value) == true)
                {
                    i = i + 1;
                }


            }
            LblCount2.Text = i.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //DataRow dr = null;
            //dr = dtSelectedCustomer.Select("Select='" + false + "'").[0];
            REMOVEROW:
            foreach (DataGridViewRow item in dgvSelectCustomer.Rows)
            {
                if (Convert.ToBoolean(item.Cells[0].Value) == false)
                {
                    dgvSelectCustomer.Rows.Remove(item);
                    goto REMOVEROW;
                }
            }

           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (TextSMS.Text == string.Empty)
            {
                MessageBox.Show(this, "Please Add Message Text", "Customer SMS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            if (MessageBox.Show("Do You Want To send message to the selected customer?", "Customer SMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CustomerClass CSMS = new CustomerClass();
                string Contact;
                string Messagetext = TextSMS.Text;
                SMSQue q = new SMSQue(dtSelectedCustomer, Messagetext, UniqueShopID, DateTime.Now);
                q.ShowDialog();
                //foreach (DataRow item in dtSelectedCustomer.Rows)
                //{
                //    Contact = item["Mobile"].ToString();
                //    CSMS.InsertNotification(Contact, Messagetext, UniqueShopID, DateTime.Now);
                //}
                MessageBox.Show(this, "Record Saved in queue.", "Customer SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dtSearchCustomer = new DataTable();
            dtSearchCustomer.Columns.Add("Select", typeof(System.Boolean));
            dtSearchCustomer.Columns.Add("CustomerName", typeof(System.String));
            dtSearchCustomer.Columns.Add("Mobile", typeof(System.String));

            foreach (DataRow item in dtAllCustomer.Select("CustomerName like '%" + txtSearch.Text + "%' or Mobile like '%" + txtSearch.Text + "%' "))
            {
                dtSearchCustomer.Rows.Add(item["Select"], item["CustomerName"], item["Mobile"]);
            }
            DgvAllCustomer.DataSource = dtSearchCustomer;
        }




        private void BtnSchedule_Click(object sender, EventArgs e)
        {
            if (TextSMS.Text == string.Empty)
            {
                MessageBox.Show(this, "Please Add Message Text", "Customer SMS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            List<CustomerClassBe> Lstbe = new List<CustomerClassBe>();
            string ContactNo = string.Empty;
            string CustomerName = string.Empty;
            foreach (DataRow item in dtSelectedCustomer.Rows)
            {
                ContactNo = item["Mobile"].ToString();
                CustomerName = item["CustomerName"].ToString();
                Lstbe.Add(new CustomerClassBe { Contact = ContactNo,CustomerName = CustomerName});
            }
            SMSScheduling schd = new SMSScheduling(Lstbe, TextSMS.Text, UniqueShopID);
            schd.ShowDialog();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int i = 0;
            if (checkBox1.Checked == true)
            {

                foreach (DataGridViewRow item in DgvAllCustomer.Rows)
                {
                    item.Cells[0].Value = true;
                    i = i + 1;
                }

            }
            else
            {
                if (checkBox1.Checked == false)
                {

                    foreach (DataGridViewRow item in DgvAllCustomer.Rows)
                    {
                        item.Cells[0].Value = false;
                    }

                }
            }
            LblCount1.Text = i.ToString();
            txtSearch.Focus();
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            int i = 0;
            if (checkBox2.Checked == true)
            {

                foreach (DataGridViewRow item in dgvSelectCustomer.Rows)
                {
                    item.Cells[0].Value = true;
                    i = i + 1;
                }

            }
            else
            {
                if (checkBox2.Checked == false)
                {

                    foreach (DataGridViewRow item in dgvSelectCustomer.Rows)
                    {
                        item.Cells[0].Value = false;
                    }

                }
            }
            LblCount2.Text = i.ToString();
        }

        private void DgvAllCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void DgvAllCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DgvAllCustomer.CommitEdit(DataGridViewDataErrorContexts.Commit);
            int i = 0;
            foreach (DataGridViewRow item in DgvAllCustomer.Rows)
            {
                if (Convert.ToBoolean(item.Cells[0].Value) == true)
                {
                    i = i + 1;
                }


            }
            LblCount1.Text = i.ToString();
        }

        private void DgvAllCustomer_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void DgvAllCustomer_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void DgvAllCustomer_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
           
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void dgvSelectCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvSelectCustomer.CommitEdit(DataGridViewDataErrorContexts.Commit);
            int i = 0;
            foreach (DataGridViewRow item in dgvSelectCustomer.Rows)
            {
                if (Convert.ToBoolean(item.Cells[0].Value) == true)
                {
                    i = i + 1;
                }
            }
            LblCount2.Text = i.ToString();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoryclassBe be = new CategoryclassBe();
            try
            {
                if (cmbCategory.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    CategoryClass catc = new CategoryClass();
                    dtAllCustomer = catc.BindCustomerDetails(UniqueShopID,Convert.ToInt32(cmbCategory.SelectedValue));
                    DgvAllCustomer.DataSource = dtAllCustomer;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
