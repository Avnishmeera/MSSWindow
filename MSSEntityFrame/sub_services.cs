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
    
    public partial class sub_services
    {
        public sub_services()
        {
            this.Business_Services = new HashSet<Business_Services>();
        }
    
        public int sub_service_id { get; set; }
        public Nullable<int> service_id { get; set; }
        public string sub_service_name { get; set; }
        public Nullable<bool> active { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public string description { get; set; }
    
        public virtual ICollection<Business_Services> Business_Services { get; set; }
    }
}
