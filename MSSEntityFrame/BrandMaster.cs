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
    
    public partial class BrandMaster
    {
        public BrandMaster()
        {
            this.ProductsMaster = new HashSet<ProductsMaster>();
        }
    
        public int Brandid { get; set; }
        public Nullable<int> CategoryBrandID { get; set; }
        public string Brandname { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Createby { get; set; }
        public string Updateby { get; set; }
        public System.DateTime Createdate { get; set; }
        public System.DateTime Updatedate { get; set; }
        public Nullable<int> ShopID { get; set; }
    
        public virtual CategoryMaster CategoryMaster { get; set; }
        public virtual CategoryMaster CategoryMaster1 { get; set; }
        public virtual CategoryMaster CategoryMaster2 { get; set; }
        public virtual CategoryMaster CategoryMaster3 { get; set; }
        public virtual CategoryMaster CategoryMaster4 { get; set; }
        public virtual CategoryMaster CategoryMaster5 { get; set; }
        public virtual CategoryMaster CategoryMaster6 { get; set; }
        public virtual CategoryMaster CategoryMaster7 { get; set; }
        public virtual CategoryMaster CategoryMaster8 { get; set; }
        public virtual CategoryMaster CategoryMaster9 { get; set; }
        public virtual CategoryMaster CategoryMaster10 { get; set; }
        public virtual CategoryMaster CategoryMaster11 { get; set; }
        public virtual ICollection<ProductsMaster> ProductsMaster { get; set; }
    }
}
