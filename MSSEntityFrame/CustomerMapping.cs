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
    
    public partial class CustomerMapping
    {
        public int Custid { get; set; }
        public Nullable<int> Customer_id { get; set; }
        public string Cardnumber { get; set; }
        public string ReferenceBy { get; set; }
        public string Custsalerefno { get; set; }
        public bool isactive { get; set; }
        public System.DateTime createdate { get; set; }
        public System.DateTime updatedate { get; set; }
    
        public virtual CustomerMaster CustomerMaster { get; set; }
    }
}