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
    
    public partial class SalesHeader
    {
        public int SAID { get; set; }
        public string PoNo { get; set; }
        public System.DateTime PoDate { get; set; }
        public string BookNo { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> PaidByID { get; set; }
        public string Remark { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Bankname { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }
        public Nullable<int> ShopID { get; set; }
        public string vehicleno { get; set; }
        public Nullable<bool> Is_War_Dur { get; set; }
        public Nullable<int> War_Dur { get; set; }
        public Nullable<System.DateTime> War_ExpDate { get; set; }
        public string RefBy { get; set; }
        public Nullable<int> deliverymode { get; set; }
        public string deliverby { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public Nullable<decimal> BalanceAmount { get; set; }
        public Nullable<bool> PayStatus { get; set; }
        public string UserID { get; set; }
        public Nullable<System.DateTime> InsertedDateTime { get; set; }
        public Nullable<System.DateTime> UpdatedDateTime { get; set; }
        public string IPAddress { get; set; }
        public Nullable<bool> IsDelivered { get; set; }
        public Nullable<System.DateTime> ExpDelDate { get; set; }
    }
}
