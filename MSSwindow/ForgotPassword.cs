using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using MSSwindow.CommonClass;

namespace MSSwindow
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword(string UserName)
        {
            InitializeComponent();
            txtUsername.Text = UserName;
            txtUsername.Enabled = false;
        }
        private bool LoginVerified()
        {
            bool IsVerified = false;

            LoginClass lc = new LoginClass();
            DataTable dt = new DataTable();
            dt = lc.shoploginsucess(txtUsername.Text, TxtOld.Text);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "0")
                {
                    IsVerified = false;
                }
                else
                {
                    IsVerified = true;
                }
                
            }
            return IsVerified;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            string strNewPassword = TxtNewPassword.Text;
            
            string username = txtUsername.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please provide User ID");
            }
            else if (string.IsNullOrEmpty(TxtOld.Text))
            {
                MessageBox.Show("Please provide Old password");
                return;
            }
          
            else if (string.IsNullOrEmpty(TxtNewPassword.Text))
            {
                MessageBox.Show("Please provide New password");
                return;
            }
            else if (LoginVerified() == false)
            {
                MessageBox.Show("Please provide Correct UserName and Password");
                return;
            }
            else
            {
                if (MessageBox.Show("Do You Want To Change Password?", "Shop Login", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LoginClass lc = new LoginClass();
                    int j = 0;
                    j = lc.ForgotPassword(username, strNewPassword);
                    if (j > 0)
                    {
                        MessageBox.Show(this, "Password Change Successfully.", "Shop Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
