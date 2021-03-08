//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MSSEntityFrame
{
    using System;
    using System.Collections.Generic;
    
    public partial class StoreRegistration
    {
        public StoreRegistration()
        {
            this.MemberRegistraction = new HashSet<MemberRegistraction>();
            this.UserMaster = new HashSet<UserMaster>();
        }
    
        public int ShopID { get; set; }
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }
        public string ShopDescription { get; set; }
        public string ShopGSTIN { get; set; }
        public string ShopTin { get; set; }
        public string ShopCIN { get; set; }
        public string ShopRegNo { get; set; }
        public string ShopOwner { get; set; }
        public string ShopOwnerPAN { get; set; }
        public string ShopOwnerMob { get; set; }
        public string ShopOwnerOfficeContact { get; set; }
        public string ShopEMail { get; set; }
        public string ShopUserID { get; set; }
        public string ShopPwd { get; set; }
        public System.DateTime ShopCreatedOn { get; set; }
        public string ShopApplicationVersion { get; set; }
        public bool ShopIsActive { get; set; }
        public bool ShopIsDelete { get; set; }
        public System.Guid ShopPwdHasKey { get; set; }
        public string ReportName { get; set; }
        public Nullable<bool> IsSMSEnabled { get; set; }
        public Nullable<bool> IsBirthDaySMS { get; set; }
        public Nullable<bool> IsAniversary { get; set; }
        public Nullable<bool> IsBillingSMS { get; set; }
        public string BirthdayMessage { get; set; }
        public string AniversaryMessage { get; set; }
        public string BillingMessage { get; set; }
        public string SMSUserID { get; set; }
        public string SMSPassword { get; set; }
        public string SMSSenderID { get; set; }
        public string SMSType { get; set; }
        public string SMSPriority { get; set; }
        public string UriString { get; set; }
        public string AlternateEmail { get; set; }
        public string WebAdd { get; set; }
        public string WebsiteTittle { get; set; }
        public string WebShortName { get; set; }
        public string PurchaseReportName { get; set; }
        public Nullable<bool> IsHappyCodeEnable { get; set; }
        public string ComplaintFormat { get; set; }
        public string ComplaintInit { get; set; }
        public string imagepath { get; set; }
        public string ApiUrl { get; set; }
        public string imgfav { get; set; }
        public int InConvertEMIEnable { get; set; }
        public string AndroidAppUrl { get; set; }
    
        public virtual ICollection<MemberRegistraction> MemberRegistraction { get; set; }
        public virtual ICollection<UserMaster> UserMaster { get; set; }
    }
}
