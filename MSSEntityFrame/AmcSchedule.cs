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
    
    public partial class AmcSchedule
    {
        public int AmcScheduleid { get; set; }
        public Nullable<int> SalesheaderID { get; set; }
        public System.DateTime Startdate { get; set; }
        public System.DateTime Entdate { get; set; }
        public int Duration { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string Remark { get; set; }
    }
}