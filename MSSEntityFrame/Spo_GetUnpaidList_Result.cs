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
    
    public partial class Spo_GetUnpaidList_Result
    {
        public string CompalintID { get; set; }
        public Nullable<System.DateTime> ComplaintDate { get; set; }
        public string Customername { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public Nullable<int> Previous_Balance { get; set; }
        public Nullable<int> Complaint_Charge { get; set; }
        public int PaidAmt { get; set; }
        public int BalAmt { get; set; }
        public Nullable<int> ActualBalance { get; set; }
    }
}