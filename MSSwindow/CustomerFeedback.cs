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
    public partial class CustomerFeedback : Form
    {
        public int _CompID = 0; 
        public CustomerFeedback(int CompID)
        {
            InitializeComponent();
            _CompID = CompID;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ChkSer_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSer.Checked == true)
            {
                ChkSer.Text = "Yes";
                dtp1.Enabled = true;
            }
            else
            {
                ChkSer.Text = "No";
                dtp1.Enabled = false;
            }
        }

        private void CustomerFeedback_Load(object sender, EventArgs e)
        {
            SetFeedBack(_CompID);
        }

        private void SetFeedBack(int CompID)
        {
            DataTable dTFeed = new DataTable();
            CustomerClass cls = new CustomerClass();
            dTFeed = cls.GetFeedBackByOwner(CompID);
            if (dTFeed.Rows.Count > 0)
            {
                EmpFeedBack.Rating = Convert.ToInt32(dTFeed.Rows[0]["EMP_BehaviourRating"]);
                SerViceQualityFeedback.Rating = Convert.ToInt32(dTFeed.Rows[0]["ServiceQualityRating"]);
                TxtCharge.Text= dTFeed.Rows[0]["Charges_iwow"].ToString();
                ChkSer.Checked = Convert.ToBoolean(dTFeed.Rows[0]["NextServiceReminder"]);
                dtp1.Value = Convert.ToDateTime(dTFeed.Rows[0]["NextSerDate"]);
                TxtRemark.Text = dTFeed.Rows[0]["Remark"].ToString();


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(EmpFeedBack.Rating==0)
            {
                MessageBox.Show(this, "Employee Feedback Rating is Mandatory.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SerViceQualityFeedback.Rating == 0)
            {
                MessageBox.Show(this, "Service Quality Feedback Rating is Mandatory.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TxtCharge.Text == string.Empty)
            {
                MessageBox.Show(this, "Charges IW/OW is Mandatory.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Do You Want To Save the Feedback?", "Customer Complaint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                OwnerFeedBack FB = new OwnerFeedBack();
                FB.CompID = _CompID;
                FB.FBID = 0;
                FB.EMP_BehaviourRating = EmpFeedBack.Rating;
                FB.ServiceQualityRating = SerViceQualityFeedback.Rating;
                FB.Charges_iwow = Convert.ToInt32(TxtCharge.Text);
                FB.Remark = TxtRemark.Text;
                FB.NextServiceReminder = ChkSer.Checked;
                FB.NextSerDate = dtp1.Value;
                CustomerClass cls = new CustomerClass();
                cls.InsertUpdateFeedBackByOwner(FB);
                MessageBox.Show(this, "Feedback Saved Successfully.", "Customer Complaint", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmpFeedBack.Rating = 0;
            SerViceQualityFeedback.Rating = 0;
            TxtCharge.Text = string.Empty;
            ChkSer.Checked = false;
            dtp1.Value = DateTime.Now.Date;
            TxtRemark.Text = string.Empty;

        }
    }
}
