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
    
    public partial class SMSNotification
    {
        public string ContactNo { get; set; }
        public string MessageText { get; set; }
        public Nullable<bool> IsMessageSend { get; set; }
        public Nullable<bool> IsError { get; set; }
        public string ErrorMessage { get; set; }
        public Nullable<int> ShopID { get; set; }
        public Nullable<System.DateTime> InsertedDate { get; set; }
        public Nullable<System.DateTime> ScheduledDate { get; set; }
        public int NotID { get; set; }
    }
}
