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
    
    public partial class MemberRegistraction
    {
        public Nullable<int> Shopid { get; set; }
        public int Memberid { get; set; }
        public System.DateTime AdmissionDate { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public Nullable<int> Gender { get; set; }
        public Nullable<System.DateTime> DateofBirth { get; set; }
        public Nullable<int> ProofGiven { get; set; }
        public string ProofDetails { get; set; }
        public string Salary { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string EmployeeID { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string UserID { get; set; }
    
        public virtual StoreRegistration StoreRegistration { get; set; }
    }
}