using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSwindow.CommonClass
{
    class Helper
    {
        public static void Delete(Button BtnAdd, Button BtnSave, Button BtnDelete, Button BtnReset, Button BtnClose)
        {
            BtnAdd.Enabled = true;
            BtnSave.Enabled = false;
            BtnDelete.Enabled = false;
            BtnReset.Enabled = true;
            BtnClose.Enabled = true;
        }
        public static void AddNew(Button BtnAdd, Button BtnSave, Button BtnDelete, Button BtnReset, Button BtnClose)
        {
            BtnAdd.Enabled = false;
            BtnSave.Enabled = true;
            BtnDelete.Enabled = false;
            BtnReset.Enabled = true;
            BtnClose.Enabled = true;
        }

        public void SaveClick(Button BtnAdd, Button BtnSave, Button BtnDelete, Button BtnReset, Button BtnClose)
        {
            BtnAdd.Enabled = true;
            BtnSave.Enabled = false;
            BtnDelete.Enabled = false;
            BtnReset.Enabled = true;
            BtnClose.Enabled = true;
        }

        public void GridClick(Button BtnAdd, Button BtnSave, Button BtnDelete, Button BtnReset, Button BtnClose)
        {
            BtnAdd.Enabled = false;
            BtnSave.Enabled = true;
            BtnDelete.Enabled = true;
            BtnReset.Enabled = true;
            BtnClose.Enabled = true;
        }
        public static string ShopUserID { get; set; }
        public static string ShopName { get; set; }
        public static string ShopAddress { get; set; }
        public static string ShopDescription { get; set; }
        public static string ShopGSTIN { get; set; }
        public static string ShopTin { get; set; }
        public static string ShopCIN { get; set; }
        public static string ShopRegNo { get; set; }
        public static string ShopOwner { get; set; }
        public static string ShopOwnerPAN { get; set; }
        public static string ShopOwnerMob { get; set; }
        public static string ShopOwnerOfficeContact { get; set; }
        public static string ShopEMail { get; set; }
        public static string ReportName { get; set; }
        public static string ApiUrl { get; set; }
        public static bool HappyCodeEnabled { get; set; }
        public static bool SmsEnabled { get; set; }
        public static string complaintInit { get; set; }
        public static bool IsConvertEMIEnabled { get; set; }

    }
}
