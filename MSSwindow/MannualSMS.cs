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
    public partial class MannualSMS : Form
    {

        public readonly int UniqueShopID = 0;
        public int Memberid = 0;
        DataTable dtAllCustomer = new DataTable();
        DataTable dtSelectedCustomer = new DataTable();

        public MannualSMS(MainForm Admn)
        {
            InitializeComponent();
            UniqueShopID = Admn.Shopid;
        }

        public MannualSMS(int memberid, int SHOPID)
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

        private void CustomerSMS_Load(object sender, EventArgs e)
        {
          
            dtAllCustomer.Columns.Add("Mobile", typeof(System.String));
            dtSelectedCustomer.Columns.Add("Mobile", typeof(System.String));
          

        }

        private void button1_Click(object sender, EventArgs e)
        {

          

        }

        private void button2_Click(object sender, EventArgs e)
        {

            
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (TextSMS.Text == string.Empty)
            {
                MessageBox.Show(this, "Please Add Message Text", "Customer SMS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            if (MessageBox.Show("Do You Want To send message to the selected Contact?", "Customer SMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CustomerClass CSMS = new CustomerClass();
                string Contact;
                string Messagetext = TextSMS.Text;
                foreach (DataRow item in dtSelectedCustomer.Rows)
                {
                    Contact = item["Mobile"].ToString();
                    CSMS.InsertNotification(Contact, Messagetext, UniqueShopID, DateTime.Now);
                }
                MessageBox.Show(this, "Record Saved in queue.", "Customer SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
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
            foreach (DataRow item in dtSelectedCustomer.Rows)
            {
                ContactNo = item["Mobile"].ToString();
                if (Lstbe.Where(X => X.Contact == ContactNo).Count() == 0)
                {
                    Lstbe.Add(new CustomerClassBe { Contact = ContactNo });
                }
                
            }
            
            SMSScheduling schd = new SMSScheduling(Lstbe, TextSMS.Text, UniqueShopID);
            schd.ShowDialog();


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int i = 0;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void DgvAllCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void DgvAllCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
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
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length < 10)
            {
                MessageBox.Show(this, "Please Add Valid Contact", "Customer SMS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtSearch.Focus();
                return;
            }
            if (txtSearch.Text != string.Empty)
            {
                if (dtSelectedCustomer.Select("Mobile='" + txtSearch.Text + "'").Count() > 0)
                {
                    MessageBox.Show(this, "Contact Already Added", "Customer SMS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    txtSearch.Focus();
                    return;
                }
                dtSelectedCustomer.Rows.Add(txtSearch.Text);
                dgvSelectCustomer.Rows.Add(txtSearch.Text);
                txtSearch.Text = string.Empty;
            }
        }

        private void dgvSelectCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Do You Want To Delete the Contact?", "Customer SMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string Mobile = string.Empty;
                    Mobile = dgvSelectCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
                    dgvSelectCustomer.Rows.RemoveAt(e.RowIndex);
                    dtSelectedCustomer.Rows.Remove(dtSelectedCustomer.Select("Mobile='" + Mobile + "'").First());
                }
            }
        }



    }
}
