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
    public partial class ShopDetail : Form
    {
        int UniqueShopID = 0;
        public ShopDetail(int ShpID)
        {
            InitializeComponent();
            UniqueShopID = ShpID;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
        private void InitializeSetting()
        {
            Helper.ShopName = TXTSHOPNAME.Text;
            Helper.ShopAddress = TxtShopAddress.Text;
            Helper.ShopDescription = TxtShopBusinessType.Text;
            Helper.ShopGSTIN = txtgstin.Text;
            Helper.ShopTin = TxtTIN.Text;
            Helper.ShopCIN = TxtCIN.Text;
            Helper.ShopRegNo = TxtRegNO.Text;
            Helper.ShopOwner = TxtOwnerName.Text;
            Helper.ShopOwnerPAN = TxtPAN.Text;
            Helper.ShopOwnerMob = TxtMobile.Text;
            Helper.ShopOwnerOfficeContact = TxtOfficePhone.Text;
            Helper.ShopEMail = TxtOfficeEmail.Text;
            Helper.ReportName = TxtReportName.Text;
            Helper.ApiUrl = txtapi.Text;
            if (IsActive.Checked==true)
            {
                Helper.HappyCodeEnabled = true;
            }
            else
            {
                Helper.HappyCodeEnabled = false;
            }
           
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Change Shop Detail?", "Shop Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoginClass LGN = new LoginClass();
                InitializeSetting();
                int i = LGN.ChangeProfile(UniqueShopID);
                if (i > 0)
                {
                    MessageBox.Show(this, "Shop Detail Saved Successfully .", "Shop Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                SetShopProperties(UniqueShopID);
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
                Helper.ApiUrl = item["Apiurl"].ToString();
                Helper.IsConvertEMIEnabled =Convert.ToBoolean(item["InConvertEMIEnable"].ToString());

            }
        }

        private void ShopDetail_Load(object sender, EventArgs e)
        {

            ShowShopDetail();
        }

        private void ShowShopDetail()
        {
            TXTSHOPNAME.Text = Helper.ShopName;
            TxtShopAddress.Text = Helper.ShopAddress;
            TxtShopBusinessType.Text = Helper.ShopDescription;
            txtgstin.Text = Helper.ShopGSTIN;
            TxtTIN.Text = Helper.ShopTin;
            TxtCIN.Text = Helper.ShopCIN;
            TxtRegNO.Text = Helper.ShopRegNo;
            TxtOwnerName.Text = Helper.ShopOwner;
            TxtPAN.Text = Helper.ShopOwnerPAN;
            TxtMobile.Text = Helper.ShopOwnerMob;
            TxtOfficePhone.Text = Helper.ShopOwnerOfficeContact;
            TxtOfficeEmail.Text = Helper.ShopEMail;
            TxtReportName.Text = Helper.ReportName;
            txtapi.Text = Helper.ApiUrl;
            IsActive.Checked = Helper.HappyCodeEnabled;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
