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
    
    public partial class Rec_Payment
    {
        public int PayID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<int> CompID { get; set; }
        public Nullable<int> ModeID { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<System.DateTime> PayDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Remark { get; set; }
    }
}
