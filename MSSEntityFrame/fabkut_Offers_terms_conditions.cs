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
    
    public partial class fabkut_Offers_terms_conditions
    {
        public int fabkut_offer_terms_id { get; set; }
        public Nullable<int> fabkut_offer_id { get; set; }
        public Nullable<int> OfferTermId { get; set; }
    
        public virtual OfferTermsMaster OfferTermsMaster { get; set; }
    }
}
