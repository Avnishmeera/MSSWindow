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
    
    public partial class business_ServiceCost
    {
        public int ServiceCostID { get; set; }
        public Nullable<int> business_service_id { get; set; }
        public Nullable<int> BusinessID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> UnitID { get; set; }
        public Nullable<int> Qty { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string Remark { get; set; }
    }
}
