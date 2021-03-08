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
    public partial class Loginform : Form
    {
        public Loginform()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == string.Empty)
            {
                MessageBox.Show(this, "Please enter user name", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtUsername.Focus();
                return;
            }
            else if (txtPassword.Text == string.Empty)
            {
                MessageBox.Show(this, "Please enter user password", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtPassword.Focus();
                return;
            }
            //if (DateTime.Now.Date >= Convert.ToDateTime("10/30/2017"))
            //{
            //    //MessageBox.Show("The trial version is now expired!Please contact administrator");
            //    MessageBox.Show(this, "The trial version is now expired! Please contact administrator", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            //    txtUsername.Text = string.Empty;
            //    txtPassword.Text = string.Empty;
            //    return;
            //}
            else
            {
                LoginClassBe be = new LoginClassBe();
                be.Username = txtUsername.Text;
                be.OldPassword = txtPassword.Text;
                LoginClass lc = new LoginClass();
                DataTable dt = new DataTable();
                dt = lc.shoploginsucess(be.Username, be.OldPassword);
                if (dt.Rows.Count > 0)
                {
                    int ShopID = Convert.ToInt32(dt.Rows[0][0].ToString());
                    string Role = dt.Rows[0][1].ToString();
                    int ShopUserID = Convert.ToInt32(dt.Rows[0][2].ToString());
                    if (ShopID != 0)
                    {
                        SetShopProperties(ShopID);
                        MainForm af = new MainForm(ShopID, ShopUserID, Role, this);
                        af.ShowDialog();

                        txtUsername.Text = string.Empty;
                        txtPassword.Text = string.Empty;

                    }
                    else
                    {
                        MessageBox.Show(this, "Please enter valid username and password", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        txtUsername.Text = string.Empty;
                        txtPassword.Text = string.Empty;
                        txtUsername.Focus();
                        return;
                    }

                }
                else
                {
                    MessageBox.Show(this, "Please enter valid username and password", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    txtUsername.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                }
            }

        }

        private void SetShopProperties(int ShopID)
        {
            DataSet ds = ShopMaster.SetShopProperty(ShopID);
            DataTable dt = ds.Tables[0];
            foreach (DataRow item in dt.Rows)
            {

                Helper.ShopName = item["ShopName"].ToString();
                Helper.ShopAddress = item["ShopAddress"].ToString();
                Helper.ShopDescription = item["ShopDescription"].ToString();
                Helper.ShopGSTIN = item["ShopGSTIN"].ToString();
                Helper.ShopTin = item["ShopTin"].ToString();
                Helper.ShopCIN = item["ShopCIN"].ToString();
                Helper.ShopRegNo = item["ShopRegNo"].ToString();
                Helper.ShopOwner = item["ShopOwner"].ToString();
                Helper.ShopOwnerPAN = item["ShopOwnerPAN"].ToString();
                Helper.ShopOwnerMob = item["ShopOwnerMob"].ToString();
                Helper.ShopOwnerOfficeContact = item["ShopOwnerOfficeContact"].ToString();
                Helper.ShopEMail = item["ShopEMail"].ToString();
                Helper.ShopUserID = item["ShopUserID"].ToString();
                Helper.ReportName = item["ReportName"].ToString();
                Helper.HappyCodeEnabled = Convert.ToBoolean(item["HappyCodeEnabled"]);
                Helper.SmsEnabled = Convert.ToBoolean(item["IsSMSEnabled"]);
                Helper.ApiUrl = item["ApiUrl"].ToString();
                Helper.complaintInit = item["complaintInit"].ToString();
               // Helper.IsConvertEMIEnabled =Convert.ToBoolean(item["InConvertEMIEnable"].ToString());
                
            }


        }
        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            // throw new NotImplementedException();
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetPassword fp = new ResetPassword();
            fp.ShowDialog();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
