using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSwindow.CommonClass
{
    class RegistarctionClassBe
    {
        public int Shopid { get; set; }
        public int membershipid { get; set; }
        public string memberid { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
        public DateTime DateofBirth { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public int ProofGiven { get; set; }
        public string ProofDetails { get; set; }       
        public int Plan { get; set; }
        public int Fees { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Images { get; set; }
        public string Userid { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public DateTime Fromdate { get; set; }
        public DateTime ToDate { get; set; }
        public string Role { get; set; }
        
        

    }
    class paymentsbe : RegistarctionClassBe
    {
        public int PaymentID { get; set; }
        public int Months { get; set; }
        public int Years { get; set; }

        public int PaymentMode { get; set; }

        public string PaymentRemarks { get; set; }
        public int PaidAmt { get; set; }

        public int BalAmt { get; set; }

    }
}
