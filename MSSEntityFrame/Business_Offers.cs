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
    
    public partial class Business_Offers
    {
        public int business_id { get; set; }
        public int business_offer_id { get; set; }
        public string business_offer_type { get; set; }
        public string business_offer_code { get; set; }
        public string business_offer_name { get; set; }
        public string business_offer_desc { get; set; }
        public byte[] business_offer_pic { get; set; }
        public Nullable<System.DateTime> business_offer_start { get; set; }
        public Nullable<System.DateTime> business_offer_end { get; set; }
        public Nullable<int> business_offer_price { get; set; }
        public Nullable<int> business_offer_disc_perc { get; set; }
        public Nullable<int> business_offer_disc_coupon_value { get; set; }
        public Nullable<bool> active { get; set; }
    }
}
