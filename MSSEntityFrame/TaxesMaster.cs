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
    
    public partial class TaxesMaster
    {
        public int Taxid { get; set; }
        public string Taxname { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Createby { get; set; }
        public System.DateTime Createdate { get; set; }
        public string Updateby { get; set; }
        public System.DateTime Updatedate { get; set; }
        public Nullable<int> ShopID { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
}