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
    
    public partial class SPO_GETAllComplaint_Result
    {
        public int GenID { get; set; }
        public string ComplaintID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public int Customerid { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string CustomerContact { get; set; }
        public Nullable<int> StatusID { get; set; }
        public string Status { get; set; }
        public int EmpID { get; set; }
        public Nullable<int> ReasonID { get; set; }
        public string AssignedTo { get; set; }
        public Nullable<System.DateTime> VisitDate { get; set; }
        public Nullable<System.DateTime> ResolveDate { get; set; }
        public string Remark { get; set; }
        public Nullable<System.TimeSpan> CompStartTime { get; set; }
        public Nullable<System.TimeSpan> CompEndTime { get; set; }
        public string SubmittedBy { get; set; }
        public Nullable<int> SubID { get; set; }
        public string ReferenceNo { get; set; }
        public Nullable<int> ComplaintLogType { get; set; }
        public Nullable<System.DateTime> ServiceDueDate { get; set; }
        public Nullable<System.DateTime> ActualServiceDate { get; set; }
        public int PayStatus { get; set; }
        public Nullable<int> PrevDue { get; set; }
        public Nullable<int> CurrentDue { get; set; }
        public int PaidAmt { get; set; }
        public int BalAmt { get; set; }
    }
}
