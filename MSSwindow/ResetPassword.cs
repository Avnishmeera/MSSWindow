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
    public partial class ResetPassword : Form
    {
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            String RegEmailid = string.Empty;
            if (MessageBox.Show("Do You Want To Get your Password?", "Password Detail", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                if (txtUsername.Text.Trim() == string.Empty)
                {
                    MessageBox.Show(this, "Please Enter User ID.", "Shop Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoginClass LGN = new LoginClass();
                DataTable dt = new DataTable();
                dt = LGN.GetShopEmail(txtUsername.Text);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() != string.Empty)
                    {
                        RegEmailid = dt.Rows[0][0].ToString();
                        string body = string.Format("<div>Hi {0},<div><br/>Your MSS POS password is {1}<br/><br/><br/>Thanks,<br/>Meera Infotech<br>7838633460", dt.Rows[0][2].ToString(), dt.Rows[0][1].ToString());
                        LGN.SendEmail(dt.Rows[0][0].ToString(), "Password Reset", body);
                    }
                    else
                    {

                        MessageBox.Show(this, "Please Enter Correct User ID.", "Shop Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(this, "Please Enter Correct User ID.", "Shop Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                MessageBox.Show(this, "Your password will be available at your registered Email ID '"+RegEmailid+"'", "Shop Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
