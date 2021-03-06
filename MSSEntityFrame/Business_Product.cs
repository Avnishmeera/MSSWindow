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
    
    public partial class Business_Product
    {
        public Business_Product()
        {
            this.VendorContract = new HashSet<VendorContract>();
        }
    
        public int item_id { get; set; }
        public string product_type { get; set; }
        public int product_id { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public Nullable<decimal> product_size { get; set; }
        public string product_uom { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<int> product_Target_min { get; set; }
        public Nullable<int> product_Target_max { get; set; }
        public Nullable<decimal> product_useup_times { get; set; }
        public Nullable<int> product_useup_no { get; set; }
        public string Description { get; set; }
        public Nullable<int> business_id { get; set; }
        public string photo { get; set; }
        public Nullable<System.DateTime> exdate { get; set; }
    
        public virtual ICollection<VendorContract> VendorContract { get; set; }
    }
}
